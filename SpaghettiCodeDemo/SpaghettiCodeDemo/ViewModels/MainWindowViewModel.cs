// <copyright file="MainWindowViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SpaghettiCodeDemo.ViewModels
{
    using ReactiveUI;

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
            this.content = this.Todos = new TodosViewModel();
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
        /// Gets the view model holding the list of Todos.
        /// </summary>
        public TodosViewModel Todos { get; }
    }
}