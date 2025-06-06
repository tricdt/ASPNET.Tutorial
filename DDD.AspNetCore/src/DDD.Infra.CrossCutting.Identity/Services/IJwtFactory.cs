using System;
using System.Security.Claims;

namespace DDD.Infra.CrossCutting.Identity.Services;

public interface IJwtFactory
{
    Task<JwtToken> GenerateJwtToken(ClaimsIdentity claimsIdentity);
}
