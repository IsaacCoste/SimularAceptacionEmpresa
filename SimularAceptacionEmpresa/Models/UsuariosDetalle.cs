using System.ComponentModel.DataAnnotations;

namespace SimularAceptacionEmpresa.Models;

public class UsuariosDetalle
{
    [Key]
    public int UsuarioDetalleId { get; set; }
    public int UsuarioId { get; set; }
    public Usuario Usuario { get; set; }
    public int PreguntaId { get; set; }
    public Preguntas Pregunta { get; set; }
    public int PreguntaDetalleId { get; set; }
    public PreguntasDetalle PreguntaDetalle { get; set; }
}
