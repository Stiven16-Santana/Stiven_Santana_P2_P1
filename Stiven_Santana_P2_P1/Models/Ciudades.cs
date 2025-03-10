using System.ComponentModel.DataAnnotations;

namespace Stiven_Santana_P2_P1.Models
{
    public class Ciudades
    {
        [Key]

        [Required(ErrorMessage ="Este campo es requerido")]
        public int Id { get; set; }

        [Required(ErrorMessage ="Este campo es requerido.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Este campo es requerido.")]
        public decimal Mpnto { get; set; }

    }
}
