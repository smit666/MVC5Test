using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace MVC5Test.Models
{
    public class JWTContainerModel : IAuthenticationContainerModel
    {
        public string SecretKey { get; set; } = "sfsdsdgsdvxsvgvfdgdfgfdgdfffgfdgfg==";
        public string SecurityAlgorithm { get; set; } = SecurityAlgorithms.HmacSha256Signature;
        public int ExpireMinutes { get ; set ; } = 1;
        public Claim[] Claims { get; set; }

        public static JWTContainerModel GetJWTContainerModel(string name,string email)
        {
            return new JWTContainerModel()
            {
                Claims = new Claim[]
                {
                    new Claim(ClaimTypes.Name,name),
                    new Claim(ClaimTypes.Email,email)
                }
            };
        }
    }
}