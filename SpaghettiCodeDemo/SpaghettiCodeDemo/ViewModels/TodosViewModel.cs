// <copyright file="TodosViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SpaghettiCodeDemo.ViewModels
{
    using System.Collections.ObjectModel;
    using SpaghettiCodeDemo.Models;

    /// <summary>
    /// Viewmodel to hold/prepare the data related to the list of _todo items.
    /// </summary>
    public class TodosViewModel : ViewModelBase
    {
        /// <summary>
        /// Gets the observable list of TodoItems, initially empty.
        /// </summary>
        public ObservableCollection<TodoItem> Items { get; } = [];
    }
}