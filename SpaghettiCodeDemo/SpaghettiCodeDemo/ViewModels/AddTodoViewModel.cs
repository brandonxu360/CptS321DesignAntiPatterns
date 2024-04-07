// <copyright file="AddTodoViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SpaghettiCodeDemo.ViewModels;

using System.Reactive;
using ReactiveUI;
using SpaghettiCodeDemo.Models;

/// <summary>
/// View model for adding a _todo view.
/// </summary>
public class AddTodoViewModel : ViewModelBase
{
    /// <summary>
    /// The staged name of the new _todo.
    /// </summary>
    // ReSharper disable once InconsistentNaming
    private string? name;

    /// <summary>
    /// Initializes a new instance of the <see cref="AddTodoViewModel"/> class.
    /// </summary>
    public AddTodoViewModel()
    {
        var okEnabled = this.WhenAnyValue(
            x => x.Name,
            x => !string.IsNullOrWhiteSpace(x));

        this.Ok = ReactiveCommand.Create(
            () => new TodoItem { Name = this.Name },
            okEnabled);
        this.Cancel = ReactiveCommand.Create(() => { });
    }

    /// <summary>
    /// Gets or sets property for name.
    /// </summary>
    public string? Name
    {
        get => this.name;
        set => this.RaiseAndSetIfChanged(ref this.name, value);
    }

    /// <summary>
    /// Gets command for pressing ok button.
    /// </summary>
    public ReactiveCommand<Unit, TodoItem> Ok { get; }

    /// <summary>
    /// Gets command for pressing cancel button.
    /// </summary>
    public ReactiveCommand<Unit, Unit> Cancel { get; }
}