/*
 * Created by SharpDevelop.
 * User: Nuclear Cheese
 * Date: 2017-09-16
 * Time: 14:24
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace RabiRibi_Editor
{
  /// <summary>
  /// Description of MainForm.
  /// </summary>
  public partial class MainForm : Form
  {
    LevelData level = new LevelData();
    
    CheckBox[] layer_checkboxes;
    CheckBox collision_checkbox;
    CheckBox event_layer_checkbox;
    CheckBox item_layer_checkbox;
    
    CheckBox room_type_checkbox;
    CheckBox room_color_checkbox;
    CheckBox room_bg_checkbox;
    
    CheckBox tile_grid_checkbox;
    CheckBox screen_grid_checkbox;
    
    RadioButton no_tool_radio;
    RadioButton[] layer_tool_radios;
    RadioButton collision_radio;
    RadioButton event_radio;
    RadioButton item_radio;
    RadioButton room_type_radio;
    RadioButton room_color_radio;
    RadioButton room_bg_radio;
    RadioButton metatile_radio;
    
    short selected_tile = 0;
    short selected_collision = 0;
    
    CommandStack command_stack;
    
    List<Metatile> metatile_list;
    
    // TODO make this configurable for the user
    const bool show_event_ids = true;
    
    /// <summary>
    /// Simple container class to contain both event names and IDs within the
    /// event selection lists.
    /// </summary>
    class Event_Selection_Item
    {
      public string name;
      public short id;
      
      public List<Event_Selection_Item> direction_list;
      public List<Event_Selection_Item> type_list;
      public bool laser_delay;
      
      public Event_Selection_Item(string event_name, short event_id)
      {
        name = event_name;
        id = event_id;
        direction_list = new List<MainForm.Event_Selection_Item>();
        type_list = new List<MainForm.Event_Selection_Item>();
        laser_delay = false;
      }
      
      public override string ToString()
      {
        if (show_event_ids)
        {
          return id.ToString() + " " + name;
        }
        else
        {
          return name;
        }
      }
    }
    
    public MainForm()
    {
      //
      // The InitializeComponent() call is required for Windows Forms designer support.
      //
      InitializeComponent();
      
      //
      // TODO: Add constructor code after the InitializeComponent() call.
      //
    }
    
    /// <summary>
    /// Loads tile graphics and passes them to the tile view.  If an error
    /// occurs, fills in a default tile set with each tile just having text of
    /// its tile ID.
    /// </summary>
    /// <param name="filename">File to read tiles from</param>
    void Load_Tile_Graphics(string filename)
    {
      Bitmap tiles = null;
      try
      {
        tiles = new Bitmap(filename);
      }
      catch (Exception E)
      {
        if (tiles != null)
        {
          tiles.Dispose();
        }
        MessageBox.Show("Could not load tileset graphics from " + filename + "\n\n"
                        + "A default tileset with tile numbers will be loaded instead.\n\n"
                        + "Exception info:\n" + E.Message);
        tiles = new Bitmap(960, 1792);
        using (Graphics g = Graphics.FromImage(tiles))
        {
          g.Clear(Color.DarkBlue);
          for (int x = 0; x < tiles.Width; x += 32)
          {
            for (int y = 0; y < tiles.Height; y += 32)
            {
              int tile_index = (x / 32) + (y / 32) * 32;
              if (tile_index > 0)
              {
                g.DrawString(tile_index.ToString(), DefaultFont, Brushes.Goldenrod, x, y);
              }
            }
          }
        }
      }
      
      if (tile_picturebox.Image != null)
      {
        tile_picturebox.Image.Dispose();
      }
      tile_picturebox.Image = tiles;
      tileView1.Update_Tileset_Graphics(tiles);
    }
    
    /// <summary>
    /// Loads graphics representing the collision tiles, and passes them to the
    /// tile view.  If an error occurs, the graphic is filled in with a default
    /// representation of the collision tiles.
    /// </summary>
    /// <param name="filename"></param>
    void Load_Collision_Graphics(string filename)
    {
      Bitmap tiles = null;
      try
      {
        tiles = new Bitmap(filename);
      }
      catch (Exception E)
      {
        if (tiles != null)
        {
          tiles.Dispose();
        }
        MessageBox.Show("Could not load collision graphics from " + filename + "\n\n"
                        + "A default graphic set will be loaded instead.\n\n"
                        + "Exception info:\n" + E.Message);
        
        tiles = new Bitmap(640, 32);
        using (Graphics g = Graphics.FromImage(tiles))
        {
          g.Clear(Color.Transparent);
          using (Brush b = new SolidBrush(Color.FromArgb(128, 64, 96, 192)))
          {
            // tile 1 - filled
            g.FillRectangle(b, 32, 0, 32, 32);
            
            // tile 2 - 45 degree slant right
            g.FillPolygon(b, new Point[] { new Point(64, 31),
                            new Point(95, 0),
                            new Point(95, 31) });
            
            // tile 3 - 45 degree slant left
            g.FillPolygon(b, new Point[] { new Point(96, 31),
                            new Point(96, 0),
                            new Point(127, 31) });
            
            // tile 4 - 1/2 slant right, lower part
            g.FillPolygon(b, new Point[] { new Point(128, 31),
                            new Point(159, 16),
                            new Point(159, 31) });
            
            // tile 5 - 1/2 slant left, lower part
            g.FillPolygon(b, new Point[] { new Point(160, 31),
                            new Point(160, 16),
                            new Point(191, 31) });
            
            // tile 6 - 1/2 slant right, upper part
            g.FillPolygon(b, new Point[] { new Point(192, 15),
                            new Point(223, 0),
                            new Point(223, 31),
                            new Point(192, 31) });
            
            // tile 7 - 1/2 slant left, upper part
            g.FillPolygon(b, new Point[] { new Point(224, 31),
                            new Point(224, 0),
                            new Point(255, 15),
                            new Point(255, 31) });
            
            // tile 8 - 1/3 slant left, lower part
            g.FillPolygon(b, new Point[] { new Point(256, 21),
                            new Point(256, 31),
                            new Point(287, 31) });
            
            // tile 9 - 1/3 slant right, lower part
            g.FillPolygon(b, new Point[] { new Point(319, 21),
                            new Point(288, 31),
                            new Point(319, 31) });
            
            // tile 10 - 1/3 slant left, middle part
            g.FillPolygon(b, new Point[] { new Point(320, 10),
                            new Point(320, 31),
                            new Point(351, 31),
                            new Point(351, 21) });
            
            // tile 11 - 1/3 slant right, middle part
            g.FillPolygon(b, new Point[] { new Point(352, 21),
                            new Point(383, 10),
                            new Point(383, 31),
                            new Point(352, 31) });
            
            // tile 12 - 1/3 slant left, upper part
            g.FillPolygon(b, new Point[] { new Point(384, 0),
                            new Point(384, 31),
                            new Point(415, 31),
                            new Point(415, 10) });
            
            // tile 13 - 1/3 slant right, upper part
            g.FillPolygon(b, new Point[] { new Point(416, 10),
                            new Point(416, 31),
                            new Point(447, 31),
                            new Point(447, 0) });
            
            // tile 14 - high platform
            g.FillRectangle(b, 448, 0, 32, 8);
            
            // tile 15 - low platform
            g.FillRectangle(b, 480, 20, 32, 8);
            
            // tile 16 - left side
            g.FillRectangle(b, 512, 0, 12, 32);
            
            // tile 17 - right side
            g.FillRectangle(b, 564, 0, 12, 32);
            
            // tile 18 - mid platform
            g.FillRectangle(b, 576, 10, 32, 8);
            
            // tile 19 - lower half
            g.FillRectangle(b, 608, 16, 32, 16);
            
          }
        }
      }
      
      if (collision_tiles.Image != null)
      {
        collision_tiles.Image.Dispose();
      }
      collision_tiles.Image = tiles;
      tileView1.Update_Collision_Graphics(tiles);
    }
    
    void UpdateMetatileList()
    {
      metatile_selection.Items.Clear();
      metatile_selection.Items.Add("Select a metatile ...");
      for (int i = 0; i < metatile_list.Count; i++)
      {
        metatile_selection.Items.Add(metatile_list[i].name);
      }
      metatile_selection.SelectedIndex = 0;
    }
    
    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);
      
      try
      {
        
        // If this is the first time running this version, pull settings from
        // any previous versions.
        if (Settings1.Default.upgradeRequired)
        {
          Settings1.Default.Upgrade();
          Settings1.Default.upgradeRequired = false;
          Settings1.Default.Save();
        }
        
        // Initialize stuff
        command_stack = new CommandStack(level, tileView1);
        
        metatile_list = new List<Metatile>();
        
        UpdateMetatileList();
        
        metatile_layer_selection.SelectedIndex = 1;
        
        tileView1.Init(level, Process_Tile_Mouse, Process_Left_Click, Process_Right_Click, Process_Hover, Update_Scrollbar_Size);
        
        infoView1.level = level;
        
        // Load tile graphics
        Load_Tile_Graphics("TILE1_A.png");
        Load_Collision_Graphics("COLLISION_TILES.png");
        
        // Set up preview areas
        tile_preview.Image = new Bitmap(32, 32);
        collision_preview.Image = new Bitmap(32, 32);
        
        // Create checkboxes for visibility toggles
        layer_checkboxes = new CheckBox[LevelData.num_tile_layers];
        for (int i = 0; i < LevelData.num_tile_layers; i++)
        {
          CheckBox c = new CheckBox();
          c.Parent = tabPage1;
          c.Text = "Layer " + i.ToString();
          
          // Do a reverse lookup on the draw order to get each layer's priority.
          // This allows us to position the tools in draw order.
          for (int j = 0; j < tileView1.layer_draw_order.Length; j++)
          {
            if (tileView1.layer_draw_order[j] == i)
            {
              c.Top = 10 + j * 20;
            }
          }
          c.Left = 10;
          c.Width = 90;
          c.Checked = true;
          c.CheckedChanged += new EventHandler(LayerVisibleChanged);
          layer_checkboxes[i] = c;
        }
        collision_checkbox = new CheckBox();
        collision_checkbox.Parent = tabPage1;
        collision_checkbox.Text = "Collision";
        collision_checkbox.Top = 150;
        collision_checkbox.Left = 10;
        collision_checkbox.Checked = false;
        collision_checkbox.CheckedChanged += new EventHandler(collision_checkbox_CheckedChanged);
        event_layer_checkbox = new CheckBox();
        event_layer_checkbox.Parent = tabPage1;
        event_layer_checkbox.Text = "Event IDs";
        event_layer_checkbox.Top = 10;
        event_layer_checkbox.Left = 110;
        event_layer_checkbox.Checked = false;
        event_layer_checkbox.CheckedChanged += new EventHandler(event_layer_checkbox_CheckedChanged);
        item_layer_checkbox = new CheckBox();
        item_layer_checkbox.Parent = tabPage1;
        item_layer_checkbox.Text = "Item IDs";
        item_layer_checkbox.Top = 30;
        item_layer_checkbox.Left = 110;
        item_layer_checkbox.Checked = false;
        item_layer_checkbox.CheckedChanged += new EventHandler(item_layer_checkbox_CheckedChanged);
        
        room_type_checkbox = new CheckBox();
        room_type_checkbox.Parent = tabPage1;
        room_type_checkbox.Text = "Room types";
        room_type_checkbox.Top = 70;
        room_type_checkbox.Left = 110;
        room_type_checkbox.Checked = false;
        room_type_checkbox.CheckedChanged += new EventHandler(room_type_checkbox_CheckedChanged);
        room_color_checkbox = new CheckBox();
        room_color_checkbox.Parent = tabPage1;
        room_color_checkbox.Text = "Room colors";
        room_color_checkbox.Top = 90;
        room_color_checkbox.Left = 110;
        room_color_checkbox.Checked = false;
        room_color_checkbox.CheckedChanged += new EventHandler(room_color_checkbox_CheckedChanged);
        room_bg_checkbox = new CheckBox();
        room_bg_checkbox.Parent = tabPage1;
        room_bg_checkbox.Text = "Room BGs";
        room_bg_checkbox.Top = 110;
        room_bg_checkbox.Left = 110;
        room_bg_checkbox.Checked = false;
        room_bg_checkbox.CheckedChanged += new EventHandler(room_bg_checkbox_CheckedChanged);
        
        tile_grid_checkbox = new CheckBox();
        tile_grid_checkbox.Parent = tabPage1;
        tile_grid_checkbox.Text = "Tile Grid";
        tile_grid_checkbox.Top = 190;
        tile_grid_checkbox.Left = 10;
        tile_grid_checkbox.Checked = false;
        tile_grid_checkbox.CheckedChanged += new EventHandler(tile_grid_checkbox_CheckedChanged);
        screen_grid_checkbox = new CheckBox();
        screen_grid_checkbox.Parent = tabPage1;
        screen_grid_checkbox.Text = "Screen Grid";
        screen_grid_checkbox.Top = 210;
        screen_grid_checkbox.Left = 10;
        screen_grid_checkbox.Checked = false;
        screen_grid_checkbox.CheckedChanged += new EventHandler(screen_grid_checkbox_CheckedChanged);
        
        // Create radio buttons for tool selection
        no_tool_radio = new RadioButton();
        no_tool_radio.Parent = tools_panel;
        no_tool_radio.Text = "No tool";
        no_tool_radio.Top = 10;
        no_tool_radio.Left = 10;
        no_tool_radio.Width = 80;
        no_tool_radio.Checked = true;
        no_tool_radio.CheckedChanged += new EventHandler(tool_selection_changed);
        
        layer_tool_radios = new RadioButton[LevelData.num_tile_layers];
        for (int i = 0; i < LevelData.num_tile_layers; i++)
        {
          RadioButton r = new RadioButton();
          r.Parent = tools_panel;
          r.Text = "Layer " + i.ToString();
          
          // Do a reverse lookup on the draw order to get each layer's priority.
          // This allows us to position the tools in draw order.
          for (int j = 0; j < tileView1.layer_draw_order.Length; j++)
          {
            if (tileView1.layer_draw_order[j] == i)
            {
              r.Top = 30 + j * 20;
            }
          }
          r.Left = 10;
          r.Width = 80;
          r.Checked = false;
          r.CheckedChanged += new EventHandler(tool_selection_changed);
          layer_tool_radios[i] = r;
        }
        
        collision_radio = new RadioButton();
        collision_radio.Parent = tools_panel;
        collision_radio.Text = "Collision";
        collision_radio.Top = 170;
        collision_radio.Left = 10;
        collision_radio.Checked = false;
        collision_radio.CheckedChanged += new EventHandler(tool_selection_changed);
        
        event_radio = new RadioButton();
        event_radio.Parent = tools_panel;
        event_radio.Text = "Event IDs";
        event_radio.Top = 190;
        event_radio.Left = 10;
        event_radio.Checked = false;
        event_radio.CheckedChanged += new EventHandler(tool_selection_changed);
        
        item_radio = new RadioButton();
        item_radio.Parent = tools_panel;
        item_radio.Text = "Item IDs";
        item_radio.Top = 210;
        item_radio.Left = 10;
        item_radio.Checked = false;
        item_radio.CheckedChanged += new EventHandler(tool_selection_changed);
        
        metatile_radio = new RadioButton();
        metatile_radio.Parent = tools_panel;
        metatile_radio.Text = "Metatile";
        metatile_radio.Top = 230;
        metatile_radio.Left = 10;
        metatile_radio.Checked = false;
        metatile_radio.CheckedChanged += new EventHandler(tool_selection_changed);
        
        room_type_radio = new RadioButton();
        room_type_radio.Parent = tools_panel;
        room_type_radio.Text = "Room Type";
        room_type_radio.Top = 30;
        room_type_radio.Left = 100;
        room_type_radio.Checked = false;
        room_type_radio.CheckedChanged += new EventHandler(tool_selection_changed);
        
        room_color_radio = new RadioButton();
        room_color_radio.Parent = tools_panel;
        room_color_radio.Text = "Room Color";
        room_color_radio.Top = 50;
        room_color_radio.Left = 100;
        room_color_radio.Checked = false;
        room_color_radio.CheckedChanged += new EventHandler(tool_selection_changed);
        
        room_bg_radio = new RadioButton();
        room_bg_radio.Parent = tools_panel;
        room_bg_radio.Text = "Room BG";
        room_bg_radio.Top = 70;
        room_bg_radio.Left = 100;
        room_bg_radio.Checked = false;
        room_bg_radio.CheckedChanged += new EventHandler(tool_selection_changed);
        
        // TODO other tools (what else?)
        
        // Load event IDs
        using (var resource = GetType().Assembly.GetManifestResourceStream("RabiRibi_Editor.Data_Files.event_ids.txt"))
        {
          using (var input = new StreamReader(resource))
          {
            ComboBox current_target = null;
            Event_Selection_Item item = null;
            while (!input.EndOfStream)
            {
              string line = input.ReadLine().Trim();
              
              // Ignore blank lines
              if (line == "")
              {
                continue;
              }
              
              // The following change which category of events are being added.
              else if (line == "[music]")
              {
                current_target = music_event_selection;
                continue;
              }
              else if (line == "[tile]")
              {
                current_target = tile_event_selection;
                continue;
              }
              else if (line == "[misc]")
              {
                current_target = misc_event_selection;
                continue;
              }
              else if (line == "[warps]")
              {
                current_target = warp_destination_selection;
                continue;
              }
              else if (line == "[warps2]")
              {
                current_target = warp_local_id_selection;
                continue;
              }
              else if (line == "[mapwarps]")
              {
                current_target = warp_map_selection;
                continue;
              }
              else if (line == "[entity]")
              {
                current_target = entity_event_selection;
                continue;
              }
              else if (line == "[environment]")
              {
                current_target = environment_event_selection;
                continue;
              }
              
              // Add a direction modified entry to the most recent event
              else if (line.StartsWith("dir"))
              {
                line = line.Substring(4).Trim();
                bool zero_id = false;
                if (line.StartsWith("0"))
                {
                  zero_id = true;
                  line = line.Substring(2).Trim();
                }
                if (line == "left")
                {
                  item.direction_list.Add(new Event_Selection_Item("left", (short)(zero_id ? 0 : 196)));
                }
                if (line == "right")
                {
                  item.direction_list.Add(new Event_Selection_Item("right", (short)(zero_id ? 0 : 195)));
                }
                if (line == "up")
                {
                  item.direction_list.Add(new Event_Selection_Item("up", (short)(zero_id ? 0 : 198)));
                }
                if (line == "down")
                {
                  item.direction_list.Add(new Event_Selection_Item("down", (short)(zero_id ? 0 : 199)));
                }
                continue;
              }
              
              // Add a type modifier to the most recent event
              else if (line.StartsWith("type"))
              {
                line = line.Substring(5).Trim();
                short subtype_id = short.Parse(line.Substring(0, line.IndexOf(' ')));
                if (subtype_id != 0)
                {
                  subtype_id += 5000;
                }
                line = line.Substring(line.IndexOf(' ')).Trim();
                item.type_list.Add(new Event_Selection_Item(line, subtype_id));
                continue;
              }
              
              // Enable laser delay modifiers on the most recent event
              else if (line == "laser")
              {
                item.laser_delay = true;
                continue;
              }
              
              // None of the above -> this is a new event definition
              short id = short.Parse(line.Substring(0, line.IndexOf(' ')));
              string name = line.Substring(line.IndexOf(' ')).Trim();
              item = new MainForm.Event_Selection_Item(name, id);
              current_target.Items.Add(item);
            }
          }
        }
        
        // Define the laser delay events
        for (int i = 0; i < 6; i++)
        {
          entity_laser_delay_selection.Items.Add
            (new Event_Selection_Item("Laser delay " + i.ToString(),
                                      (short)(i > 0 ? i + 200 : 0)));
        }
        entity_laser_delay_selection.SelectedIndex = 0;
        
        room_type_selection.SelectedIndex = 0;
        room_color_selection.SelectedIndex = 0;
        item_selection.SelectedIndex = 0;
        music_event_selection.SelectedIndex = 0;
        tile_event_selection.SelectedIndex = 0;
        entity_event_selection.SelectedIndex = 0;
        misc_event_selection.SelectedIndex = 0;
        warp_destination_selection.SelectedIndex = 0;
        warp_map_selection.SelectedIndex = 0;
        warp_local_id_selection.SelectedIndex = 0;
        event_category_selection.SelectedIndex = 0;
        environment_event_selection.SelectedIndex = 0;
        
        Update_Scrollbar_Size();
      }
      catch (Exception E)
      {
        MessageBox.Show("An exception occurred while initializing the editor!\n"
                        + "The editor will now close.\n\n" + E.ToString());
        Close();
      }
    }

    void room_bg_checkbox_CheckedChanged(object sender, EventArgs e)
    {
      tileView1.room_bg_visible = room_bg_checkbox.Checked;
      tileView1.InvalidateAllTiles();
    }
    
    void tool_selection_changed(object sendor, EventArgs e)
    {
      Update_Tool_Visibilities();
    }

    void room_color_checkbox_CheckedChanged(object sender, EventArgs e)
    {
      // Only have one room-size rectangle at a time
      // TODO is there a better way to do this?  maybe switch to radio buttons?
      if (room_color_checkbox.Checked)
      {
        room_type_checkbox.Checked = false;
      }
      tileView1.room_color_visible = room_color_checkbox.Checked;
      tileView1.InvalidateAllTiles();
    }

    void room_type_checkbox_CheckedChanged(object sender, EventArgs e)
    {
      // Only have one room-size rectangle at a time
      // TODO is there a better way to do this?  maybe switch to radio buttons?
      if (room_type_checkbox.Checked)
      {
        room_color_checkbox.Checked = false;
      }
      tileView1.room_type_visible = room_type_checkbox.Checked;
      tileView1.InvalidateAllTiles();
    }
    
    void Update_Event_Tool_Visibilities()
    {
      if (!event_radio.Checked)
      {
        event_ID_entry.Visible = music_event_selection.Visible =
          tile_event_selection.Visible = entity_event_selection.Visible =
          warp_destination_selection.Visible = warp_map_selection.Visible =
          warp_entrance_checkbox.Visible = warp_exit_checkbox.Visible =
          warp_local_id_selection.Visible = misc_event_selection.Visible =
          environment_event_selection.Visible = warp_graphic_checkbox.Visible = false;
      }
      else
      {
        // TODO maybe make these ID connections less fragile?
        // Right now we use these IDs in a few different places - is there a
        // good way to force them to be consistent?
        event_ID_entry.Visible = event_category_selection.SelectedIndex == 0;
        music_event_selection.Visible = event_category_selection.SelectedIndex == 1;
        tile_event_selection.Visible = event_category_selection.SelectedIndex == 2;
        entity_event_selection.Visible = event_category_selection.SelectedIndex == 3;
        warp_destination_selection.Visible = warp_map_selection.Visible =
          warp_entrance_checkbox.Visible = warp_exit_checkbox.Visible =
          warp_local_id_selection.Visible = warp_graphic_checkbox.Visible
          = event_category_selection.SelectedIndex == 4;
        misc_event_selection.Visible = event_category_selection.SelectedIndex == 5;
        environment_event_selection.Visible = event_category_selection.SelectedIndex == 6;
      }
      Update_Entity_Selection_Visibility();
    }
    
    /// <summary>
    /// Refreshes which tool options are visible, based on the currently
    /// selected tool.
    /// </summary>
    void Update_Tool_Visibilities()
    {
      collision_tile_panel.Visible = collision_preview.Visible
        = collision_radio.Checked;
      
      bool any_layer_tool_selected = false;
      foreach (var entry in layer_tool_radios)
      {
        if (entry.Checked)
        {
          any_layer_tool_selected = true;
          break;
        }
      }
      hflip_checkbox.Visible = vflip_checkbox.Visible
        = tile_picturebox_panel.Visible = tile_preview.Visible
        = any_layer_tool_selected;
      
      event_category_selection.Visible = event_radio.Checked;
      Update_Event_Tool_Visibilities();
      
      item_selection.Visible = item_ID_entry.Visible = item_radio.Checked;
      
      room_type_selection.Visible = room_type_radio.Checked;
      
      room_color_selection.Visible = room_color_radio.Checked;
      
      bg_ID_entry.Visible = room_bg_radio.Checked;
      
      metatile_layer_selection.Visible = metatile_layer_label.Visible =
        metatile_selection.Visible = metatile_radio.Checked;
    }

    void item_layer_checkbox_CheckedChanged(object sender, EventArgs e)
    {
      tileView1.item_layer_visible = item_layer_checkbox.Checked;
      tileView1.InvalidateAllTiles();
    }

    void event_layer_checkbox_CheckedChanged(object sender, EventArgs e)
    {
      tileView1.event_layer_visible = event_layer_checkbox.Checked;
      tileView1.InvalidateAllTiles();
    }

    void screen_grid_checkbox_CheckedChanged(object sender, EventArgs e)
    {
      tileView1.show_screen_grid = screen_grid_checkbox.Checked;
      tileView1.Invalidate();
    }

    void tile_grid_checkbox_CheckedChanged(object sender, EventArgs e)
    {
      tileView1.show_tile_grid = tile_grid_checkbox.Checked;
      tileView1.Invalidate();
    }

    void collision_checkbox_CheckedChanged(object sender, EventArgs e)
    {
      tileView1.collision_layer_visible = collision_checkbox.Checked;
      tileView1.InvalidateAllTiles();
    }

    void LayerVisibleChanged(object sender, EventArgs e)
    {
      for (int i = 0; i < LevelData.num_tile_layers; i++)
      {
        tileView1.tile_layers_visible[i] = layer_checkboxes[i].Checked;
      }
      tileView1.InvalidateAllTiles();
    }
    
    void OpenToolStripMenuItemClick(object sender, EventArgs e)
    {
      using (OpenFileDialog od = new OpenFileDialog())
      {
        od.Filter = "RBRB Map Files (*.map)|*.map|All Files|*";
        
        string temp = Settings1.Default.lastMapPath;
        if (temp != null)
        {
          // SharpDevelop's app settings generator doesn't generate an empty
          // string quite right (it leaves in some whitespace).  This works
          // around it.
          temp = temp.Trim();
          if (temp != "")
          {
            od.InitialDirectory = temp;
          }
        }
        
        if (od.ShowDialog() == DialogResult.OK)
        {
          try
          {
            level.Load_Level(od.FileName);
            
            command_stack.ClearUndoStack();
            CheckUndoEnabled();
            
            // If there is a tile1_a.png tileset image in the same directory as
            // the loaded level, ask the user if they want to load it now.
            string auto_tiles_file = Path.GetDirectoryName(od.FileName) +
              Path.DirectorySeparatorChar + "tile1_a.png";
            if (File.Exists(auto_tiles_file))
            {
              if (MessageBox.Show
                  ("It appears a tileset image is in the same directory as this level file.\n" +
                   "Do you want to load it now?", "Load tiles?", MessageBoxButtons.YesNo)
                  == DialogResult.Yes)
              {
                Load_Tile_Graphics(auto_tiles_file);
                tile_picturebox.Invalidate();
              }
            }
            
            // Also check for collision graphic tiles
            auto_tiles_file = Path.GetDirectoryName(od.FileName) +
              Path.DirectorySeparatorChar + "collision_tiles.png";
            if (File.Exists(auto_tiles_file))
            {
              if (MessageBox.Show
                  ("It appears a collision tiles image is in the same directory as this level file.\n" +
                   "Do you want to load it now?", "Load tiles?", MessageBoxButtons.YesNo)
                  == DialogResult.Yes)
              {
                Load_Collision_Graphics(auto_tiles_file);
                collision_tiles.Invalidate();
              }
            }
            
            tileView1.InvalidateAllTiles();
          }
          catch (Exception E)
          {
            MessageBox.Show("Error loading file!\n\nError information:\n" +
                            E.Message);
          }
          
          Settings1.Default.lastMapPath = Path.GetDirectoryName(od.FileName);
        }
      }
    }
    
    void HScrollBar1Scroll(object sender, EventArgs e)
    {
      tileView1.scroll_x = hScrollBar1.Value;
      tileView1.Invalidate();
    }
    
    void VScrollBar1Scroll(object sender, EventArgs e)
    {
      tileView1.scroll_y = vScrollBar1.Value;
      tileView1.Invalidate();
    }
    
    /// <summary>
    /// Handles mouse input on the tile viewer.
    /// </summary>
    /// <param name="left_tile">Left selection tile index</param>
    /// <param name="top_tile">Top selection tile index</param>
    /// <param name="right_tile">Right selection tile index </param>
    /// <param name="bottom_tile">Bottom selection tile index</param>
    void Process_Tile_Mouse(int left_tile, int top_tile, int right_tile,
                            int bottom_tile)
    {
      // Figure out which tool is selected, and make updates to the data.
      
      // Check if a tile layer tool is active
      for (int i = 0; i < LevelData.num_tile_layers; i++)
      {
        if (layer_tool_radios[i].Checked)
        {
          short actual_tile = selected_tile;
          // Check H/V flip
          if (vflip_checkbox.Checked)
          {
            actual_tile += 5000;
          }
          if (hflip_checkbox.Checked)
          {
            actual_tile = (short)(-actual_tile);
          }
          // Note - Write_Layer commands have the same value as their respective
          // layer indices.
          CommandStack.CommandEntry cmd =
            new CommandStack.CommandEntry((CommandStack.CommandType)i,
                                          left_tile, right_tile, top_tile, bottom_tile);
          for (int j = 0; j < cmd.data.GetLength(0); j++)
          {
            for (int k = 0; k < cmd.data.GetLength(1); k++)
            {
              cmd.data[j,k] = actual_tile;
            }
          }
          command_stack.RunCommnd(cmd);
        }
      }
      
      if (collision_radio.Checked)
      {
        CommandStack.CommandEntry cmd =
          new CommandStack.CommandEntry(CommandStack.CommandType.Write_Collision,
                                        left_tile, right_tile, top_tile, bottom_tile);
        for (int j = 0; j < cmd.data.GetLength(0); j++)
        {
          for (int k = 0; k < cmd.data.GetLength(1); k++)
          {
            cmd.data[j,k] = selected_collision;
          }
        }
        command_stack.RunCommnd(cmd);
      }
      
      if (event_radio.Checked)
      {
        switch (event_category_selection.SelectedIndex)
        {
            // Raw ID
          case 0:
            {
              short data;
              if (short.TryParse(event_ID_entry.Text, out data))
              {
                CommandStack.CommandEntry cmd =
                  new CommandStack.CommandEntry(CommandStack.CommandType.Write_Event,
                                                left_tile, right_tile, top_tile, bottom_tile);
                for (int j = 0; j < cmd.data.GetLength(0); j++)
                {
                  for (int k = 0; k < cmd.data.GetLength(1); k++)
                  {
                    cmd.data[j,k] = data;
                  }
                }
                command_stack.RunCommnd(cmd);
              }
              else
              {
                MessageBox.Show("Invalid event ID!");
              }
            }
            break;
            
            // Music Events
          case 1:
            {
              short data = ((Event_Selection_Item)music_event_selection.SelectedItem).id;
              
              CommandStack.CommandEntry cmd =
                new CommandStack.CommandEntry(CommandStack.CommandType.Write_Event,
                                              left_tile, right_tile, top_tile, bottom_tile);
              for (int j = 0; j < cmd.data.GetLength(0); j++)
              {
                for (int k = 0; k < cmd.data.GetLength(1); k++)
                {
                  cmd.data[j,k] = data;
                }
              }
              command_stack.RunCommnd(cmd);
            }
            break;
            
            // Tile Events
          case 2:
            {
              short data = ((Event_Selection_Item)tile_event_selection.SelectedItem).id;
              
              CommandStack.CommandEntry cmd =
                new CommandStack.CommandEntry(CommandStack.CommandType.Write_Event,
                                              left_tile, right_tile, top_tile, bottom_tile);
              for (int j = 0; j < cmd.data.GetLength(0); j++)
              {
                for (int k = 0; k < cmd.data.GetLength(1); k++)
                {
                  cmd.data[j,k] = data;
                }
              }
              command_stack.RunCommnd(cmd);
            }
            break;
            
            // Misc Events
          case 5:
            {
              short data = ((Event_Selection_Item)misc_event_selection.SelectedItem).id;
              
              CommandStack.CommandEntry cmd =
                new CommandStack.CommandEntry(CommandStack.CommandType.Write_Event,
                                              left_tile, right_tile, top_tile, bottom_tile);
              for (int j = 0; j < cmd.data.GetLength(0); j++)
              {
                for (int k = 0; k < cmd.data.GetLength(1); k++)
                {
                  cmd.data[j,k] = data;
                }
              }
              command_stack.RunCommnd(cmd);
            }
            break;
        }
      }
      
      if (item_radio.Checked)
      {
        short data;
        if (short.TryParse(item_ID_entry.Text, out data))
        {
          CommandStack.CommandEntry cmd =
            new CommandStack.CommandEntry(CommandStack.CommandType.Write_Item,
                                          left_tile, right_tile, top_tile, bottom_tile);
          for (int j = 0; j < cmd.data.GetLength(0); j++)
          {
            for (int k = 0; k < cmd.data.GetLength(1); k++)
            {
              cmd.data[j,k] = data;
            }
          }
          command_stack.RunCommnd(cmd);
        }
        else
        {
          MessageBox.Show("Invalid item ID!");
        }
      }
      
      if (metatile_radio.Checked)
      {
        if (metatile_selection.SelectedIndex > 0)
        {
          command_stack.RunCommandList
            (metatile_list[metatile_selection.SelectedIndex - 1].Get_Commands(left_tile, right_tile, top_tile, bottom_tile, metatile_layer_selection.SelectedIndex));
        }
      }
      
      if (room_type_radio.Checked)
      {
        CommandStack.CommandEntry cmd =
          new CommandStack.CommandEntry(CommandStack.CommandType.Write_Room_Type,
                                        left_tile, right_tile, top_tile, bottom_tile);
        
        for (int j = 0; j < cmd.data.GetLength(0); j++)
        {
          for (int k = 0; k < cmd.data.GetLength(1); k++)
          {
            cmd.data[j,k] = (short)room_type_selection.SelectedIndex;
          }
        }
        command_stack.RunCommnd(cmd);
      }
      
      if (room_color_radio.Checked)
      {
        // TODO right now this just parses the text in the selection box for the
        // BG index - probably should get a better way to do this.
        short selected_index;
        string selection_string = (string)room_color_selection.Items[room_color_selection.SelectedIndex];
        selection_string = selection_string.Substring(0, selection_string.IndexOf(' '));
        
        if (short.TryParse(selection_string, out selected_index))
        {
          CommandStack.CommandEntry cmd =
            new CommandStack.CommandEntry(CommandStack.CommandType.Write_Room_Color,
                                          left_tile, right_tile, top_tile, bottom_tile);
          
          for (int j = 0; j < cmd.data.GetLength(0); j++)
          {
            for (int k = 0; k < cmd.data.GetLength(1); k++)
            {
              cmd.data[j,k] = selected_index;
            }
          }
          command_stack.RunCommnd(cmd);
        }
        else
        {
          MessageBox.Show("Error getting room color value!");
        }
      }
      
      if (room_bg_radio.Checked)
      {
        short selected_index;
        
        if (short.TryParse(bg_ID_entry.Text, out selected_index))
        {
          CommandStack.CommandEntry cmd =
            new CommandStack.CommandEntry(CommandStack.CommandType.Write_Room_BG,
                                          left_tile, right_tile, top_tile, bottom_tile);
          
          for (int j = 0; j < cmd.data.GetLength(0); j++)
          {
            for (int k = 0; k < cmd.data.GetLength(1); k++)
            {
              cmd.data[j,k] = selected_index;
            }
          }
          command_stack.RunCommnd(cmd);
        }
        else
        {
          MessageBox.Show("Invalid BG ID!");
        }
      }
      
      CheckUndoEnabled();
    }
    
    void Process_Left_Click(int tile_x, int tile_y)
    {
      if (event_radio.Checked)
      {
        switch (event_category_selection.SelectedIndex)
        {
            // Entity Events
          case 3:
            {
              List<short> entity_values = new List<short>();
              var entity_object = ((Event_Selection_Item)entity_event_selection.SelectedItem);
              if (entity_object.type_list.Count > 0)
              {
                var type_object = ((Event_Selection_Item)entity_type_selection.SelectedItem);
                if (type_object.id > 0)
                {
                  entity_values.Add(type_object.id);
                }
              }
              if (entity_object.direction_list.Count > 0)
              {
                var dir_object = ((Event_Selection_Item)entity_dir_selection.SelectedItem);
                if (dir_object.id > 0)
                {
                  entity_values.Add(dir_object.id);
                }
              }
              entity_values.Add(entity_object.id);
              if (tile_y < (entity_values.Count - 1))
              {
                MessageBox.Show("Entity needs more space above to fit modifiers.");
                break;
              }
              if (entity_object.laser_delay)
              {
                short laser_delay = ((Event_Selection_Item)entity_laser_delay_selection.SelectedItem).id;
                if (laser_delay > 0)
                {
                  if (tile_y == (LevelData.map_tile_height - 1))
                  {
                    MessageBox.Show("Entity needs more space below to fit modifiers.");
                    break;
                  }
                  tile_y += 1;
                  entity_values.Add(laser_delay);
                }
              }
              CommandStack.CommandEntry cmd = new CommandStack.CommandEntry
                (CommandStack.CommandType.Write_Event, tile_x, tile_x,
                 tile_y - (entity_values.Count - 1), tile_y);
              for (int i = 0; i < entity_values.Count; i++)
              {
                cmd.data[0, i] = entity_values[i];
              }
              command_stack.RunCommnd(cmd);
            }
            break;
            
            // Warp Events
          case 4:
            {
              List<CommandStack.CommandEntry> cmd_list = new List<CommandStack.CommandEntry>();
              if (warp_entrance_checkbox.Checked)
              {
                // Make sure we're not too close to the edge of the map
                if ((tile_x < 2) || (tile_x >= (LevelData.map_tile_width - 2)) ||
                    (tile_y < 2) || (tile_y >= (LevelData.map_tile_height - 2)))
                {
                  MessageBox.Show("Warp entrance cannot be within 2 tiles of the map edge.");
                  break;
                }
                short target_map_id = ((Event_Selection_Item)warp_map_selection.SelectedItem).id;
                short target_id = ((Event_Selection_Item)warp_destination_selection.SelectedItem).id;
                CommandStack.CommandEntry cmd = new CommandStack.CommandEntry
                  (CommandStack.CommandType.Write_Event, tile_x - 2, tile_x + 2, tile_y - 2, tile_y + 2);
                for (int x = 0; x <= 4; x++)
                {
                  for (int y = 0; y <= 4; y++)
                  {
                    int dx = Math.Abs(2 - x);
                    int dy = Math.Abs(2 - y);
                    short data = 208;
                    if (dx == 2 || dy == 2)
                    {
                      data = target_map_id;
                    }
                    else if (dx == 1 || dy == 1)
                    {
                      data = target_id;
                    }
                    cmd.data[x,y] = data;
                  }
                }
                cmd_list.Add(cmd);
              }
              if (warp_exit_checkbox.Checked)
              {
                // Make sure we're not too close to the edge of the map
                if (tile_y < 5)
                {
                  MessageBox.Show("Warp exit must be for a warp at least 5 tiles below the map top.");
                  break;
                }
                CommandStack.CommandEntry cmd = new CommandStack.CommandEntry
                  (CommandStack.CommandType.Write_Event, tile_x, tile_x, tile_y - 5, tile_y - 4);
                cmd.data[0, 0] = ((Event_Selection_Item)warp_local_id_selection.SelectedItem).id;
                cmd.data[0, 1] = 240;
                cmd_list.Add(cmd);
              }
              if (warp_graphic_checkbox.Checked)
              {
                // Make sure we're not too close to the edge of the map
                if (tile_y < 7)
                {
                  MessageBox.Show("Warp graphic must be for a warp at least 7 tiles below the map top.");
                  break;
                }
                CommandStack.CommandEntry cmd = new CommandStack.CommandEntry
                  (CommandStack.CommandType.Write_Event, tile_x, tile_x, tile_y - 7, tile_y - 7);
                cmd.data[0, 0] = 112;
                cmd_list.Add(cmd);
              }
              if (cmd_list.Count > 0)
              {
                command_stack.RunCommandList(cmd_list);
              }
            }
            break;
            
            // Environmental Events
          case 6:
            {
              short data = ((Event_Selection_Item)environment_event_selection.SelectedItem).id;
              CommandStack.CommandEntry cmd = new CommandStack.CommandEntry
                (CommandStack.CommandType.Write_Event, tile_x, tile_x, tile_y, tile_y);
              cmd.data[0,0] = data;
              command_stack.RunCommnd(cmd);
            }
            break;
        }
      }
    }
    
    void Process_Right_Click(int tile_x, int tile_y)
    {
      // Figure out which tool is selected, and grab a new selection from
      // where the user clicked.
      
      // Check if a tile layer tool is active
      for (int i = 0; i < LevelData.num_tile_layers; i++)
      {
        if (layer_tool_radios[i].Checked)
        {
          short tile_index = level.tile_data[i][tile_x, tile_y];
          if (tile_index < 0)
          {
            hflip_checkbox.Checked = true;
            tile_index = (short)(-tile_index);
          }
          else
          {
            hflip_checkbox.Checked = false;
          }
          if (tile_index > 5000)
          {
            tile_index -= 5000;
            vflip_checkbox.Checked = true;
          }
          else
          {
            vflip_checkbox.Checked = false;
          }
          selected_tile = tile_index;
          Update_Tile_Preview();
        }
      }
      
      if (collision_radio.Checked)
      {
        selected_collision = level.collision_data[tile_x, tile_y];
        Update_Collision_Preview();
      }
      
      if (event_radio.Checked)
      {
        event_ID_entry.Text = level.event_data[tile_x, tile_y].ToString();
        
        // Force the event tool to the raw ID category
        event_category_selection.SelectedIndex = 0;
        Update_Event_Tool_Visibilities();
      }
      
      if (item_radio.Checked)
      {
        item_ID_entry.Text = level.item_data[tile_x, tile_y].ToString();
      }
      
      if (room_type_radio.Checked)
      {
        int map_x = tile_x / LevelData.screen_width_in_tiles;
        int map_y = LevelData.Tile_Y_To_Map_Y(tile_y);
        short data = level.room_type_data[map_x, map_y];
        
        if (data >= 0 && data < room_type_selection.Items.Count)
        {
          room_type_selection.SelectedIndex = data;
        }
      }
      
      if (room_color_radio.Checked)
      {
        // TODO there's probably a better way to do this.
        int map_x = tile_x / LevelData.screen_width_in_tiles;
        int map_y = LevelData.Tile_Y_To_Map_Y(tile_y);
        short data = level.room_color_data[map_x, map_y];
        
        for (int i = 0; i < room_color_selection.Items.Count; i++)
        {
          string temp_text = (string)(room_color_selection.Items[i]);
          temp_text = temp_text.Substring(0, temp_text.IndexOf(' '));
          short temp_value;
          if (short.TryParse(temp_text, out temp_value))
          {
            if (temp_value == data)
            {
              room_color_selection.SelectedIndex = i;
              break;
            }
          }
          else
          {
            MessageBox.Show("Error parsing room colors!");
            break;
          }
        }
      }
      
      if (room_bg_radio.Checked)
      {
        int map_x = tile_x / LevelData.screen_width_in_tiles;
        int map_y = LevelData.Tile_Y_To_Map_Y(tile_y);
        bg_ID_entry.Text = level.room_bg_data[map_x, map_y].ToString();
      }
    }
    
    void Process_Hover(int tile_x, int tile_y)
    {
      infoView1.x = tile_x;
      infoView1.y = tile_y;
      infoView1.Invalidate();
    }
    
    /// <summary>
    /// Updates the tile preview based on the selected tile and flip flags.
    /// </summary>
    void Update_Tile_Preview()
    {
      using (Graphics g = Graphics.FromImage(tile_preview.Image))
      {
        g.Clear(Color.Transparent);
        int src_x = (selected_tile % 32) * 32;
        int src_y = (selected_tile / 32) * 32;
        g.DrawImage(tile_picturebox.Image, new Rectangle(0, 0, 32, 32),
                    src_x, src_y, 32, 32, GraphicsUnit.Pixel);
        if (hflip_checkbox.Checked)
        {
          tile_preview.Image.RotateFlip(RotateFlipType.RotateNoneFlipX);
        }
        if (vflip_checkbox.Checked)
        {
          tile_preview.Image.RotateFlip(RotateFlipType.RotateNoneFlipY);
        }
      }
      tile_preview.Invalidate();
    }
    
    void PictureBox1MouseClick(object sender, MouseEventArgs e)
    {
      selected_tile = (short)((e.Y / 32) * 32 + (e.X / 32));
      Update_Tile_Preview();
    }
    
    void Hflip_checkboxCheckedChanged(object sender, EventArgs e)
    {
      Update_Tile_Preview();
    }
    
    void Vflip_checkboxCheckedChanged(object sender, EventArgs e)
    {
      Update_Tile_Preview();
    }
    
    void Update_Collision_Preview()
    {
      using (Graphics g = Graphics.FromImage(collision_preview.Image))
      {
        g.Clear(Color.Transparent);
        int src_x = (selected_collision % 32) * 32;
        int src_y = (selected_collision / 32) * 32;
        g.DrawImage(collision_tiles.Image, new Rectangle(0, 0, 32, 32),
                    src_x, src_y, 32, 32, GraphicsUnit.Pixel);
      }
      collision_preview.Invalidate();
    }
    
    void Collision_tilesMouseClick(object sender, MouseEventArgs e)
    {
      // TODO do we actually need to worry about 32+ collision tiles?
      selected_collision = (short)((e.Y / 32) * 32 + (e.X / 32));
      
      Update_Collision_Preview();
    }
    
    void SaveToolStripMenuItemClick(object sender, EventArgs e)
    {
      using (SaveFileDialog sd = new SaveFileDialog())
      {
        sd.Filter = "RBRB Map Files (*.map)|*.map|All Files|*";
        sd.OverwritePrompt = true;
        
        string temp = Settings1.Default.lastMapPath;
        if (temp != null)
        {
          // SharpDevelop's app settings generator doesn't generate an empty
          // string quite right (it leaves in some whitespace).  This works
          // around it.
          temp = temp.Trim();
          if (temp != "")
          {
            sd.InitialDirectory = temp;
          }
        }
        
        if (sd.ShowDialog() == DialogResult.OK)
        {
          try
          {
            level.Save_Level(sd.FileName);
          }
          catch (Exception E)
          {
            MessageBox.Show("Error saving file!\n\nError information:\n" +
                            E.Message);
          }
          Settings1.Default.lastMapPath = Path.GetDirectoryName(sd.FileName);
        }
      }
    }
    
    void Item_selectionSelectedIndexChanged(object sender, EventArgs e)
    {
      if (item_selection.SelectedIndex > 0)
      {
        int temp;
        string text = (string)item_selection.Items[item_selection.SelectedIndex];
        text = text.Substring(0, text.IndexOf(' '));
        if (int.TryParse(text, out temp))
        {
          item_ID_entry.Text = temp.ToString();
        }
        else
        {
          MessageBox.Show("Error reading item box selection!");
        }
        item_selection.SelectedIndex = 0;
      }
    }
    
    void UndoToolStripMenuItemClick(object sender, EventArgs e)
    {
      command_stack.Undo();
      CheckUndoEnabled();
    }
    
    void RedoToolStripMenuItemClick(object sender, EventArgs e)
    {
      command_stack.Redo();
      CheckUndoEnabled();
    }
    
    void CheckUndoEnabled()
    {
      bool undo, redo;
      command_stack.UndoAvailable(out undo,
                                  out redo);
      
      undoToolStripMenuItem.Enabled = undo;
      redoToolStripMenuItem.Enabled = redo;
    }
    
    void LoadTilesetToolStripMenuItemClick(object sender, EventArgs e)
    {
      using (OpenFileDialog od = new OpenFileDialog())
      {
        od.Filter = "PNG Image Files (*.png)|*.png|All Files|*";
        
        string temp = Settings1.Default.lastTilePath;
        if (temp != null)
        {
          // SharpDevelop's app settings generator doesn't generate an empty
          // string quite right (it leaves in some whitespace).  This works
          // around it.
          temp = temp.Trim();
          if (temp != "")
          {
            od.InitialDirectory = temp;
          }
        }
        
        if (od.ShowDialog() == DialogResult.OK)
        {
          Load_Tile_Graphics(od.FileName);
          tile_picturebox.Invalidate();
          tileView1.InvalidateAllTiles();
          Settings1.Default.lastTilePath = Path.GetDirectoryName(od.FileName);
        }
      }
    }
    
    void LoadCollisionTilesToolStripMenuItemClick(object sender, EventArgs e)
    {
      using (OpenFileDialog od = new OpenFileDialog())
      {
        od.Filter = "PNG Image Files (*.png)|*.png|All Files|*";
        
        string temp = Settings1.Default.lastCollisionPath;
        if (temp != null)
        {
          // SharpDevelop's app settings generator doesn't generate an empty
          // string quite right (it leaves in some whitespace).  This works
          // around it.
          temp = temp.Trim();
          if (temp != "")
          {
            od.InitialDirectory = temp;
          }
        }
        
        if (od.ShowDialog() == DialogResult.OK)
        {
          Load_Collision_Graphics(od.FileName);
          collision_tiles.Invalidate();
          tileView1.InvalidateAllTiles();
          
          Settings1.Default.lastCollisionPath = Path.GetDirectoryName(od.FileName);
        }
      }
    }
    
    void ClearLoadedMetatilesToolStripMenuItemClick(object sender, EventArgs e)
    {
      if (MessageBox.Show
          ("Are you sure you want to clear all loaded metatile definitions?",
           "Clear metatiles?",
           MessageBoxButtons.YesNo) == DialogResult.Yes)
      {
        metatile_list.Clear();
        UpdateMetatileList();
      }
    }
    
    void LoadMetatileFileToolStripMenuItemClick(object sender, EventArgs e)
    {
      using (OpenFileDialog od = new OpenFileDialog())
      {
        od.Filter = "Text files (*.txt)|*.txt|All files|*";
        
        string temp = Settings1.Default.lastMetatilePath;
        if (temp != null)
        {
          // SharpDevelop's app settings generator doesn't generate an empty
          // string quite right (it leaves in some whitespace).  This works
          // around it.
          temp = temp.Trim();
          if (temp != "")
          {
            od.InitialDirectory = temp;
          }
        }
        
        if (od.ShowDialog() == DialogResult.OK)
        {
          List<Metatile> new_metatiles;
          try
          {
            new_metatiles = Metatile.LoadFromFile(od.FileName);
            metatile_list.AddRange(new_metatiles);
            UpdateMetatileList();
          }
          catch (Metatile.MetatileFileException E)
          {
            MessageBox.Show
              ("Error reading metatile definitions!\n" + E.Message);
          }
          
          Settings1.Default.lastMetatilePath = Path.GetDirectoryName(od.FileName);
        }
      }
    }
    
    void MainFormFormClosed(object sender, FormClosedEventArgs e)
    {
      Settings1.Default.Save();
    }
    
    void Event_category_selectionSelectedIndexChanged(object sender, EventArgs e)
    {
      Update_Event_Tool_Visibilities();
    }
    
    void Entity_event_selectionSelectedIndexChanged(object sender, EventArgs e)
    {
      Update_Entity_Selection_Visibility();
    }
    
    void Update_Entity_Selection_Visibility()
    {
      if ((!event_radio.Checked) ||(event_category_selection.SelectedIndex != 3))
      {
        entity_type_selection.Visible = entity_dir_selection.Visible =
          entity_laser_delay_selection.Visible = false;
      }
      else
      {
        entity_type_selection.Items.Clear();
        var type_list = ((Event_Selection_Item)entity_event_selection.SelectedItem).type_list;
        if (type_list.Count > 0)
        {
          entity_type_selection.Visible = true;
          foreach (var entry in type_list)
          {
            entity_type_selection.Items.Add(entry);
          }
          entity_type_selection.SelectedIndex = 0;
        }
        else
        {
          entity_type_selection.Visible = false;
        }
        
        entity_dir_selection.Items.Clear();
        var dir_list = ((Event_Selection_Item)entity_event_selection.SelectedItem).direction_list;
        if (dir_list.Count > 0)
        {
          entity_dir_selection.Visible = true;
          foreach (var entry in dir_list)
          {
            entity_dir_selection.Items.Add(entry);
          }
          entity_dir_selection.SelectedIndex = 0;
        }
        else
        {
          entity_dir_selection.Visible = false;
        }
        
        entity_laser_delay_selection.Visible =
          ((Event_Selection_Item)entity_event_selection.SelectedItem).laser_delay;
      }
    }
    
    void ZoomLevelTextChanged(object sender, EventArgs e)
    {
      float new_zoom;
      
      const float min_zoom = 0.5f;
      const float max_zoom = 4.0f;
      
      if (float.TryParse(zoom_level_textbox.Text, out new_zoom))
      {
        // Don't zoom too far out, as it'll make redraws take way too long.
        // Also set a 'reasonable' upper bound on the zoom.
        if ((new_zoom >= min_zoom) && (new_zoom <= max_zoom))
        {
          tileView1.zoom = new_zoom;
          Update_Scrollbar_Size();
          //tileView1.Invalidate();
          tileView1.InvalidateAllTiles();
        }
        else
        {
          MessageBox.Show("Zoom must be between " + min_zoom.ToString() +
                          " and " + max_zoom.ToString());
        }
      }
      else
      {
        MessageBox.Show("Could not parse the zoom value!");
      }
    }
    
    void Zoom_level_textboxKeyDown(object sender, KeyEventArgs e)
    {
      // The only purpose of this handler is to catch the Enter key and update
      // the zoom.
      if (e.KeyCode == Keys.Enter)
      {
        ZoomLevelTextChanged(null, null);
        
        // Disable passing the event to the underlying control.  This is done
        // just to suppress the 'ding' noise it would otherwise make.
        e.Handled = true;
        e.SuppressKeyPress = true;
      }
    }
    
    void Update_Scrollbar_Size()
    {
      // Standard behavior for the scrollbars in Winforms is that they will
      // normally only ever scroll up until (Maximum - LargeChange + 1).
      // This logic updates the LargeChange based on the size of the view, and
      // pushes back from the right/bottom edge if needed.
      hScrollBar1.LargeChange = (int)(tileView1.Width / tileView1.zoom / 32.0f);
      if (hScrollBar1.Value > ((hScrollBar1.Maximum - hScrollBar1.LargeChange) + 1))
      {
        hScrollBar1.Value = ((hScrollBar1.Maximum - hScrollBar1.LargeChange) + 1);
      }
      vScrollBar1.LargeChange = (int)(tileView1.Height / tileView1.zoom / 32.0f);
      if (vScrollBar1.Value > ((vScrollBar1.Maximum - vScrollBar1.LargeChange) + 1))
      {
        vScrollBar1.Value = ((vScrollBar1.Maximum - vScrollBar1.LargeChange) + 1);
      }
    }
  }
}
