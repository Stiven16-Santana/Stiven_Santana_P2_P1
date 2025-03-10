using Microsoft.EntityFrameworkCore;
using Stiven_Santana_P2_P1.Models;

namespace Stiven_Santana_P2_P1.DAL
{
    public class Contexto: DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }

        public DbSet<Ciudades> Ciudades { get; set; }
    }
}
