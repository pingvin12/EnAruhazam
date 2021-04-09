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

        public static HashSet<string> testHashSet = new HashSet<string>{ "dbo.Workers","dbo.Riports","dbo.Managers","dbo.Equipments","dbo.Products","dbo.Schedules","dbo.Shifts","dbo.Traffic"};
        /// <summary>
        /// Gets connection string from configurationmanager and sets as default value
        /// </summary>
        public static string GetConStr()
        {
            return ConfigurationManager.ConnectionStrings["EnAruhazam"].ConnectionString;
        }

       


        /// <summary>
        /// Function for SELECT type data queries
        /// </summary>
        public static DataSet NewConnection( string query)
        {
            SqlCommand command = new SqlCommand(query, new SqlConnection(GetConStr()));
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command);
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            
            return dataSet;
        }



    }
}
