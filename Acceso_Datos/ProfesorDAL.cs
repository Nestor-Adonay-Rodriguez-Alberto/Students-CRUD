using Entidades;
using Microsoft.EntityFrameworkCore;


namespace Acceso_Datos
{
    public class ProfesorDAL
    {
        // Representa La DB:
        private readonly MyDBContext _MyDBContext;

        // Constructor:
        public ProfesorDAL (MyDBContext myDBContext)
        {
            _MyDBContext = myDBContext;
        }



        // ******* METODOS QUE MANDARAN OBJETOS A LAS VISTAS ********:

        // Manda Un Objeto Encontrado:
        public async Task<Profesor> Obtener_PorId(Profesor profesor)
        {
            Profesor? Objeto_Obtenido = await _MyDBContext.Profesores.FirstOrDefaultAsync(x => x.Id_Profesor == profesor.Id_Profesor);

            if (Objeto_Obtenido != null)
            {
                return Objeto_Obtenido;
            }
            else
            {
                return new Profesor();
            }

        }

        // Manda Todos Los Objetos De La Tabla:
        public async Task<List<Profesor>> Obtener_Todos()
        {
            List<Profesor> Objetos_Obtenidos = await _MyDBContext.Profesores.ToListAsync();

            return Objetos_Obtenidos;
        }

        // Manda Todos Los Objetos De Otra Tabla Para ViewData:
        public async Task<List<Rol>> Lista_Roles()
        {
            List<Rol> Objetos_Obtenidos = await _MyDBContext.Roles.ToListAsync();

            return Objetos_Obtenidos;
        }




        // ******* METODOS QUE RECIBIRAN OBJETOS Y MODIFICARAN LA DB ********:

        // Recibe Un Objeto Y Lo Guarda En La Tabla:
        public async Task<int> Create(Profesor profesor)
        {
            _MyDBContext.Add(profesor);
            return await _MyDBContext.SaveChangesAsync();
        }

        // Recibe Un Objeto Lo Busca Y Lo Elimina De La Tabla:
        public async Task<int> Delete(Profesor profesor)
        {
            Profesor? Objeto_Obtenido = await _MyDBContext.Profesores.FirstOrDefaultAsync(x => x.Id_Profesor == profesor.Id_Profesor);

            if (Objeto_Obtenido != null)
            {
                _MyDBContext.Remove(Objeto_Obtenido);
            }

            return await _MyDBContext.SaveChangesAsync();
        }

        // Recibe Un Objeto Lo Busca Y Lo Modifica
        public async Task<int> Edit(Profesor profesor)
        {
            Profesor? Objeto_Obtenido = await _MyDBContext.Profesores.FirstOrDefaultAsync(x => x.Id_Profesor == profesor.Id_Profesor);

            if (Objeto_Obtenido != null)
            {
                // Modififanco Atributos:
                Objeto_Obtenido.Nombre = profesor.Nombre;
                Objeto_Obtenido.FechaNacimiento = profesor.FechaNacimiento;
                Objeto_Obtenido.GradoAcademico = profesor.GradoAcademico;
                Objeto_Obtenido.Telefono = profesor.Telefono;
                Objeto_Obtenido.Gmail = profesor.Gmail;
                Objeto_Obtenido.Sueldo = profesor.Sueldo;
                Objeto_Obtenido.Aula = profesor.Aula;
                Objeto_Obtenido.Fotografia = profesor.Fotografia;
                Objeto_Obtenido.IdRolEnProfesor = profesor.IdRolEnProfesor;

                _MyDBContext.Update(Objeto_Obtenido);
            }

            return await _MyDBContext.SaveChangesAsync();
        }


    }
}
