namespace Aegis.Gateway.Models;

public class AuthResult
{
    public bool IsValid {get; set;}
    public string ErrorMessage {get; set;} = string.Empty;
    public string? Subject {get; set;}
}