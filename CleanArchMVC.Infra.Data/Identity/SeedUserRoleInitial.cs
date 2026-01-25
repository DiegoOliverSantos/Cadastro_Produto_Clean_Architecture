using CleanArchMVC.Domain.Account;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMVC.Infra.Data.Identity
{
    public class SeedUserRoleInitial : ISeedUserRoleInitial
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public SeedUserRoleInitial(UserManager<ApplicationUser> userManager, 
                                   RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public void SeedRole()
        {
            if (!_roleManager.RoleExistsAsync("User").Result)
            {
                IdentityRole role = new IdentityRole()
                {
                    Name = "User",
                    NormalizedName = "USER"
                };
                IdentityResult result = _roleManager.CreateAsync(role).Result;
            }
            if (!_roleManager.RoleExistsAsync("Admin").Result)
            {
                IdentityRole role = new IdentityRole()
                {
                    Name = "Admin",
                    NormalizedName = "Admin"
                };
                IdentityResult result = _roleManager.CreateAsync(role).Result;
            }
        }

        public void SeedUser()
        {
            if(_userManager.FindByEmailAsync("usuario@localhost").Result == null)
            {
                ApplicationUser user = new ApplicationUser
                {
                    UserName = "usuario@localhost",
                    Email = "usuario@localhost",
                    NormalizedEmail = "USUARIO@LOCALHOST",
                    NormalizedUserName = "USUARIO@LOCALHOST",
                    EmailConfirmed = true,
                    LockoutEnabled = false,
                    SecurityStamp = Guid.NewGuid().ToString(),
                };

                IdentityResult result = _userManager.CreateAsync(user, "NumSey#2021").Result;

                if (result.Succeeded)
                    _userManager.AddToRoleAsync(user, "User").Wait();
                {
                    
                }

            }

            if (_userManager.FindByEmailAsync("admin@localhost").Result == null)
            {
                ApplicationUser admin = new ApplicationUser
                {
                    UserName = "admin@localhost",
                    Email = "admin@localhost",
                    NormalizedEmail = "ADMIN@LOCALHOST",
                    NormalizedUserName = "ADMIN@LOCALHOST",
                    EmailConfirmed = true,
                    LockoutEnabled = false,
                    SecurityStamp = Guid.NewGuid().ToString(),
                };

                IdentityResult result = _userManager.CreateAsync(admin, "NumSey#2021").Result;

                if (result.Succeeded)
                    _userManager.AddToRoleAsync(admin, "Admin").Wait();
                {

                }

            }
        }
    }
}
