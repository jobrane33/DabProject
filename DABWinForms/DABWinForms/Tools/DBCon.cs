using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
namespace DABWinForms.Tools
{
    public  class DBCon
    {
        private static readonly string connectionString = "Data Source=DESKTOP-MOT8LB0;Initial Catalog=DAB;Integrated Security=True";
        private static SqlConnection connection = null;
        private static readonly object padlock = new object();

        private DBCon()
        {
        }

        public static SqlConnection GetInstance()
        {
            if (connection == null)
            {
                lock (padlock)
                {
                    if (connection == null)
                    {
                        connection = new SqlConnection(connectionString);
                        connection.Open();
                    }
                }
            }
            return connection;
        }
    }
}
