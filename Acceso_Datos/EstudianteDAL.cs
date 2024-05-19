using Entidades;
using Microsoft.EntityFrameworkCore;


namespace Acceso_Datos
{
    public class EstudianteDAL
    {
        // Representa La DB:
        private readonly MyDBContext _MyDBContext;

        // Constructor:
        public EstudianteDAL(MyDBContext myDBContext)
        {
            _MyDBContext = myDBContext;
        }



        // ******* METODOS QUE MANDARAN OBJETOS A LAS VISTAS ********:

        // Manda Un Objeto Encontrado:
        public async Task<Estudiante> Obtener_PorId(Estudiante estudiante)
        {
            Estudiante? Objeto_Obtenido = await _MyDBContext.Estudiantes
                .Include(x => x.Objeto_Materia)
                .FirstOrDefaultAsync(x => x.Id_Estudiante == estudiante.Id_Estudiante);

            if (Objeto_Obtenido != null)
            {
                return Objeto_Obtenido;
            }
            else
            {
                return new Estudiante();
            }

        }

        // Manda Todos Los Objetos De La Tabla:
        public async Task<List<Estudiante>> Obtener_Todos()
        {
            List<Estudiante> Objetos_Obtenidos = await _MyDBContext.Estudiantes
                .Include(x => x.Objeto_Materia)
                .ToListAsync();

            return Objetos_Obtenidos;
        }

        // Manda Todos Los Objetos De Otra Tabla Para ViewData:
        public async Task<List<Materia>> Lista_Materias()
        {
            List<Materia> Objetos_Obtenidos = await _MyDBContext.Materias.ToListAsync();

            return Objetos_Obtenidos;
        }




        // ******* METODOS QUE RECIBIRAN OBJETOS Y MODIFICARAN LA DB ********:

        // Recibe Un Objeto Y Lo Guarda En La Tabla:
        public async Task<int> Create(Estudiante estudiante)
        {
            _MyDBContext.Add(estudiante);
            return await _MyDBContext.SaveChangesAsync();
        }

        // Recibe Un Objeto Lo Busca Y Lo Elimina De La Tabla:
        public async Task<int> Delete(Estudiante estudiante)
        {
            Estudiante? Objeto_Obtenido = await _MyDBContext.Estudiantes.FirstOrDefaultAsync(x => x.Id_Estudiante == estudiante.Id_Estudiante);

            if (Objeto_Obtenido != null)
            {
                _MyDBContext.Remove(Objeto_Obtenido);
            }

            return await _MyDBContext.SaveChangesAsync();
        }

        // Recibe Un Objeto Lo Busca Y Lo Modifica
        public async Task<int> Edit(Estudiante estudiante)
        {
            Estudiante? Objeto_Obtenido = await _MyDBContext.Estudiantes.FirstOrDefaultAsync(x => x.Id_Estudiante == estudiante.Id_Estudiante);

            if (Objeto_Obtenido != null)
            {
                // Modififanco Atributos:
                Objeto_Obtenido.Nombre = estudiante.Nombre;
                Objeto_Obtenido.FechaNacimiento = estudiante.FechaNacimiento;
                Objeto_Obtenido.GradoAcademico = estudiante.GradoAcademico;
                Objeto_Obtenido.Direccion = estudiante.Direccion;
                Objeto_Obtenido.Telefono = estudiante.Telefono;
                Objeto_Obtenido.Gmail = estudiante.Gmail;
                Objeto_Obtenido.IdMateriaEnEstudiante = estudiante.IdMateriaEnEstudiante;
                Objeto_Obtenido.Fotografia= estudiante.Fotografia;

                _MyDBContext.Update(Objeto_Obtenido);
            }

            return await _MyDBContext.SaveChangesAsync();
        }

    }
}
