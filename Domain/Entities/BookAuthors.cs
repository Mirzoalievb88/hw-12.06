namespace Domain.Entities;

public class BookAuthors
{
    public int Isbn { get; set; }
    public int AuthorId { get; set; }
    public int AuthorOrder { get; set; }
    public decimal Royaltyshare { get; set; }

    //navigations
    public Books Book { get; set; }
    public Authors Author { get; set; }
}