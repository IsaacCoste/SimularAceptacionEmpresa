using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace SimularAceptacionEmpresa.Models;
public class Preguntas
{
    [Key]
    public int PreguntaId { get; set; }
    public string Texto { get; set; } // Ej: ¿Qué tan satisfecho estás con el servicio?

    [ForeignKey("PreguntaId")]
    public ICollection<PreguntasDetalle> PreguntasDetalle { get; set; } = new List<PreguntasDetalle>();
}
