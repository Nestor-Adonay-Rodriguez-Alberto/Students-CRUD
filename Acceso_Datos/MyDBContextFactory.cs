using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;


namespace Acceso_Datos
{
    public class MyDBContextFactory : IDesignTimeDbContextFactory<MyDBContext>
    {
        // Implementacion:
        public MyDBContext CreateDbContext(string[] args)
        {
            var OptionsBuilder = new DbContextOptionsBuilder<MyDBContext>();
            const string Cadena_Conexion = "Data Source=.;Initial Catalog=Z1_Students_CRUD;Integrated Security=True;Trust Server Certificate=True";
            OptionsBuilder.UseSqlServer(Cadena_Conexion);

            return new MyDBContext(OptionsBuilder.Options);
        }
    }
}
