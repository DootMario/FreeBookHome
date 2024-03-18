using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeBookHome
{
    class ConectareBazaDate
    {

        public SqlConnection connection;

        public ConectareBazaDate()
        {
            string strConnection = GetSConnectionByName("FreeBookConnectionString");
            connection = new SqlConnection(strConnection);
        }
        
        static string GetSConnectionByName(string name)
        {
            string strConnection = null;

            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings[name];

            if (settings != null)
            {
                strConnection = settings.ConnectionString;
            }

            return strConnection;

        }

    }
}
