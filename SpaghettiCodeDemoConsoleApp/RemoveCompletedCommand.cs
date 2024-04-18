namespace SpaghettiCodeDemoConsoleApp;

/// <summary>
/// Removes the completed to-dos from the to-do collection.
/// </summary>
public class RemoveCompletedCommand : ICommand
{
    /// <summary>
    /// The collection of to-dos.
    /// </summary>
    // ReSharper disable once InconsistentNaming
    private readonly List<TodoItem> todos;

    /// <summary>
    /// Initializes a new instance of the <see cref="RemoveCompletedCommand"/> class.
    /// </summary>
    /// <param name="todos">The collection of to-do items.</param>
    public RemoveCompletedCommand(List<TodoItem> todos)
    {
        this.todos = todos;
    }

    /// <summary>
    /// Removes the completed to-dos from the to-do collection.
    /// </summary>
    public void Execute()
    {
        this.todos.RemoveAll(item => item.IsCompleted);
        Console.WriteLine("All completed items removed.");
    }
}