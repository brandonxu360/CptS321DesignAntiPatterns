using System;
using System.Collections.ObjectModel;
using System.Reactive;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Controls.Presenters;
using Avalonia.Layout;
using Avalonia.VisualTree;
using ReactiveUI;

namespace SpaghettiCodeDemo.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    // Friends list
    public ObservableCollection<string> Todos { get; } = new();

    // Property for binding to the TextBox
    public string NewTodo { get; set; }

    // Show a popup to add a todo
    public void AddTodo()
    {
        var todoTextBox = new TextBox
            { Name = "TodoTextBox", Margin = new Thickness(10) }; // TextBox for entering the todo

        var addButton = new Button
        {
            Content = "Add",
            Command = ReactiveCommand.Create(() =>
            {
                Add(todoTextBox.Text);
                var lifetime = (IClassicDesktopStyleApplicationLifetime)App.Current.ApplicationLifetime;
                if (lifetime?.Windows.Count > 1)
                {
                    var activeWindow = lifetime?.Windows[1];
                    activeWindow?.Close();
                }
            }) // Invoke Add method with the entered todo
        };

        var cancelButton = new Button
        {
            Content = "Cancel",
            Command = ReactiveCommand.Create(() =>
            {
                var lifetime = (IClassicDesktopStyleApplicationLifetime)App.Current.ApplicationLifetime;
                if (lifetime?.Windows.Count > 1)
                {
                    var activeWindow = lifetime?.Windows[1];
                    activeWindow?.Close();
                }
            }) // Close the dialog when Cancel is clicked
        };

        var buttonRow = new StackPanel
        {
            Children =
            {
                addButton, // Button to add the todo
                cancelButton // Button to cancel and close the dialog 
            },
            Orientation = Orientation.Horizontal,
            HorizontalAlignment = HorizontalAlignment.Center
        };
        var addTodoScreen = new Window
        {
            Title = "Add Todo",
            Width = 300,
            Height = 90,
            Content = new StackPanel
            {
                Children =
                {
                    todoTextBox,
                    buttonRow // Row of buttons
                }
            },
            WindowStartupLocation = WindowStartupLocation.CenterScreen // Center the window on the screen
        };

        var mainWindow = (App.Current.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime)?.MainWindow;
        addTodoScreen.ShowDialog(mainWindow); // Show the popup window
    }

    // Add a friend to the friends list
    public void Add(string todo)
    {
        if (!string.IsNullOrWhiteSpace(todo))
        {
            Todos.Add(todo);
            Console.WriteLine(Todos.Count);
        }
    }

    // Get the currently active window
    private Window GetActiveWindow()
    {
        var lifetime = (IClassicDesktopStyleApplicationLifetime)App.Current
            .ApplicationLifetime;
        return lifetime?.MainWindow ?? lifetime?.Windows[0];
    }

    // Method to close the add todo screen
    private void CloseAddTodoScreen()
    {
        var lifetime = (IClassicDesktopStyleApplicationLifetime)App.Current.ApplicationLifetime;
        var activeWindow = lifetime?.MainWindow ?? lifetime?.Windows[0];
        activeWindow?.Close();
    }

    // Command to clear completed todos
    public ReactiveCommand<Unit, Unit> ClearCompletedTodos { get; }

    // Constructor
    public MainWindowViewModel()
    {
        ClearCompletedTodos = ReactiveCommand.Create(() => ClearCompleted());
    }

    // Method to clear completed todos
    private void ClearCompleted()
    {
        for (int i = Todos.Count - 1; i >= 0; i--)
        {
            if (IsTodoCompleted(i))
            {
                Todos.RemoveAt(i);
            }
        }
    }

    // Check if a todo is completed based on its index (associated with a checkbox)
    private bool IsTodoCompleted(int index)
    {
        // Get the corresponding CheckBox control from the item container
        var itemContainer = GetItemContainer(index);
        if (itemContainer != null && itemContainer.Child is CheckBox checkBox)
        {
            // Return true if the CheckBox is checked
            return checkBox.IsChecked == true;
        }

        return false;
    }

    // Helper method to get the item container of the todo at the specified index
    private ContentPresenter GetItemContainer(int index)
    {
        var lifetime = (IClassicDesktopStyleApplicationLifetime)App.Current.ApplicationLifetime;
        var mainWindow = lifetime?.MainWindow ?? lifetime?.Windows[0];
        var itemsControl = mainWindow?.FindDescendantOfType<ItemsControl>();
        if (itemsControl != null &&
            itemsControl.ContainerFromIndex(index) is ContentPresenter container)
        {
            return container;
        }

        return null;
    }
}