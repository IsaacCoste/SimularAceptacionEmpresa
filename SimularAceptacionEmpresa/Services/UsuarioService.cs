using Microsoft.EntityFrameworkCore;
using SimularAceptacionEmpresa.DAL;
using SimularAceptacionEmpresa.Models;
using System.Linq.Expressions;

namespace SimularAceptacionEmpresa.Services;

public class UsuarioService
{
    private readonly Contexto _contexto;

    public UsuarioService(Contexto contexto)
    {
        _contexto = contexto;
    }

    public async Task<bool> Existe(int usuarioId)
    {
        return await _contexto.Usuarios.AnyAsync(u => u.UsuarioId == usuarioId);
    }

    public async Task<bool> Existe(int usuarioId, string? nombre)
    {
        return await _contexto.Usuarios.AnyAsync(u => u.UsuarioId != usuarioId && u.Nombre == nombre);
    }

    public async Task<bool> Insertar(Usuario usuario)
    {
        _contexto.Usuarios.Add(usuario);
        return await _contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Modificar(Usuario usuario)
    {
        _contexto.Update(usuario);
        var modifico = await _contexto.SaveChangesAsync() > 0;
        _contexto.Entry(usuario).State = EntityState.Detached;
        return modifico;
    }

    public async Task<bool> Guardar(Usuario usuario)
    {
        if (!await Existe(usuario.UsuarioId))
            return await Insertar(usuario);
        else
            return await Modificar(usuario);
    }

    public async Task<bool> Eliminar(Usuario usuario)
    {
        var existente = await _contexto.Usuarios.FindAsync(usuario.UsuarioId);
        _contexto.Entry(existente!).State = EntityState.Detached;
        _contexto.Entry(usuario).State = EntityState.Deleted;
        return await _contexto.SaveChangesAsync() > 0;
    }

    public async Task<Usuario?> Buscar(int usuarioId)
    {
        return await _contexto.Usuarios
            .Include(u => u.UsuariosDetalle)
                .ThenInclude(ud => ud.Pregunta)
            .Include(u => u.UsuariosDetalle)
                .ThenInclude(ud => ud.PreguntaDetalle)
            .AsNoTracking()
            .SingleOrDefaultAsync(u => u.UsuarioId == usuarioId);
    }

    public async Task<List<Usuario>> Listar(Expression<Func<Usuario, bool>> criterio)
    {
        return await _contexto.Usuarios
            .Include(u => u.UsuariosDetalle)
                .ThenInclude(ud => ud.PreguntaDetalle)
            .Where(criterio)
            .ToListAsync();
    }

}
