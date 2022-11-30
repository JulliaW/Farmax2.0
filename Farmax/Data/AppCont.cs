using Farmax.Models;
using Microsoft.EntityFrameworkCore;

namespace Farmax.Data
{
    public class AppCont : DbContext
    {
        public AppCont(DbContextOptions<AppCont> options) : base(options)
        {

        }

        public DbSet<Produto> produtos { get; set; }
        public DbSet<Fornecedor> fornecedores { get; set; }
        public DbSet<Usuario> usuarios { get; set; }
    }
}
