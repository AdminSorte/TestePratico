using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace TestePratico.DAL.Context
{
    public class TestePraticoContext : DbContext
    {
        private DbConnection _objCn;

        public TestePraticoContext()
            : this("TestePraticoContext")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

        public TestePraticoContext(string connectionString)
        {
            var cn = ConfigurationManager.ConnectionStrings[connectionString];
            _objCn = DbProviderFactories.GetFactory(cn.ProviderName).CreateConnection();
            _objCn.ConnectionString = cn.ConnectionString;
        }

        public TestePraticoContext(DbConnection connection)
            : base(connection, true)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelbuilder)
        {
            modelbuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet<Model.Entity.Agenda> Agendas { get; set; }
    }
}
