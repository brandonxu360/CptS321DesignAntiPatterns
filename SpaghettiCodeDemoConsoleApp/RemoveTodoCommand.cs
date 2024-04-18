// <copyright file="RemoveTodoCommand.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SpaghettiCodeDemoConsoleApp;

/// <summary>
/// Remove to-do from to-do collection command.
/// </summary>
public class RemoveTodoCommand
{
    /// <summary>
    /// The collection of to-do items.
    /// </summary>
    // ReSharper disable once InconsistentNaming
    private readonly List<TodoItem> todos;

    /// <summary>
    /// Initializes a new instance of the <see cref="RemoveTodoCommand"/> class.
    /// </summary>
    /// <param name="todos">The collection of to-dos.</param>
    public RemoveTodoCommand(List<TodoItem> todos)
    {
        this.todos = todos;
    }

    /// <summary>
    /// Removes the to-do at the specified index.
    /// </summary>
    public void Execute()
    {
        Console.WriteLine("Enter the item number to remove:");
        if (int.TryParse(Console.ReadLine(), out var itemNumber) && itemNumber > 0 && itemNumber <= this.todos.Count)
        {
            this.todos.RemoveAt(itemNumber - 1);
            Console.WriteLine("Item removed.");
        }
        else
        {
            Console.WriteLine("Invalid item number.");
        }
    }
}