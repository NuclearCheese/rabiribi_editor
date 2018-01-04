/*
 * Created by SharpDevelop.
 * User: Nuclear Cheese
 * Date: 2017-09-16
 * Time: 14:24
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace RabiRibi_Editor
{
  partial class MainForm
  {
    /// <summary>
    /// Designer variable used to keep track of non-visual components.
    /// </summary>
    private System.ComponentModel.IContainer components = null;
    
    /// <summary>
    /// Disposes resources used by the form.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing) {
        if (components != null) {
          components.Dispose();
        }
      }
      base.Dispose(disposing);
    }
    
    /// <summary>
    /// This method is required for Windows Forms designer support.
    /// Do not change the method contents inside the source code editor. The Forms designer might
    /// not be able to load this method if it was changed manually.
    /// </summary>
    private void InitializeComponent()
    {
      this.menuStrip1 = new System.Windows.Forms.MenuStrip();
      this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.newLevelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
      this.loadTilesetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.loadCollisionTilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.metatilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.loadMetatileFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.clearLoadedMetatilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.tileView1 = new RabiRibi_Editor.TileView();
      this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
      this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
      this.tabControl1 = new System.Windows.Forms.TabControl();
      this.tabPage1 = new System.Windows.Forms.TabPage();
      this.transparent_icons_checkbox = new System.Windows.Forms.CheckBox();
      this.item_visibility_selection = new System.Windows.Forms.ComboBox();
      this.label2 = new System.Windows.Forms.Label();
      this.event_visibility_selection = new System.Windows.Forms.ComboBox();
      this.label1 = new System.Windows.Forms.Label();
      this.zoom_track_bar = new System.Windows.Forms.TrackBar();
      this.infoView1 = new RabiRibi_Editor.InfoView();
      this.set_zoom_button = new System.Windows.Forms.Button();
      this.zoom_level_textbox = new System.Windows.Forms.TextBox();
      this.zoom_label = new System.Windows.Forms.Label();
      this.tabPage2 = new System.Windows.Forms.TabPage();
      this.environment_event_selection = new System.Windows.Forms.ComboBox();
      this.entity_laser_delay_selection = new System.Windows.Forms.ComboBox();
      this.entity_dir_selection = new System.Windows.Forms.ComboBox();
      this.entity_type_selection = new System.Windows.Forms.ComboBox();
      this.warp_graphic_checkbox = new System.Windows.Forms.CheckBox();
      this.warp_local_id_selection = new System.Windows.Forms.ComboBox();
      this.warp_exit_checkbox = new System.Windows.Forms.CheckBox();
      this.warp_entrance_checkbox = new System.Windows.Forms.CheckBox();
      this.warp_map_selection = new System.Windows.Forms.ComboBox();
      this.event_category_selection = new System.Windows.Forms.ComboBox();
      this.warp_destination_selection = new System.Windows.Forms.ComboBox();
      this.metatile_layer_selection = new System.Windows.Forms.ComboBox();
      this.metatile_selection = new System.Windows.Forms.ComboBox();
      this.bg_ID_entry = new System.Windows.Forms.TextBox();
      this.misc_event_selection = new System.Windows.Forms.ComboBox();
      this.entity_event_selection = new System.Windows.Forms.ComboBox();
      this.tile_event_selection = new System.Windows.Forms.ComboBox();
      this.music_event_selection = new System.Windows.Forms.ComboBox();
      this.item_selection = new System.Windows.Forms.ComboBox();
      this.room_color_selection = new System.Windows.Forms.ComboBox();
      this.room_type_selection = new System.Windows.Forms.ComboBox();
      this.item_ID_entry = new System.Windows.Forms.TextBox();
      this.event_ID_entry = new System.Windows.Forms.TextBox();
      this.collision_preview = new System.Windows.Forms.PictureBox();
      this.collision_tile_panel = new System.Windows.Forms.Panel();
      this.collision_tiles = new System.Windows.Forms.PictureBox();
      this.tile_preview = new System.Windows.Forms.PictureBox();
      this.vflip_checkbox = new System.Windows.Forms.CheckBox();
      this.hflip_checkbox = new System.Windows.Forms.CheckBox();
      this.tile_picturebox_panel = new System.Windows.Forms.Panel();
      this.tile_picturebox = new System.Windows.Forms.PictureBox();
      this.tools_panel = new System.Windows.Forms.Panel();
      this.splitContainer1 = new System.Windows.Forms.SplitContainer();
      this.metatile_layer_label = new System.Windows.Forms.Label();
      this.menuStrip1.SuspendLayout();
      this.tabControl1.SuspendLayout();
      this.tabPage1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.zoom_track_bar)).BeginInit();
      this.tabPage2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.collision_preview)).BeginInit();
      this.collision_tile_panel.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.collision_tiles)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.tile_preview)).BeginInit();
      this.tile_picturebox_panel.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.tile_picturebox)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
      this.splitContainer1.Panel1.SuspendLayout();
      this.splitContainer1.Panel2.SuspendLayout();
      this.splitContainer1.SuspendLayout();
      this.SuspendLayout();
      // 
      // menuStrip1
      // 
      this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                  this.fileToolStripMenuItem,
                  this.editToolStripMenuItem,
                  this.metatilesToolStripMenuItem});
      this.menuStrip1.Location = new System.Drawing.Point(0, 0);
      this.menuStrip1.Name = "menuStrip1";
      this.menuStrip1.Size = new System.Drawing.Size(942, 24);
      this.menuStrip1.TabIndex = 1;
      this.menuStrip1.Text = "menuStrip1";
      // 
      // fileToolStripMenuItem
      // 
      this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                  this.newLevelToolStripMenuItem,
                  this.openToolStripMenuItem,
                  this.saveToolStripMenuItem,
                  this.toolStripSeparator1,
                  this.loadTilesetToolStripMenuItem,
                  this.loadCollisionTilesToolStripMenuItem});
      this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
      this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
      this.fileToolStripMenuItem.Text = "File";
      // 
      // newLevelToolStripMenuItem
      // 
      this.newLevelToolStripMenuItem.Name = "newLevelToolStripMenuItem";
      this.newLevelToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
      this.newLevelToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
      this.newLevelToolStripMenuItem.Text = "New Level";
      this.newLevelToolStripMenuItem.Click += new System.EventHandler(this.NewLevelToolStripMenuItemClick);
      // 
      // openToolStripMenuItem
      // 
      this.openToolStripMenuItem.Name = "openToolStripMenuItem";
      this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
      this.openToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
      this.openToolStripMenuItem.Text = "Open Level";
      this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItemClick);
      // 
      // saveToolStripMenuItem
      // 
      this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
      this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
      this.saveToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
      this.saveToolStripMenuItem.Text = "Save Level";
      this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItemClick);
      // 
      // toolStripSeparator1
      // 
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      this.toolStripSeparator1.Size = new System.Drawing.Size(165, 6);
      // 
      // loadTilesetToolStripMenuItem
      // 
      this.loadTilesetToolStripMenuItem.Name = "loadTilesetToolStripMenuItem";
      this.loadTilesetToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
      this.loadTilesetToolStripMenuItem.Text = "Load Tileset";
      this.loadTilesetToolStripMenuItem.Click += new System.EventHandler(this.LoadTilesetToolStripMenuItemClick);
      // 
      // loadCollisionTilesToolStripMenuItem
      // 
      this.loadCollisionTilesToolStripMenuItem.Name = "loadCollisionTilesToolStripMenuItem";
      this.loadCollisionTilesToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
      this.loadCollisionTilesToolStripMenuItem.Text = "Load Collision Tiles";
      this.loadCollisionTilesToolStripMenuItem.Click += new System.EventHandler(this.LoadCollisionTilesToolStripMenuItemClick);
      // 
      // editToolStripMenuItem
      // 
      this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                  this.undoToolStripMenuItem,
                  this.redoToolStripMenuItem});
      this.editToolStripMenuItem.Name = "editToolStripMenuItem";
      this.editToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
      this.editToolStripMenuItem.Text = "Edit";
      // 
      // undoToolStripMenuItem
      // 
      this.undoToolStripMenuItem.Enabled = false;
      this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
      this.undoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
      this.undoToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
      this.undoToolStripMenuItem.Text = "Undo";
      this.undoToolStripMenuItem.Click += new System.EventHandler(this.UndoToolStripMenuItemClick);
      // 
      // redoToolStripMenuItem
      // 
      this.redoToolStripMenuItem.Enabled = false;
      this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
      this.redoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
      this.redoToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
      this.redoToolStripMenuItem.Text = "Redo";
      this.redoToolStripMenuItem.Click += new System.EventHandler(this.RedoToolStripMenuItemClick);
      // 
      // metatilesToolStripMenuItem
      // 
      this.metatilesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                  this.loadMetatileFileToolStripMenuItem,
                  this.clearLoadedMetatilesToolStripMenuItem});
      this.metatilesToolStripMenuItem.Name = "metatilesToolStripMenuItem";
      this.metatilesToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
      this.metatilesToolStripMenuItem.Text = "Metatiles";
      // 
      // loadMetatileFileToolStripMenuItem
      // 
      this.loadMetatileFileToolStripMenuItem.Name = "loadMetatileFileToolStripMenuItem";
      this.loadMetatileFileToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
      this.loadMetatileFileToolStripMenuItem.Text = "Load Metatile file";
      this.loadMetatileFileToolStripMenuItem.Click += new System.EventHandler(this.LoadMetatileFileToolStripMenuItemClick);
      // 
      // clearLoadedMetatilesToolStripMenuItem
      // 
      this.clearLoadedMetatilesToolStripMenuItem.Name = "clearLoadedMetatilesToolStripMenuItem";
      this.clearLoadedMetatilesToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
      this.clearLoadedMetatilesToolStripMenuItem.Text = "Clear Loaded Metatiles";
      this.clearLoadedMetatilesToolStripMenuItem.Click += new System.EventHandler(this.ClearLoadedMetatilesToolStripMenuItemClick);
      // 
      // tileView1
      // 
      this.tileView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
                  | System.Windows.Forms.AnchorStyles.Left) 
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.tileView1.Location = new System.Drawing.Point(0, -1);
      this.tileView1.Name = "tileView1";
      this.tileView1.Size = new System.Drawing.Size(681, 527);
      this.tileView1.TabIndex = 2;
      this.tileView1.Text = "tileView1";
      // 
      // hScrollBar1
      // 
      this.hScrollBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.hScrollBar1.Location = new System.Drawing.Point(0, 526);
      this.hScrollBar1.Maximum = 499;
      this.hScrollBar1.Name = "hScrollBar1";
      this.hScrollBar1.Size = new System.Drawing.Size(681, 16);
      this.hScrollBar1.TabIndex = 3;
      this.hScrollBar1.ValueChanged += new System.EventHandler(this.HScrollBar1Scroll);
      // 
      // vScrollBar1
      // 
      this.vScrollBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.vScrollBar1.Location = new System.Drawing.Point(681, 0);
      this.vScrollBar1.Maximum = 199;
      this.vScrollBar1.Name = "vScrollBar1";
      this.vScrollBar1.Size = new System.Drawing.Size(16, 526);
      this.vScrollBar1.TabIndex = 4;
      this.vScrollBar1.ValueChanged += new System.EventHandler(this.VScrollBar1Scroll);
      // 
      // tabControl1
      // 
      this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
                  | System.Windows.Forms.AnchorStyles.Left) 
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.tabControl1.Controls.Add(this.tabPage1);
      this.tabControl1.Controls.Add(this.tabPage2);
      this.tabControl1.Location = new System.Drawing.Point(0, 0);
      this.tabControl1.Name = "tabControl1";
      this.tabControl1.SelectedIndex = 0;
      this.tabControl1.Size = new System.Drawing.Size(239, 542);
      this.tabControl1.TabIndex = 5;
      // 
      // tabPage1
      // 
      this.tabPage1.Controls.Add(this.transparent_icons_checkbox);
      this.tabPage1.Controls.Add(this.item_visibility_selection);
      this.tabPage1.Controls.Add(this.label2);
      this.tabPage1.Controls.Add(this.event_visibility_selection);
      this.tabPage1.Controls.Add(this.label1);
      this.tabPage1.Controls.Add(this.zoom_track_bar);
      this.tabPage1.Controls.Add(this.infoView1);
      this.tabPage1.Controls.Add(this.set_zoom_button);
      this.tabPage1.Controls.Add(this.zoom_level_textbox);
      this.tabPage1.Controls.Add(this.zoom_label);
      this.tabPage1.Location = new System.Drawing.Point(4, 22);
      this.tabPage1.Name = "tabPage1";
      this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage1.Size = new System.Drawing.Size(231, 516);
      this.tabPage1.TabIndex = 0;
      this.tabPage1.Text = "View";
      this.tabPage1.UseVisualStyleBackColor = true;
      // 
      // transparent_icons_checkbox
      // 
      this.transparent_icons_checkbox.Checked = true;
      this.transparent_icons_checkbox.CheckState = System.Windows.Forms.CheckState.Checked;
      this.transparent_icons_checkbox.Location = new System.Drawing.Point(110, 92);
      this.transparent_icons_checkbox.Name = "transparent_icons_checkbox";
      this.transparent_icons_checkbox.Size = new System.Drawing.Size(125, 24);
      this.transparent_icons_checkbox.TabIndex = 9;
      this.transparent_icons_checkbox.Text = "Transparent Icons";
      this.transparent_icons_checkbox.UseVisualStyleBackColor = true;
      this.transparent_icons_checkbox.CheckedChanged += new System.EventHandler(this.Transparent_icons_checkboxCheckedChanged);
      // 
      // item_visibility_selection
      // 
      this.item_visibility_selection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.item_visibility_selection.FormattingEnabled = true;
      this.item_visibility_selection.Items.AddRange(new object[] {
                  "Not visible",
                  "Text",
                  "Icons"});
      this.item_visibility_selection.Location = new System.Drawing.Point(125, 64);
      this.item_visibility_selection.Name = "item_visibility_selection";
      this.item_visibility_selection.Size = new System.Drawing.Size(100, 21);
      this.item_visibility_selection.TabIndex = 8;
      this.item_visibility_selection.SelectedIndexChanged += new System.EventHandler(this.item_layer_checkbox_CheckedChanged);
      // 
      // label2
      // 
      this.label2.Location = new System.Drawing.Point(125, 47);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(100, 23);
      this.label2.TabIndex = 7;
      this.label2.Text = "Items:";
      // 
      // event_visibility_selection
      // 
      this.event_visibility_selection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.event_visibility_selection.FormattingEnabled = true;
      this.event_visibility_selection.Items.AddRange(new object[] {
                  "Not visible",
                  "Text",
                  "Icons"});
      this.event_visibility_selection.Location = new System.Drawing.Point(125, 19);
      this.event_visibility_selection.Name = "event_visibility_selection";
      this.event_visibility_selection.Size = new System.Drawing.Size(100, 21);
      this.event_visibility_selection.TabIndex = 6;
      this.event_visibility_selection.SelectedIndexChanged += new System.EventHandler(this.event_layer_checkbox_CheckedChanged);
      // 
      // label1
      // 
      this.label1.Location = new System.Drawing.Point(125, 3);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(100, 23);
      this.label1.TabIndex = 5;
      this.label1.Text = "Events:";
      // 
      // zoom_track_bar
      // 
      this.zoom_track_bar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.zoom_track_bar.Location = new System.Drawing.Point(6, 478);
      this.zoom_track_bar.Maximum = 40;
      this.zoom_track_bar.Name = "zoom_track_bar";
      this.zoom_track_bar.Size = new System.Drawing.Size(219, 42);
      this.zoom_track_bar.TabIndex = 4;
      this.zoom_track_bar.TickFrequency = 10;
      this.zoom_track_bar.Value = 10;
      this.zoom_track_bar.Scroll += new System.EventHandler(this.ZoomTrackBarScroll);
      // 
      // infoView1
      // 
      this.infoView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
                  | System.Windows.Forms.AnchorStyles.Left) 
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.infoView1.Location = new System.Drawing.Point(6, 240);
      this.infoView1.Name = "infoView1";
      this.infoView1.Size = new System.Drawing.Size(219, 209);
      this.infoView1.TabIndex = 3;
      this.infoView1.Text = "infoView1";
      // 
      // set_zoom_button
      // 
      this.set_zoom_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.set_zoom_button.Location = new System.Drawing.Point(150, 453);
      this.set_zoom_button.Name = "set_zoom_button";
      this.set_zoom_button.Size = new System.Drawing.Size(75, 23);
      this.set_zoom_button.TabIndex = 2;
      this.set_zoom_button.Text = "Set Zoom";
      this.set_zoom_button.UseVisualStyleBackColor = true;
      this.set_zoom_button.Click += new System.EventHandler(this.ZoomLevelTextChanged);
      // 
      // zoom_level_textbox
      // 
      this.zoom_level_textbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.zoom_level_textbox.Location = new System.Drawing.Point(49, 455);
      this.zoom_level_textbox.Name = "zoom_level_textbox";
      this.zoom_level_textbox.Size = new System.Drawing.Size(88, 20);
      this.zoom_level_textbox.TabIndex = 1;
      this.zoom_level_textbox.Text = "1.0";
      this.zoom_level_textbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Zoom_level_textboxKeyDown);
      // 
      // zoom_label
      // 
      this.zoom_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.zoom_label.Location = new System.Drawing.Point(6, 458);
      this.zoom_label.Name = "zoom_label";
      this.zoom_label.Size = new System.Drawing.Size(37, 23);
      this.zoom_label.TabIndex = 0;
      this.zoom_label.Text = "Zoom:";
      // 
      // tabPage2
      // 
      this.tabPage2.Controls.Add(this.environment_event_selection);
      this.tabPage2.Controls.Add(this.entity_laser_delay_selection);
      this.tabPage2.Controls.Add(this.entity_dir_selection);
      this.tabPage2.Controls.Add(this.entity_type_selection);
      this.tabPage2.Controls.Add(this.warp_graphic_checkbox);
      this.tabPage2.Controls.Add(this.warp_local_id_selection);
      this.tabPage2.Controls.Add(this.warp_exit_checkbox);
      this.tabPage2.Controls.Add(this.warp_entrance_checkbox);
      this.tabPage2.Controls.Add(this.warp_map_selection);
      this.tabPage2.Controls.Add(this.event_category_selection);
      this.tabPage2.Controls.Add(this.warp_destination_selection);
      this.tabPage2.Controls.Add(this.metatile_layer_selection);
      this.tabPage2.Controls.Add(this.metatile_selection);
      this.tabPage2.Controls.Add(this.bg_ID_entry);
      this.tabPage2.Controls.Add(this.misc_event_selection);
      this.tabPage2.Controls.Add(this.entity_event_selection);
      this.tabPage2.Controls.Add(this.tile_event_selection);
      this.tabPage2.Controls.Add(this.music_event_selection);
      this.tabPage2.Controls.Add(this.item_selection);
      this.tabPage2.Controls.Add(this.room_color_selection);
      this.tabPage2.Controls.Add(this.room_type_selection);
      this.tabPage2.Controls.Add(this.item_ID_entry);
      this.tabPage2.Controls.Add(this.event_ID_entry);
      this.tabPage2.Controls.Add(this.collision_preview);
      this.tabPage2.Controls.Add(this.collision_tile_panel);
      this.tabPage2.Controls.Add(this.tile_preview);
      this.tabPage2.Controls.Add(this.vflip_checkbox);
      this.tabPage2.Controls.Add(this.hflip_checkbox);
      this.tabPage2.Controls.Add(this.tile_picturebox_panel);
      this.tabPage2.Controls.Add(this.tools_panel);
      this.tabPage2.Location = new System.Drawing.Point(4, 22);
      this.tabPage2.Name = "tabPage2";
      this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage2.Size = new System.Drawing.Size(231, 516);
      this.tabPage2.TabIndex = 1;
      this.tabPage2.Text = "Tools";
      this.tabPage2.UseVisualStyleBackColor = true;
      // 
      // environment_event_selection
      // 
      this.environment_event_selection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.environment_event_selection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.environment_event_selection.DropDownWidth = 300;
      this.environment_event_selection.FormattingEnabled = true;
      this.environment_event_selection.Location = new System.Drawing.Point(6, 300);
      this.environment_event_selection.Name = "environment_event_selection";
      this.environment_event_selection.Size = new System.Drawing.Size(218, 21);
      this.environment_event_selection.TabIndex = 30;
      this.environment_event_selection.Visible = false;
      // 
      // entity_laser_delay_selection
      // 
      this.entity_laser_delay_selection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.entity_laser_delay_selection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.entity_laser_delay_selection.FormattingEnabled = true;
      this.entity_laser_delay_selection.Location = new System.Drawing.Point(6, 390);
      this.entity_laser_delay_selection.Name = "entity_laser_delay_selection";
      this.entity_laser_delay_selection.Size = new System.Drawing.Size(218, 21);
      this.entity_laser_delay_selection.TabIndex = 29;
      this.entity_laser_delay_selection.Visible = false;
      // 
      // entity_dir_selection
      // 
      this.entity_dir_selection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.entity_dir_selection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.entity_dir_selection.FormattingEnabled = true;
      this.entity_dir_selection.Location = new System.Drawing.Point(6, 360);
      this.entity_dir_selection.Name = "entity_dir_selection";
      this.entity_dir_selection.Size = new System.Drawing.Size(121, 21);
      this.entity_dir_selection.TabIndex = 28;
      this.entity_dir_selection.Visible = false;
      // 
      // entity_type_selection
      // 
      this.entity_type_selection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.entity_type_selection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.entity_type_selection.FormattingEnabled = true;
      this.entity_type_selection.Location = new System.Drawing.Point(6, 330);
      this.entity_type_selection.Name = "entity_type_selection";
      this.entity_type_selection.Size = new System.Drawing.Size(218, 21);
      this.entity_type_selection.TabIndex = 27;
      this.entity_type_selection.Visible = false;
      // 
      // warp_graphic_checkbox
      // 
      this.warp_graphic_checkbox.Checked = true;
      this.warp_graphic_checkbox.CheckState = System.Windows.Forms.CheckState.Checked;
      this.warp_graphic_checkbox.Location = new System.Drawing.Point(6, 450);
      this.warp_graphic_checkbox.Name = "warp_graphic_checkbox";
      this.warp_graphic_checkbox.Size = new System.Drawing.Size(218, 24);
      this.warp_graphic_checkbox.TabIndex = 26;
      this.warp_graphic_checkbox.Text = "Create Warp Graphic";
      this.warp_graphic_checkbox.UseVisualStyleBackColor = true;
      this.warp_graphic_checkbox.Visible = false;
      // 
      // warp_local_id_selection
      // 
      this.warp_local_id_selection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.warp_local_id_selection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.warp_local_id_selection.FormattingEnabled = true;
      this.warp_local_id_selection.Location = new System.Drawing.Point(6, 420);
      this.warp_local_id_selection.Name = "warp_local_id_selection";
      this.warp_local_id_selection.Size = new System.Drawing.Size(218, 21);
      this.warp_local_id_selection.TabIndex = 25;
      this.warp_local_id_selection.Visible = false;
      // 
      // warp_exit_checkbox
      // 
      this.warp_exit_checkbox.Checked = true;
      this.warp_exit_checkbox.CheckState = System.Windows.Forms.CheckState.Checked;
      this.warp_exit_checkbox.Location = new System.Drawing.Point(6, 390);
      this.warp_exit_checkbox.Name = "warp_exit_checkbox";
      this.warp_exit_checkbox.Size = new System.Drawing.Size(218, 24);
      this.warp_exit_checkbox.TabIndex = 24;
      this.warp_exit_checkbox.Text = "Create Warp Exit";
      this.warp_exit_checkbox.UseVisualStyleBackColor = true;
      this.warp_exit_checkbox.Visible = false;
      // 
      // warp_entrance_checkbox
      // 
      this.warp_entrance_checkbox.Checked = true;
      this.warp_entrance_checkbox.CheckState = System.Windows.Forms.CheckState.Checked;
      this.warp_entrance_checkbox.Location = new System.Drawing.Point(6, 300);
      this.warp_entrance_checkbox.Name = "warp_entrance_checkbox";
      this.warp_entrance_checkbox.Size = new System.Drawing.Size(218, 24);
      this.warp_entrance_checkbox.TabIndex = 23;
      this.warp_entrance_checkbox.Text = "Create Warp Entrance";
      this.warp_entrance_checkbox.UseVisualStyleBackColor = true;
      this.warp_entrance_checkbox.Visible = false;
      // 
      // warp_map_selection
      // 
      this.warp_map_selection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.warp_map_selection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.warp_map_selection.FormattingEnabled = true;
      this.warp_map_selection.Location = new System.Drawing.Point(6, 330);
      this.warp_map_selection.Name = "warp_map_selection";
      this.warp_map_selection.Size = new System.Drawing.Size(218, 21);
      this.warp_map_selection.TabIndex = 22;
      this.warp_map_selection.Visible = false;
      // 
      // event_category_selection
      // 
      this.event_category_selection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.event_category_selection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.event_category_selection.FormattingEnabled = true;
      this.event_category_selection.Items.AddRange(new object[] {
                  "Raw ID Entry",
                  "Music Events",
                  "Tile Events",
                  "Entities",
                  "Warp Events",
                  "Misc. Events",
                  "Environment Objects"});
      this.event_category_selection.Location = new System.Drawing.Point(6, 266);
      this.event_category_selection.Name = "event_category_selection";
      this.event_category_selection.Size = new System.Drawing.Size(218, 21);
      this.event_category_selection.TabIndex = 21;
      this.event_category_selection.Visible = false;
      this.event_category_selection.SelectedIndexChanged += new System.EventHandler(this.Event_category_selectionSelectedIndexChanged);
      // 
      // warp_destination_selection
      // 
      this.warp_destination_selection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.warp_destination_selection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.warp_destination_selection.FormattingEnabled = true;
      this.warp_destination_selection.Location = new System.Drawing.Point(6, 360);
      this.warp_destination_selection.Name = "warp_destination_selection";
      this.warp_destination_selection.Size = new System.Drawing.Size(218, 21);
      this.warp_destination_selection.TabIndex = 20;
      this.warp_destination_selection.Visible = false;
      // 
      // metatile_layer_selection
      // 
      this.metatile_layer_selection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.metatile_layer_selection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.metatile_layer_selection.FormattingEnabled = true;
      this.metatile_layer_selection.Items.AddRange(new object[] {
                  "Layer 0",
                  "Layer 1",
                  "Layer 2",
                  "Layer 3",
                  "Layer 4",
                  "Layer 5",
                  "Layer 6"});
      this.metatile_layer_selection.Location = new System.Drawing.Point(6, 314);
      this.metatile_layer_selection.Name = "metatile_layer_selection";
      this.metatile_layer_selection.Size = new System.Drawing.Size(218, 21);
      this.metatile_layer_selection.TabIndex = 19;
      this.metatile_layer_selection.Visible = false;
      // 
      // metatile_selection
      // 
      this.metatile_selection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.metatile_selection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.metatile_selection.FormattingEnabled = true;
      this.metatile_selection.Items.AddRange(new object[] {
                  "Select a metatile ..."});
      this.metatile_selection.Location = new System.Drawing.Point(6, 266);
      this.metatile_selection.Name = "metatile_selection";
      this.metatile_selection.Size = new System.Drawing.Size(215, 21);
      this.metatile_selection.TabIndex = 17;
      this.metatile_selection.Visible = false;
      // 
      // bg_ID_entry
      // 
      this.bg_ID_entry.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.bg_ID_entry.Location = new System.Drawing.Point(118, 268);
      this.bg_ID_entry.Name = "bg_ID_entry";
      this.bg_ID_entry.Size = new System.Drawing.Size(100, 20);
      this.bg_ID_entry.TabIndex = 16;
      this.bg_ID_entry.Visible = false;
      // 
      // misc_event_selection
      // 
      this.misc_event_selection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.misc_event_selection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.misc_event_selection.DropDownWidth = 300;
      this.misc_event_selection.FormattingEnabled = true;
      this.misc_event_selection.Location = new System.Drawing.Point(6, 300);
      this.misc_event_selection.Name = "misc_event_selection";
      this.misc_event_selection.Size = new System.Drawing.Size(218, 21);
      this.misc_event_selection.TabIndex = 15;
      this.misc_event_selection.Visible = false;
      // 
      // entity_event_selection
      // 
      this.entity_event_selection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.entity_event_selection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.entity_event_selection.DropDownWidth = 375;
      this.entity_event_selection.FormattingEnabled = true;
      this.entity_event_selection.Location = new System.Drawing.Point(6, 300);
      this.entity_event_selection.Name = "entity_event_selection";
      this.entity_event_selection.Size = new System.Drawing.Size(218, 21);
      this.entity_event_selection.TabIndex = 14;
      this.entity_event_selection.Visible = false;
      this.entity_event_selection.SelectedIndexChanged += new System.EventHandler(this.Entity_event_selectionSelectedIndexChanged);
      // 
      // tile_event_selection
      // 
      this.tile_event_selection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.tile_event_selection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.tile_event_selection.DropDownWidth = 300;
      this.tile_event_selection.FormattingEnabled = true;
      this.tile_event_selection.Location = new System.Drawing.Point(6, 300);
      this.tile_event_selection.Name = "tile_event_selection";
      this.tile_event_selection.Size = new System.Drawing.Size(218, 21);
      this.tile_event_selection.TabIndex = 13;
      this.tile_event_selection.Visible = false;
      // 
      // music_event_selection
      // 
      this.music_event_selection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.music_event_selection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.music_event_selection.DropDownWidth = 250;
      this.music_event_selection.FormattingEnabled = true;
      this.music_event_selection.Location = new System.Drawing.Point(6, 300);
      this.music_event_selection.Name = "music_event_selection";
      this.music_event_selection.Size = new System.Drawing.Size(218, 21);
      this.music_event_selection.TabIndex = 12;
      this.music_event_selection.Visible = false;
      // 
      // item_selection
      // 
      this.item_selection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.item_selection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.item_selection.DropDownWidth = 325;
      this.item_selection.FormattingEnabled = true;
      this.item_selection.Items.AddRange(new object[] {
                  "select an item ..."});
      this.item_selection.Location = new System.Drawing.Point(6, 300);
      this.item_selection.Name = "item_selection";
      this.item_selection.Size = new System.Drawing.Size(218, 21);
      this.item_selection.TabIndex = 11;
      this.item_selection.Visible = false;
      this.item_selection.SelectedIndexChanged += new System.EventHandler(this.Item_selectionSelectedIndexChanged);
      // 
      // room_color_selection
      // 
      this.room_color_selection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.room_color_selection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.room_color_selection.FormattingEnabled = true;
      this.room_color_selection.Items.AddRange(new object[] {
                  "0 None",
                  "1 Starting Forest (green)",
                  "2 Spectral Cave (dark blue)",
                  "3 Forgotten Cave (brown)",
                  "5 Hall of Memories DLC area (boss area)",
                  "6 Forgotten Cave 2 (brown)",
                  "7 Starting Forest Night (dark green)",
                  "9 Rabi-Rabi Beach (blue)",
                  "10 Golden Pyramid (yellow)",
                  "11 Rabi-Rabi Ravine (green)",
                  "12 Rabi-Rabi Town (tan)",
                  "13 Rabi-Rabi Park (brown)",
                  "14 UPRPRC HQ (blue)",
                  "15 Sky Island Town (purple)",
                  "16 Azure Snow Land (purple)",
                  "17 System Interior (light blue)",
                  "18 Evernight Peak (blue)",
                  "19 Exotic Laboratory",
                  "20 Golden Riverbank (orange)",
                  "21 Floating Graveyard (dark red)",
                  "22 System Interior II (bright red)",
                  "23 Aurora Palace (blue)",
                  "24 Library (cyan)",
                  "25 Natural Aquarium (green)",
                  "26 Sky High Bridge (slightly darker cyan)",
                  "27 Warp Destination outside (green)",
                  "28 Volcanic Caverns",
                  "29 Plurkwood (dark orange) - also used for CreSpirit HQ",
                  "30 Hall of Memories (dark blue)",
                  "32 Hall of Memories DLC area",
                  "31 Icy Summit (dark blue)",
                  "34 Haloween area (darker red)",
                  "50 Warp Destination inside (blue)",
                  "55 ravine DLC area",
                  "81 - used on warp destination map - boss arena?",
                  "83 - used on warp destination map - boss arena?",
                  "87 Rumi boss fight room (light brown)",
                  "95 - Hall of Memories DLC area (different colors)",
                  "96 - Hall of Memories DLC area (different colors)",
                  "97 - Hall of Memories DLC area (different colors)",
                  "98 - Hall of Memories DLC area (different colors)"});
      this.room_color_selection.Location = new System.Drawing.Point(6, 266);
      this.room_color_selection.Name = "room_color_selection";
      this.room_color_selection.Size = new System.Drawing.Size(218, 21);
      this.room_color_selection.TabIndex = 10;
      this.room_color_selection.Visible = false;
      // 
      // room_type_selection
      // 
      this.room_type_selection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.room_type_selection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.room_type_selection.FormattingEnabled = true;
      this.room_type_selection.Items.AddRange(new object[] {
                  "Unused (0)",
                  "Single Room (1)",
                  "Horizontal Scroll (2)",
                  "Vertical Scroll (3)",
                  "Free Scroll (4)",
                  "Area Transition (5)"});
      this.room_type_selection.Location = new System.Drawing.Point(6, 266);
      this.room_type_selection.Name = "room_type_selection";
      this.room_type_selection.Size = new System.Drawing.Size(215, 21);
      this.room_type_selection.TabIndex = 9;
      this.room_type_selection.Visible = false;
      // 
      // item_ID_entry
      // 
      this.item_ID_entry.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.item_ID_entry.Location = new System.Drawing.Point(118, 268);
      this.item_ID_entry.Name = "item_ID_entry";
      this.item_ID_entry.Size = new System.Drawing.Size(100, 20);
      this.item_ID_entry.TabIndex = 8;
      this.item_ID_entry.Visible = false;
      // 
      // event_ID_entry
      // 
      this.event_ID_entry.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.event_ID_entry.Location = new System.Drawing.Point(118, 300);
      this.event_ID_entry.Name = "event_ID_entry";
      this.event_ID_entry.Size = new System.Drawing.Size(100, 20);
      this.event_ID_entry.TabIndex = 7;
      this.event_ID_entry.Visible = false;
      // 
      // collision_preview
      // 
      this.collision_preview.Location = new System.Drawing.Point(185, 266);
      this.collision_preview.Name = "collision_preview";
      this.collision_preview.Size = new System.Drawing.Size(32, 32);
      this.collision_preview.TabIndex = 6;
      this.collision_preview.TabStop = false;
      this.collision_preview.Visible = false;
      // 
      // collision_tile_panel
      // 
      this.collision_tile_panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
                  | System.Windows.Forms.AnchorStyles.Left) 
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.collision_tile_panel.AutoScroll = true;
      this.collision_tile_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.collision_tile_panel.Controls.Add(this.collision_tiles);
      this.collision_tile_panel.Location = new System.Drawing.Point(6, 304);
      this.collision_tile_panel.Name = "collision_tile_panel";
      this.collision_tile_panel.Size = new System.Drawing.Size(218, 209);
      this.collision_tile_panel.TabIndex = 5;
      this.collision_tile_panel.Visible = false;
      // 
      // collision_tiles
      // 
      this.collision_tiles.Location = new System.Drawing.Point(6, 5);
      this.collision_tiles.Name = "collision_tiles";
      this.collision_tiles.Size = new System.Drawing.Size(205, 195);
      this.collision_tiles.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
      this.collision_tiles.TabIndex = 0;
      this.collision_tiles.TabStop = false;
      this.collision_tiles.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Collision_tilesMouseClick);
      // 
      // tile_preview
      // 
      this.tile_preview.Location = new System.Drawing.Point(185, 266);
      this.tile_preview.Name = "tile_preview";
      this.tile_preview.Size = new System.Drawing.Size(32, 32);
      this.tile_preview.TabIndex = 4;
      this.tile_preview.TabStop = false;
      this.tile_preview.Visible = false;
      // 
      // vflip_checkbox
      // 
      this.vflip_checkbox.Location = new System.Drawing.Point(74, 274);
      this.vflip_checkbox.Name = "vflip_checkbox";
      this.vflip_checkbox.Size = new System.Drawing.Size(58, 24);
      this.vflip_checkbox.TabIndex = 3;
      this.vflip_checkbox.Text = "V. Flip";
      this.vflip_checkbox.UseVisualStyleBackColor = true;
      this.vflip_checkbox.Visible = false;
      this.vflip_checkbox.CheckedChanged += new System.EventHandler(this.Vflip_checkboxCheckedChanged);
      // 
      // hflip_checkbox
      // 
      this.hflip_checkbox.Location = new System.Drawing.Point(7, 274);
      this.hflip_checkbox.Name = "hflip_checkbox";
      this.hflip_checkbox.Size = new System.Drawing.Size(61, 24);
      this.hflip_checkbox.TabIndex = 2;
      this.hflip_checkbox.Text = "H. Flip";
      this.hflip_checkbox.UseVisualStyleBackColor = true;
      this.hflip_checkbox.Visible = false;
      this.hflip_checkbox.CheckedChanged += new System.EventHandler(this.Hflip_checkboxCheckedChanged);
      // 
      // tile_picturebox_panel
      // 
      this.tile_picturebox_panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
                  | System.Windows.Forms.AnchorStyles.Left) 
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.tile_picturebox_panel.AutoScroll = true;
      this.tile_picturebox_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.tile_picturebox_panel.Controls.Add(this.tile_picturebox);
      this.tile_picturebox_panel.Location = new System.Drawing.Point(7, 304);
      this.tile_picturebox_panel.Name = "tile_picturebox_panel";
      this.tile_picturebox_panel.Size = new System.Drawing.Size(214, 206);
      this.tile_picturebox_panel.TabIndex = 1;
      this.tile_picturebox_panel.Visible = false;
      // 
      // tile_picturebox
      // 
      this.tile_picturebox.Location = new System.Drawing.Point(4, 4);
      this.tile_picturebox.Name = "tile_picturebox";
      this.tile_picturebox.Size = new System.Drawing.Size(205, 191);
      this.tile_picturebox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
      this.tile_picturebox.TabIndex = 0;
      this.tile_picturebox.TabStop = false;
      this.tile_picturebox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PictureBox1MouseClick);
      // 
      // tools_panel
      // 
      this.tools_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.tools_panel.Location = new System.Drawing.Point(7, 7);
      this.tools_panel.Name = "tools_panel";
      this.tools_panel.Size = new System.Drawing.Size(214, 255);
      this.tools_panel.TabIndex = 0;
      // 
      // splitContainer1
      // 
      this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
                  | System.Windows.Forms.AnchorStyles.Left) 
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
      this.splitContainer1.Location = new System.Drawing.Point(0, 28);
      this.splitContainer1.Name = "splitContainer1";
      // 
      // splitContainer1.Panel1
      // 
      this.splitContainer1.Panel1.Controls.Add(this.vScrollBar1);
      this.splitContainer1.Panel1.Controls.Add(this.tileView1);
      this.splitContainer1.Panel1.Controls.Add(this.hScrollBar1);
      this.splitContainer1.Panel1MinSize = 100;
      // 
      // splitContainer1.Panel2
      // 
      this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
      this.splitContainer1.Panel2MinSize = 235;
      this.splitContainer1.Size = new System.Drawing.Size(942, 542);
      this.splitContainer1.SplitterDistance = 697;
      this.splitContainer1.TabIndex = 6;
      // 
      // metatile_layer_label
      // 
      this.metatile_layer_label.Location = new System.Drawing.Point(0, 0);
      this.metatile_layer_label.Name = "metatile_layer_label";
      this.metatile_layer_label.Size = new System.Drawing.Size(100, 23);
      this.metatile_layer_label.TabIndex = 0;
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(942, 573);
      this.Controls.Add(this.splitContainer1);
      this.Controls.Add(this.menuStrip1);
      this.MainMenuStrip = this.menuStrip1;
      this.MinimumSize = new System.Drawing.Size(650, 600);
      this.Name = "MainForm";
      this.Text = "RabiRibi_Editor";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormFormClosing);
      this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainFormFormClosed);
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      this.tabControl1.ResumeLayout(false);
      this.tabPage1.ResumeLayout(false);
      this.tabPage1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.zoom_track_bar)).EndInit();
      this.tabPage2.ResumeLayout(false);
      this.tabPage2.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.collision_preview)).EndInit();
      this.collision_tile_panel.ResumeLayout(false);
      this.collision_tile_panel.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.collision_tiles)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.tile_preview)).EndInit();
      this.tile_picturebox_panel.ResumeLayout(false);
      this.tile_picturebox_panel.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.tile_picturebox)).EndInit();
      this.splitContainer1.Panel1.ResumeLayout(false);
      this.splitContainer1.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
      this.splitContainer1.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();
    }
    private System.Windows.Forms.CheckBox transparent_icons_checkbox;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.ComboBox item_visibility_selection;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.ComboBox event_visibility_selection;
    private System.Windows.Forms.ToolStripMenuItem newLevelToolStripMenuItem;
    private System.Windows.Forms.TrackBar zoom_track_bar;
    private RabiRibi_Editor.InfoView infoView1;
    private System.Windows.Forms.Button set_zoom_button;
    private System.Windows.Forms.Label zoom_label;
    private System.Windows.Forms.TextBox zoom_level_textbox;
    private System.Windows.Forms.SplitContainer splitContainer1;
    private System.Windows.Forms.ComboBox environment_event_selection;
    private System.Windows.Forms.ComboBox entity_laser_delay_selection;
    private System.Windows.Forms.ComboBox entity_dir_selection;
    private System.Windows.Forms.ComboBox entity_type_selection;
    private System.Windows.Forms.CheckBox warp_graphic_checkbox;
    private System.Windows.Forms.CheckBox warp_exit_checkbox;
    private System.Windows.Forms.ComboBox warp_local_id_selection;
    private System.Windows.Forms.CheckBox warp_entrance_checkbox;
    private System.Windows.Forms.ComboBox warp_map_selection;
    private System.Windows.Forms.ComboBox event_category_selection;
    private System.Windows.Forms.ComboBox warp_destination_selection;
    private System.Windows.Forms.ToolStripMenuItem clearLoadedMetatilesToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem loadMetatileFileToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem metatilesToolStripMenuItem;
    private System.Windows.Forms.ComboBox metatile_layer_selection;
    private System.Windows.Forms.Label metatile_layer_label;
    private System.Windows.Forms.ComboBox metatile_selection;
    private System.Windows.Forms.ToolStripMenuItem loadCollisionTilesToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem loadTilesetToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
    private System.Windows.Forms.TextBox bg_ID_entry;
    private System.Windows.Forms.ComboBox misc_event_selection;
    private System.Windows.Forms.ComboBox entity_event_selection;
    private System.Windows.Forms.ComboBox tile_event_selection;
    private System.Windows.Forms.ComboBox music_event_selection;
    private System.Windows.Forms.ComboBox item_selection;
    private System.Windows.Forms.ComboBox room_color_selection;
    private System.Windows.Forms.ComboBox room_type_selection;
    private System.Windows.Forms.TextBox item_ID_entry;
    private System.Windows.Forms.TextBox event_ID_entry;
    private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
    private System.Windows.Forms.PictureBox collision_preview;
    private System.Windows.Forms.PictureBox collision_tiles;
    private System.Windows.Forms.Panel collision_tile_panel;
    private System.Windows.Forms.PictureBox tile_preview;
    private System.Windows.Forms.CheckBox hflip_checkbox;
    private System.Windows.Forms.CheckBox vflip_checkbox;
    private System.Windows.Forms.PictureBox tile_picturebox;
    private System.Windows.Forms.Panel tile_picturebox_panel;
    private System.Windows.Forms.Panel tools_panel;
    private System.Windows.Forms.TabPage tabPage2;
    private System.Windows.Forms.TabPage tabPage1;
    private System.Windows.Forms.TabControl tabControl1;
    private System.Windows.Forms.VScrollBar vScrollBar1;
    private System.Windows.Forms.HScrollBar hScrollBar1;
    private RabiRibi_Editor.TileView tileView1;
    private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
    private System.Windows.Forms.MenuStrip menuStrip1;
  }
}
