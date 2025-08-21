using ControleDeContatos.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
namespace ControleDeContatos.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions options) : base(options) { }
       
        public DbSet<ContatoModel> Contato { get; set; }
       

        protected BancoContext()
        {
        }
    }
}
