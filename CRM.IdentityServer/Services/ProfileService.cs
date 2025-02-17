﻿using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CRM.DAL.Models.DatabaseModels.Users;
using CRM.IdentityServer.Models;
using IdentityServer4.Models;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Identity;
using ClaimTypes = CRM.IdentityServer.Extensions.Constants.ClaimTypes;

namespace CRM.IdentityServer.Services
{
    public class ProfileService : IProfileService
    {
        private readonly UserManager<User> userManager;

        private readonly IdentityServerDbContext identityServerDbContext;

        public ProfileService(UserManager<User> userManager, IdentityServerDbContext identityServerDbContext)
        {
            this.userManager = userManager;
            this.identityServerDbContext = identityServerDbContext;
        }

        //ПРОСТАНОВКА ПОЛИТИК
        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var user = await userManager.GetUserAsync(context.Subject);

            if (user == null)
            {
                return;
            }

            var claims = new List<Claim>();
            
            claims.Add(new Claim(ClaimTypes.SecurityStamp, user.SecurityStamp));

            var roles = await userManager.GetRolesAsync(user);

            claims.AddRange(roles.Select(i => new Claim(System.Security.Claims.ClaimTypes.Role, i)));
            

                claims.Add(new Claim(System.Security.Claims.ClaimTypes.NameIdentifier,user.UserName));
            claims.Add(new Claim(ClaimTypes.UserId,user.Id));
            context.IssuedClaims = claims;
        }

        public async Task IsActiveAsync(IsActiveContext context)
        {
            var userId = context.Subject.Claims.FirstOrDefault(x => x.Type == "userId");

            if (!string.IsNullOrEmpty(userId?.Value))
            {
                var user = await userManager.FindByIdAsync(userId.Value);
                if (user != null)
                {
                    context.IsActive = true;
                }
            }
        }
    }
}