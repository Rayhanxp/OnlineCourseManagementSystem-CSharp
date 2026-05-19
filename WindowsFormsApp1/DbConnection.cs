using System.Configuration;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public class DbConnection
    {
        public static SqlConnection GetConnection()
        {
            string cs = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
            return new SqlConnection(cs);
        }
    }
}