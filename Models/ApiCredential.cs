namespace Aegis.Gateway.Models;

public class ApiCredential
{
    public string Id { get; } = string.Empty;
    public string Key { get; set; } = string.Empty;
    public bool IsActive {get; set;}
    public string? Subject {get; set;}
}