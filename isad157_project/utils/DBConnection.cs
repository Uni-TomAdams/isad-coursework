using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isad157_project.utils
{
    class DBConnection
    {
        // Connection string used to connect with the database.
        public static string connectionString =
                "SERVER=" + DBCredentials.SERVER + ";" +
                "DATABASE=" + DBCredentials.DATABASE_NAME + ";" +
                "UID=" + DBCredentials.USER_NAME + ";" +
                "PASSWORD=" + DBCredentials.PASSWORD + ";" +
                "SslMode=" + DBCredentials.SslMode + ";";
    }
}
