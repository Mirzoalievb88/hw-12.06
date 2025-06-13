namespace Domain.Filters;

public class EditorFilter : ValidFilter
{
    public string? Title { get; set; }
    public int? MinPrice { get; set; }
    public int? MaxPrice { get; set; }
}