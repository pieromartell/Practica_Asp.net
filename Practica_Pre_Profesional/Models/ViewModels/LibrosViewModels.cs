using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace Practica_Pre_Profesional.Models.ViewModels
{
    public class LibrosViewModels
    {
        [Required]
        public int? IdLibro { get; set; }

        [Required]
        public string Descripcion { get; set; }

        [Required]
        public string IdAsing { get; set; }
        [Required]
        public int stock { get; set; }

    }
}
