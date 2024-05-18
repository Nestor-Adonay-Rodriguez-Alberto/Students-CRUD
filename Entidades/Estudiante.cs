using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Estudiante
    {
        // ATRIBUTOS:

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_Estudiante { get; set; }

        [Required(ErrorMessage ="El Nombre Es Obligatorio.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage ="Nacimiento Obligatorio.")]
        public DateTime FechaNacimiento { get; set; }

        [Required(ErrorMessage = "Es Obligatorio.")]
        public string GradoAcademico { get; set; }

        [Required(ErrorMessage ="Ingrese La Direccion De Residencia.")]
        public string Direccion { get; set; }

        [Required(ErrorMessage ="Ingrese El Telefono.")]
        public string Telefono { get; set; }

        [Required(ErrorMessage ="Es Obligatorio El Email")]
        public string Gmail { get; set; }



        // Referencia Tabla Materia:
        [ForeignKey("Objeto_Materia")]
        public int IdMateriaEnEstudiante { get; set; }
        public virtual Materia Objeto_Materia {  get; set; }
    }
}
