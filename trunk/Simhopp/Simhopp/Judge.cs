using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Simhopp
{
    public class Judge
    {
        private int ID;
        private string name;

        //konstruktorer
        public Judge() 
        {
            this.ID = -1;
            this.name = "";
        }

        public Judge(int ID, string name)
        {
            this.ID = ID;
            this.name = name;
        }

        //ansluter till databasen och returnerar anslutningen
        private MySql.Data.MySqlClient.MySqlConnection connectToDatabase()
        {
            MySql.Data.MySqlClient.MySqlConnection conn;
            string myConnectionString = "server=tuffast.com;uid=teamb;pwd=teambteamb;database=db_teamb;";
            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();
                return conn;
            }

            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return null;
        }

        //medlemsfunktioner
        public void addJudgeToDatabase()
        {
            //ansluter till databasen
            MySql.Data.MySqlClient.MySqlConnection conn = connectToDatabase();

            //om anslutningen misslyckades
            if (conn != null)
            {
                //lägger till domaren i databasen
                MySqlCommand comm = conn.CreateCommand();
                comm.CommandText = "INSERT INTO judge(id,name) VALUES(@id, @name)";
                comm.Parameters.AddWithValue("@id", this.ID);
                comm.Parameters.AddWithValue("@name", this.name);
                comm.ExecuteNonQuery();
                conn.Close();
            }
            
           
        }

        public void readJudgeFromDatabase(int ID)
        {
            //ansluter till databasen
            MySql.Data.MySqlClient.MySqlConnection conn;
            string myConnectionString = "server=tuffast.com;uid=teamb;pwd=teambteamb;database=db_teamb;";
            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();

                //lägger till domaren i databasen
                MySqlCommand comm = conn.CreateCommand();
                comm.CommandText = "INSERT INTO judge(id,name) VALUES(@id, @name)";
                comm.Parameters.AddWithValue("@id", this.ID);
                comm.Parameters.AddWithValue("@name", this.name);
                comm.ExecuteNonQuery();
                conn.Close();
            }

            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void setJudgeName(string name)
        {
            this.name = name;
        }

        public string getJudgeName()
        {
            return this.name;
        }
    }
}
