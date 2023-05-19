namespace GhostProject.App.Core.Models;

public class EmailRequest
{
    public string Body { get; set; }
    
    public  string Subject { get; set; }
    
    public string[] Addresses { get; set; }
}
