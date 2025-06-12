namespace Domain.Entities;

public class Publishers
{
    public int PublisherId { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string State { get; set; }

    //navigations

    public ICollection<Books> Books { get; set; }
}