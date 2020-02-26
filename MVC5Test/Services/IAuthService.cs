using MVC5Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace MVC5Test.Services
{
    public interface IAuthService
    {
         string SecretKey { get; set; }

        bool IsTokenValid(string token);
        string GenerateToken(IAuthenticationContainerModel model);

        IEnumerable<Claim> GetTokenClaims(string token);

    }
}