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
      this.tabPage2 = new System.Windows.Forms.TabPage();
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
      this.metatile_layer_label = new System.Windows.Forms.Label();
      this.menuStrip1.SuspendLayout();
      this.tabControl1.SuspendLayout();
      this.tabPage2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.collision_preview)).BeginInit();
      this.collision_tile_panel.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.collision_tiles)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.tile_preview)).BeginInit();
      this.tile_picturebox_panel.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.tile_picturebox)).BeginInit();
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
                  this.openToolStripMenuItem,
                  this.saveToolStripMenuItem,
                  this.toolStripSeparator1,
                  this.loadTilesetToolStripMenuItem,
                  this.loadCollisionTilesToolStripMenuItem});
      this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
      this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
      this.fileToolStripMenuItem.Text = "File";
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
      this.tileView1.Location = new System.Drawing.Point(13, 28);
      this.tileView1.Name = "tileView1";
      this.tileView1.Size = new System.Drawing.Size(659, 517);
      this.tileView1.TabIndex = 2;
      this.tileView1.Text = "tileView1";
      // 
      // hScrollBar1
      // 
      this.hScrollBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.hScrollBar1.Location = new System.Drawing.Point(13, 548);
      this.hScrollBar1.Maximum = 499;
      this.hScrollBar1.Name = "hScrollBar1";
      this.hScrollBar1.Size = new System.Drawing.Size(659, 16);
      this.hScrollBar1.TabIndex = 3;
      this.hScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.HScrollBar1Scroll);
      // 
      // vScrollBar1
      // 
      this.vScrollBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.vScrollBar1.Location = new System.Drawing.Point(675, 28);
      this.vScrollBar1.Maximum = 199;
      this.vScrollBar1.Name = "vScrollBar1";
      this.vScrollBar1.Size = new System.Drawing.Size(16, 512);
      this.vScrollBar1.TabIndex = 4;
      this.vScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.VScrollBar1Scroll);
      // 
      // tabControl1
      // 
      this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.tabControl1.Controls.Add(this.tabPage1);
      this.tabControl1.Controls.Add(this.tabPage2);
      this.tabControl1.Location = new System.Drawing.Point(695, 28);
      this.tabControl1.Name = "tabControl1";
      this.tabControl1.SelectedIndex = 0;
      this.tabControl1.Size = new System.Drawing.Size(235, 536);
      this.tabControl1.TabIndex = 5;
      // 
      // tabPage1
      // 
      this.tabPage1.Location = new System.Drawing.Point(4, 22);
      this.tabPage1.Name = "tabPage1";
      this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage1.Size = new System.Drawing.Size(227, 510);
      this.tabPage1.TabIndex = 0;
      this.tabPage1.Text = "View";
      this.tabPage1.UseVisualStyleBackColor = true;
      // 
      // tabPage2
      // 
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
      this.tabPage2.Controls.Add(this.metatile_layer_label);
      this.tabPage2.Location = new System.Drawing.Point(4, 22);
      this.tabPage2.Name = "tabPage2";
      this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage2.Size = new System.Drawing.Size(227, 510);
      this.tabPage2.TabIndex = 1;
      this.tabPage2.Text = "Tools";
      this.tabPage2.UseVisualStyleBackColor = true;
      // 
      // metatile_layer_selection
      // 
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
      this.bg_ID_entry.Location = new System.Drawing.Point(118, 268);
      this.bg_ID_entry.Name = "bg_ID_entry";
      this.bg_ID_entry.Size = new System.Drawing.Size(100, 20);
      this.bg_ID_entry.TabIndex = 16;
      this.bg_ID_entry.Visible = false;
      // 
      // misc_event_selection
      // 
      this.misc_event_selection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.misc_event_selection.FormattingEnabled = true;
      this.misc_event_selection.Items.AddRange(new object[] {
                  "select a misc. event ...",
                  "32 Warp stone",
                  "34 Start point",
                  "42 Auto save trigger",
                  "44 Auto save reenable (allows auto save to trigger again)",
                  "45 Heal point",
                  "80 Door (goes upward 2 screens on map)",
                  "81 Door (goes downward 2 screens on map)",
                  "193 Hide layer 2",
                  "194 Show layer 2",
                  "195 Right direction modifier",
                  "196 Left direction modifier",
                  "198 Up direction modifier",
                  "199 Down direction modifier",
                  "200 Red laser delay 1 (place below)",
                  "201 Red laser delay 2 (place below)",
                  "202 Red laser delay 3 (place below)",
                  "203 Red laser delay 4 (place below)",
                  "204 Red laser delay 5 (place below)",
                  "205 Red laser delay 6 (place below)",
                  "224 Save point",
                  "250 Easter egg",
                  "483 Fall damage and reset",
                  "5001 Type 1 modifier",
                  "5002 Type 2 modifier",
                  "5003 Type 3 modifier",
                  "5004 Type 4 modifier",
                  "5005 Type 5 modifier",
                  "5006 Type 6 modifier",
                  "5007 Type 7 modifier",
                  "5008 Type 8 modifier",
                  "5009 Type 9 modifier",
                  "5010 Type 10 modifier",
                  "5011 Type 11 modifier",
                  "5012 Type 12 modifier"});
      this.misc_event_selection.Location = new System.Drawing.Point(6, 390);
      this.misc_event_selection.Name = "misc_event_selection";
      this.misc_event_selection.Size = new System.Drawing.Size(218, 21);
      this.misc_event_selection.TabIndex = 15;
      this.misc_event_selection.Visible = false;
      this.misc_event_selection.SelectedIndexChanged += new System.EventHandler(this.Event_selectionSelectedIndexChanged);
      // 
      // entity_event_selection
      // 
      this.entity_event_selection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.entity_event_selection.DropDownWidth = 375;
      this.entity_event_selection.FormattingEnabled = true;
      this.entity_event_selection.Items.AddRange(new object[] {
                  "select an entity event ...",
                  "1003 Four-way fire bar",
                  "1004 Three-way fire bar",
                  "1005 Spike ball",
                  "1006 Super spike ball",
                  "1007 Wall climber",
                  "1008 Blue death laser",
                  "1009 Prologue Cocoa",
                  "1010 Pixelface (Cave 2 face boss)",
                  "1011 Rumi",
                  "1012 Ashuri",
                  "1013 Rita",
                  "1014 Ribbon",
                  "1015 Forgotten Cave Cocoa",
                  "1016 Computer Cicini",
                  "1017 Cicini\'s desk (also other objects)",
                  "1018 Cicini",
                  "1019 Red laser",
                  "1020 Saya",
                  "1021 Syaro",
                  "1022 Pandora",
                  "1023 Nieve",
                  "1024 Nixie",
                  "1025 Aruraune",
                  "1027 \"Into Town\" (???)",
                  "1028 Interactable NPC",
                  "1030 Seana",
                  "1031 Lilith",
                  "1032 Vanilla",
                  "1033 Chocolate",
                  "1035 Illusion Alius 1 (/2/3/4)",
                  "1036 Pink Kotri (/Green/Blue/Pink)",
                  "1037 Noah",
                  "1038 Irisu",
                  "1039 Miriam",
                  "1043 Miru",
                  "1045 Rita 2",
                  "1046 Lilli (/Pixie)",
                  "1053 Noah 3",
                  "1054 Keke Bunny",
                  "1055 Mr. Tako (sitting; type 3 is standing)",
                  "1056 Blue Ordinary Cat (/Pink)",
                  "1096 Pink bunny slime (5: big, 6: large)",
                  "1097 Flowers",
                  "1098 \"Ball mouse\"",
                  "1099 Bee",
                  "1102 Bird",
                  "1100 Rafflesia (type 1: green)",
                  "1101 Wisp (type 2+: exploding halloween pumpkins)",
                  "1103 Mushroom",
                  "1104 Dog",
                  "1105 Brown Mushroom (5: big, 6: large)",
                  "1106 Worm (1: shoots)",
                  "1107 Cactus",
                  "1108 Eagle (1: shoots)",
                  "1109 Blue blob charger (1: pink)",
                  "1110 UPRPRC, overalls, pink hair",
                  "1111 Purple bunny slime (5: big, 6: large)",
                  "1112 Egg (1: blue, shoots, 2: yellow, shoots)",
                  "1113 Dice (type changes value & fairies to spawn, up to 5)",
                  "1114 Blue UPRPRC fairy (/red/yellow/green/purple/gray)",
                  "1115 Card soldier",
                  "1116 Bunny thromp (down, /left/up/right/no movement)",
                  "1117 UPRPRC hugger (red, /green/blue/yellow)",
                  "1118 UPRPRC swimsuit gunner (red, /blue/yellow/green)",
                  "1119 UPRPRC debuff mage (blue, /red/green/yellow)",
                  "1120 UPRPRC bomber (red, /blue/purple/green)",
                  "1124 Open box",
                  "1125 Vehicle",
                  "1126 Skinny otaku (green, /yellow/blue)",
                  "1127 Fat otaku (red, /black)",
                  "1128 Sandbag",
                  "1129 \"STG fairy\"",
                  "1130 Fake rock (type 1: snow version)",
                  "1131 Rock-tossing mole",
                  "1132 Five-way lab turret (down, /left/right/up)",
                  "1133 Tall lab robot (1: Mr. Big Box, 5: eye lasers that turn)",
                  "1134 Flying lab robot",
                  "1135 Small lab robot (1: tiny robot)",
                  "1136 Robot maid (pink, /blue/yellow/green/Rainbow Maid)",
                  "1137 Spider (1: already dropped)",
                  "1138 Riverbank running swarmers (2: halloween variant)",
                  "1139 Hug fairy (blue, /yellow/red/green)",
                  "1140 Cyber cube (blue, /green/yellow/red/silver)",
                  "1141 Irisu clone",
                  "1142 Rainbow Crystal boss core",
                  "1143 Rainbow Crystal boss part (type affects color)",
                  "1144 UPRPRC tank (yellow, /blue/green)",
                  "1145 Bouncy cat (gray, /blue/halloween)",
                  "1146 Spark ball (rainbow, /blue/yellow/green/rainbow slow)",
                  "1147 UPRPC mage (blue, /red/green/yellow)",
                  "1148 Snow ball (type 1: fragment)",
                  "1149 Elemental magic ball (light blue, /dark blue/red)",
                  "1150 UPRPC fairy (white, /red/yellow/green/purple/gray)",
                  "1151 Pyramid eye",
                  "1152 Pyramid laser (move horizontal/vertical)",
                  "1153 UPRPC speed up mage",
                  "1154 City NPC (type affects appearance)",
                  "1155 Aurora Palace laser",
                  "1156 Meaty bone (boomerang, 1: explosive, 5: large, 6: huge)",
                  "1157 Plurkwood bullet spitter",
                  "1158 Plurkwood moth slime (5: large, 6: huge)",
                  "1159 Plurkwood bat (type affects initial movement)",
                  "1160 Fish (yellow, /blue/green)",
                  "1161 Mummy ball",
                  "1162 Five floating energy swords",
                  "1163 Library crystal (red, /orange/yellow/green/cyan/blue/purple/silver)",
                  "1164 Bunny ghost (high type modifier deals more damage)"});
      this.entity_event_selection.Location = new System.Drawing.Point(6, 360);
      this.entity_event_selection.Name = "entity_event_selection";
      this.entity_event_selection.Size = new System.Drawing.Size(218, 21);
      this.entity_event_selection.TabIndex = 14;
      this.entity_event_selection.Visible = false;
      this.entity_event_selection.SelectedIndexChanged += new System.EventHandler(this.Event_selectionSelectedIndexChanged);
      // 
      // tile_event_selection
      // 
      this.tile_event_selection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.tile_event_selection.DropDownWidth = 300;
      this.tile_event_selection.FormattingEnabled = true;
      this.tile_event_selection.Items.AddRange(new object[] {
                  "select a tile event ...",
                  "1 Wood block (break with hammer)",
                  "2 Bomb block",
                  "3 Bomb chain block",
                  "6 Fairy block (break with magic)",
                  "7 Ice block (break by touch with Fire Orb)",
                  "8 Cracked block (break when stepped on)",
                  "30 Low Item % block (disappears at >10% item collection)",
                  "108 Rainbow Crystal gate (solid until crystal boss is defeated)",
                  "109 Ignore adjacent Spikes",
                  "110 Pandora gate (solid until Pandora is defeated)",
                  "160 Boss gate (blocks exit during boss fight)",
                  "192 Reset breakable blocks",
                  "197 Spike block",
                  "455 Keke Bunny Gate (used in Keke Bunny fight)",
                  "432 Break after post game clear?"});
      this.tile_event_selection.Location = new System.Drawing.Point(6, 330);
      this.tile_event_selection.Name = "tile_event_selection";
      this.tile_event_selection.Size = new System.Drawing.Size(218, 21);
      this.tile_event_selection.TabIndex = 13;
      this.tile_event_selection.Visible = false;
      this.tile_event_selection.SelectedIndexChanged += new System.EventHandler(this.Event_selectionSelectedIndexChanged);
      // 
      // music_event_selection
      // 
      this.music_event_selection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.music_event_selection.DropDownWidth = 250;
      this.music_event_selection.FormattingEnabled = true;
      this.music_event_selection.Items.AddRange(new object[] {
                  "select a music event ...",
                  "128 No Music (disable currently playing music)",
                  "129 Adventure Starts Here",
                  "130 Spectral Cave",
                  "131 Forgotten Cave",
                  "132 Underwater Ambient",
                  "133 Library Ambient",
                  "134 Forgotten Cave II",
                  "135 Starting Forest Night / Nightwalker",
                  "136 Bounce Bounce",
                  "137 Rabi Rabi Beach",
                  "138 Pandora\'s Palace",
                  "139 Rabi Rabi Ravine",
                  "140 Home Sweet Home",
                  "141 Rabi Rabi Park",
                  "142 Inside UPRPRC",
                  "143 Sky Island Town",
                  "144 Winter Wonderland",
                  "145 Cyberspace.exe",
                  "146 Evernight Peak",
                  "147 Exotic Laboratory",
                  "148 Golden Riverbank",
                  "149 Floating Graveyard",
                  "150 System Interior II",
                  "151 Aurora Palace",
                  "152 Speicher Galerie",
                  "153 Deep Under The Sea (Natural Aquarium)",
                  "154 Sky-High Bridge",
                  "155 Warp Destination",
                  "156 Volcanic Caverns",
                  "157 Plurkwood",
                  "158 Another D (Hall of Memories)",
                  "159 Icy Summit"});
      this.music_event_selection.Location = new System.Drawing.Point(6, 300);
      this.music_event_selection.Name = "music_event_selection";
      this.music_event_selection.Size = new System.Drawing.Size(218, 21);
      this.music_event_selection.TabIndex = 12;
      this.music_event_selection.Visible = false;
      this.music_event_selection.SelectedIndexChanged += new System.EventHandler(this.Event_selectionSelectedIndexChanged);
      // 
      // item_selection
      // 
      this.item_selection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.item_selection.DropDownWidth = 325;
      this.item_selection.FormattingEnabled = true;
      this.item_selection.Items.AddRange(new object[] {
                  "select an item ...",
                  "0 no item",
                  "1 Piko Hammer",
                  "2 Air Jump",
                  "3 Sliding Powder",
                  "4 Carrot Bomb",
                  "5 Hourglass",
                  "6 Speed Boost",
                  "7 Auto Earrings",
                  "8 Ribbon (Ribbon joins on screen transition or save and reload)",
                  "9 Soul Heart",
                  "10 Rabi Slippers",
                  "11 Bunny Whirl",
                  "12 Quick Barrette",
                  "13 Book of Carrot",
                  "14 Chaos Rod",
                  "15 Hammer Wave",
                  "16 Hammer Roll",
                  "17 Light Orb",
                  "18 Water Orb",
                  "19 Fire Orb",
                  "20 Nature Orb",
                  "21 P Hairpin",
                  "22 Sunny Beam",
                  "23 Plus Necklace",
                  "24 Cyber Flower",
                  "25 Healing Staff",
                  "26 Max Bracelet",
                  "27 Explode Shot",
                  "28 Air Dash",
                  "29 Bunny Strike",
                  "30 Strange Box",
                  "31 Wall Jump",
                  "32 Spike Barrier",
                  "33 Bunny Amulet",
                  "34 Charge Ring",
                  "35 Carrot Shooter",
                  "36 Super Carrot",
                  "37 Rumi Donut",
                  "38 Rumi Cake",
                  "39 Gold Carrot",
                  "40 Cocoa Bomb",
                  "42 Congratulations! Trophy",
                  "43 Exclaimation point",
                  "48 Rainbow Magic (Does not actually give rainbow magic)",
                  "60 1.8 DLC",
                  "61 1.8 DLC",
                  "62 1.8 DLC",
                  "63 1.8 DLC",
                  "64 Health Plus",
                  "65 Health Surge",
                  "66 Mana Plus",
                  "67 Mana Surge",
                  "68 Crisis Boost",
                  "69 Atk Grow",
                  "70 Def Grow",
                  "71 Atk Trade",
                  "72 Def Trade",
                  "73 Arm Strength",
                  "74 Carrot Boost",
                  "75 Weaken",
                  "76 Self Defense",
                  "77 Armored",
                  "78 Lucky Seven",
                  "79 Hex Cancel",
                  "80 Pure Love",
                  "81 Toxic Strike",
                  "82 Frame Cancel",
                  "83 Health Wager",
                  "84 Mana Wager",
                  "85 Stamina Plus",
                  "86 Blessed",
                  "87 Hitbox Down",
                  "88 Cashback",
                  "89 Survival",
                  "90 Top Form",
                  "91 Tough Skin",
                  "92 Erina Badge",
                  "93 Ribbon Badge",
                  "94 Auto Trigger",
                  "95 Lilith\'s Gift",
                  "96 Health Up (also IDs up until 159)",
                  "160 Attack Up (also IDs up until 223)",
                  "224 Mana Up (also IDs up until 287)",
                  "288 Regen Up (also IDs up until 351)",
                  "352 Pack Up (also IDs up until 415)"});
      this.item_selection.Location = new System.Drawing.Point(6, 300);
      this.item_selection.Name = "item_selection";
      this.item_selection.Size = new System.Drawing.Size(218, 21);
      this.item_selection.TabIndex = 11;
      this.item_selection.Visible = false;
      this.item_selection.SelectedIndexChanged += new System.EventHandler(this.Item_selectionSelectedIndexChanged);
      // 
      // room_color_selection
      // 
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
      this.item_ID_entry.Location = new System.Drawing.Point(118, 268);
      this.item_ID_entry.Name = "item_ID_entry";
      this.item_ID_entry.Size = new System.Drawing.Size(100, 20);
      this.item_ID_entry.TabIndex = 8;
      this.item_ID_entry.Visible = false;
      // 
      // event_ID_entry
      // 
      this.event_ID_entry.Location = new System.Drawing.Point(118, 268);
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
      this.collision_tile_panel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
                  | System.Windows.Forms.AnchorStyles.Left)));
      this.collision_tile_panel.AutoScroll = true;
      this.collision_tile_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.collision_tile_panel.Controls.Add(this.collision_tiles);
      this.collision_tile_panel.Location = new System.Drawing.Point(6, 304);
      this.collision_tile_panel.Name = "collision_tile_panel";
      this.collision_tile_panel.Size = new System.Drawing.Size(218, 203);
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
      this.tile_picturebox_panel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
                  | System.Windows.Forms.AnchorStyles.Left)));
      this.tile_picturebox_panel.AutoScroll = true;
      this.tile_picturebox_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.tile_picturebox_panel.Controls.Add(this.tile_picturebox);
      this.tile_picturebox_panel.Location = new System.Drawing.Point(7, 304);
      this.tile_picturebox_panel.Name = "tile_picturebox_panel";
      this.tile_picturebox_panel.Size = new System.Drawing.Size(214, 200);
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
      // metatile_layer_label
      // 
      this.metatile_layer_label.Location = new System.Drawing.Point(6, 290);
      this.metatile_layer_label.Name = "metatile_layer_label";
      this.metatile_layer_label.Size = new System.Drawing.Size(100, 23);
      this.metatile_layer_label.TabIndex = 18;
      this.metatile_layer_label.Text = "Selectable layer:";
      this.metatile_layer_label.Visible = false;
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(942, 573);
      this.Controls.Add(this.tabControl1);
      this.Controls.Add(this.vScrollBar1);
      this.Controls.Add(this.hScrollBar1);
      this.Controls.Add(this.tileView1);
      this.Controls.Add(this.menuStrip1);
      this.MainMenuStrip = this.menuStrip1;
      this.MinimumSize = new System.Drawing.Size(650, 500);
      this.Name = "MainForm";
      this.Text = "RabiRibi_Editor";
      this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainFormFormClosed);
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      this.tabControl1.ResumeLayout(false);
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
      this.ResumeLayout(false);
      this.PerformLayout();
    }
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
