// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SpaghettiCodeDemoConsoleApp;

/// <summary>
/// The to-do app.
/// </summary>
internal class ToDoApp
{
    /// <summary>
    /// The collection of to-do items.
    /// </summary>
    private static readonly List<TodoItem> Todos = [];

    private static void Main()
    {
        // Initialize the command invoker
        var commandInvoker = new CommandInvoker(Todos);

        // Command-response loop
        while (true)
        {
            // Prompt and collect user command input
            Console.WriteLine("Choose an option: add, remove, list, mark completed, remove completed, exit");
            var input = Console.ReadLine()?.ToLower() ?? string.Empty;

            // Exit the program
            if (input == "exit")
            {
                break;
            }

            // Call the command invoker to execute the command
            commandInvoker.ExecuteCommand(input);
        }
    }
}