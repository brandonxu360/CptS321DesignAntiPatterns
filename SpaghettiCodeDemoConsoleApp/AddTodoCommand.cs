// <copyright file="AddTodoCommand.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SpaghettiCodeDemoConsoleApp;

/// <summary>
/// Adds a to-do item to the collection of to-do items.
/// </summary>
public class AddTodoCommand : ICommand
{
    /// <summary>
    /// The list of to-dos.
    /// </summary>
    // ReSharper disable once InconsistentNaming
    private readonly List<TodoItem> todos;

    /// <summary>
    /// Initializes a new instance of the <see cref="AddTodoCommand"/> class.
    /// </summary>
    /// <param name="todos">The collection of to-dos.</param>
    public AddTodoCommand(List<TodoItem> todos)
    {
        this.todos = todos;
    }

    /// <summary>
    /// Create a new to-do and add it to the collection of to-dos.
    /// </summary>
    /// <exception cref="InvalidOperationException">Invalid user input.</exception>
    public void Execute()
    {
        // Prompt the user for the title
        Console.WriteLine("Enter a description:");
        var title = Console.ReadLine() ?? throw new InvalidOperationException();

        // Prompt the user for the description
        Console.WriteLine("Enter a description:");
        var description = Console.ReadLine() ?? throw new InvalidOperationException();

        // Add the new to-do to the collection of to-dos
        this.todos.Add(new TodoItem(title, description));
        Console.WriteLine("Item added.");
    }
}