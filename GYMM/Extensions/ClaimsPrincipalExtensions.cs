﻿using System.Linq;
using System.Security.Claims;

namespace GYMM.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static string ReteriveEmailFromPrincipal(this ClaimsPrincipal User)
        {
           return User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;
        }
    }
}
