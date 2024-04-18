namespace SpaghettiCodeDemoConsoleApp;

/// <summary>
/// Command to list to-dos.
/// </summary>
public class ListTodosCommand : ICommand
{
    /// <summary>
    /// The collection of to-dos.
    /// </summary>
    // ReSharper disable once InconsistentNaming
    private readonly List<TodoItem> todos;

    /// <summary>
    /// Initializes a new instance of the <see cref="ListTodosCommand"/> class.
    /// </summary>
    /// <param name="todos">The collection of to-do items.</param>
    public ListTodosCommand(List<TodoItem> todos)
    {
        this.todos = todos;
    }

    /// <summary>
    /// List the to-dos in the collection.
    /// </summary>
    public void Execute()
    {
        Console.WriteLine("To-do list:");
        for (var i = 0; i < this.todos.Count; i++)
        {
            var item = this.todos[i];
            Console.WriteLine($"{i + 1}. {(item.IsCompleted ? "[Completed] " : string.Empty)}{item.Description}");
        }
    }
}