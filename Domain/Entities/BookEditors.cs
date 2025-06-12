namespace Domain.Entities;

public class BookEditors
{
    public int Isbn { get; set; }
    public int EditorId { get; set; }

    // navigations

    public Books Book { get; set; }
    public Editors Editor { get; set; }
}
