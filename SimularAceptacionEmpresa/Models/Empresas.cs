using System.ComponentModel.DataAnnotations;
namespace SimularAceptacionEmpresa.Models;
public class Empresas
{
    [Key]
    public int EmpresaId { get; set; }
    public string Nombre { get; set; }
}
