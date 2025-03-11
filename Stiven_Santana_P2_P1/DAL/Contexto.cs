using Microsoft.EntityFrameworkCore;
using Stiven_Santana_P2_P1.Models;

namespace Stiven_Santana_P2_P1.DAL
{
    public class Contexto: DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }

        public DbSet<Encuestas> Ciudades { get; set; }
        public DbSet<Ciudades> DetalleCiudades { get; set; }

    }
}
