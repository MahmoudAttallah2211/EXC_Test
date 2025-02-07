﻿using EntityLayer.Identity.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using RepositoryLayer.context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.Identity
{
    public  static class IdentityExtension
    {
        public static IServiceCollection LoadIdentityExtensions (this IServiceCollection services)
        {

            services.AddIdentity<AppUser, AppRole>(opt =>
            {
                opt.Password.RequiredLength = 10;
                opt.Password.RequireNonAlphanumeric = true;
                opt.Password.RequiredUniqueChars = 2;
                opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(3);
                opt.Lockout.MaxFailedAccessAttempts = 3;


            }).AddRoleManager<RoleManager<AppRole>>()
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();


            services.ConfigureApplicationCookie(opt =>
                {

                    opt.LoginPath = new PathString ("/Authentication/LogIn");
                    opt.LogoutPath = new PathString ("/Authentication/LogOut");
                    opt.AccessDeniedPath = new PathString ("/Authentication/AccessDenied");
                    opt.ExpireTimeSpan = TimeSpan.FromMinutes(60);
                });
                
            return services;
        }
    }
}
