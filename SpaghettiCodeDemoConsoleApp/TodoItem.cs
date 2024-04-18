namespace SpaghettiCodeDemoConsoleApp;

/// <summary>
/// Class to represent a single to-do item.
/// </summary>
public class TodoItem
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TodoItem"/> class.
    /// </summary>
    /// <param name="title">String title of the to-do.</param>
    /// <param name="description">String description of the to-do.</param>
    public TodoItem(string title, string description)
    {
        this.Title = title;
        this.Description = description;
        this.IsCompleted = false;
    }

    /// <summary>
    /// Gets or sets the title of the to-do item.
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// Gets or sets the description of the to-do item.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the completion status of the to-do item.
    /// </summary>
    public bool IsCompleted { get; set; }
}