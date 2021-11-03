using Microsoft.EntityFrameworkCore;

namespace TestePratico.Models
{
  public class DataContext : DbContext
  {
    public DataContext (DbContextOptions<DataContext> options)
        : base (options)
    {
    }

    public DbSet<AgendaModel> AgendaModels { get;set; }
  }
}