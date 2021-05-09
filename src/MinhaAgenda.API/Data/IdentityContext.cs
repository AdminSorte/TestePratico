using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhaAgenda.API.Data
{
    public class IdentityContext : IdentityDbContext
    {
       
        public IdentityContext(DbContextOptions<IdentityContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            base.OnModelCreating(modelBuilder);
            this.Inserir(modelBuilder);


        }

        private void Inserir(ModelBuilder builder)
        {
            var hasher = new PasswordHasher<IdentityUser>();
            builder.Entity<IdentityUser>().HasData(
                new IdentityUser
                {
                    Id = "496ea12b-af65-45c3-9cf8-e0c33a52c386",
                    Email = "SorteOnline@gmail.com",
                    NormalizedEmail = "SORTEONLINE@GMAIL.COM",
                    UserName = "SorteOnline@gmail.com",
                    NormalizedUserName = "SORTEONLINE@GMAIL.COM",
                    PhoneNumber = "+111111111111",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString("D"),
                    PasswordHash = hasher.HashPassword(null, "Sorte123")

                });

            
        }

    }
}
