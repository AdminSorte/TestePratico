using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static CalendarAPI.Models.CalendarModel;

namespace CalendarAPI.BD
{
    public class CalendarDB : DbContext
    {
        public CalendarDB(DbContextOptions<CalendarDB> options) : base(options)
        {
        }
        public DbSet<Calendar> calendar { get; set; }

        public DbSet<Events> events { get; set; }

        public DbSet<EventsShare> eventsShare { get; set; }


    }
}
