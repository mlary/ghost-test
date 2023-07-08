using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GhostProject.App.Core.Business.Users.Entities;
using GhostProject.App.Core.Business.Users.Interfaces;
using GhostProject.App.Core.Business.Users.Primitives;
using GhostProject.App.Core.Common;
using GhostProject.App.Core.Common.Abstractions.DataAccess;
using GhostProject.App.Core.Common.Handlers;
using GhostProject.App.Core.Exceptions;
using GhostProject.App.Core.Extensions;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace GhostProject.App.Core.Business.Users.Commands.Authenticate;

public class AuthenticateCommandHandler : HandlerBase<AuthenticateCommand, string>
{
    private readonly IUserRepository _userRepository;
    private readonly AuthConfiguration _authConfiguration;
    public AuthenticateCommandHandler(
        IUserRepository userRepository,
        IOptions<AuthConfiguration> authConfiguration,
        IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
    {
        _userRepository = userRepository;
        _authConfiguration = authConfiguration.Value ??
                             throw new NotImplementedException(typeof(AuthConfiguration).ToString());
    }

    public override async Task<string> Handle(AuthenticateCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.FirstAsync(new SpecificationBuilder<User>()
            .FilterBy(x => x.NormalizedEmail == request.Email.ToUpper()), cancellationToken);
        if (request.Password.ToHashPassword() != user.PasswordHash)
        {
            throw new UnauthorizedException();
        }

        return GenerateJsonWebToken(user);
    }

    private string GenerateJsonWebToken(User user)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authConfiguration.Secret));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(_authConfiguration.Issuer,
            _authConfiguration.Issuer,
            new[]
            {
                new Claim(ClaimTypes.Name, user.NormalizedEmail),
                new Claim(ClaimTypes.Role,
                    ((Roles)user.RoleId).ToString())
            },
            expires: DateTime.Now.AddDays(3),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
