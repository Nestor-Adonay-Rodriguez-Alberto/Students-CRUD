using Acceso_Datos;
using Entidades;


namespace Logica_Negocio
{
    public class EstudianteBL
    {
        // Objeto De La DB:
        private readonly EstudianteDAL _EstudianteDAL;

        // Constructor:
        public EstudianteBL(EstudianteDAL estudianteDAL)
        {
            _EstudianteDAL = estudianteDAL;
        }



        // ******* METODOS QUE MANDARAN OBJETOS A LAS VISTAS ********:

        // Manda Un Objeto Encontrado:
        public async Task<Estudiante> Obtener_PorId(Estudiante estudiante)
        {
            return await _EstudianteDAL.Obtener_PorId(estudiante);
        }

        // Manda Todos Los Objetos De La Tabla:
        public async Task<List<Estudiante>> Obtener_Todos()
        {
            return await _EstudianteDAL.Obtener_Todos();
        }

        // Manda Todos Los Objetos De Otra Tabla Para ViewData:
        public async Task<List<Materia>> Lista_Materias()
        {
            return await _EstudianteDAL.Lista_Materias();
        }




        // ******* METODOS QUE RECIBIRAN OBJETOS Y MODIFICARAN LA DB ********:

        // Recibe Un Objeto Y Lo Guarda En La Tabla:
        public async Task<int> Create(Estudiante estudiante)
        {
            return await _EstudianteDAL.Create(estudiante);
        }

        // Recibe Un Objeto Lo Busca Y Lo Elimina De La Tabla:
        public async Task<int> Delete(Estudiante estudiante)
        {
            return await _EstudianteDAL.Delete(estudiante);
        }

        // Recibe Un Objeto Lo Busca Y Lo Modifica
        public async Task<int> Edit(Estudiante estudiante)
        {
            return await _EstudianteDAL.Edit(estudiante);
        }
    }
}
