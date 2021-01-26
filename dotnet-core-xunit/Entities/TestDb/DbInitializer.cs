using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static dotnet_core_xunit.Dtos.UserDto;

namespace dotnet_core_xunit.Entities.TestDb
{
    public static class DataSeeder
    {
        public static void SeedData(this IApplicationBuilder app)
        {
            using (IServiceScope serviceScope = app.ApplicationServices.CreateScope())
            {
                var db = serviceScope.ServiceProvider.GetService<TestDbContext>();

                db.Users.AddRange(new Users[]
                {
                    new Users() {Id = 1, FullName = "Barış Ateş", Email = "info@barisates.com", Password = "123", CreateDate = DateTime.Now, LastLogin = DateTime.Now, Status = true },
                    new Users() {Id = 2, FullName = "Kemal Akçıl", Email = "me@kemalakcil.com", Password = "123", CreateDate = DateTime.Now, LastLogin = DateTime.Now, Status = true },
                });

                db.SaveChanges();
            }
        }
    }
}
