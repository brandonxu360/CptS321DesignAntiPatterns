namespace SpaghettiCodeDemo.Models;

/// <summary>
/// Represents a single _todo item.
/// </summary>
public class TodoItem
{
    /// <summary>
    /// Gets or sets the name of the _todo item.
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the TodoItem is checked off.
    /// </summary>
    public bool IsChecked { get; set; }
}
