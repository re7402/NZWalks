﻿using Microsoft.AspNetCore.Identity;

namespace NZWalks.API.Repository
{
    public interface ITokenRepository
    {
        string CreateJwtToken(IdentityUser user,List<string> Roles);
    }
}
