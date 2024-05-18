using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades
{
    public class Profesor
    {

        // ATRIBUTOS:

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_Profesor { get; set; }


        [Required(ErrorMessage ="El Nombre Es Obligatorio")]
        public string Nombre { get; set; }


        [Required(ErrorMessage ="La Fecha Es Obligatoria.")]
        public DateTime FechaNacimiento { get; set; }


        [Required(ErrorMessage ="Es Obligatorio.")]
        public string GradoAcademico { get; set; }


        [Required(ErrorMessage ="El Telefono Es Obligatorio.")]
        public string Telefono { get; set; }


        [Required(ErrorMessage ="El Email Es Obligatorio.")]
        [DataType(DataType.EmailAddress)]
        public string Gmail { get; set; }


        [Required(ErrorMessage ="Ingrese El Sueldo.")]
        public double Sueldo { get; set; }


        [Required(ErrorMessage ="N° De Aula.")]
        public int Aula { get; set; }

        public byte[]? Fotografia { get; set; }


        // Materia Asociada A Esta Clase
        public virtual List<Materia> Lista_Materia { get; set; }



        // Referencia Tabla Rol:
        [ForeignKey("Objeto_Rol")]
        public int IdRolEnProfesor { get; set; }
        public virtual Rol Objeto_Rol { get; set; }


        // Constructor:
        public Profesor()
        {
            Lista_Materia = new List<Materia>();
        }
    }
}
