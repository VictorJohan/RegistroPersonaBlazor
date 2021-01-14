using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RegistroPersonaBlazor.Models
{
    public class Personas
    {
        [Key]
        public int PersonaId { get; set; }
        [Required(ErrorMessage ="Es obligatorio introducir un nombre.")]
        public string Nombres { get; set; }
        [Range(minimum:10, maximum:10, ErrorMessage = "Número telefónico no válido.")]
        public string Telefono { get; set; }
        [Range(minimum:8, maximum:8, ErrorMessage = "Cédula no válida")]
        public string Cedula { get; set; }
        public string Direccion { get; set; }
        public DateTime FechaNacimiento { get; set; } = DateTime.Now;


    }
}
