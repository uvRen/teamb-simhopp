﻿using System;
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
        /// <returns>returnerar TRUE om det lyckas annars FALSe</returns>
        public static bool AddJudgeToDatabase(Judge j1)
        {
            //ansluter till databasen
            MySqlConnection conn = Database.ConnectToDatabase();
            if (conn != null)
            {
                //lägger till domaren i databasen
                MySqlCommand comm = conn.CreateCommand();
                comm.CommandText = "INSERT INTO judge(id,name) VALUES(@id, @name)";
                comm.Parameters.AddWithValue("@id", j1.GetJudgeID());
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
    }
}
