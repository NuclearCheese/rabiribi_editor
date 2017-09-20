/*
 * Created by SharpDevelop.
 * User: Nuclear Cheese
 * Date: 2017-09-19
 * Time: 19:36
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace RabiRibi_Editor
{
  /// <summary>
  /// Manages commands from the user, and maintains the undo and redo stacks.
  /// </summary>
  public class CommandStack
  {
    // Local reference to the level data
    LevelData level = null;
    
    internal enum CommandType
    {
      // The values on the Write_Layer values are important - they directly
      // correlate to the layer indices.
      Write_Layer_0 = 0,
      Write_Layer_1 = 1,
      Write_Layer_2 = 2,
      Write_Layer_3 = 3,
      Write_Layer_4 = 4,
      Write_Layer_5 = 5,
      Write_Layer_6 = 6,
      
      // All enumerated values below here do not rely on having a specific value.
      Write_Collision,
      Write_Event,
      Write_Item,
      Write_Room_Type,
      Write_Room_Color,
      Write_Room_BG,
      
      // TODO other command types
    };
    
    internal class CommandEntry
    {
      internal CommandType command;
      internal int left_tile, top_tile, right_tile, bottom_tile;
      internal short[,] old_data;
      internal short[,] new_data;
      // TODO this might need some more smarts to handle multi-layer commands.
      
      internal CommandEntry(CommandType cmd, int left, int right, int top, int bottom)
      {
        command = cmd;
        
        left_tile = left;
        right_tile = right;
        top_tile = top;
        bottom_tile = bottom;
        
        // If the command is a per-room command, collapse the coordinates to room coordinates
        // TODO add other per-room commands.  maybe a smarter way to do this?
        if (command == CommandType.Write_Room_Type ||
           command == CommandType.Write_Room_Color ||
           command == CommandType.Write_Room_BG)
        {
          left_tile /= LevelData.screen_width_in_tiles;
          right_tile /= LevelData.screen_width_in_tiles;
          top_tile = LevelData.Tile_Y_To_Map_Y(top_tile);
          bottom_tile = LevelData.Tile_Y_To_Map_Y(bottom_tile);
        }
        
        old_data = new short[(right_tile - left_tile) + 1, (bottom_tile - top_tile) + 1];
        new_data = new short[(right_tile - left_tile) + 1, (bottom_tile - top_tile) + 1];
      }
    }
    
    // TODO - need some way to limit the capacity of the stack
    // Apparently not present in standard collections, probably need to roll our own.
    Stack<CommandEntry> undo_stack;
    Stack<CommandEntry> redo_stack;
    
    public CommandStack(LevelData l)
    {
      level = l;
      
      undo_stack = new Stack<CommandStack.CommandEntry>();
      redo_stack = new Stack<CommandStack.CommandEntry>();
    }
    
    /// <summary>
    /// Execute a new command from the user, including placing it on the undo
    /// stack.
    /// </summary>
    /// <param name="command">Command to execute</param>
    internal void RunCommnd(CommandEntry command)
    {
      undo_stack.Push(command);
      
      // We're breaking from the old undo chain.
      // TODO - this is typical behavior, but maybe there's something smarter?
      redo_stack.Clear();
      
      RunCommandInternal(command);
    }
    
    /// <summary>
    /// Actual performance of a command.  This is reused for undo and redo in
    /// addition to normal command execution.
    /// </summary>
    /// <param name="command">Command to execute</param>
    void RunCommandInternal(CommandEntry command)
    {
      switch (command.command)
      {
        case CommandType.Write_Layer_0:
        case CommandType.Write_Layer_1:
        case CommandType.Write_Layer_2:
        case CommandType.Write_Layer_3:
        case CommandType.Write_Layer_4:
        case CommandType.Write_Layer_5:
        case CommandType.Write_Layer_6:
          int layer = (int)command.command;
          for (int x = command.left_tile; x <= command.right_tile; x++)
          {
            for (int y = command.top_tile; y <= command.bottom_tile; y++)
            {
              command.old_data[x - command.left_tile, y - command.top_tile] = level.tile_data[layer, x, y];
              level.tile_data[layer, x, y] = command.new_data[x - command.left_tile, y - command.top_tile];
            }
          }
          break;
          
        case CommandType.Write_Collision:
          for (int x = command.left_tile; x <= command.right_tile; x++)
          {
            for (int y = command.top_tile; y <= command.bottom_tile; y++)
            {
              command.old_data[x - command.left_tile, y - command.top_tile] = level.collision_data[x, y];
              level.collision_data[x, y] = command.new_data[x - command.left_tile, y - command.top_tile];
            }
          }
          break;
          
        case CommandType.Write_Event:
          for (int x = command.left_tile; x <= command.right_tile; x++)
          {
            for (int y = command.top_tile; y <= command.bottom_tile; y++)
            {
              command.old_data[x - command.left_tile, y - command.top_tile] = level.event_data[x, y];
              level.event_data[x, y] = command.new_data[x - command.left_tile, y - command.top_tile];
            }
          }
          break;
          
        case CommandType.Write_Item:
          for (int x = command.left_tile; x <= command.right_tile; x++)
          {
            for (int y = command.top_tile; y <= command.bottom_tile; y++)
            {
              command.old_data[x - command.left_tile, y - command.top_tile] = level.item_data[x, y];
              level.item_data[x, y] = command.new_data[x - command.left_tile, y - command.top_tile];
            }
          }
          break;
          
        case CommandType.Write_Room_Type:
          for (int x = command.left_tile; x <= command.right_tile; x++)
          {
            for (int y = command.top_tile; y <= command.bottom_tile; y++)
            {
              command.old_data[x - command.left_tile, y -command.top_tile] = level.room_type_data[x, y];
              level.room_type_data[x, y] = command.new_data[x -command.left_tile, y - command.top_tile];
            }
          }
          break;
          
        case CommandType.Write_Room_Color:
          for (int x = command.left_tile; x <= command.right_tile; x++)
          {
            for (int y = command.top_tile; y <= command.bottom_tile; y++)
            {
              command.old_data[x - command.left_tile, y -command.top_tile] = level.room_color_data[x, y];
              level.room_color_data[x, y] = command.new_data[x -command.left_tile, y - command.top_tile];
            }
          }
          break;
          
        case CommandType.Write_Room_BG:
          for (int x = command.left_tile; x <= command.right_tile; x++)
          {
            for (int y = command.top_tile; y <= command.bottom_tile; y++)
            {
              command.old_data[x - command.left_tile, y -command.top_tile] = level.room_bg_data[x, y];
              level.room_bg_data[x, y] = command.new_data[x -command.left_tile, y - command.top_tile];
            }
          }
          break;
      }
    }
    
    /// <summary>
    /// Undo the most recent item in the command stack
    /// </summary>
    internal void Undo()
    {
      if (undo_stack.Count > 0)
      {
        CommandEntry cmd = undo_stack.Pop();
        short[,] temp = cmd.old_data;
        cmd.old_data = cmd.new_data;
        cmd.new_data = temp;
        redo_stack.Push(cmd);
        RunCommandInternal(cmd);
      }
    }
    
    /// <summary>
    /// Redo the most recently undone item in the command stack
    /// </summary>
    internal void Redo()
    {
      if (redo_stack.Count > 0)
      {
        CommandEntry cmd = redo_stack.Pop();
        short[,] temp = cmd.old_data;
        cmd.old_data = cmd.new_data;
        cmd.new_data = temp;
        undo_stack.Push(cmd);
        RunCommandInternal(cmd);
      }
    }
  }
}
