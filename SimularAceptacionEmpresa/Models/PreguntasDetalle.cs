using System.ComponentModel.DataAnnotations;

namespace SimularAceptacionEmpresa.Models;

public class PreguntasDetalle
{
    [Key]
    public int PreguntaDetalleId { get; set; }
    public int PreguntaId { get; set; } // ID de la pregunta a la que pertenece el detalle
    public string Respuesta { get; set; } // Ej: "Muy satisfecho", "Satisfecho", etc.
    public int Valoracion { get; set; } // Ej: 1-10
}
