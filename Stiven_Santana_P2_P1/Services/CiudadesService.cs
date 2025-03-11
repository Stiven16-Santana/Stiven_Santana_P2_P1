using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using Stiven_Santana_P2_P1.DAL;
using Stiven_Santana_P2_P1.Models;
using System.Linq.Expressions;
 

namespace Stiven_Santana_P2_P1.Service
{
    public class CiudadesService
    {
        private readonly IDbContextFactory<Contexto> DbFactory;

        public CiudadesService(IDbContextFactory<Contexto> dbFactory)
        {
            DbFactory = dbFactory;
        }

        public async Task<bool> Guardar(Encuestas ciudad)
        {
            if (!await Existe(ciudad.Id))
            {
                return await Insertar(ciudad);
            }
            else
            {
                return await Modificar(ciudad);
            }
        }

        private async Task<bool> Existe(int ciudadId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Ciudades.AnyAsync(c => c.Id == ciudadId);
        }

        private async Task<bool> Insertar(Encuestas ciudad)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            contexto.Ciudades.Add(ciudad);
            return await contexto.SaveChangesAsync() > 0;
        }

        private async Task<bool> Modificar(Encuestas ciudad)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            contexto.Update(ciudad);
            return await contexto.SaveChangesAsync() > 0;
        }

        public async Task<Encuestas?> Buscar(int ciudadId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Ciudades.FirstOrDefaultAsync(c => c.Id == ciudadId);
        }

        public async Task<bool> Eliminar(int ciudadId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Ciudades
                .Where(c => c.Id == ciudadId)
                .ExecuteDeleteAsync() > 0;
        }

        public async Task<List<Encuestas>> Listar(Expression<Func<Encuestas, bool>> criterio)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Ciudades.Where(criterio).AsNoTracking().ToListAsync();
        }

        // Método para obtener todas las ciudades sin filtro
        public async Task<List<Encuestas>> ObtenerTodasAsync()
        {
            return await Listar(c => true);
        }
    }
}
