using Acceso_Datos;
using Entidades;


namespace Logica_Negocio
{
    public class ProfesorBL
    {
        // Objetod De La DB:
        private readonly ProfesorDAL _ProfesorDAL;

        // Constructor:
        public ProfesorBL(ProfesorDAL profesorDAL)
        {
            _ProfesorDAL = profesorDAL;
        }



        // ******* METODOS QUE MANDARAN OBJETOS A LAS VISTAS ********:

        // Manda Un Objeto Encontrado:
        public async Task<Profesor> Obtener_PorId(Profesor profesor)
        {
            return await _ProfesorDAL.Obtener_PorId(profesor);
        }

        // Manda Todos Los Objetos De La Tabla:
        public async Task<List<Profesor>> Obtener_Todos()
        {
            return await _ProfesorDAL.Obtener_Todos();
        }

        // Manda Todos Los Objetos De Otra Tabla Para ViewData:
        public async Task<List<Rol>> Lista_Roles()
        {
            return await _ProfesorDAL.Lista_Roles();
        }




        // ******* METODOS QUE RECIBIRAN OBJETOS Y MODIFICARAN LA DB ********:

        // Recibe Un Objeto Y Lo Guarda En La Tabla:
        public async Task<int> Create(Profesor profesor)
        {
            return await _ProfesorDAL.Create(profesor);
        }

        // Recibe Un Objeto Lo Busca Y Lo Elimina De La Tabla:
        public async Task<int> Delete(Profesor profesor)
        {
            return await _ProfesorDAL.Delete(profesor);
        }

        // Recibe Un Objeto Lo Busca Y Lo Modifica
        public async Task<int> Edit(Profesor profesor)
        {
            return await _ProfesorDAL.Edit(profesor);
        }

    }
}
