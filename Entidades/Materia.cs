using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades
{
    public class Materia
    {
        // ATRIBUTOS:

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_Materia { get; set; }


        [Required(ErrorMessage ="El Nombre Es Obligatorio.")]
        public string Nombre { get; set; }


        [Required(ErrorMessage ="Debe Ingresar El Horario.")]
        [StringLength(8,MinimumLength = 8,ErrorMessage ="Ejemplo De Horario: 00:00 am")]
        public string Horario { get; set; }

        // Estudiante Asociada A Esta Clase
        public virtual List<Estudiante> Lista_Estudiantes {  get; set; }


        // Referencia Tabla Profesor:
        [ForeignKey("Objeto_Profesor")]
        public int IdProfesorEnMateria { get; set; }
        public virtual Profesor Objeto_Profesor {  get; set; }


        // Constructor:
        public Materia()
        {
            Lista_Estudiantes = new List<Estudiante>();
        }
    }
}
