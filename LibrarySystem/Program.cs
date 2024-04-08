using System;
using System.Collections.Generic;

class LibrarySystem
{
    private static List<string> books = new List<string>();
    private static Dictionary<string, string> members = new Dictionary<string, string>();
    private static Dictionary<string, List<string>> checkedOutBooks = new Dictionary<string, List<string>>();

    static void Main(string[] args)
    {
        AddBook("The Great Gatsby");
        RegisterMember("JohnDoe", "John Doe");
        CheckoutBook("JohnDoe", "The Great Gatsby");
        DisplayMemberInformation("JohnDoe");
    }

    static void AddBook(string title)
    {
        books.Add(title);
        Console.WriteLine($"Book added: {title}");
    }

    static void RegisterMember(string username, string fullName)
    {
        members[username] = fullName;
        Console.WriteLine($"Member registered: {fullName}");
    }

    static void CheckoutBook(string username, string bookTitle)
    {
        if (!members.ContainsKey(username))
        {
            Console.WriteLine("Member does not exist.");
            return;
        }
        if (!books.Contains(bookTitle))
        {
            Console.WriteLine("Book does not exist.");
            return;
        }

        if (!checkedOutBooks.ContainsKey(username))
        {
            checkedOutBooks[username] = new List<string>();
        }

        checkedOutBooks[username].Add(bookTitle);
        Console.WriteLine($"{bookTitle} has been checked out to {members[username]}.");
    }

    static void DisplayMemberInformation(string username)
    {
        if (!members.ContainsKey(username))
        {
            Console.WriteLine("Member does not exist.");
            return;
        }

        Console.WriteLine($"Member: {members[username]}");
        if (checkedOutBooks.ContainsKey(username) && checkedOutBooks[username].Count > 0)
        {
            Console.WriteLine("Checked out books:");
            foreach (var book in checkedOutBooks[username])
            {
                Console.WriteLine($"- {book}");
            }
        }
        else
        {
            Console.WriteLine("No books checked out.");
        }
    }
}
