namespace Domain.Dtos.BookDTO;

public class CreateBookDto
{
    public string Title { get; set; }
    public string Type { get; set; }
    public int PublisherId { get; set; }
    public decimal Price { get; set; }
    public decimal Advance { get; set; }
    public DateTime PubDate { get; set; }
}