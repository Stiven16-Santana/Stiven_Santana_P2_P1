using System.ComponentModel.DataAnnotations;

namespace Stiven_Santana_P2_P1.Models;

public class Encuestas
{
    [Key]
    public int Id { get; set; }

    [Required]
    public DateTime Fecha { get; set; } = DateTime.Now; // Valor por defecto

    [Required]
    [StringLength(100)]
    public string Asignatura { get; set; }

    [Required]
    public decimal Monto { get; set; }

    // Relación con Detalles
    public List<Ciudades> Detalles { get; set; } = new List<Ciudades>();
}
