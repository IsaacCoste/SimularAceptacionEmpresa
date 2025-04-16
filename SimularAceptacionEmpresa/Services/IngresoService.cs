using Microsoft.EntityFrameworkCore;
using SimularAceptacionEmpresa.DAL;
using SimularAceptacionEmpresa.Models;
using System.Linq.Expressions;

namespace SimularAceptacionEmpresa.Service
{
    public class IngresoService
    {
        private readonly Contexto _contexto;

        public IngresoService(Contexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<bool> Existe(int IngresoId)
        {
            return await _contexto.Ingresos.AnyAsync(i => i.IngresoId == IngresoId);
        }
        public async Task<bool> Existe(int IngresoId, string? Tipo)
        {
            return await _contexto.Ingresos.AnyAsync(i => i.IngresoId != IngresoId && i.Tipo.Equals(Tipo));
        }
        public async Task<bool> Insertar(Ingresos ingreso)
        {
            _contexto.Ingresos.Add(ingreso);
            return await _contexto.SaveChangesAsync() > 0;
        }

        public async Task<bool> Modificar(Ingresos ingreso)
        {
            var i = await _contexto.Ingresos.FindAsync(ingreso.IngresoId);
            _contexto.Entry(i!).State = EntityState.Detached;
            _contexto.Entry(ingreso).State = EntityState.Modified;
            return await _contexto.SaveChangesAsync() > 0;
        }

        public async Task<bool> Guardar(Ingresos ingreso)
        {
            if (!await Existe(ingreso.IngresoId))
                return await Insertar(ingreso);
            else
                return await Modificar(ingreso);
        }

        public async Task<bool> Eliminar(Ingresos ingreso)
        {
            var i = await _contexto.Ingresos.FindAsync(ingreso.IngresoId);
            _contexto.Entry(i!).State = EntityState.Detached;
            _contexto.Entry(ingreso).State = EntityState.Deleted;
            return await _contexto.SaveChangesAsync() > 0;
        }

        public async Task<Ingresos?> Buscar(int IngresoId)
        {
            return await _contexto.Ingresos
                .Where(i => i.IngresoId == IngresoId)
                .AsNoTracking()
                .SingleOrDefaultAsync();
        }

        public async Task<List<Ingresos>> Listar(Expression<Func<Ingresos, bool>> criterio)
        {
            return await _contexto.Ingresos
                .Where(criterio)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
