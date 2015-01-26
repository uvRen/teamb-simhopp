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
        #region Kontruktor
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
    #endregion

        #region Funktioner
        //ansluter till databasen och returnerar anslutningen
        public MySqlConnection connectToDatabase()
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

        //medlemsfunktioner

        //lägger till domare i databasen, returnerar TRUE om det lyckas
        public bool addJudgeToDatabase()
        {
            //ansluter till databasen
            MySqlConnection conn = connectToDatabase();
            if (conn != null)
            {
                //lägger till domaren i databasen
                MySqlCommand comm = conn.CreateCommand();
                comm.CommandText = "INSERT INTO judge(id,name) VALUES(@id, @name)";
                comm.Parameters.AddWithValue("@id", this.ID);
                comm.Parameters.AddWithValue("@name", this.name);
                comm.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            else
            {
                return false;
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
        #endregion
    }
}
