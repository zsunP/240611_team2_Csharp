using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace team2
{
    public class DBHelper
    {
        private List<Melting> meltings;
        private List<Melting> filteredMeltings;

        private static SqlConnection conn = new SqlConnection();
        public static SqlDataAdapter da;
        public static DataSet ds;
        public static DataTable dt;
        private static string TABLENAME = " MeltingManager ";

        private static void connectDB()
        {
            string dataSource = "local";
            string db = "MeltingDB";
            string security = "SSPI";
            conn.ConnectionString = $"Data Source = ({dataSource});" +
                $"initial Catalog = {db};" +
                $"integrated Security = {security};" +
                $"Timeout = 3";
            conn = new SqlConnection(conn.ConnectionString);

            conn.Open();
        }
    }
}
