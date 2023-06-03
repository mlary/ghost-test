using Newtonsoft.Json;

namespace GhostProject.App.Core.Business.Users.Dto;

public class RecaptchaDto
{
    public bool Success { get; set; }

    [JsonProperty("error-codes")]
    public string[] ErrorCodes { get; set; }
}
