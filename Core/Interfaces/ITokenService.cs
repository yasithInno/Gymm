using GYMM.Core.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace GYMM.Core.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser appUser);
    }
}
