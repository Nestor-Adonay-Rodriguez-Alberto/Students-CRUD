using Entidades;
using Microsoft.EntityFrameworkCore;


namespace Acceso_Datos
{
    public class RolDAL
    {
        // Representa La DB:
        private readonly MyDBContext _MyDBContext;

        // Constructor:
        public RolDAL(MyDBContext myDBContext)
        {
            _MyDBContext = myDBContext;
        }



        // ******* METODOS QUE MANDARAN OBJETOS A LAS VISTAS ********:

        // Manda Un Objeto Encontrado:
        public async Task<Rol> Obtener_PorId(Rol rol)
        {
            Rol? Objeto_Obtenido = await _MyDBContext.Roles.FirstOrDefaultAsync(x => x.Id_Rol == rol.Id_Rol);

            if (Objeto_Obtenido != null)
            {
                return Objeto_Obtenido;
            }
            else
            {
                return new Rol();
            }
        }

        // Manda Todos Los Objetos De La Tabla:
        public async Task<List<Rol>> Obtener_Todos()
        {
            List<Rol> Objetos_Obtenidos = await _MyDBContext.Roles.ToListAsync();

            return Objetos_Obtenidos;
        }




        // ******* METODOS QUE RECIBIRAN OBJETOS Y MODIFICARAN LA DB ********:

        // Recibe Un Objeto Y Lo Guarda En La Tabla:
        public async Task<int> Create(Rol rol)
        {
            _MyDBContext.Add(rol);
            return await _MyDBContext.SaveChangesAsync();
        }

        // Recibe Un Objeto Lo Busca Y Lo Elimina De La Tabla:
        public async Task<int> Delete(Rol rol)
        {
            Rol? Objeto_Obtenido = await _MyDBContext.Roles.FirstOrDefaultAsync(x => x.Id_Rol == rol.Id_Rol);

            if(Objeto_Obtenido!=null)
            {
                _MyDBContext.Remove(Objeto_Obtenido);
            }

            return await _MyDBContext.SaveChangesAsync();
        }

        // Recibe Un Objeto Lo Busca Y Lo Modifica
        public async Task<int> Edit(Rol rol)
        {
            Rol? Objeto_Obtenido = await _MyDBContext.Roles.FirstOrDefaultAsync(x => x.Id_Rol == rol.Id_Rol);

            if(Objeto_Obtenido!=null)
            {
                // Modififanco Atributos:
                Objeto_Obtenido.Nombre = rol.Nombre;
                _MyDBContext.Update(Objeto_Obtenido);
            }

            return await _MyDBContext.SaveChangesAsync();
        }

    }
}
