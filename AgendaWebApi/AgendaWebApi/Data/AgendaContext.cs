using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgendaWebApi.Models;


namespace AgendaWebApi.Data
{
    public class AgendaContext : DbContext
    {
        public AgendaContext(DbContextOptions<AgendaContext> opt) : base (opt)
        {


        }

        public DbSet<Evento> Eventos { get; set; }



    }
}
