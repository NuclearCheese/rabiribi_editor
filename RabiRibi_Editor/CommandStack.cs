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
      Write_Layer_1,
      // TODO other command types
    };
    
    internal class CommandEntry
    {
      internal CommandType command;
      internal int left_tile, top_tile, right_tile, bottom_tile;
      internal short[,] old_data;
      internal short[,] new_data;
      // TODO this might need some more smarts to handle multi-layer commands.
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
        case CommandType.Write_Layer_1:
          for (int x = command.left_tile; x <= command.right_tile; x++)
          {
            for (int y = command.top_tile; y <= command.bottom_tile; y++)
            {
              command.old_data[x - command.left_tile, y - command.top_tile] = level.tile_data[1, x, y];
              level.tile_data[1, x, y] = command.new_data[x - command.left_tile, y - command.top_tile];
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
