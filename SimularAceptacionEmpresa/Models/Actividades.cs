using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace SimularAceptacionEmpresa.Models;

public class Actividades
{
    [Key]
    public string ActividadId { get; set; }
    public string Nombre { get; set; }
    public int valoracion { get; set; } // Ej: 1-10
    [ForeignKey("Empresas")]
    public int EmpresaId { get; set; } // ID de la empresa a la que pertenece la actividad
}
