using Microsoft.EntityFrameworkCore;
using SimularAceptacionEmpresa.DAL;
using SimularAceptacionEmpresa.Models;
using System.Linq.Expressions;

namespace SimularAceptacionEmpresa.Service
{
    public class EmpresaService
    {
        private readonly Contexto _contexto;

        public EmpresaService(Contexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<bool> Existe(int EmpresaId, string? Nombre)
        {
            return await _contexto.Empresas.AnyAsync(e => e.EmpresaId != EmpresaId && e.Nombre.Equals(Nombre));
        }
        public async Task<bool> Existe(int EmpresaId)
        {
            return await _contexto.Empresas.AnyAsync(e => e.EmpresaId == EmpresaId);
        }

        public async Task<bool> Insertar(Empresas empresa)
        {
            _contexto.Empresas.Add(empresa);
            return await _contexto.SaveChangesAsync() > 0;
        }

        public async Task<bool> Modificar(Empresas empresa)
        {
            var e = await _contexto.Empresas.FindAsync(empresa.EmpresaId);
            _contexto.Entry(e!).State = EntityState.Detached;
            _contexto.Entry(empresa).State = EntityState.Modified;
            return await _contexto.SaveChangesAsync() > 0;
        }

        public async Task<bool> Guardar(Empresas empresa)
        {
            if (!await Existe(empresa.EmpresaId))
                return await Insertar(empresa);
            else
                return await Modificar(empresa);
        }

        public async Task<bool> Eliminar(Empresas empresa)
        {
            var e = await _contexto.Empresas.FindAsync(empresa.EmpresaId);
            _contexto.Entry(e!).State = EntityState.Detached;
            _contexto.Entry(empresa).State = EntityState.Deleted;
            return await _contexto.SaveChangesAsync() > 0;
        }

        public async Task<Empresas?> Buscar(int EmpresaId)
        {
            return await _contexto.Empresas
                .Where(e => e.EmpresaId == EmpresaId)
                .AsNoTracking()
                .SingleOrDefaultAsync();
        }

        public async Task<List<Empresas>> Listar(Expression<Func<Empresas, bool>> criterio)
        {
            return await _contexto.Empresas
                .Where(criterio)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
