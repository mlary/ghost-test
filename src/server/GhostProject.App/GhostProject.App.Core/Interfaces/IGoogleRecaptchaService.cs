using System.Threading;
using System.Threading.Tasks;
using GhostProject.App.Core.Business.Users.Dto;

namespace GhostProject.App.Core.Interfaces;

public interface IGoogleRecaptchaService
{
    public Task<RecaptchaDto> GetResultAsync(string token, CancellationToken cancellationToken);
}
