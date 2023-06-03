using System.Net;
using GhostProject.App.Core.Business.Users.Dto;
using GhostProject.App.Core.Common;
using GhostProject.App.Core.Interfaces;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace GhostProject.App.Infrastructure.Services;

public class GoogleRecaptchaServiceService : IGoogleRecaptchaService
{
    private readonly HttpClient _httpClient;
    private readonly RecaptchaSettings _recaptchaSettings;

    public GoogleRecaptchaServiceService(IOptions<RecaptchaSettings> recaptchaSettings, HttpClient httpClient)
    {
        _httpClient = httpClient;
        _recaptchaSettings = recaptchaSettings.Value ?? throw new ArgumentNullException(nameof(recaptchaSettings));
    }

    public async Task<RecaptchaDto?> GetResultAsync(string token, CancellationToken cancellationToken)
    {
        using var request = new HttpRequestMessage();
        request.Method = new HttpMethod("POST");
        request.RequestUri = new Uri($"?secret={_recaptchaSettings.SecretKey}&response={token}", UriKind.RelativeOrAbsolute);
        request.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));
        var response = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken);
        var result = await response.Content.ReadAsStringAsync(cancellationToken);
        return JsonConvert.DeserializeObject<RecaptchaDto>(result);
    }
}
