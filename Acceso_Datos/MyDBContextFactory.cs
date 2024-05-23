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
            const string Cadena_Conexion_2 = "workstation id=Students-CRUD.mssql.somee.com;packet size=4096;user id=Test_Proyect_SQLLogin_11;pwd=29ytyqo4j2;data source=Students-CRUD.mssql.somee.com;persist security info=False;initial catalog=Students-CRUD;TrustServerCertificate=True";
            OptionsBuilder.UseSqlServer(Cadena_Conexion_2);

            return new MyDBContext(OptionsBuilder.Options);
        }
    }
}
