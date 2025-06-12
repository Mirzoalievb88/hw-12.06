namespace Domain.Entities;

public class Books
{
    public string Isbn { get; set; }
    public string Title { get; set; }
    public string Type { get; set; }
    public int PublisherId { get; set; }
    public decimal Price { get; set; }
    public decimal Advance { get; set; }
    public int Ytdsales { get; set; }
    public DateTime PubDate { get; set; }

    //navigations

    public Publishers Publisher { get; set; }
    public ICollection<BookAuthors> BookAuthors { get; set; }
    public ICollection<BookEditors> BookEditors { get; set; }
}