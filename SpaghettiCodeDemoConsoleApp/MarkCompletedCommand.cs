namespace SpaghettiCodeDemoConsoleApp;

/// <summary>
/// Mark a to-do as completed.
/// </summary>
public class MarkCompletedCommand : ICommand
{
    /// <summary>
    /// The collection of to-dos.
    /// </summary>
    // ReSharper disable once InconsistentNaming
    private readonly List<TodoItem> todos;

    /// <summary>
    /// Initializes a new instance of the <see cref="MarkCompletedCommand"/> class.
    /// </summary>
    /// <param name="todos">The collection of to-dos.</param>
    public MarkCompletedCommand(List<TodoItem> todos)
    {
        this.todos = todos;
    }

    /// <summary>
    /// Mark a to-do's completion status as true.
    /// </summary>
    public void Execute()
    {
        Console.WriteLine("Enter the item number to mark as completed:");
        if (int.TryParse(Console.ReadLine(), out var itemNumber) && itemNumber > 0 && itemNumber <= this.todos.Count)
        {
            this.todos[itemNumber - 1].IsCompleted = true;
            Console.WriteLine("Item marked as completed.");
        }
        else
        {
            Console.WriteLine("Invalid item number.");
        }
    }
}