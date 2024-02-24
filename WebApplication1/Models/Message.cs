using WebApplication1.Controllers;

namespace WebApplication1.Models;

public class Message
{
    public string Name;
    public string Text;
    //public string UserId;

    public Message(string text, string name)
    {
        Text = text;
        //UserId = userId;
        Name = name;
    }

}