/*
 * Created by SharpDevelop.
 * User: Nuclear Cheese
 * Date: 2017-09-16
 * Time: 14:33
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;

namespace RabiRibi_Editor
{
  /// <summary>
  /// Container class for level data.
  /// </summary>
  public class LevelData
  {
    // Many thanks to wcko87 for the reference implementation on reading
    // Rabi Ribi map data.
    internal const int num_tile_layers = 7;
    internal const int map_tile_width = 500;
    internal const int map_tile_height = 200;
    
    // full map size data file offsets
    const int map_data_offset = 0;
    const int event_data_offset = 200000;
    const int item_data_offset = 402700;
    const int tile_layer_0_data_offset = 602704;
    const int tile_layer_1_data_offset = 802704;
    const int tile_layer_2_data_offset = 1002704;
    const int tile_layer_3_data_offset = 1202704;
    const int tile_layer_4_data_offset = 1402704;
    const int tile_layer_5_data_offset = 1602704;
    const int tile_layer_6_data_offset = 1802704;
    
    // minimap size data file offsets
    const int room_type_data_offset = 400000;
    const int room_color_data_offset = 400900;
    const int room_bg_data_offset = 401800;
    
    // integer size data file offsets
    
    // "area"
    const int int_data_offset = 602700;
    
    // version
    const int int_version_offset = 2602704;
    
    // Local data storage
    internal short[][,] tile_data;
    internal short[,] collision_data;
    internal short[,] event_data;
    internal short[,] item_data;
    
    internal short[,] room_type_data;
    internal short[,] room_color_data;
    internal short[,] room_bg_data;
    
    internal int version;
    internal int area;
    
    // Helper data
    static readonly int[] tile_layer_offsets = new int[]
    {
      tile_layer_0_data_offset,
      tile_layer_1_data_offset,
      tile_layer_2_data_offset,
      tile_layer_3_data_offset,
      tile_layer_4_data_offset,
      tile_layer_5_data_offset,
      tile_layer_6_data_offset,
    };
    
    internal const int screen_width_in_tiles = 20;
    // TODO screen is actually 11.25 tiles tall.
    // Use Tile_Y_To_Map_Y and Map_Y_To_Tile_Y instead.
    internal const int screen_height_in_tiles = 11;
    
    internal const int map_screen_width = 25;
    internal const int map_screen_height = 18;
    
    public void ClearLevelData()
    {
      for (int x = 0; x < map_tile_width; x++)
      {
        for (int y = 0; y < map_tile_height; y++)
        {
          for (int layer = 0; layer < num_tile_layers; layer++)
          {
            tile_data[layer][x,y] = 0;
          }
          collision_data[x,y] = 0;
          event_data[x,y] = 0;
          item_data[x,y] = 0;
        }
      }
      
      for (int x = 0; x < map_screen_width; x++)
      {
        for (int y = 0; y < map_screen_height; y++)
        {
          room_type_data[x,y] = 0;
          room_color_data[x,y] = 0;
          room_bg_data[x,y] = 0;
        }
      }
    }
    
    public LevelData()
    {
      // Allocate the arrays to hold the level data
      tile_data = new short[num_tile_layers][,];
      for (int i = 0; i < num_tile_layers; i++)
      {
        tile_data[i] = new short[map_tile_width,map_tile_height];
      }
      collision_data = new short[map_tile_width,map_tile_height];
      event_data = new short[map_tile_width,map_tile_height];
      item_data = new short[map_tile_width,map_tile_height];
      
      room_type_data = new short[map_screen_width, map_screen_height];
      room_color_data = new short[map_screen_width,map_screen_height];
      room_bg_data = new short[map_screen_width,map_screen_height];
      
      // Default to blanked-out data
      ClearLevelData();
    }
    
    internal void Save_Level(string file)
    {
      using (BinaryWriter output = new BinaryWriter(File.Open(file, FileMode.Create)))
      {
        // Write tile layers
        for (int i = 0; i < tile_layer_offsets.Length; i++)
        {
          output.BaseStream.Seek(tile_layer_offsets[i], SeekOrigin.Begin);
          for (int x = 0; x < map_tile_width; x++)
          {
            for (int y = 0; y < map_tile_height; y++)
            {
              output.Write(tile_data[i][x,y]);
            }
          }
        }
        
        // Write collision layer
        output.BaseStream.Seek(map_data_offset, SeekOrigin.Begin);
        for (int x = 0; x < map_tile_width; x++)
        {
          for (int y = 0; y < map_tile_height; y++)
          {
            output.Write(collision_data[x,y]);
          }
        }
        
        // Write event layer
        output.BaseStream.Seek(event_data_offset, SeekOrigin.Begin);
        for (int x = 0; x < map_tile_width; x++)
        {
          for (int y = 0; y < map_tile_height; y++)
          {
            output.Write(event_data[x,y]);
          }
        }
        
        // Write item layer
        output.BaseStream.Seek(item_data_offset, SeekOrigin.Begin);
        for (int x = 0; x < map_tile_width; x++)
        {
          for (int y = 0; y < map_tile_height; y++)
          {
            output.Write(item_data[x,y]);
          }
        }
        
        // Write room type data
        output.BaseStream.Seek(room_type_data_offset, SeekOrigin.Begin);
        for (int x = 0; x < map_screen_width; x++)
        {
          for (int y = 0; y < map_screen_height; y++)
          {
            output.Write(room_type_data[x,y]);
          }
        }
        
        // Write room color data
        output.BaseStream.Seek(room_color_data_offset, SeekOrigin.Begin);
        for (int x = 0; x < map_screen_width; x++)
        {
          for (int y = 0; y < map_screen_height; y++)
          {
            output.Write(room_color_data[x,y]);
          }
        }
        
        // Write room bg data
        output.BaseStream.Seek(room_bg_data_offset, SeekOrigin.Begin);
        for (int x = 0; x < map_screen_width; x++)
        {
          for (int y = 0; y < map_screen_height; y++)
          {
            output.Write(room_bg_data[x,y]);
          }
        }
        
        // Write version
        output.BaseStream.Seek(int_version_offset, SeekOrigin.Begin);
        output.Write(version);
        
        // Write area
        output.BaseStream.Seek(int_data_offset, SeekOrigin.Begin);
        output.Write(area);
      }
    }
    
    internal void Load_Level(string file)
    {
      // Create new arrays, and only assign them at the end.  This way, if the
      // load fails we still keep the old data
      short[][,] new_tile_data = new short[num_tile_layers][,];
      for (int i = 0; i < num_tile_layers; i++)
      {
        new_tile_data[i] = new short[map_tile_width,map_tile_height];
      }
      short[,] new_collision_data = new short[map_tile_width,map_tile_height];
      short[,] new_event_data = new short[map_tile_width,map_tile_height];
      short[,] new_item_data = new short[map_tile_width,map_tile_height];
      short[,] new_room_type_data = new short[map_screen_width,map_screen_height];
      short[,] new_room_color_data = new short[map_screen_width,map_screen_height];
      short[,] new_room_bg_data = new short[map_screen_width,map_screen_height];
      int new_version;
      int new_area;
      
      using (BinaryReader input = new BinaryReader(File.Open(file, FileMode.Open)))
      {
        // Read tile layers
        for (int i = 0; i < tile_layer_offsets.Length; i++)
        {
          input.BaseStream.Seek(tile_layer_offsets[i], SeekOrigin.Begin);
          
          for (int x = 0; x < map_tile_width; x++)
          {
            for (int y = 0; y < map_tile_height; y++)
            {
              new_tile_data[i][x,y] = input.ReadInt16();
            }
          }
        }
        
        // Read collision layer
        input.BaseStream.Seek(map_data_offset, SeekOrigin.Begin);
        for (int x = 0; x < map_tile_width; x++)
        {
          for (int y = 0; y < map_tile_height; y++)
          {
            new_collision_data[x,y] = input.ReadInt16();
          }
        }
        
        // Read event layer
        input.BaseStream.Seek(event_data_offset, SeekOrigin.Begin);
        for (int x = 0; x < map_tile_width; x++)
        {
          for (int y = 0; y < map_tile_height; y++)
          {
            new_event_data[x,y] = input.ReadInt16();
          }
        }
        
        // Read item layer
        input.BaseStream.Seek(item_data_offset, SeekOrigin.Begin);
        for (int x = 0; x < map_tile_width; x++)
        {
          for (int y = 0; y < map_tile_height; y++)
          {
            new_item_data[x,y] = input.ReadInt16();
          }
        }
        
        // Read room type data
        input.BaseStream.Seek(room_type_data_offset, SeekOrigin.Begin);
        for (int x = 0; x < map_screen_width; x++)
        {
          for (int y = 0; y < map_screen_height; y++)
          {
            new_room_type_data[x,y] = input.ReadInt16();
          }
        }
        
        // Read room color data
        input.BaseStream.Seek(room_color_data_offset, SeekOrigin.Begin);
        for (int x = 0; x < map_screen_width; x++)
        {
          for (int y = 0; y < map_screen_height; y++)
          {
            new_room_color_data[x,y] = input.ReadInt16();
          }
        }
        
        // Read room bg data
        input.BaseStream.Seek(room_bg_data_offset, SeekOrigin.Begin);
        for (int x = 0; x < map_screen_width; x++)
        {
          for (int y = 0; y < map_screen_height; y++)
          {
            new_room_bg_data[x,y] = input.ReadInt16();
          }
        }
        
        // Read version
        input.BaseStream.Seek(int_version_offset, SeekOrigin.Begin);
        new_version = input.ReadInt32();
        
        // Read area
        input.BaseStream.Seek(int_data_offset, SeekOrigin.Begin);
        new_area = input.ReadInt32();
      }
      
      tile_data = new_tile_data;
      collision_data = new_collision_data;
      event_data = new_event_data;
      item_data = new_item_data;
      room_type_data = new_room_type_data;
      room_color_data = new_room_color_data;
      room_bg_data = new_room_bg_data;
      version = new_version;
      area = new_area;
    }
    
    internal static int Tile_Y_To_Map_Y(int tile_y)
    {
      // divide by 11.25, keeping in integer
      return (tile_y * 4) / 45;
    }
    
    internal static int Map_Y_To_Tile_Y(int map_y)
    {
      // multiply by 11.25, keeping in integer and rounding up
      return (map_y * 45 + 3) / 4;
    }
  }
}
