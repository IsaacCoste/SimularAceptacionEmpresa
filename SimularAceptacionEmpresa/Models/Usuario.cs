using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimularAceptacionEmpresa.Models;
public class Usuario
{
    [Key]
    public int UsuarioId { get; set; }
    public string Nombre { get; set; }
    [ForeignKey("UsuarioId")]
    public ICollection<UsuariosDetalle> UsuariosDetalle { get; set; }
}
