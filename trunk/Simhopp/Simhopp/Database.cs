using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Simhopp
{
    public class Database
    {
        #region Connection
        /// <summary>
        /// ansluter till databasen och returnerar anslutningen
        /// </summary>
        /// <returns>En coonection</returns>
        public static MySqlConnection ConnectToDatabase()
        {
            const string myConnectionString = "server=tuffast.com;uid=teamb;pwd=teambteamb;database=db_teamb;";
            try
            {
                MySqlConnection conn = new MySqlConnection();
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
        #endregion

        #region Jugde
        public static List<Judge> GetJudges()
        {
            var judgeList = new List<Judge>();

            var conn = ConnectToDatabase();
            var cmd = new MySqlCommand("SELECT * FROM judge", conn);
            var dr = cmd.ExecuteReader();
            var dt = new DataTable();
            dt.Load(dr);

            foreach (DataRow row in dt.Rows)
            {
                var tmp = new Judge((int)row["id"], row["name"].ToString());
                judgeList.Add(tmp);
            }
            return judgeList;
        }

        /// <summary>
        /// lägger till domare i databasen
        /// </summary>
        /// <returns>returnerar TRUE om det lyckas annars FALSE</returns>
        public static bool AddJudgeToDatabase(Judge j1)
        {
            //ansluter till databasen
            MySqlConnection conn = Database.ConnectToDatabase();
            if (conn != null)
            {
                //lägger till domaren i databasen
                MySqlCommand comm = conn.CreateCommand();
                comm.CommandText = "INSERT INTO judge(name) VALUES(@name)";
                comm.Parameters.AddWithValue("@name", j1.GetJudgeName());
                comm.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region Event
        /// <summary>
        /// lägger till tävling i databasen
        /// </summary>
        /// <returns>returnerar TRUE om det lyckas annars FALSE</returns>
        public static bool AddEventToDatabase(Event c)
        {
            //ansluter till databasen
            MySqlConnection conn = Database.ConnectToDatabase();
            if (conn != null)
            {
                //lägger till tävling i databasen
                MySqlCommand comm = conn.CreateCommand();
                comm.CommandText = "INSERT INTO event(name, date, location, discipline, sync, diveCount, sex) VALUES(@name, @date, @location, @discipline, @sync, @diveCount, @sex)";
                comm.Parameters.AddWithValue("@name", c.name);
                comm.Parameters.AddWithValue("@date", c.date);
                comm.Parameters.AddWithValue("@location", c.location);
                comm.Parameters.AddWithValue("@discipline", c.discipline);
                comm.Parameters.AddWithValue("@sync", c.sync);
                comm.Parameters.AddWithValue("@diveCount", c.diveCount);
                comm.Parameters.AddWithValue("@sex", c.sex);
                int rowsAffected = comm.ExecuteNonQuery();
                conn.Close();
                //om inamtningen lyckades
                if (rowsAffected >= 0)
                    return true;
                else
                    return false;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region Diver
        public static List<Diver> GetDivers()
        {
            var diverList = new List<Diver>();

            var conn = ConnectToDatabase();
            var cmd = new MySqlCommand("SELECT * FROM diver", conn);
            var dr = cmd.ExecuteReader();
            var dt = new DataTable();
            dt.Load(dr);

            foreach (DataRow row in dt.Rows)
            {
                var tmp = new Diver(Int32.Parse(row["id"].ToString()), row["name"].ToString(), Int32.Parse(row["age"].ToString()), Int32.Parse(row["sex"].ToString()), row["country"].ToString());
                diverList.Add(tmp);
            }
            return diverList;
        }

        /// <summary>
        /// lägger till hoppare i databasen
        /// </summary>
        /// <returns>Returnerar hopparens auto increment ID</returns>
        public static int AddDiverToDatabase(Diver d1)
        {
            //ansluter till databasen
            MySqlConnection conn = Database.ConnectToDatabase();
            if (conn != null)
            {
                //lägger till hopparen i databasen
                MySqlCommand comm = conn.CreateCommand();
                comm.CommandText = "INSERT INTO diver(name, age, sex, country) VALUES(@name, @age, @sex, @country)";

                comm.Parameters.AddWithValue("@name", d1.name);
                comm.Parameters.AddWithValue("@age", d1.age);
                comm.Parameters.AddWithValue("@sex", d1.sex);
                comm.Parameters.AddWithValue("@country", d1.country);
                comm.ExecuteNonQuery();
                comm.CommandText = "SELECT LAST_INSERT_ID() AS id";
                var dr = comm.ExecuteReader();
                var dt = new DataTable();
                dt.Load(dr);
                DataRow row = dt.Rows[0];
                string id = row["id"].ToString();
                                
                conn.Close();
                return Int32.Parse(id);
            }
            else
            {
                return -1;
            }
        }
        #endregion
    }
}
