using Entidades;
using Microsoft.EntityFrameworkCore;


namespace Acceso_Datos
{
    public class MateriaDAL
    {
        // Representa La DB:
        private readonly MyDBContext _MyDBContext;

        // Constructor:
        public MateriaDAL(MyDBContext myDBContext)
        {
            _MyDBContext = myDBContext;
        }



        // ******* METODOS QUE MANDARAN OBJETOS A LAS VISTAS ********:

        // Manda Un Objeto Encontrado:
        public async Task<Materia> Obtener_PorId(Materia materia)
        {
            Materia? Objeto_Obtenido = await _MyDBContext.Materias
                .Include(x => x.Objeto_Profesor)
                .FirstOrDefaultAsync(x => x.Id_Materia == materia.Id_Materia);

            if (Objeto_Obtenido != null)
            {
                return Objeto_Obtenido;
            }
            else
            {
                return new Materia();
            }

        }

        // Manda Todos Los Objetos De La Tabla:
        public async Task<List<Materia>> Obtener_Todos()
        {
            List<Materia> Objetos_Obtenidos = await _MyDBContext.Materias
                .Include(x => x.Objeto_Profesor)
                .ToListAsync();

            return Objetos_Obtenidos;
        }

        // Manda Todos Los Objetos De Otra Tabla Para ViewData:
        public async Task<List<Profesor>> Lista_Profesores()
        {
            List<Profesor> Objetos_Obtenidos = await _MyDBContext.Profesores.ToListAsync();

            return Objetos_Obtenidos;
        }




        // ******* METODOS QUE RECIBIRAN OBJETOS Y MODIFICARAN LA DB ********:

        // Recibe Un Objeto Y Lo Guarda En La Tabla:
        public async Task<int> Create(Materia materia)
        {
            _MyDBContext.Add(materia);
            return await _MyDBContext.SaveChangesAsync();
        }

        // Recibe Un Objeto Lo Busca Y Lo Elimina De La Tabla:
        public async Task<int> Delete(Materia materia)
        {
            Materia? Objeto_Obtenido = await _MyDBContext.Materias.FirstOrDefaultAsync(x => x.Id_Materia == materia.Id_Materia);

            if (Objeto_Obtenido != null)
            {
                _MyDBContext.Remove(Objeto_Obtenido);
            }

            return await _MyDBContext.SaveChangesAsync();
        }

        // Recibe Un Objeto Lo Busca Y Lo Modifica
        public async Task<int> Edit(Materia materia)
        {
            Materia? Objeto_Obtenido = await _MyDBContext.Materias.FirstOrDefaultAsync(x => x.Id_Materia == materia.Id_Materia);

            if (Objeto_Obtenido != null)
            {
                // Modififanco Atributos:
                Objeto_Obtenido.Nombre = materia.Nombre;
                Objeto_Obtenido.Horario = materia.Horario;
                Objeto_Obtenido.IdProfesorEnMateria = materia.IdProfesorEnMateria;

                _MyDBContext.Update(Objeto_Obtenido);
            }

            return await _MyDBContext.SaveChangesAsync();
        }
    }
}
