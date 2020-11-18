using System.Data.SqlClient;

namespace PE_DE130011.dao
{
    class DBHelper
    {
  
        public static SqlConnection GetDBConnection()
        {
            string dbName = "PE_DE130011";
            string dataSource = "DESKTOP-HPJ37M1";
            string username = "sa";
            string password = "123456";

            string connStr = @"Data Source=" + dataSource
                                    + ";Initial Catalog=" + dbName
                                    + ";Persist Security Info=True;User ID=" + username
                                    + ";Password=" + password;
            SqlConnection conn = new SqlConnection(connStr);
            return conn;
        }
    }
}
