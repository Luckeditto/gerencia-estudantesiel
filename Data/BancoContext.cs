using ControleDeEstudantes.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleDeEstudantes.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) :base(options)
        {
        }

        public DbSet<EstudanteModel> Estudantes { get; set; }

    }
}
