using Microsoft.EntityFrameworkCore;
using SimularAceptacionEmpresa.DAL;
using SimularAceptacionEmpresa.Models;
using System.Linq.Expressions;

namespace SimularAceptacionEmpresa.Service
{
    public class RecursoService
    {
        private readonly Contexto _contexto;

        public RecursoService(Contexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<bool> Existe(int RecursoId)
        {
            return await _contexto.Recursos.AnyAsync(r => r.RecursoId == RecursoId);
        }

        public async Task<bool> Insertar(Recursos recurso)
        {
            _contexto.Recursos.Add(recurso);
            return await _contexto.SaveChangesAsync() > 0;
        }

        public async Task<bool> Modificar(Recursos recurso)
        {
            var r = await _contexto.Recursos.FindAsync(recurso.RecursoId);
            _contexto.Entry(r!).State = EntityState.Detached;
            _contexto.Entry(recurso).State = EntityState.Modified;
            return await _contexto.SaveChangesAsync() > 0;
        }

        public async Task<bool> Guardar(Recursos recurso)
        {
            if (!await Existe(recurso.RecursoId))
                return await Insertar(recurso);
            else
                return await Modificar(recurso);
        }

        public async Task<bool> Eliminar(Recursos recurso)
        {
            var r = await _contexto.Recursos.FindAsync(recurso.RecursoId);
            _contexto.Entry(r!).State = EntityState.Detached;
            _contexto.Entry(recurso).State = EntityState.Deleted;
            return await _contexto.SaveChangesAsync() > 0;
        }

        public async Task<Recursos?> Buscar(int RecursoId)
        {
            return await _contexto.Recursos
                .Where(r => r.RecursoId == RecursoId)
                .AsNoTracking()
                .SingleOrDefaultAsync();
        }

        public async Task<List<Recursos>> Listar(Expression<Func<Recursos, bool>> criterio)
        {
            return await _contexto.Recursos
                .Where(criterio)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
