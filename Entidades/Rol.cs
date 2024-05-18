using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Rol
    {
        // ATRIBUTOS:

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_Rol {  get; set; }

        [Required(ErrorMessage ="El Nombre Del Rol Es Obligatorio...")]
        public string Nombre { get; set; }


        // Profesor Asociada A Esta Clase
        public virtual List<Profesor> Lista_Profesores { get; set; }


        // Constructor:
        public Rol()
        {
            Lista_Profesores = new List<Profesor>();
        }
    }
}
