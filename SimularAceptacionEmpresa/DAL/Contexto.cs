using Microsoft.EntityFrameworkCore;
using SimularAceptacionEmpresa.Models;

namespace SimularAceptacionEmpresa.DAL;
public class Contexto : DbContext
{
    public DbSet<Preguntas> Preguntas { get; set; }
    public DbSet<Ingresos> Ingresos { get; set; }
    public DbSet<Recursos> Recursos { get; set; }
    public DbSet<Actividades> Actividades { get; set; }
    public Contexto(DbContextOptions<Contexto> options) : base(options)
    {
    }
}
