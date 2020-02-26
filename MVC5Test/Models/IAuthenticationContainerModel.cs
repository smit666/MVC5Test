using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace MVC5Test.Models
{
    public interface IAuthenticationContainerModel
    {
         string SecretKey { get; set; }
         string SecurityAlgorithm { get; set; }
         int ExpireMinutes { get; set; }
        Claim[] Claims { get; set; }
    }
}