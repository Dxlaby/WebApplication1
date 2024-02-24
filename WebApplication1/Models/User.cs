namespace WebApplication1.Models;

public class User
{
    public string Name;
    public string Id;
    private string Password;

    public User(string name, string id, string password)
    {
        Name = name;
        Id = id;
        Password = password;
    }
}