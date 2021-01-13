using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using lojaCet500.Dados.Entidades;

namespace lojaCet500.Data
{
    public class lojaCet500Context : DbContext
    {
        public lojaCet500Context (DbContextOptions<lojaCet500Context> options)
            : base(options)
        {
        }

        public DbSet<lojaCet500.Dados.Entidades.Produto> Produto { get; set; }

        public DbSet<lojaCet500.Dados.Entidades.Cliente> Cliente { get; set; }
    }
}
