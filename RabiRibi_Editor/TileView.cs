/*
 * Created by SharpDevelop.
 * User: Nuclear Cheese
 * Date: 2017-09-16
 * Time: 14:28
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Collections.Generic;

namespace RabiRibi_Editor
{
  /// <summary>
  /// Custom control to display tile layers.
  /// </summary>
  public class TileView : System.Windows.Forms.Control
  {
    Bitmap tileset_graphics;
    Bitmap collision_graphics;
    
    // Temp bitmap to handle flipping tiles
    Bitmap temp;
    Graphics temp_gfx;
    
    // Pointer to level data
    LevelData level = null;
    
    // Current zoom level
    public float zoom = 1.0f;
    
    // Scroll location, in tiles
    internal int scroll_x = 0;
    internal int scroll_y = 0;
    
    internal bool[] tile_layers_visible = new bool[LevelData.num_tile_layers];
    
    internal readonly int[] layer_draw_order = new int[]
    {
      0, 3, 4, 1, 5, 6, 2,
    };
    
    internal bool collision_layer_visible = false;
    internal bool event_layer_visible = false;
    internal bool item_layer_visible = false;
    
    internal bool room_type_visible = false;
    internal bool room_color_visible = false;
    internal bool room_bg_visible = false;
    
    internal bool show_tile_grid = false;
    internal bool show_screen_grid = false;
    
    int mouse_down_x;
    int mouse_down_y;
    bool send_mouse_event = false;
    
    // callback for sending tile clicks to the main window for processing
    // note that this control tracks mouse down and mouse up, so that the user
    // can drag a range of tiles to update them all at once.
    public delegate void Process_Mouse_Delegate(int old_tx, int old_ty, int new_tx, int new_ty);
    Process_Mouse_Delegate mouse_callback;
    
    public delegate void Single_Tile_Delegate(int tile_x, int tile_y);
    Single_Tile_Delegate left_click_callback;
    Single_Tile_Delegate right_click_callback;
    
    Single_Tile_Delegate hover_callback;
    
    public delegate void Resize_Delegate();
    Resize_Delegate resize_callback = null;
    
    Brush[] room_type_brushes;
    Dictionary<int, Brush> room_color_brushes;
    
    Pen tile_grid_pen;
    Pen screen_grid_pen;
    
    // The below are used for the bitmap cache - this keeps a cache of images
    // representing the rooms in a level to improve draw times.
    struct Map_Coordinate
    {
      public int x;
      public int y;
    }
    
    class Bitmap_Cache
    {
      public Bitmap b;
      public bool up_to_date;
    }
    
    Dictionary<Map_Coordinate, Bitmap_Cache> bitmap_dict = new Dictionary<Map_Coordinate, Bitmap_Cache>();
    
    // This represents how far off screen a room must be scrolled before its
    // cache entry can be reused for another room.
    const int map_bound_buffer = 2;
    
    public TileView()
    {
      this.DoubleBuffered = true;
    }
    
    internal void Update_Tileset_Graphics(Bitmap tile_gfx)
    {
      tileset_graphics = tile_gfx;
    }
    
    internal void Update_Collision_Graphics(Bitmap coll_gfx)
    {
      collision_graphics = coll_gfx;
    }
    
    internal void Init(LevelData level_data, Process_Mouse_Delegate callback, Single_Tile_Delegate lc_callback, Single_Tile_Delegate rc_callback, Single_Tile_Delegate hv_callback,
                       Resize_Delegate rs_callback)
    {
      level = level_data;
      
      // Set up a temp bitmap object, used to flip tiles before drawing them
      // to the main screen.
      temp = new Bitmap(32, 32);
      temp_gfx = Graphics.FromImage(temp);
      for (int i = 0; i < LevelData.num_tile_layers; i++)
      {
        tile_layers_visible[i] = true;
      }
      
      tile_grid_pen = new Pen(Color.Wheat, 1.0f);
      screen_grid_pen = new Pen(Color.SkyBlue, 2.0f);
      
      // Room types:
      // 0 = unused
      // 1 = single screen
      // 2 = horizontal scrolling
      // 3 = vertical scrolling
      // 4 = horizontal/vertical scrolling
      // 5 = map transition room
      room_type_brushes = new Brush[6];
      // 0 shouldn't be used, but fill it in just in case
      room_type_brushes[0] = new SolidBrush(Color.FromArgb(0, 0, 0, 0));
      room_type_brushes[1] = new SolidBrush(Color.FromArgb(96, 200, 200, 0));
      room_type_brushes[2] = new SolidBrush(Color.FromArgb(96, 0, 255, 0));
      room_type_brushes[3] = new SolidBrush(Color.FromArgb(96, 0, 0, 255));
      room_type_brushes[4] = new SolidBrush(Color.FromArgb(96, 200, 0, 200));
      room_type_brushes[5] = new SolidBrush(Color.FromArgb(96, 255, 0, 0));
      
      // Room colors:
      // 1 Starting Forest (green)
      // 2 Spectral Cave (dark blue)
      // 3 Forgotten Cave (brown)
      // 5 Hall of Memories DLC area (boss area)
      // 6 Forgotten Cave 2 (brown)
      // 7 Starting Forest Night (dark green)
      // 9 Rabi-Rabi Beach (blue)
      //10 Golden Pyramid (yellow)
      //11 Rabi-Rabi Ravine (green)
      //12 Rabi-Rabi Town (tan)
      //13 Rabi-Rabi Park (brown)
      //14 UPRPRC HQ (blue)
      //15 Sky Island Town (purple)
      //16 Azure Snow Land (purple)
      //17 System Interior (light blue)
      //18 Evernight Peak (blue)
      //19 Exotic Laboratory (reddish purple)
      //20 Golden Riverbank (orange)
      //21 Floating Graveyard (dark red)
      //22 System Interior II (bright red)
      //23 Aurora Palace (blue)
      //24 Library (cyan)
      //25 Natural Aquarium (green)
      //26 Sky High Bridge (slightly darker cyan)
      //27 Warp Destination outside (green)
      //28 Volcanic Caverns
      //29 Plurkwood (dark orange) - also used for CreSpirit HQ
      //30 Hall of Memories (dark blue)
      //32 Hall of Memories DLC area
      //31 Icy Summit (dark blue)
      //34 Haloween area (darker red)
      //50 Warp Destination inside (blue)
      //55 ravine DLC area
      //81,83 - used on warp destination map - boss arenas?
      //87 Rumi boss fight room (light brown)
      //95..98 - Hall of Memories DLC area (different colors)
      // TODO - the below are just rough approximations (if even that).
      // might want to get more exact colors at some point.
      room_color_brushes = new Dictionary<int, Brush>();
      room_color_brushes[1] = new SolidBrush(Color.FromArgb(96, 0, 255, 0));
      room_color_brushes[2] = new SolidBrush(Color.FromArgb(96, 0, 0, 128));
      room_color_brushes[3] = new SolidBrush(Color.FromArgb(96, 200, 100, 0));
      room_color_brushes[5] = new SolidBrush(Color.FromArgb(96, 160, 160, 160));
      room_color_brushes[6] = new SolidBrush(Color.FromArgb(96, 200, 100, 0));
      room_color_brushes[7] = new SolidBrush(Color.FromArgb(96, 0, 128, 0));
      room_color_brushes[9] = new SolidBrush(Color.FromArgb(96, 0, 0, 255));
      room_color_brushes[10] = new SolidBrush(Color.FromArgb(96, 200, 200, 0));
      room_color_brushes[11] = new SolidBrush(Color.FromArgb(96, 0, 255, 0));
      room_color_brushes[12] = new SolidBrush(Color.FromArgb(96, 180, 200, 0));
      room_color_brushes[13] = new SolidBrush(Color.FromArgb(96, 200, 100, 0));
      room_color_brushes[14] = new SolidBrush(Color.FromArgb(96, 0, 0, 255));
      room_color_brushes[15] = new SolidBrush(Color.FromArgb(96, 200, 0, 200));
      room_color_brushes[16] = new SolidBrush(Color.FromArgb(96, 200, 0, 200));
      room_color_brushes[17] = new SolidBrush(Color.FromArgb(96, 32, 64, 255));
      room_color_brushes[18] = new SolidBrush(Color.FromArgb(96, 0, 0, 255));
      room_color_brushes[19] = new SolidBrush(Color.FromArgb(96, 200, 0, 100));
      room_color_brushes[20] = new SolidBrush(Color.FromArgb(96, 180, 200, 0));
      room_color_brushes[21] = new SolidBrush(Color.FromArgb(96, 150, 0, 0));
      room_color_brushes[22] = new SolidBrush(Color.FromArgb(96, 255, 48, 32));
      room_color_brushes[23] = new SolidBrush(Color.FromArgb(96, 0, 0, 255));
      room_color_brushes[24] = new SolidBrush(Color.FromArgb(96, 0, 180, 200));
      room_color_brushes[25] = new SolidBrush(Color.FromArgb(96, 0, 255, 0));
      room_color_brushes[26] = new SolidBrush(Color.FromArgb(96, 0, 160, 180));
      room_color_brushes[27] = new SolidBrush(Color.FromArgb(96, 0, 255, 0));
      room_color_brushes[28] = new SolidBrush(Color.FromArgb(96, 220, 0, 0));
      room_color_brushes[29] = new SolidBrush(Color.FromArgb(96, 160, 120, 0));
      room_color_brushes[30] = new SolidBrush(Color.FromArgb(96, 0, 0, 150));
      room_color_brushes[31] = new SolidBrush(Color.FromArgb(96, 0, 0, 150));
      room_color_brushes[32] = new SolidBrush(Color.FromArgb(96, 160, 160, 160));
      room_color_brushes[34] = new SolidBrush(Color.FromArgb(96, 120, 0, 0));
      room_color_brushes[50] = new SolidBrush(Color.FromArgb(96, 0, 0, 255));
      room_color_brushes[55] = new SolidBrush(Color.FromArgb(96, 0, 180, 0));
      room_color_brushes[81] = new SolidBrush(Color.FromArgb(96, 64, 64, 64));
      room_color_brushes[83] = new SolidBrush(Color.FromArgb(96, 64, 64, 64));
      room_color_brushes[87] = new SolidBrush(Color.FromArgb(96, 200, 170, 32));
      room_color_brushes[95] = new SolidBrush(Color.FromArgb(96, 160, 160, 160));
      room_color_brushes[96] = new SolidBrush(Color.FromArgb(96, 160, 160, 160));
      room_color_brushes[97] = new SolidBrush(Color.FromArgb(96, 160, 160, 160));
      room_color_brushes[98] = new SolidBrush(Color.FromArgb(96, 160, 160, 160));
      
      mouse_callback = callback;
      left_click_callback = lc_callback;
      right_click_callback = rc_callback;
      hover_callback = hv_callback;
      resize_callback = rs_callback;
    }
    
    /// <summary>
    /// Invalidates the appropriate region of the control for the given
    /// rectangle of tiles.
    /// </summary>
    /// <param name="left">Leftmost tile index</param>
    /// <param name="right">Rightmost tile index</param>
    /// <param name="top">Topmost tile index</param>
    /// <param name="bottom">Bottommost tile index</param>
    internal void InvalidateTiles(int left, int right, int top, int bottom)
    {
      // Invalidate cached room bitmaps
      int map_x = left / 20;
      int end_map_x = (right + 19) / 20;
      int end_map_y = LevelData.Tile_Y_To_Map_Y(bottom);
      while (map_x <= end_map_x)
      {
        int map_y = LevelData.Tile_Y_To_Map_Y(top);
        while (map_y <= end_map_y)
        {
          Map_Coordinate m;
          m.x = map_x;
          m.y = map_y;
          if (bitmap_dict.ContainsKey(m))
          {
            bitmap_dict[m].up_to_date = false;
          }
          
          map_y++;
        }
        map_x++;
      }
      
      // If showing a room-size layer, expand to include the the full size of
      // all rooms included in this tile range.
      if (room_bg_visible || room_color_visible || room_type_visible)
      {
        left -= left % LevelData.screen_width_in_tiles;
        right = right + LevelData.screen_width_in_tiles;
        right -= right % LevelData.screen_width_in_tiles;
        
        top = LevelData.Map_Y_To_Tile_Y(LevelData.Tile_Y_To_Map_Y(top));
        bottom = LevelData.Map_Y_To_Tile_Y(LevelData.Tile_Y_To_Map_Y(bottom) + 1);
      }
      
      left -= scroll_x;
      right -= scroll_x;
      top -= scroll_y;
      bottom -= scroll_y;
      
      int x = (int)(left * 32 * zoom);
      int width = (int)((right - left + 1) * 32 * zoom);
      int y = (int)(top * 32 * zoom);
      int height = (int)((bottom - top + 1) * 32 * zoom);
      Invalidate(new Rectangle(x, y, width, height));
    }
    
    /// <summary>
    /// Invalidate all cached room bitmaps, forcing a redraw of the entire
    /// view.
    /// </summary>
    internal void InvalidateAllTiles()
    {
      foreach (var entry in bitmap_dict)
      {
        entry.Value.up_to_date = false;
      }
      Invalidate();
    }
    
    void Draw_Room(int map_x, int map_y, Bitmap b)
    {
      int tile_start_x = map_x * 20;
      int tile_start_y = LevelData.Map_Y_To_Tile_Y(map_y);
      
      using (var gfx = Graphics.FromImage(b))
      {
        gfx.Clear(Color.Black);
        
        int draw_x = 0;
        for (int x = tile_start_x; x < tile_start_x + 20; x++, draw_x += 32)
        {
          if ((x < 0) || (x >= LevelData.map_tile_width))
          {
            continue;
          }
          int draw_y = 0;
          for (int y = tile_start_y; y < LevelData.Map_Y_To_Tile_Y(map_y + 1); y++, draw_y += 32)
          {
            if ((y < 0) || (y >= LevelData.map_tile_height))
            {
              continue;
            }
            
            // Draw the tile layers
            foreach (int layer in layer_draw_order)
            {
              if (tile_layers_visible[layer])
              {
                int data = level.tile_data[layer][x, y];
                if (data != 0)
                {
                  int tile_index = data;
                  bool horiz_flip = false;
                  bool vert_flip = false;
                  if (tile_index < 0)
                  {
                    tile_index = -tile_index;
                    horiz_flip = true;
                  }
                  if (tile_index >= 5000)
                  {
                    tile_index -= 5000;
                    vert_flip = true;
                  }
                  int tile_source_x = (tile_index % 32) * 32;
                  int tile_source_y = (tile_index / 32) * 32;
                  temp_gfx.Clear(Color.Transparent);
                  temp_gfx.DrawImage
                    (tileset_graphics, new Rectangle(0, 0, 32, 32),
                     tile_source_x, tile_source_y, 32, 32, GraphicsUnit.Pixel);
                  if (horiz_flip)
                  {
                    if (vert_flip)
                    {
                      temp.RotateFlip(RotateFlipType.RotateNoneFlipXY);
                    }
                    else
                    {
                      temp.RotateFlip(RotateFlipType.RotateNoneFlipX);
                    }
                  }
                  else if (vert_flip)
                  {
                    temp.RotateFlip(RotateFlipType.RotateNoneFlipY);
                  }
                  gfx.DrawImage(temp, draw_x, draw_y);
                }
              }
            }
            
            if (collision_layer_visible)
            {
              int data = level.collision_data[x, y];
              if (data != 0)
              {
                int tile_source_x = (data % 32) * 32;
                int tile_source_y = (data / 32) * 32;
                gfx.DrawImage
                  (collision_graphics, new Rectangle(draw_x, draw_y, 32, 32),
                   tile_source_x, tile_source_y, 32, 32, GraphicsUnit.Pixel);
              }
            }
            
            if (event_layer_visible)
            {
              int data = level.event_data[x, y];
              if (data != 0)
              {
                gfx.DrawString(data.ToString(), DefaultFont, Brushes.Wheat,
                               draw_x, draw_y);
              }
            }
            
            if (item_layer_visible)
            {
              int data = level.item_data[x, y];
              if (data != 0)
              {
                gfx.DrawString(data.ToString(), DefaultFont,
                               Brushes.Turquoise, draw_x, draw_y + 12);
              }
            }
          }
        }
        
        if (room_type_visible)
        {
          short data = level.room_type_data[map_x, map_y];
          if (data > 0 && data < room_type_brushes.Length)
          {
            gfx.FillRectangle(room_type_brushes[data], 0, 0, b.Width, b.Height);
          }
        }
        
        if (room_color_visible)
        {
          short data = level.room_color_data[map_x, map_y];
          if (room_color_brushes.ContainsKey(data))
          {
            gfx.FillRectangle(room_color_brushes[data], 0, 0, b.Width, b.Height);
          }
        }
        
        if (room_bg_visible)
        {
          short data = level.room_bg_data[map_x, map_y];
          gfx.DrawString("Room BG: " + data.ToString(),
                         DefaultFont, Brushes.Wheat, 0, 0);
        }
      }
    }
    
    /// <summary>
    /// Finds an appropriate bitmap object for the specified room, either by
    /// reusing one from a cache entry we don't need to keep around or by
    /// creating a new one.
    /// </summary>
    /// <param name="map_x">Map X</param>
    /// <param name="map_y">Map Y</param>
    /// <returns>Bitmap object</returns>
    Bitmap Find_Cache_Bitmap(int map_x, int map_y)
    {
      int desired_height = (LevelData.Map_Y_To_Tile_Y(map_y + 1) - LevelData.Map_Y_To_Tile_Y(map_y)) * 32;
      
      int view_min_x = (scroll_x / LevelData.screen_width_in_tiles) - map_bound_buffer;
      int view_max_x = (int)((scroll_x + (Width / zoom / 32)) / LevelData.screen_width_in_tiles) + map_bound_buffer;
      int view_min_y = LevelData.Tile_Y_To_Map_Y(scroll_y) - map_bound_buffer;
      int view_max_y = LevelData.Tile_Y_To_Map_Y(scroll_y + (int)(Height / zoom / 32)) + map_bound_buffer;
      
      Map_Coordinate m;
      m.x = 0;
      m.y = 0;
      bool found = false;
      foreach (var entry in bitmap_dict)
      {
        m = entry.Key;
        if ((m.x < view_min_x) || (m.x > view_max_x) ||
            (m.y < view_min_y) || (m.y > view_max_y))
        {
          if (entry.Value.b.Height == desired_height)
          {
            found = true;
            break;
          }
        }
      }
      
      Bitmap b;
      
      if (found)
      {
        b = bitmap_dict[m].b;
        bitmap_dict.Remove(m);
      }
      else
      {
        b = new Bitmap(LevelData.screen_width_in_tiles * 32, desired_height);
      }
      return b;
    }
    
    protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
    {
      e.Graphics.FillRectangle(Brushes.Black, e.ClipRectangle);
      
      e.Graphics.ScaleTransform(zoom, zoom);
      
      // Prevents the form designer from crashing.
      if (level == null)
      {
        return;
      }
      
      // Draw the rooms to the view.
      int map_x = scroll_x / 20;
      int draw_x = ((map_x * 20) - scroll_x) * 32;
      while (draw_x < (Width / zoom))
      {
        int map_y = LevelData.Tile_Y_To_Map_Y(scroll_y);
        int draw_y = (LevelData.Map_Y_To_Tile_Y(map_y) - scroll_y) * 32;
        while (draw_y < (Height / zoom))
        {
          Map_Coordinate m;
          Bitmap_Cache c;
          m.x = map_x;
          m.y = map_y;
          if (bitmap_dict.ContainsKey(m))
          {
            // We already have a bitmap object cached for this room.
            c = bitmap_dict[m];
          }
          else
          {
            // We need to create a bitmap object cache entry for this room.
            Bitmap b;
            b = Find_Cache_Bitmap(map_x, map_y);
            c = new TileView.Bitmap_Cache();
            c.b = b;
            c.up_to_date = false;
            bitmap_dict[m] = c;
          }
          
          // Update the room image, if needed.
          if (!c.up_to_date)
          {
            Draw_Room(map_x, map_y, c.b);
            c.up_to_date = true;
          }
          
          e.Graphics.DrawImage(c.b, draw_x, draw_y);
          draw_y += (LevelData.Map_Y_To_Tile_Y(map_y + 1) - LevelData.Map_Y_To_Tile_Y(map_y)) * 32;
          map_y++;
          if (LevelData.Map_Y_To_Tile_Y(map_y) >= LevelData.map_tile_height)
          {
            break;
          }
        }
        map_x++;
        if (map_x >= level.room_bg_data.GetLength(0))
        {
          break;
        }
        draw_x += 32 * 20;
      }
      
      if (show_tile_grid)
      {
        int end_x = (int)(Width / zoom);
        int tile_final_x = scroll_x + (end_x / 32);
        if (tile_final_x > (LevelData.map_tile_width - 1))
        {
          end_x -= (tile_final_x - LevelData.map_tile_width) * 32;
          end_x -= (end_x % 32);
        }
        
        int end_y = (int)(Height / zoom);
        int tile_final_y = scroll_y + (end_y / 32);
        if (tile_final_y > (LevelData.map_tile_height - 1))
        {
          end_y -= (tile_final_y - LevelData.map_tile_height) * 32;
          end_y -= (end_y % 32);
        }
        
        for (int x = 0; x <= end_x; x += 32)
        {
          e.Graphics.DrawLine(tile_grid_pen, x, 0, x, end_y);
        }
        for (int y = 0; y <= end_y; y += 32)
        {
          e.Graphics.DrawLine(tile_grid_pen, 0, y, end_x, y);
        }
      }
      
      // TODO - perhaps a 'smarter' screen border display
      // this would check the room scroll types, and eliminate screen borders
      // between multiple screens that are conjoined.
      if (show_screen_grid)
      {
        int end_x = (int)(Width / zoom);
        int tile_final_x = scroll_x + (end_x / 32);
        if (tile_final_x > (LevelData.map_tile_width - 1))
        {
          end_x -= (tile_final_x - LevelData.map_tile_width) * 32;
          end_x -= (end_x % 32);
        }
        
        int end_y = (int)(Height / zoom);
        int tile_final_y = scroll_y + (end_y / 32);
        if (tile_final_y > (LevelData.map_tile_height - 1))
        {
          end_y -= (tile_final_y - LevelData.map_tile_height) * 32;
          end_y -= (end_y % 32);
        }
        
        for (int x = (scroll_x % LevelData.screen_width_in_tiles) * -32; x < end_x; x += (32 * LevelData.screen_width_in_tiles))
        {
          e.Graphics.DrawLine(screen_grid_pen, x, 0, x, end_y);
        }
        int draw_y = 0;
        for (int y = scroll_y; y <= (scroll_y + (end_y / 32)); y++)
        {
          int map_y = LevelData.Tile_Y_To_Map_Y(y);
          int test_y = LevelData.Map_Y_To_Tile_Y(map_y);
          if (test_y == y)
          {
            e.Graphics.DrawLine(screen_grid_pen, 0, draw_y, end_x, draw_y);
          }
          draw_y += 32;
        }
      }
    }
    
    protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
    {
      base.OnMouseDown(e);
      
      float scale_factor = 32.0f * zoom;
      
      if (e.Button == System.Windows.Forms.MouseButtons.Left)
      {
        // Note where the left mouse started, so that we can report the full
        // range of the input when it is released.
        mouse_down_x = e.X;
        mouse_down_y = e.Y;
        send_mouse_event = true;
        
        // Also trigger the left click callback.
        int tile_x = (int)((e.X / scale_factor) + scroll_x);
        if (tile_x < 0)
        {
          tile_x = 0;
        }
        else if (tile_x >= LevelData.map_tile_width)
        {
          tile_x = LevelData.map_tile_width - 1;
        }
        int tile_y = (int)((e.Y / scale_factor) + scroll_y);
        if (tile_y < 0)
        {
          tile_y = 0;
        }
        else if (tile_y >= LevelData.map_tile_height)
        {
          tile_y = LevelData.map_tile_height - 1;
        }
        left_click_callback(tile_x, tile_y);
      }
      else if (e.Button == System.Windows.Forms.MouseButtons.Right)
      {
        // Right button down is used to select the tile below the cursor.
        send_mouse_event = false;
        int tile_x = (int)((e.X / scale_factor) + scroll_x);
        if (tile_x < 0)
        {
          tile_x = 0;
        }
        else if (tile_x >= LevelData.map_tile_width)
        {
          tile_x = LevelData.map_tile_width - 1;
        }
        int tile_y = (int)((e.Y / scale_factor) + scroll_y);
        if (tile_y < 0)
        {
          tile_y = 0;
        }
        else if (tile_y >= LevelData.map_tile_height)
        {
          tile_y = LevelData.map_tile_height - 1;
        }
        right_click_callback(tile_x, tile_y);
      }
    }
    
    protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
    {
      base.OnMouseUp(e);
      
      float scale_factor = 32.0f * zoom;
      
      if (e.Button == System.Windows.Forms.MouseButtons.Left)
      {
        // This Boolean is meant to prevent processing a mouse up event when
        // the mouse down was not focused on this control.
        if (send_mouse_event)
        {
          send_mouse_event = false;
          
          // Convert mouse click coordinates to tile coordinates
          int left_tile = (int)((mouse_down_x / scale_factor) + scroll_x);
          if (left_tile < 0)
          {
            left_tile = 0;
          }
          else if (left_tile >= LevelData.map_tile_width)
          {
            left_tile = LevelData.map_tile_width - 1;
          }
          int right_tile = (int)((e.X / scale_factor) + scroll_x);
          if (right_tile < 0)
          {
            right_tile = 0;
          }
          else if (right_tile >= LevelData.map_tile_width)
          {
            right_tile = LevelData.map_tile_width - 1;
          }
          if (left_tile > right_tile)
          {
            int tmp = right_tile;
            right_tile = left_tile;
            left_tile = tmp;
          }
          int top_tile = (int)((mouse_down_y / scale_factor) + scroll_y);
          if (top_tile < 0)
          {
            top_tile = 0;
          }
          else if (top_tile >= LevelData.map_tile_height)
          {
            top_tile = LevelData.map_tile_height - 1;
          }
          int bottom_tile = (int)((e.Y / scale_factor) + scroll_y);
          if (bottom_tile < 0)
          {
            bottom_tile = 0;
          }
          else if (bottom_tile >= LevelData.map_tile_height)
          {
            bottom_tile = LevelData.map_tile_height - 1;
          }
          if (top_tile > bottom_tile)
          {
            int tmp = bottom_tile;
            bottom_tile = top_tile;
            top_tile = tmp;
          }
          
          mouse_callback(left_tile, top_tile, right_tile, bottom_tile);
        }
      }
    }
    
    protected override void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
    {
      base.OnMouseMove(e);
      
      int tile_x = (int)(e.X / 32.0f / zoom) + scroll_x;
      int tile_y = (int)(e.Y / 32.0f / zoom) + scroll_y;
      
      hover_callback(tile_x, tile_y);
    }
    
    protected override void OnResize(EventArgs e)
    {
      base.OnResize(e);
      
      if (resize_callback != null)
      {
        resize_callback();
      }
    }
  }
}
