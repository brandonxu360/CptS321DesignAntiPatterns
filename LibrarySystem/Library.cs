
public class Library
{
    private List<Book> books = new List<Book>();
    private Dictionary<string, Member> members = new Dictionary<string, Member>();

    public void AddBook(string title)
    {
        books.Add(new Book(title));
        Console.WriteLine($"Book added: {title}");
    }

    public void RegisterMember(string username, string fullName)
    {
        members[username] = new Member(username, fullName);
        Console.WriteLine($"Member registered: {fullName}");
    }

    public void CheckoutBook(string username, string bookTitle)
    {
        if (!members.ContainsKey(username))
        {
            Console.WriteLine("Member does not exist.");
            return;
        }
        Book book = books.Find(b => b.Title == bookTitle);
        if (book == null)
        {
            Console.WriteLine("Book does not exist.");
            return;
        }

        members[username].CheckoutBook(book);
        Console.WriteLine($"{bookTitle} has been checked out to {members[username].FullName}.");
    }

    public void DisplayMemberInformation(string username)
    {
        if (members.ContainsKey(username))
        {
            members[username].DisplayInformation();
        }
        else
        {
            Console.WriteLine("Member does not exist.");
        }
    }
}