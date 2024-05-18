using Acceso_Datos;
using Entidades;


namespace Logica_Negocio
{
    public class MateriaBL
    {
        // Objetod De La DB:
        private readonly MateriaDAL _MateriaDAL;

        // Constructor:
        public MateriaBL(MateriaDAL materiaDAL)
        {
            _MateriaDAL = materiaDAL;
        }



        // ******* METODOS QUE MANDARAN OBJETOS A LAS VISTAS ********:

        // Manda Un Objeto Encontrado:
        public async Task<Materia> Obtener_PorId(Materia materia)
        {
            return await _MateriaDAL.Obtener_PorId(materia);
        }

        // Manda Todos Los Objetos De La Tabla:
        public async Task<List<Materia>> Obtener_Todos()
        {
            return await _MateriaDAL.Obtener_Todos();
        }

        // Manda Todos Los Objetos De Otra Tabla Para ViewData:
        public async Task<List<Profesor>> Lista_Profesores()
        {
            return await _MateriaDAL.Lista_Profesores();
        }




        // ******* METODOS QUE RECIBIRAN OBJETOS Y MODIFICARAN LA DB ********:

        // Recibe Un Objeto Y Lo Guarda En La Tabla:
        public async Task<int> Create(Materia materia)
        {
            return await _MateriaDAL.Create(materia);
        }

        // Recibe Un Objeto Lo Busca Y Lo Elimina De La Tabla:
        public async Task<int> Delete(Materia materia)
        {
            return await _MateriaDAL.Delete(materia);
        }

        // Recibe Un Objeto Lo Busca Y Lo Modifica
        public async Task<int> Edit(Materia materia)
        {
            return await _MateriaDAL.Edit(materia);
        }
    }
}
