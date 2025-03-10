using Microsoft.EntityFrameworkCore;

namespace Stiven_Santana_P2_P1.DAL
{
    public class Contexto: DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }

 
    }
}
