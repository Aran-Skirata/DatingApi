namespace API.Helpers;

public class UserParams : PaginationParams
{

    public int MinAge { get; set; } = 18;
    public int MaxAge { get; set; } = 150;
    

    public string? CurrentUser { get; set; }
    public string? Gender { get; set; }

    public string? OrderBy { get; set; } = "lastActive";
}