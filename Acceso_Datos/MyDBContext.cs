using Entidades;
using Microsoft.EntityFrameworkCore;


namespace Acceso_Datos
{
    public class MyDBContext : DbContext
    {
        // Constructor:
        public MyDBContext(DbContextOptions<MyDBContext> Options)
            :base(Options) 
        {

        }


        // Tablas De La DB:
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Profesor> Profesores { get; set; }
        public DbSet<Materia> Materias { get; set; }
        public DbSet<Estudiante> Estudiantes { get; set; }

    }
}
