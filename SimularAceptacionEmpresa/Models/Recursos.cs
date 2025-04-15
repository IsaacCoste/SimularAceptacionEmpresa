using System.ComponentModel.DataAnnotations;
namespace SimularAceptacionEmpresa.Models;
public class Recursos
{
    [Key]
    public int RecursoId { get; set; }
    public string Nombre { get; set; }
}
