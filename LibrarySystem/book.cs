using System;
using System.Collections.Generic;

public class Book
{
    public string Title { get; private set; }

    public Book(string title)
    {
        Title = title;
    }
}