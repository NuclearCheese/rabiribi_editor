/*
 * Created by SharpDevelop.
 * User: Nuclear Cheese
 * Date: 2017-10-14
 * Time: 18:17
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;

namespace RabiRibi_Editor
{
  /// <summary>
  /// Control to display level data pointed to in the tile view.
  /// </summary>
  public class InfoView : System.Windows.Forms.Control
  {
    public int x;
    public int y;
    
    // Local reference to the level data
    public LevelData level = null;
    
    string[] labels;
    
    Dictionary<int, string> event_name_lookup = new Dictionary<int, string>();
    Dictionary<int, string> item_name_lookup = new Dictionary<int, string>();
    
    public InfoView()
    {
      labels = new string[]
      {
        "X:",
        "Y:",
        "Layer 0:",
        "Layer 3:",
        "Layer 4:",
        "Layer 1:",
        "Layer 5:",
        "Layer 6:",
        "Layer 2:",
        "Collision:",
        "Event:",
        "Item:",
        "Room Type:",
        "Room Color:",
        "Room BG:",
      };
      
      DoubleBuffered = true;
    }
    
    internal void AddEventName(int id, string name)
    {
      if (event_name_lookup.ContainsKey(id))
      {
        // This extra if statement works around the fact that we list the warp
        // ID events twice in the event list file.  Without this, they'd show
        // up as "Warp ID 0/Warp ID 0" and such.
        if (event_name_lookup[id] != name)
        {
          event_name_lookup[id] =
            event_name_lookup[id] + "/" + name;
        }
      }
      else
      {
        event_name_lookup[id] = name;
      }
    }
    
    internal void AddItemName(int id, string name)
    {
      item_name_lookup[id] = name;
    }
    
    string Get_Layer_Tile_String(int tile)
    {
      bool hflip = (tile < 0);
      if (hflip)
      {
        tile = -tile;
      }
      bool vflip = (tile >= 5000);
      if (vflip)
      {
        tile -= 5000;
      }
      return tile.ToString() + (hflip ? " H.flip" : "") +
        (vflip ? " V.flip" : "");
    }
    
    string Get_Room_Type_String(int type)
    {
      switch (type)
      {
        case 1:
          return "Single Room";
          
        case 2:
          return "Horizontal";
          
        case 3:
          return "Vertical";
          
        case 4:
          return "Free Scroll";
          
        case 5:
          return "Area Transition";
          
        default:
          return "Unused";
      }
    }
    
    protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
    {
      base.OnPaint(e);
      
      float max_label_width = 0.0f;
      float current_y = 0.0f;
      float[] y_list = new float[labels.Length];
      
      int i = 0;
      
      using (var bold_font = new Font(DefaultFont, FontStyle.Bold))
      {
        // Draw the labels, and track where the values should be drawn
        foreach (var entry in labels)
        {
          var temp = e.Graphics.MeasureString(entry, bold_font);
          if (temp.Width > max_label_width)
          {
            max_label_width = temp.Width;
          }
          e.Graphics.DrawString(entry, bold_font, Brushes.Black, 0, current_y);
          y_list[i] = current_y;
          i++;
          current_y += temp.Height;
        }
        
        e.Graphics.DrawString(x.ToString(), DefaultFont, Brushes.Black, max_label_width, y_list[0]);
        e.Graphics.DrawString(y.ToString(), DefaultFont, Brushes.Black, max_label_width, y_list[1]);
        
        // The following data is only valid if within the level bounds.
        if ((level != null) && (x >= 0) && (x < LevelData.map_tile_width) &&
            (y >= 0) && (y < LevelData.map_tile_height))
        {
          e.Graphics.DrawString(Get_Layer_Tile_String(level.tile_data[0][x,y]), DefaultFont, Brushes.Black, max_label_width, y_list[2]);
          e.Graphics.DrawString(Get_Layer_Tile_String(level.tile_data[3][x,y]), DefaultFont, Brushes.Black, max_label_width, y_list[3]);
          e.Graphics.DrawString(Get_Layer_Tile_String(level.tile_data[4][x,y]), DefaultFont, Brushes.Black, max_label_width, y_list[4]);
          e.Graphics.DrawString(Get_Layer_Tile_String(level.tile_data[1][x,y]), DefaultFont, Brushes.Black, max_label_width, y_list[5]);
          e.Graphics.DrawString(Get_Layer_Tile_String(level.tile_data[5][x,y]), DefaultFont, Brushes.Black, max_label_width, y_list[6]);
          e.Graphics.DrawString(Get_Layer_Tile_String(level.tile_data[6][x,y]), DefaultFont, Brushes.Black, max_label_width, y_list[7]);
          e.Graphics.DrawString(Get_Layer_Tile_String(level.tile_data[2][x,y]), DefaultFont, Brushes.Black, max_label_width, y_list[8]);
          e.Graphics.DrawString(level.collision_data[x,y].ToString(), DefaultFont, Brushes.Black, max_label_width, y_list[9]);
          
          var event_id = level.event_data[x,y];
          string event_name;
          
          // Look up the name associated with this event.
          if (event_name_lookup.ContainsKey(event_id))
          {
            event_name = event_name_lookup[event_id];
          }
          else if (event_id == 0)
          {
            event_name = "<none>";
          }
          else if ((event_id >= 5000) && (event_id < 5500))
          {
            event_name = "<subtype modifier " + event_id.ToString() + ">";
          }
          else
          {
            event_name = "<unknown>";
          }
          e.Graphics.DrawString(event_id.ToString() + " " + event_name, DefaultFont, Brushes.Black, max_label_width, y_list[10]);
          
          var item_id = level.item_data[x,y];
          string item_name;
          
          // Look up the name associated with this item
          if (item_name_lookup.ContainsKey(item_id))
          {
            item_name = item_name_lookup[item_id];
          }
          else if (item_id == 0)
          {
            item_name = "<none>";
          }
          else
          {
            item_name = "<unknown>";
          }
          e.Graphics.DrawString(item_id.ToString() + " " + item_name, DefaultFont, Brushes.Black, max_label_width, y_list[11]);
          
          int room_x = x / 20;
          int room_y = LevelData.Tile_Y_To_Map_Y(y);
          e.Graphics.DrawString(Get_Room_Type_String(level.room_type_data[room_x,room_y]), DefaultFont, Brushes.Black, max_label_width, y_list[12]);
          e.Graphics.DrawString(level.room_color_data[room_x,room_y].ToString(), DefaultFont, Brushes.Black, max_label_width, y_list[13]);
          e.Graphics.DrawString(level.room_bg_data[room_x,room_y].ToString(), DefaultFont, Brushes.Black, max_label_width, y_list[14]);
        }
      }
    }
  }
}
