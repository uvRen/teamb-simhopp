using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Simhopp
{
    public class Database
    {
        /// <summary>
        /// ansluter till databasen och returnerar anslutningen
        /// </summary>
        /// <returns>En coonection</returns>

        public MySqlConnection ConnectToDatabase()
        {
            MySqlConnection conn;
            string myConnectionString = "server=tuffast.com;uid=teamb;pwd=teambteamb;database=db_teamb;";
            try
            {
                conn = new MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();
                return conn;
            }

            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return null;
        }

        public MySqlDataReader GetJudges()
        {
            MySqlConnection conn = ConnectToDatabase();
        }
    }
}
