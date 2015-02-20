﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Simhopp
{
    public class Database
    {
        public static MySqlConnection conn = null;
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
                conn = new MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();
            }

            catch (MySqlException ex)
            {
                MessageBox.Show("Kunde inte ansluta till databasen, försök igen", "Fel", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn = null;
            }

            catch(Exception e)
            {
                MessageBox.Show("Kunde inte ansluta till databasen, försök igen", "Fel", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn = null;
            }

            return conn;
        }
        #endregion

        #region Judge
        public static List<Judge> GetJudges()
        {
            var judgeList = new List<Judge>();

            var conn = ConnectToDatabase();
            if (conn != null)
            {
                var cmd = new MySqlCommand("SELECT * FROM judge ORDER BY id", conn);
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

            else
            {
                MessageBox.Show("Anslutningen till databasen misslyckades", "Fel", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                string id = "";
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
                id = row["id"].ToString();

                conn.Close();
                return Int32.Parse(id);
            }
            else
            {
                MessageBox.Show("Anslutningen till databasen misslyckades", "Fel", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }
        #endregion

        #region Contest
        /// <summary>
        /// lägger till tävling i databasen
        /// </summary>
        /// <returns>1 = lyckat, 0 = fel, -1 = identisk tävling finns redan</returns>
        public static int AddEventToDatabase(Contest c)
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

                foreach(Diver diver in c.Divers)
                {
                    comm = conn.CreateCommand();
                    comm.CommandText = "INSERT INTO event_diver(eventId, diverId) VALUES(@eventid, @diverid)";
                    comm.Parameters.AddWithValue("@eventid", eventID);
                    comm.Parameters.AddWithValue("@diverid", diver.ID);
                    rowsAffected = comm.ExecuteNonQuery();
                    if (rowsAffected <= 0)
                        return 0;
                }

                foreach (Judge judge in c.Judges)
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

        public static List<Contest> getEvents()
        {
            Contest e;
            List<Contest> events = new List<Contest>();

            MySqlConnection conn = ConnectToDatabase();

            if(conn != null)
            {
                var cmd = new MySqlCommand("SELECT * FROM event ORDER BY started DESC", conn);
                var dr = cmd.ExecuteReader();
                var dt = new DataTable();
                dt.Load(dr);

                foreach (DataRow row in dt.Rows)
                {
                    e = new Contest(Int32.Parse(row["id"].ToString()), row["name"].ToString(), row["date"].ToString(), row["location"].ToString(), Int32.Parse(row["discipline"].ToString()), Int32.Parse(row["sync"].ToString()), Int32.Parse(row["diveCount"].ToString()), Int32.Parse(row["sex"].ToString()), Int32.Parse(row["started"].ToString()));
                    events.Add(e);
                }
            }
            return events;
        }

        public static void StartEvent(int eventID)
        {
            MySqlConnection conn = ConnectToDatabase();
            string sql = "";

            if(conn != null)
            {
                sql = "UPDATE event SET started=1 WHERE id=" + eventID + ";";
                var cmd = new MySqlCommand(sql, conn);
                var dr = cmd.ExecuteNonQuery();
            }

            else
            {
                MessageBox.Show("Anslutningen till databasen misslyckades", "Fel", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        public static void StopEvent(int eventID)
        {
            MySqlConnection conn = ConnectToDatabase();
            string sql = "";

            if (conn != null)
            {
                sql = "UPDATE event SET started=0 WHERE id=" + eventID + ";";
                var cmd = new MySqlCommand(sql, conn);
                var dr = cmd.ExecuteNonQuery();
            }

            else
            {
                MessageBox.Show("Anslutningen till databasen misslyckades", "Fel", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        #endregion

        #region Diver
        public static List<Diver> GetDivers()
        {
            var diverList = new List<Diver>();

            var conn = ConnectToDatabase();
            var cmd = new MySqlCommand("SELECT * FROM diver ORDER BY name", conn);
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
                d1.ID = Int32.Parse(id);
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

        #region DD
        /*
        public static List<DD> GetDD()
        {
            var xxxList = new List<DD>();

            var conn = ConnectToDatabase();
            if (conn != null)
            {
                var cmd = new MySqlCommand("SELECT * FROM DD", conn);
                var dr = cmd.ExecuteReader();
                var dt = new DataTable();
                dt.Load(dr);

                foreach (DataRow row in dt.Rows)
                {
                    var tmp = new DD(Int32.Parse(row["DiveNo"].ToString()), row["DiveName"].ToString());    //
                    xxxList.Add(tmp);
                }
                return xxxList;
            }

            else
            {
                MessageBox.Show("Anslutningen till databasen misslyckades", "Fel", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return judgeList;
        }
        */
        #endregion
    }
}
