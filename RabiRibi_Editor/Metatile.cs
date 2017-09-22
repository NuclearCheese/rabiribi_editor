/*
 * Created by SharpDevelop.
 * User: Nuclear Cheese
 * Date: 2017-09-22
 * Time: 18:46
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace RabiRibi_Editor
{
  /// <summary>
  /// Description of Metatile.
  /// </summary>
  public class Metatile
  {
    
    class Metatile_Layer_Info
    {
      internal bool uses_selectable_layer;
      internal CommandStack.CommandType command;
      internal short[,] data;
      internal bool[,] hflip;
      internal bool[,] vflip;
      // TODO mask
    }
    
    List<Metatile_Layer_Info> layers;
    
    int top_rows;
    int mid_rows;
    int bottom_rows;
    
    int left_cols;
    int mid_cols;
    int right_cols;
    
    string name;
    
    int slope;
    
    // TODO we might need something smarter
    public Metatile()
    {
      layers = new List<Metatile.Metatile_Layer_Info>();
      
      //name = "Blue library block";
      name = "Blue library slope down-right";
      
      slope = -1;
      
      // TODO default data to start with
      //top_rows = 1;
      //mid_rows = 1;
      //bottom_rows = 1;
      top_rows = 2;
      mid_rows = 1;
      bottom_rows = 0;
      
      //left_cols = 1;
      //mid_cols = 1;
      //right_cols = 1;
      left_cols = 0;
      mid_cols = 2;
      right_cols = 0;
      
      Metatile_Layer_Info m = new Metatile.Metatile_Layer_Info();
      m.uses_selectable_layer = true;
      m.command = CommandStack.CommandType.Write_Layer_0;
      //m.data = new short[3,3];
      //m.data[0,2] = 1641;
      //m.data[1,2] = 1642;
      //m.data[2,2] = 1643;
      //m.data[0,1] = 1609;
      //m.data[1,1] = 1610;
      //m.data[2,1] = 1611;
      //m.data[0,0] = 1577;
      //m.data[1,0] = 1578;
      //m.data[2,0] = 1579;
      //m.data[0,2] = 297;
      //m.data[1,2] = 298;
      //m.data[2,2] = 297;
      //m.data[0,1] = 329;
      //m.data[1,1] = 361;
      //m.data[2,1] = 329;
      //m.data[0,0] = 297;
      //m.data[1,0] = 298;
      //m.data[2,0] = 297;
      m.data = new short[2,3];
      m.data[0,0] = 268;
      m.data[1,0] = 269;
      m.data[0,1] = 300;
      m.data[1,1] = 301;
      m.data[0,2] = 267;
      m.data[1,2] = 267;
      
      //m.hflip = new bool[3,3];
      //m.hflip[0,0] = false;
      //m.hflip[1,0] = false;
      //m.hflip[2,0] = true;
      //m.hflip[0,1] = false;
      //m.hflip[1,1] = false;
      //m.hflip[2,1] = true;
      //m.hflip[0,2] = false;
      //m.hflip[1,2] = false;
      //m.hflip[2,2] = true;
      m.hflip = new bool[2,3];
      m.vflip = new bool[2,3];
      for (int i = 0; i < 2; i++)
      {
        for (int j = 0; j < 3; j++)
        {
          m.hflip[i,j] = false;
          m.vflip[i,j] = false;
        }
      }
      
      //m.vflip = new bool[3,3];
      //m.vflip[0,0] = false;
      //m.vflip[1,0] = false;
      //m.vflip[1,0] = false;
      //m.vflip[0,1] = false;
      //m.vflip[1,1] = false;
      //m.vflip[1,1] = false;
      //m.vflip[0,2] = true;
      //m.vflip[1,2] = true;
      //m.vflip[2,2] = true;
      layers.Add(m);
      
      m = new Metatile.Metatile_Layer_Info();
      //m.data = new short[3,3];
      //m.hflip = new bool[3,3];
      //m.vflip = new bool[3,3];
      m.uses_selectable_layer = false;
      m.command = CommandStack.CommandType.Write_Collision;
      //for (int i = 0; i < 3; i++)
      //{
      //  for (int j = 0; j < 3; j++)
      //  {
      //    m.data[i,j] = 1;
      //    m.hflip[i,j] = false;
      //    m.vflip[i,j] = false;
      //  }
      //}
      m.data = new short[2,3];
      m.data[0,0] = 7;
      m.data[1,0] = 5;
      m.data[0,1] = 1;
      m.data[1,1] = 1;
      m.data[0,2] = 1;
      m.data[1,2] = 1;
      m.hflip = new bool[2,3];
      m.vflip = new bool[2,3];
      for (int i = 0; i < 2; i++)
      {
        for (int j = 0; j < 3; j++)
        {
          m.hflip[i,j] = false;
          m.vflip[i,j] = false;
        }
      }
      layers.Add(m);
    }
    
    static int CalculateDataCoordinate(int raw_coordinate, int lower_margin, int upper_margin, int total_size, int data_size)
    {
      if (raw_coordinate < lower_margin)
      {
        return raw_coordinate;
      }
      else if (raw_coordinate >= (total_size - upper_margin))
      {
        return (data_size - upper_margin) + (raw_coordinate - (total_size - upper_margin));
      }
      int mid_width = data_size - upper_margin - lower_margin;
      return (raw_coordinate - lower_margin) % mid_width + lower_margin;
    }
    
    internal List<CommandStack.CommandEntry> Get_Commands(int left, int right, int top, int bottom, int selectable_layer)
    {
      List<CommandStack.CommandEntry> results = new List<CommandStack.CommandEntry>();
      foreach (var layer in layers)
      {
        CommandStack.CommandType cmd_type;
        if (layer.uses_selectable_layer)
        {
          cmd_type = (CommandStack.CommandType)selectable_layer;
        }
        else
        {
          cmd_type = layer.command;
        }
        CommandStack.CommandEntry cmd =
          new CommandStack.CommandEntry(cmd_type, left, right, top, bottom);
        
        // Generate a command entry for each layer the metatile effects.
        for (int x = 0; x < cmd.data.GetLength(0);x ++)
        {
          for (int y = 0; y < cmd.data.GetLength(1); y++)
          {
            int data_x;
            int data_y;
            
            data_x = CalculateDataCoordinate(x, left_cols, right_cols,
                                             cmd.data.GetLength(0), layer.data.GetLength(0));
            
            // If we have a sloped top on this metatile, adjust the top of the
            // current column accordingly
            int top_y_offset = 0;
            int mid_width = layer.data.GetLength(0) - left_cols - right_cols;
            if ((slope < 0) && (x > left_cols))
            {
              top_y_offset = (x - left_cols) / mid_width;
            }
            else if ((slope > 0) && (x < (cmd.data.GetLength(0) - right_cols)))
            {
              int distance_from_right = (cmd.data.GetLength(0) - x) - right_cols;
              top_y_offset = (distance_from_right - (mid_width - 1)) / mid_width;
            }
            
            if (y < top_y_offset)
            {
              continue;
            }
            
            data_y = CalculateDataCoordinate(y - top_y_offset, top_rows, bottom_rows,
                                             cmd.data.GetLength(1) - top_y_offset, layer.data.GetLength(1));
            
            short temp = layer.data[data_x, data_y];
            if (layer.vflip[data_x, data_y])
            {
              temp += 5000;
            }
            if (layer.hflip[data_x, data_y])
            {
              temp = (short)(-temp);
            }
            cmd.data[x, y] = temp;
          }
        }
        
        results.Add(cmd);
      }
      
      return results;
    }
  }
}
