using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace EnAruhazam.DataAccess
{
    public static class MSSQLHelper 
    {
        /// <summary>
        /// Gets connection string from configurationmanager and sets as default value
        /// </summary>
        public static string ConVal(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
        /// <summary>
        /// Function for SELECT type data queries
        /// </summary>
        public static DataSet NewConnection(string dataBase, string query)
        {
            SqlCommand command = new SqlCommand(query, new SqlConnection(ConVal(dataBase)));
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command);
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);

            return dataSet;
        }



    }
}
