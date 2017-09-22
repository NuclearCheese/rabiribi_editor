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
      internal short[,] data;
      // TODO this might need some more smarts to handle multi-layer commands.
      // Most likely, our undo/redo stack entries will end up being lists of
      // CommandEntry objects, instead of individual objects.
      
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
        
        data = new short[(right_tile - left_tile) + 1, (bottom_tile - top_tile) + 1];
      }
    }
    
    const int max_undo_entries = 50;
    
    /// <summary>
    /// A stack of CommandEntry objects, with a maximum size.  If a push
    /// exceeds the size maximum, old items are dropped.
    /// </summary>
    class BoundedStack
    {
      List<List<CommandEntry>> storage;
      
      internal BoundedStack()
      {
        storage = new List<List<CommandEntry>>();
      }
      
      internal void Push(List<CommandEntry> item)
      {
        storage.Add(item);
        if (storage.Count > max_undo_entries)
        {
          storage.RemoveRange(0, storage.Count - max_undo_entries);
        }
      }
      
      internal List<CommandEntry> Pop()
      {
        List<CommandEntry> item = storage[storage.Count - 1];
        storage.RemoveAt(storage.Count - 1);
        return item;
      }
      
      internal void Clear()
      {
        storage.Clear();
      }
      
      internal int Count
      {
        get
        {
          return storage.Count;
        }
      }
    }
    BoundedStack undo_stack;
    BoundedStack redo_stack;
    
    public CommandStack(LevelData l)
    {
      level = l;
      
      undo_stack = new CommandStack.BoundedStack();
      redo_stack = new CommandStack.BoundedStack();
    }
    
    /// <summary>
    /// Execute a new command from the user, including placing it on the undo
    /// stack.
    /// </summary>
    /// <param name="command">Command to execute</param>
    internal void RunCommnd(CommandEntry command)
    {
      List<CommandEntry> temp = new List<CommandStack.CommandEntry>();
      temp.Add(command);
      RunCommandList(temp);
    }
    
    internal void RunCommandList(List<CommandEntry> command)
    {
      undo_stack.Push(command);
      
      // We're breaking from the old undo chain.
      // TODO - this is typical behavior, but maybe there's something smarter?
      redo_stack.Clear();
      
      for (int i = 0; i < command.Count; i++)
      {
        RunCommandInternal(command[i]);
      }
    }
    
    /// <summary>
    /// Actual performance of a command.  This is reused for undo and redo in
    /// addition to normal command execution.
    /// </summary>
    /// <param name="command">Command to execute</param>
    void RunCommandInternal(CommandEntry command)
    {
      short[,] data_to_modify = null;
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
          data_to_modify = level.tile_data[layer];
          break;
          
        case CommandType.Write_Collision:
          data_to_modify = level.collision_data;
          break;
          
        case CommandType.Write_Event:
          data_to_modify = level.event_data;
          break;
          
        case CommandType.Write_Item:
          data_to_modify = level.item_data;
          break;
          
        case CommandType.Write_Room_Type:
          data_to_modify = level.room_type_data;
          break;
          
        case CommandType.Write_Room_Color:
          data_to_modify = level.room_color_data;
          break;
          
        case CommandType.Write_Room_BG:
          data_to_modify = level.room_bg_data;
          break;
      }
      if (data_to_modify != null)
      {
          for (int x = command.left_tile; x <= command.right_tile; x++)
          {
            for (int y = command.top_tile; y <= command.bottom_tile; y++)
            {
              short temp = data_to_modify[x, y];
              data_to_modify[x, y] = command.data[x - command.left_tile, y - command.top_tile];
              command.data[x - command.left_tile, y - command.top_tile] = temp;
            }
          }
      }
      else
      {
        // TODO error
      }
    }
    
    /// <summary>
    /// Undo the most recent item in the command stack
    /// </summary>
    internal void Undo()
    {
      if (undo_stack.Count > 0)
      {
        List<CommandEntry> cmd = undo_stack.Pop();
        redo_stack.Push(cmd);
        for (int i = 0; i < cmd.Count; i++)
        {
          RunCommandInternal(cmd[i]);
        }
      }
    }
    
    /// <summary>
    /// Redo the most recently undone item in the command stack
    /// </summary>
    internal void Redo()
    {
      if (redo_stack.Count > 0)
      {
        List<CommandEntry> cmd = redo_stack.Pop();
        undo_stack.Push(cmd);
        for (int i = cmd.Count - 1; i >= 0; i--)
        {
          RunCommandInternal(cmd[i]);
        }
      }
    }
    
    /// <summary>
    /// Get Booleans indicating whether undo and redo are available.
    /// </summary>
    /// <param name="undo_available">Is undo available</param>
    /// <param name="redo_available">Is redo available</param>
    internal void UndoAvailable(out bool undo_available, out bool redo_available)
    {
      undo_available = undo_stack.Count > 0;
      redo_available = redo_stack.Count > 0;
    }
    
    /// <summary>
    /// Clears the undo and redo stacks.
    /// </summary>
    internal void ClearUndoStack()
    {
      undo_stack.Clear();
      redo_stack.Clear();
    }
  }
}
