using Microsoft.EntityFrameworkCore;
using SimularAceptacionEmpresa.DAL;
using SimularAceptacionEmpresa.Models;
using System.Linq.Expressions;

namespace SimularAceptacionEmpresa.Service
{
    public class ActividadService
    {
        private readonly Contexto _contexto;

        public ActividadService(Contexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<bool> Existe(string ActividadId)
        {
            return await _contexto.Actividades.AnyAsync(a => a.ActividadId == ActividadId);
        }
        public async Task<bool> Existe(string ActividadId, string? Nombre)
        {
            return await _contexto.Actividades.AnyAsync(a => a.ActividadId != ActividadId && a.Nombre.Equals(Nombre));
        }

        public async Task<bool> Insertar(Actividades actividad)
        {
            _contexto.Actividades.Add(actividad);
            return await _contexto.SaveChangesAsync() > 0;
        }

        public async Task<bool> Modificar(Actividades actividad)
        {
            var a = await _contexto.Actividades.FindAsync(actividad.ActividadId);
            _contexto.Entry(a!).State = EntityState.Detached;
            _contexto.Entry(actividad).State = EntityState.Modified;
            return await _contexto.SaveChangesAsync() > 0;
        }

        public async Task<bool> Guardar(Actividades actividad)
        {
            if (!await Existe(actividad.ActividadId))
                return await Insertar(actividad);
            else
                return await Modificar(actividad);
        }

        public async Task<bool> Eliminar(Actividades actividad)
        {
            var a = await _contexto.Actividades.FindAsync(actividad.ActividadId);
            _contexto.Entry(a!).State = EntityState.Detached;
            _contexto.Entry(actividad).State = EntityState.Deleted;
            return await _contexto.SaveChangesAsync() > 0;
        }

        public async Task<Actividades?> Buscar(string ActividadId)
        {
            return await _contexto.Actividades
                .Where(a => a.ActividadId == ActividadId)
                .AsNoTracking()
                .SingleOrDefaultAsync();
        }

        public async Task<List<Actividades>> Listar(Expression<Func<Actividades, bool>> criterio)
        {
            return await _contexto.Actividades
                .Where(criterio)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
