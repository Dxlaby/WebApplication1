using System.Diagnostics;
using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using System.Text.Json;
 

namespace WebApplication1.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        var messages = GetMessages();
        return View(messages);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    public List<Message> GetMessages()
    {
        string jsonChat = System.IO.File.ReadAllText(@"Database/Chat.json");
        var list = JsonSerializer.Deserialize<List<Message>>(jsonChat);

        return list;
    }
        
    [HttpPost]
    [ActionName("AddMessage")]
    public IActionResult AddMessage(string Name, string Text)
    {
        var message = new Message(Text, Name);

        string jsonChat = System.IO.File.ReadAllText(@"Database/Chat.json");
        var list = JsonSerializer.Deserialize<List<Message>>(jsonChat);
        list.Reverse();
        list.Add(message);
        list.Reverse();
        var convertedJson = JsonSerializer.Serialize<IEnumerable<Message>>(list);
        System.IO.File.WriteAllText(@"Database/Chat.json", convertedJson);
        return Redirect("/");
    }
    
    public string GetNameById(string id)
    {
        return id;
    }
    
}
