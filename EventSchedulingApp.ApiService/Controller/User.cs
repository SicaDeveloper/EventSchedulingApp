namespace EventSchedulingApp.ApiService.Controller;

public class User
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Username {get; set;}
    public required string Email { get; set; }
    public required string HashedPassword { get; set; }
    
    
}   