using System.Data.SqlClient;

namespace ControleEstacionamentos.Repositories
{
    public abstract class DBContext
    {
        // private readonly string strConn = @"Data Source=192.168.56.101;
        // Initial Catalog=NiJPProj;
        // User Id=sa; Password=F4tecSQL!;";
        private readonly string strConn = @"Data Source=localhost;
        Initial Catalog=BDEstacionamentos;
        User Id=sa; 
        Password=P0tatoS4Uce!;";


         protected SqlConnection connection;

         public DBContext()
         {
            connection = new SqlConnection(strConn);
            connection.Open(); 
         }

         public void Dispose()
         {
            connection.Close();
         }
    }
}