namespace SpaghettiCodeDemoConsoleApp;

/// <summary>
/// Command manager to map inputs to commands and invoke requested commands.
/// </summary>
public class CommandInvoker
{
    // ReSharper disable once InconsistentNaming
    private readonly Dictionary<string, ICommand> commands = new Dictionary<string, ICommand>();

    /// <summary>
    /// Initializes a new instance of the <see cref="CommandInvoker"/> class.
    /// </summary>
    /// <param name="todos">The collection of to-dos.</param>
    public CommandInvoker(List<TodoItem> todos)
    {
        // Initialize commands
        this.commands.Add("add", new AddTodoCommand(todos));
        this.commands.Add("remove", new RemoveTodoCommand(todos));
    }

    /// <summary>
    /// Execute the requested command if it is found.
    /// </summary>
    /// <param name="command">The string representation of the command requested.</param>
    public void ExecuteCommand(string command)
    {
        if (this.commands.TryGetValue(command, out var value))
        {
            value.Execute();
        }
        else
        {
            Console.WriteLine("Unknown command.");
        }
    }
}