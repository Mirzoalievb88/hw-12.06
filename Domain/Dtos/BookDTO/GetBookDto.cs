namespace Domain.Dtos.BookDTO;

public class GetBookDto : CreateBookDto
{
    public int Isbn { get; set; }
}