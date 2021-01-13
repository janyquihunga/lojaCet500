using lojaCet500.Dados.Entidades;
using Microsoft.EntityFrameworkCore;

namespace lojaCet500.Dados
{
    public class DataContext : DbContext
    {

        public DbSet<Produto> Produto { get; set; }

        public DbSet<Cliente> Cliente { get; set; }
        public object Products { get; internal set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

    }
}
