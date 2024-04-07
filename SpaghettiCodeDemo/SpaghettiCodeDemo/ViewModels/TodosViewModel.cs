// <copyright file="TodosViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SpaghettiCodeDemo.ViewModels
{
    using System.Collections.Generic;
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
        public ObservableCollection<TodoItem> TodoItems { get; } = [];

        /// <summary>
        /// Removes all the completed Todos
        /// </summary>
        public void ClearCompletedTodos()
        {
            // Create a list to hold items to remove
            var itemsToRemove = new List<TodoItem>();

            // Iterate over TodoItems
            foreach (var todoItem in this.TodoItems)
            {
                if (todoItem.IsChecked)
                {
                    // Add completed items to the removal list
                    itemsToRemove.Add(todoItem);
                }
            }

            // Remove completed items from TodoItems
            foreach (var itemToRemove in itemsToRemove)
            {
                this.TodoItems.Remove(itemToRemove);
            }
        }
    }
}