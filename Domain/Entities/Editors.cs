namespace Domain.Entities;

public class Editors
{
    public int EditorId { get; set; }
    public string SSN { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public string EditorPosition { get; set; }
    public decimal Salary { get; set; }

    //navigations

    public ICollection<BookEditors> BookEditors { get; set; }
}