using CalendarAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarAPI.BD
{
    public class UserDB : DbContext
    {

        public UserDB(DbContextOptions<UserDB> options) : base(options)
        {
        }
        public DbSet<User> users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<User>()
                .HasData(new User
                {
                    username = "root",
                    password = "root",
                    dateCreated = DateTime.Now,
                    email = "root"

                }
              );
        }
    }
}
