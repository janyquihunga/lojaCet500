using lojaCet500.Dados.Entidades;
using Microsoft.EntityFrameworkCore;

namespace lojaCet500.Dados
{
    public class DataContext : DbContext
    {

        public DbSet<Produto> Produtos { get; set; }


        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

    }
}
