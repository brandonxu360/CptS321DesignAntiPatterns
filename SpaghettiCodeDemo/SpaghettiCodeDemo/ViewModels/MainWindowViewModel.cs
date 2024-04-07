// <copyright file="MainWindowViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SpaghettiCodeDemo.ViewModels
{
    using System;
    using System.Reactive.Linq;
    using ReactiveUI;
    using SpaghettiCodeDemo.Models;

    /// <summary>
    /// MainWindowViewModel responsible for displaying the correct views.
    /// </summary>
    public class MainWindowViewModel : ViewModelBase
    {
        /// <summary>
        /// The current content/view that will be displayed to the user.
        /// </summary>
        // ReSharper disable once InconsistentNaming
        private ViewModelBase content;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindowViewModel"/> class.
        /// </summary>
        public MainWindowViewModel()
        {
            this.content = this.List = new TodosViewModel();
        }

        /// <summary>
        /// Gets property to expose the content to the UI and to notify the UI to changes.
        /// </summary>
        public ViewModelBase Content
        {
            get => this.content;

            // Reactively set the content if it changes
            private set => this.RaiseAndSetIfChanged(ref this.content, value);
        }

        /// <summary>
        /// Gets the viewmodel for the list of TodoItems.
        /// </summary>
        private TodosViewModel List { get; }

        /// <summary>
        /// Switches view to AddTodoView and adds TodoItems from that view.
        /// </summary>
        public void AddTodo()
        {
            var vm = new AddTodoViewModel();

            // Subscribe to the stream of outputs from both reactive commands (Ok and Cancel)
            vm.Ok.Merge(vm.Cancel.Select(_ => (TodoItem)null))
                .Take(1)
                .Subscribe(model =>
                {
                    // If the model outputted is not null, add it to the list of TodoItems
                    if (model != null)
                    {
                        this.List.TodoItems.Add(model);
                    }

                    // Display the list of Todos and hide the AddTodoView whenever Ok and Cancel are pressed
                    this.Content = this.List;
                });

            // Show the AddTodoView
            this.Content = vm;
        }
    }
}