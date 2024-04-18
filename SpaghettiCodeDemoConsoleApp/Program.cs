using System;
using System.Collections.Generic;

class ToDoApp
{
    static List<string> todos = new List<string>();
    static List<bool> completed = new List<bool>();
    static string command;
    static string todoItem;
    static int itemNumber;

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Choose an option: add, remove, mark, list, removeCompleted, exit");
            command = Console.ReadLine();

            if (command == "add")
            {
                Console.WriteLine("Enter the to-do item:");
                todoItem = Console.ReadLine();
                todos.Add(todoItem);
                completed.Add(false);
                Console.WriteLine("Item added.");
            }
            else if (command == "remove")
            {
                Console.WriteLine("Enter the item number to remove:");
                itemNumber = int.Parse(Console.ReadLine());

                if (itemNumber > 0 && itemNumber <= todos.Count)
                {
                    todos.RemoveAt(itemNumber - 1);
                    completed.RemoveAt(itemNumber - 1);
                    Console.WriteLine("Item removed.");
                }
                else
                {
                    Console.WriteLine("Invalid item number.");
                }
            }
            else if (command == "mark")
            {
                Console.WriteLine("Enter the item number to mark as completed:");
                itemNumber = int.Parse(Console.ReadLine());

                if (itemNumber > 0 && itemNumber <= todos.Count)
                {
                    completed[itemNumber - 1] = true;
                    Console.WriteLine("Item marked as completed.");
                }
                else
                {
                    Console.WriteLine("Invalid item number.");
                }
            }
            else if (command == "list")
            {
                Console.WriteLine("To-do list:");
                for (int i = 0; i < todos.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {(completed[i] ? "[Completed] " : "")}{todos[i]}");
                }
            }
            else if (command == "removeCompleted")
            {
                for (int i = todos.Count - 1; i >= 0; i--)
                {
                    if (completed[i])
                    {
                        todos.RemoveAt(i);
                        completed.RemoveAt(i);
                    }
                }
                Console.WriteLine("All completed items removed.");
            }
            else if (command == "exit")
            {
                break;
            }
            else
            {
                Console.WriteLine("Unknown command.");
            }
        }
    }
}
