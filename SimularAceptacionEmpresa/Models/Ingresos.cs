using System.ComponentModel.DataAnnotations;
namespace SimularAceptacionEmpresa.Models;
public class Ingresos
{
    [Key]
    public int IngresoId { get; set; }
    public string Tipo { get; set; } // Ej: Ventas, Despacho, Publicidad
}
