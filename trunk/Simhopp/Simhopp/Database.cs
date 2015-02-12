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
                var tmp = new Judge(Int32.Parse(row["id"].ToString()), row["name"].ToString());
                judgeList.Add(tmp);
            }
            return judgeList;
        }

        /// <summary>
        /// lägger till domare i databasen
        /// </summary>
        /// <returns>returnerar TRUE om det lyckas annars FALSE</returns>
        public static int AddJudgeToDatabase(Judge j1)
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

        /// <summary>
        /// Söker i databasen efter en specifik domare och returnerar den
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Judge or NULL</returns>
        public static Judge GetSpecificJudgeFromDatabase(int id) 
        {
            Judge j = new Judge();
            var conn = ConnectToDatabase();
            string sql = "SELECT * FROM judge WHERE id=" + id.ToString();
            var cmd = new MySqlCommand(sql, conn);
            var dr = cmd.ExecuteReader();
            var dt = new DataTable();
            dt.Load(dr);

            //om en domare hittas returneras den, annars NULL
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    j.ID = Int32.Parse(row["id"].ToString());
                    j.name = row["name"].ToString();
                }
                return j;
            }
            else
            {
                return null;
            }
        }
        #endregion

        #region Event
        /// <summary>
        /// lägger till tävling i databasen
        /// </summary>
        /// <returns>1 = lyckat, 0 = fel, -1 = identisk tävling finns redan</returns>
        public static int AddEventToDatabase(Event c, List<Judge> judgeList, List<Diver> diverList)
        {
            //ansluter till databasen
            MySqlConnection conn = Database.ConnectToDatabase();
            if (conn != null)
            {
                //kollar om en tävling redan finns i databasen
                MySqlCommand comm = conn.CreateCommand();
                string sql = "SELECT * FROM event WHERE name=\"" + c.name + "\" AND date=\"" + c.date + "\"";
                comm.CommandText = sql;

                var dr = comm.ExecuteReader();
                var dt = new DataTable();
                dt.Load(dr);

                if (dt.Rows.Count > 0)
                {
                    return -1;
                }

                //lägger till tävling i databasen
                comm = conn.CreateCommand();
                comm.CommandText = "INSERT INTO event(name, date, location, discipline, sync, diveCount, sex) VALUES(@name, @date, @location, @discipline, @sync, @diveCount, @sex)";
                comm.Parameters.AddWithValue("@name", c.name);
                comm.Parameters.AddWithValue("@date", c.date);
                comm.Parameters.AddWithValue("@location", c.location);
                comm.Parameters.AddWithValue("@discipline", c.discipline);
                comm.Parameters.AddWithValue("@sync", c.sync);
                comm.Parameters.AddWithValue("@diveCount", c.diveCount);
                comm.Parameters.AddWithValue("@sex", c.sex);
                int rowsAffected = comm.ExecuteNonQuery();

                //om inamtningen misslyckades
                if (rowsAffected <= 0)
                    return 0;

                //hämtar ID som eventet fick
                comm.CommandText = "SELECT LAST_INSERT_ID() AS id";
                dr = comm.ExecuteReader();
                dt = new DataTable();
                dt.Load(dr);
                DataRow row = dt.Rows[0];
                string id = row["id"].ToString();

                int eventID = Int32.Parse(id);

                foreach(Diver diver in diverList)
                {
                    comm = conn.CreateCommand();
                    comm.CommandText = "INSERT INTO event_diver(eventId, diverId) VALUES(@eventid, @diverid)";
                    comm.Parameters.AddWithValue("@eventid", eventID);
                    comm.Parameters.AddWithValue("@diverid", diver.ID);
                    rowsAffected = comm.ExecuteNonQuery();
                    if (rowsAffected <= 0)
                        return 0;
                }

                foreach (Judge judge in judgeList)
                {
                    comm = conn.CreateCommand();
                    comm.CommandText = "INSERT INTO event_judge(eventId, judgeId) VALUES(@eventid, @judgeid)";
                    comm.Parameters.AddWithValue("@eventid", eventID);
                    comm.Parameters.AddWithValue("@judgeid", judge.ID);
                    rowsAffected = comm.ExecuteNonQuery();
                    if (rowsAffected <= 0)
                        return 0;
                }

                conn.Close();
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public static List<Event> getEvents()
        {
            Event e;
            List<Event> events = new List<Event>();

            MySqlConnection conn = ConnectToDatabase();

            if(conn != null)
            {
                var cmd = new MySqlCommand("SELECT * FROM event", conn);
                var dr = cmd.ExecuteReader();
                var dt = new DataTable();
                dt.Load(dr);

                foreach (DataRow row in dt.Rows)
                {
                    e = new Event(Int32.Parse(row["id"].ToString()), row["name"].ToString(), row["date"].ToString(), row["location"].ToString(), Int32.Parse(row["discipline"].ToString()), Int32.Parse(row["sync"].ToString()), Int32.Parse(row["diveCount"].ToString()), Int32.Parse(row["sex"].ToString()));
                    events.Add(e);
                }
            }
            return events;
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

        /// <summary>
        /// Söker i databasen efter en specifik domare och returnerar den
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Judge or NULL</returns>
        public static Diver GetSpecificDiverFromDatabase(int id)
        {
            Diver d = new Diver();
            var conn = ConnectToDatabase();
            string sql = "SELECT * FROM diver WHERE id=" + id.ToString();
            var cmd = new MySqlCommand(sql, conn);
            var dr = cmd.ExecuteReader();
            var dt = new DataTable();
            dt.Load(dr);

            //om en hoppare hittas returneras den, annars NULL
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    d.ID = Int32.Parse(row["id"].ToString());
                    d.name = row["name"].ToString();
                }
                return d;
            }
            else
            {
                return null;
            }
        }
        #endregion

        #region Score
        public static List<double> getScoreFromDatabase()
        {
            List<double> points = new List<double>();
            return points;
        }
        #endregion

        #region Event_diver
        public static List<Diver> GetDiversInEvent(int eventID)
        {
            List<Diver> divers = new List<Diver>();

            MySqlConnection conn = ConnectToDatabase();
            if (conn != null)
            {
                Diver d;
                string sql = "SELECT * FROM diver WHERE id IN (SELECT diverId FROM event_diver WHERE event_diver.eventId=" + eventID + ");";
                var cmd = new MySqlCommand(sql, conn);
                var dr = cmd.ExecuteReader();
                var dt = new DataTable();
                dt.Load(dr);

                foreach (DataRow row in dt.Rows)
                {
                    d = new Diver(Int32.Parse(row["id"].ToString()), row["name"].ToString());
                    divers.Add(d);
                }
            }
            return divers;
        }
        #endregion

    }
}
