using System;
using System.Collections.Generic;

class LibrarySystem
{
    static void Main(string[] args)
    {
        Library library = new Library();
        library.AddBook("The Great Gatsby");
        library.RegisterMember("JohnDoe", "John Doe");
        library.CheckoutBook("JohnDoe", "The Great Gatsby");
        library.DisplayMemberInformation("JohnDoe");
    }
}
