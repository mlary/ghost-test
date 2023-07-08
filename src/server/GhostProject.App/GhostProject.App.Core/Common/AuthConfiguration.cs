namespace GhostProject.App.Core.Common;

public class AuthConfiguration
{
    public string Domain { get; set; }
    public string SearchBase { get; set; }
    public string Secret { get; set; }
    public string Issuer { get; set; }
    public string SystemUserLogin { get; set; }
    public string SystemUserPassword { get; set; }
}
