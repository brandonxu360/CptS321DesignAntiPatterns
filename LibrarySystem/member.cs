using System;
using System.Collections.Generic;

public class Member
{
    public string Username { get; private set; }
    public string FullName { get; private set; }
    private List<Book> checkedOutBooks = new List<Book>();

    public Member(string username, string fullName)
    {
        Username = username;
        FullName = fullName;
    }

    public void CheckoutBook(Book book)
    {
        checkedOutBooks.Add(book);
    }

    public void DisplayInformation()
    {
        Console.WriteLine($"Member: {FullName}");
        if (checkedOutBooks.Count > 0)
        {
            Console.WriteLine("Checked out books:");
            foreach (var book in checkedOutBooks)
            {
                Console.WriteLine($"- {book.Title}");
            }
        }
        else
        {
            Console.WriteLine("No books checked out.");
        }
    }
}