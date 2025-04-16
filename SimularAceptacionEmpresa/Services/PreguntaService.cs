namespace SimularAceptacionEmpresa.Services;

using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SimularAceptacionEmpresa.DAL;
using SimularAceptacionEmpresa.Models;

public class PreguntaService
{
    private readonly Contexto _contexto;

    public PreguntaService(Contexto contexto)
    {
        _contexto = contexto;
    }

    public async Task<bool> Existe(int preguntaId)
    {
        return await _contexto.Preguntas.AnyAsync(p => p.PreguntaId == preguntaId);
    }

    public async Task<bool> Existe(int preguntaId, string? texto)
    {
        return await _contexto.Preguntas.AnyAsync(p => p.PreguntaId != preguntaId && p.Texto == texto);
    }

    public async Task<bool> Insertar(Preguntas pregunta)
    {
        _contexto.Preguntas.Add(pregunta);
        return await _contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Modificar(Preguntas pregunta)
    {
        _contexto.Update(pregunta);
        var modifico = await _contexto.SaveChangesAsync() > 0;
        _contexto.Entry(pregunta).State = EntityState.Detached;
        return modifico;
    }

    public async Task<bool> Guardar(Preguntas pregunta)
    {
        if (!await Existe(pregunta.PreguntaId))
            return await Insertar(pregunta);
        else
            return await Modificar(pregunta);
    }

    public async Task<bool> Eliminar(Preguntas pregunta)
    {
        var existente = await _contexto.Preguntas.FindAsync(pregunta.PreguntaId);
        _contexto.Entry(existente!).State = EntityState.Detached;
        _contexto.Entry(pregunta).State = EntityState.Deleted;
        return await _contexto.SaveChangesAsync() > 0;
    }

    public async Task<Preguntas?> Buscar(int preguntaId)
    {
        return await _contexto.Preguntas
            .Include(p => p.PreguntasDetalle)
            .AsNoTracking()
            .SingleOrDefaultAsync(p => p.PreguntaId == preguntaId);
    }

    public async Task<List<Preguntas>> Listar(Expression<Func<Preguntas, bool>> criterio)
    {
        return await _contexto.Preguntas
            .Include(p => p.PreguntasDetalle)
            .Where(criterio)
            .AsNoTracking()
            .ToListAsync();
    }
}

