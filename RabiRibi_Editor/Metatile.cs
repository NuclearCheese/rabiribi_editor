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
using System.IO;

namespace RabiRibi_Editor
{
  /// <summary>
  /// Class to hold data for a metatile
  /// </summary>
  public class Metatile
  {
    /// <summary>
    /// Exception class for errors parsing a metatile definition file.
    /// </summary>
    public class MetatileFileException : System.Exception
    {
      public MetatileFileException(string message) : base(message)
      {
        
      }
    }
    
    /// <summary>
    /// Holds data for an individual layer operation for this metatile
    /// </summary>
    class Metatile_Layer_Info
    {
      internal bool uses_selectable_layer;
      internal CommandStack.CommandType command;
      internal short[,] data;
      internal bool[,] hflip;
      internal bool[,] vflip;
      internal bool[,] mask;
    }
    
    List<Metatile_Layer_Info> layers;
    
    int top_rows;
    int mid_rows;
    int bottom_rows;
    
    int left_cols;
    int mid_cols;
    int right_cols;
    
    internal string name;
    
    int slope;
    
    public Metatile()
    {
      layers = new List<Metatile.Metatile_Layer_Info>();
      slope = 0;
    }
    
    /// <summary>
    /// Helper function to calculate the coordinate within the metatile data,
    /// given the data size and the metatile placement information.  This is
    /// used for both the X and Y axes.
    /// </summary>
    /// <param name="raw_coordinate">Raw coordinate to work from</param>
    /// <param name="lower_margin">Number of one-time indices at the lower
    /// end of the range</param>
    /// <param name="upper_margin">Number of one-time indices at the upper
    /// end of the range</param>
    /// <param name="total_size">Total size of the range</param>
    /// <param name="data_size">Total size of the data to fit into</param>
    /// <param name="right_align_mid">If true, align the upper side of the
    /// repeating middle section, instead of the lower side</param>
    /// <returns></returns>
    static int CalculateDataCoordinate(int raw_coordinate, int lower_margin, int upper_margin, int total_size, int data_size, bool right_align_mid)
    {
      // If in the lower one-time range ...
      if (raw_coordinate < lower_margin)
      {
        return raw_coordinate;
      }
      // If in the upper one-time range ...
      else if (raw_coordinate >= (total_size - upper_margin))
      {
        return (data_size - upper_margin) + (raw_coordinate - (total_size - upper_margin));
      }
      
      // We're in the middle range, which can repeat.  Need to calculate the
      // correct position within the metatile data.
      int mid_width = data_size - upper_margin - lower_margin;
      if (right_align_mid)
      {
        int size_modulo = (total_size - lower_margin - upper_margin) % mid_width;
        int adjusted_coordinate = raw_coordinate + (mid_width - size_modulo);
        return (adjusted_coordinate - lower_margin) % mid_width + lower_margin;
      }
      return (raw_coordinate - lower_margin) % mid_width + lower_margin;
    }
    
    /// <summary>
    /// Returns a List of commands to enact this Metatile at the given location
    /// </summary>
    /// <param name="left">Left edge of rectangle to act within</param>
    /// <param name="right">Right edge of rectange to act within</param>
    /// <param name="top">Upper edge of rectange to act within</param>
    /// <param name="bottom">Lower edge of rectange to act within</param>
    /// <param name="selectable_layer">Index of the selectable layer</param>
    /// <returns>List of CommandEntry objects to enact this Metatile</returns>
    internal List<CommandStack.CommandEntry> Get_Commands(int left, int right, int top, int bottom, int selectable_layer)
    {
      List<CommandStack.CommandEntry> results = new List<CommandStack.CommandEntry>();
      
      // Create a CommandEntry for each layer in the Metatile
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
        
        // Determine the individual tile updates to be made.
        for (int x = 0; x < cmd.data.GetLength(0);x ++)
        {
          for (int y = 0; y < cmd.data.GetLength(1); y++)
          {
            int data_x;
            int data_y;
            
            data_x = CalculateDataCoordinate(x, left_cols, right_cols,
                                             cmd.data.GetLength(0), layer.data.GetLength(0), slope > 0);
            
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
              top_y_offset = (distance_from_right - 1) / mid_width;
            }
            
            // If the slope makes this position outside the affected area, mark
            // it as such and go to the next tile.
            if (y < top_y_offset)
            {
              cmd.mask[x,y] = false;
              continue;
            }
            
            data_y = CalculateDataCoordinate(y - top_y_offset, top_rows, bottom_rows,
                                             cmd.data.GetLength(1) - top_y_offset, layer.data.GetLength(1), false);
            
            if (!(layer.mask[data_x, data_y]))
            {
              cmd.mask[x,y] = false;
              continue;
            }
            
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
    
    /// <summary>
    /// Loads Metatile objects from a text file
    /// </summary>
    /// <param name="filename">File to read</param>
    /// <returns>List of Metatile objects</returns>
    internal static List<Metatile> LoadFromFile(string filename)
    {
      List<Metatile> result = new List<Metatile>();
      int line_number = 0;
      try
      {
        using (StreamReader input = new StreamReader(File.Open(filename, FileMode.Open)))
        {
          Metatile working = null;
          while (!input.EndOfStream)
          {
            string line = input.ReadLine().Trim();
            line_number++;
            
            // Empty line or line that starts with the comment marker - skip it.
            if ((line.Length == 0) ||
                (line.StartsWith("#")))
            {
              continue;
            }
            
            // New metatile definition
            if (line.StartsWith("metatile"))
            {
              working = new Metatile();
              working.name = line.Substring(8).Trim();
              
              // Add to the list right away.
              // Since we throw an exception out if a problem occurs, this saves
              // us from having to track if we have a new metatile to add to the
              // list.
              result.Add(working);
              
              // Default to sentinel values to detect missing definitions.
              working.left_cols = working.mid_cols = working.right_cols =
                working.top_rows = working.mid_rows = working.bottom_rows = -1;
              
              continue;
            }
            
            // Check for size definitions
            if (line.StartsWith("top_rows"))
            {
              if (working.top_rows > -1)
              {
                throw new MetatileFileException("At line " + line_number.ToString() +
                                                ": duplicate top_rows line");
              }
              working.top_rows = int.Parse(line.Substring(8).Trim());
              if (working.top_rows < 0)
              {
                throw new MetatileFileException("At line " + line_number.ToString() +
                                                ": bad top_rows (must be >= 0)");
              }
              
              continue;
            }
            
            if (line.StartsWith("mid_rows"))
            {
              if (working.mid_rows > -1)
              {
                throw new MetatileFileException("At line " + line_number.ToString() +
                                                ": duplicate mid_rows line");
              }
              working.mid_rows = int.Parse(line.Substring(8).Trim());
              if (working.mid_rows <= 0)
              {
                throw new MetatileFileException("At line " + line_number.ToString() +
                                                ": bad mid_rows (must be > 0)");
              }
              
              continue;
            }
            
            if (line.StartsWith("bottom_rows"))
            {
              if (working.bottom_rows > -1)
              {
                throw new MetatileFileException("At line " + line_number.ToString() +
                                                ": duplicate bottom_rows line");
              }
              working.bottom_rows = int.Parse(line.Substring(11).Trim());
              if (working.bottom_rows < 0)
              {
                throw new MetatileFileException("At line " + line_number.ToString() +
                                                ": bad bottom_rows (must be >= 0)");
              }
              
              continue;
            }
            
            if (line.StartsWith("left_cols"))
            {
              if (working.left_cols > -1)
              {
                throw new MetatileFileException("At line " + line_number.ToString() +
                                                ": duplicate left_cols line");
              }
              working.left_cols = int.Parse(line.Substring(9).Trim());
              if (working.left_cols < 0)
              {
                throw new MetatileFileException("At line " + line_number.ToString() +
                                                ": bad left_cols (must be >= 0)");
              }
              
              continue;
            }
            
            if (line.StartsWith("mid_cols"))
            {
              if (working.mid_cols > -1)
              {
                throw new MetatileFileException("At line " + line_number.ToString() +
                                                ": duplicate mid_cols line");
              }
              working.mid_cols = int.Parse(line.Substring(8).Trim());
              if (working.mid_cols <= 0)
              {
                throw new MetatileFileException("At line " + line_number.ToString() +
                                                ": bad mid_cols (must be > 0)");
              }
              
              continue;
            }
            
            if (line.StartsWith("right_cols"))
            {
              if (working.right_cols > -1)
              {
                throw new MetatileFileException("At line " + line_number.ToString() +
                                                ": duplicate right_cols line");
              }
              working.right_cols = int.Parse(line.Substring(10).Trim());
              if (working.right_cols < 0)
              {
                throw new MetatileFileException("At line " + line_number.ToString() +
                                                ": bad right_cols (must be >= 0)");
              }
              
              continue;
            }
            
            // Check for a slope value (optional)
            if (line.StartsWith("slope"))
            {
              working.slope = int.Parse(line.Substring(6).Trim());
              continue;
            }
            
            // Parse a layer definition
            if (line.StartsWith("layer"))
            {
              if ((working.left_cols < 0) || (working.mid_cols < 0) ||
                  (working.right_cols < 0) || (working.top_rows < 0) ||
                  (working.mid_rows < 0) || (working.bottom_rows < 0))
              {
                throw new MetatileFileException("At line " + line_number.ToString() +
                                                ": must define size before layers.");
              }
              Metatile_Layer_Info l = new Metatile.Metatile_Layer_Info();
              l.uses_selectable_layer = false;
              working.layers.Add(l);
              switch (line.Substring(6).Trim().ToLower())
              {
                case "s":
                  l.uses_selectable_layer = true;
                  // The command doesn't really matter here, but fill it in
                  // anyways just in case.
                  l.command = CommandStack.CommandType.Write_Layer_0;
                  break;
                  
                case "0":
                  l.command = CommandStack.CommandType.Write_Layer_0;
                  break;
                  
                case "1":
                  l.command = CommandStack.CommandType.Write_Layer_1;
                  break;
                  
                case "2":
                  l.command = CommandStack.CommandType.Write_Layer_2;
                  break;
                  
                case "3":
                  l.command = CommandStack.CommandType.Write_Layer_3;
                  break;
                  
                case "4":
                  l.command = CommandStack.CommandType.Write_Layer_4;
                  break;
                  
                case "5":
                  l.command = CommandStack.CommandType.Write_Layer_5;
                  break;
                  
                case "6":
                  l.command = CommandStack.CommandType.Write_Layer_6;
                  break;
                  
                case "c":
                  l.command = CommandStack.CommandType.Write_Collision;
                  break;
                  
                case "e":
                  l.command = CommandStack.CommandType.Write_Event;
                  break;
                  
                case "i":
                  l.command = CommandStack.CommandType.Write_Item;
                  break;
                  
                default:
                  throw new MetatileFileException("At line " + line_number.ToString()
                                                  + ": bad layer type");
              }
              l.data = new short[working.left_cols + working.mid_cols + working.right_cols,
                                 working.top_rows + working.mid_rows + working.bottom_rows];
              l.hflip = new bool[working.left_cols + working.mid_cols + working.right_cols,
                                 working.top_rows + working.mid_rows + working.bottom_rows];
              l.vflip = new bool[working.left_cols + working.mid_cols + working.right_cols,
                                 working.top_rows + working.mid_rows + working.bottom_rows];
              l.mask = new bool[working.left_cols + working.mid_cols + working.right_cols,
                                 working.top_rows + working.mid_rows + working.bottom_rows];
              
              // Read layer tiles
              line = "";
              for (int y = 0; y < l.data.GetLength(1); y++)
              {
                for (int x = 0; x < l.data.GetLength(0); x++)
                {
                  l.hflip[x,y] = false;
                  l.vflip[x,y] = false;
                  l.mask[x,y] = true;
                  if (line.Length == 0)
                  {
                    do
                    {
                      line = input.ReadLine().Trim();
                      line_number++;
                      if ((line.Length > 0) &&
                          !(line.StartsWith("#")))
                      {
                        break;
                      }
                    } while (true);
                  }
                  string temp;
                  if (line.IndexOf(' ') > 0)
                  {
                    temp = line.Substring(0, line.IndexOf(' ')).Trim().ToLower();
                    line = line.Substring(line.IndexOf(' ')).Trim();
                  }
                  else
                  {
                    temp = line;
                    line = "";
                  }
                  do
                  {
                    if (temp.EndsWith("h"))
                    {
                      l.hflip[x,y] = true;
                      temp = temp.Substring(0, temp.Length - 1);
                    }
                    else if (temp.EndsWith("v"))
                    {
                      l.vflip[x,y] = true;
                      temp = temp.Substring(0, temp.Length - 1);
                    }
                    else
                    {
                      break;
                    }
                  } while (true);
                  if (((l.command < CommandStack.CommandType.Write_Layer_0) ||
                      (l.command > CommandStack.CommandType.Write_Layer_6))
                      &&
                      (l.vflip[x,y] || l.hflip[x,y]))
                  {
                    throw new MetatileFileException("At line " + line_number.ToString()
                                                    + ": cannot flip non-tile-layer tiles.");
                  }
                  if (temp == "*")
                  {
                    l.mask[x,y] = false;
                  }
                  else
                  {
                    l.data[x,y] = short.Parse(temp);
                  }
                }
              }
              continue;
            }
            
            // If we get here, an invalid line was found.
            throw new MetatileFileException("At line " + line_number.ToString()
                                            + ": invalid line");
          }
          
          // Check that we don't have a partial metatile definition
          if (working != null)
          {
            if ((working.left_cols == -1) || (working.mid_cols == -1) ||
                (working.right_cols == -1) || (working.top_rows == -1) ||
                (working.mid_rows == -1) || (working.bottom_rows == -1))
            {
              throw new MetatileFileException("Incomplete metatile definition at the end of the file.");
            }
          }
        }
      }
      catch (MetatileFileException)
      {
        // Rethrow if we have a specific error message already
        throw;
      }
      catch (Exception E)
      {
        throw new MetatileFileException("Error at line " + line_number.ToString()
                                        + ": " + E.Message);
      }
      
      return result;
    }
  }
}
