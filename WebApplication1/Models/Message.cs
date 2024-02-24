using WebApplication1.Controllers;

namespace WebApplication1.Models;

public class Message
{
    public string Text { get; set; }
    public string Name { get; set; }
    
    //public string UserId;

    public Message(string text, string name)
    {
        Text = text;
        Name = name;
    }

}