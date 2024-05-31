using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace C_Final
{
    class Players
    {
        private Int32 playerid;
        private string player;
        private DateTime playingsince;
        private int lives;
        private int deaths;
        private string element;
        private string rank;
        private double hoursplayed;
        private double health;
        private double strength;
        private double armor;
        private string feedback;

        public Int32 PlayerID
        {
            get { return playerid; }
            set
            {
                if (ValidationLibrary.IsMinimunInt(value) == true)
                {
                    playerid = value;
                }
                else
                {
                    feedback += "\nERROR: Invalid Player ID";
                }
            }
        }
        public string Player
        {
            get { return player; }
            set
            {
                if (ValidationLibrary.IsFilled(value))
                {
                    player = value;
                }
                else
                {
                    feedback += "\nERROR: Invalid Player Name";
                }
            }
        }
        public DateTime PlayingSince
        {
            get { return playingsince; }
            set
            {
                if (ValidationLibrary.IsPastDate(value))
                {
                    playingsince = value;
                }
                else
                {
                    feedback += "\nERROR: Invalid Playing Since Date";
                }
            }
        }

        public int Lives
        {
            get { return lives; }
            set
            {
                if (ValidationLibrary.IsMinimunInt(value) == true)
                {
                    lives = value;
                }
                else
                {
                   feedback += "\nERROR: Invalid Lives";
                }
            }
        }
        public int Deaths
        {
            get { return deaths; }
            set
            {
                if (ValidationLibrary.IsMinimunInt(value) == true)
                {
                    deaths = value;
                }
                else
                {
                    feedback += "\nERROR: Invalid Deaths";
                }
            }
        }
        public string Element
        {
            get { return element; }
            set
            {
                if (ValidationLibrary.IsFilled(value))
                {
                    element = value;
                }
                else
                {
                    feedback += "\nERROR: Invalid Element";
                }
            }
        }
        public string Rank
        {
            get { return rank; }
            set
            {
                if (ValidationLibrary.IsFilled(value))
                {
                    rank = value;
                }
                else
                {
                    feedback += "\nERROR: Invalid Rank";
                }
            }
        }
        public double HoursPlayed
        {
            get { return hoursplayed; }
            set
            {
                if (ValidationLibrary.IsMinimunDouble(value) == true)
                {
                    hoursplayed = value;
                }
                else
                {
                    feedback += "\nERROR: Invalid Hours Played";
                }
            }
        }
        public double Health
        {
            get { return health; }
            set
            {
                if (ValidationLibrary.IsMinimunDouble(value) == true)
                {
                    health = value;
                }
                else
                {
                    feedback += "\nERROR: Invalid Health";
                }
            }
        }
        public double Strength
        {
            get { return strength; }
            set
            {
                if (ValidationLibrary.IsMinimunDouble(value) == true)
                {
                    strength = value;
                }
                else
                {
                    feedback += "\nERROR: Invalid Strength";
                }
            }
        }
        public double Armor
        {
            get { return armor; }
            set
            {
                if (ValidationLibrary.IsMinimunDouble(value) == true)
                {
                    armor = value;
                }
                else
                {
                    feedback += "\nERROR: Invalid Armor";
                }
            }
        }

        public string Feedback
        {
            get { return feedback; }
            set { feedback = value; }
        }

        //create a method to insert a player into the database
        public string InsertPlayer()
        {

            //crrate a string result
            string strResult = "";

            //create a connection to the database
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = GetConnectionString();

            //create a command to insert a player
            string strSQL = "INSERT INTO Players (Player, PlayingSince, Lives, Deaths, Element, Rank, HoursPlayed, Health, Strength, Armor) VALUES (@Player, @PlayingSince, @Lives, @Deaths, @Element, @Rank, @HoursPlayed, @Health, @Strength, @Armor)";
            //bark out command
            SqlCommand comm = new SqlCommand();
            comm.CommandText = strSQL;
            comm.Connection = conn;

            //create parameters to insert a player
            comm.Parameters.AddWithValue("@Player", Player);
            comm.Parameters.AddWithValue("@PlayingSince", PlayingSince);
            comm.Parameters.AddWithValue("@Lives", Lives);
            comm.Parameters.AddWithValue("@Deaths", Deaths);
            comm.Parameters.AddWithValue("@Element", Element);
            comm.Parameters.AddWithValue("@Rank", Rank);
            comm.Parameters.AddWithValue("@HoursPlayed", HoursPlayed);
            comm.Parameters.AddWithValue("@Health", Health);
            comm.Parameters.AddWithValue("@Strength", Strength);
            comm.Parameters.AddWithValue("@Armor", Armor);

            //try to insert a player
            try
            {
                conn.Open();
                int intRecs = comm.ExecuteNonQuery();
                strResult = $"SUCCESS: {intRecs} Player Added";
            }
            catch (Exception err)
            {
                strResult = "ERROR: " + err.Message;
            }
            finally
            {
                conn.Close();
            }

            //return the result
            return strResult;


        }

        //create a method to search for a player using dataset
        public DataSet SearchForAPlayer(string strPlayer, DateTime date, string playerrank)
        {
            //create a dataset to hold the results
            DataSet ds = new DataSet();

            //create a connection to the database
            SqlCommand comm = new SqlCommand();

            //create a command to search for a player
            string strSQL = "SELECT PlayerID, Player, PlayingSince, Lives, Deaths, Element, Rank, HoursPlayed, Health, Strength, Armor FROM Players WHERE 0=0";

            //if the player name is filled in
            if (strPlayer.Length > 0)
            {
                strSQL += " AND Player LIKE @Player";
                comm.Parameters.AddWithValue("@Player", "%" + strPlayer + "%");
            }
            //if the playing since date is filled in
            if (date > DateTime.MinValue || date <= DateTime.Now)
            {
                strSQL += " AND CAST(PlayingSince AS DATE) <= @PlayingSince";
               comm.Parameters.AddWithValue("@PlayingSince", date.Date);
            }
            //if the player rank is filled in
            if (playerrank.Length > 0)
            {
                strSQL += " AND Rank LIKE @Rank";
                comm.Parameters.AddWithValue("@Rank", "%" + playerrank + "%");
            }
            //create db tools and get connected
            SqlConnection conn = new SqlConnection();
            string strConn = GetConnectionString();
            conn.ConnectionString = strConn;

            //fill in the command text
            comm.Connection = conn;
            comm.CommandText = strSQL;

            //create a data adapter
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = comm;

            //open the database connection and fill in the dataset
            conn.Open();
            da.Fill(ds, "Players_temp");
            conn.Close();
            //return the data
            return ds;


        }

        //NEW  - Method that returns a Data Reader filled with all the data
        // of one Player.  This one Player is specified by the ID passed
        // to this function
        public SqlDataReader FindOnePlayer(int intPlayerID)
        {
            //create db tools we need
            SqlConnection conn = new SqlConnection();
            SqlCommand comm = new SqlCommand();

            //connection string
            string strConn = GetConnectionString();

            //create command to get everything from database
            string sqlString = "SELECT * FROM Players WHERE PlayerID = @PlayerID";

            //tell the command what to do
            conn.ConnectionString = strConn;
            comm.Connection = conn;
            comm.CommandText = sqlString;
            comm.Parameters.AddWithValue("@PlayerID", intPlayerID);

            conn.Open();

            //return feedback
            return comm.ExecuteReader();

        }

         //create a method to update a player
         public string UpdatePlayer()
         {
            Int32 intRecords = 0;
            string strResult = "";
            //create a sql command string
            string strSQL = "UPDATE Players SET Player = @Player, PlayingSince = @PlayingSince, Lives = @Lives, Deaths = @Deaths, Element = @Element, " +
                "Rank = @Rank, HoursPlayed = @HoursPlayed, Health = @Health, Strength = @Strength, Armor = @Armor WHERE PlayerID = @PlayerID";
            //create a connection to the database
            SqlConnection conn = new SqlConnection();
            string strConn = GetConnectionString();
            conn.ConnectionString = strConn;

            //bark out the command
            SqlCommand comm = new SqlCommand();
            comm.CommandText = strSQL;
            comm.Connection = conn;

            //fill in the parameters
            comm.Parameters.AddWithValue("@Player", Player);
            comm.Parameters.AddWithValue("@PlayingSince", PlayingSince);
            comm.Parameters.AddWithValue("@Lives", Lives);
            comm.Parameters.AddWithValue("@Deaths", Deaths);
            comm.Parameters.AddWithValue("@Element", Element);
            comm.Parameters.AddWithValue("@Rank", Rank);
            comm.Parameters.AddWithValue("@HoursPlayed", HoursPlayed);
            comm.Parameters.AddWithValue("@Health", Health);
            comm.Parameters.AddWithValue("@Strength", Strength);
            comm.Parameters.AddWithValue("@Armor", Armor);
            comm.Parameters.AddWithValue("@PlayerID", PlayerID);

            //try to open the connection and update the record
            try
            {
                conn.Open();
                intRecords = comm.ExecuteNonQuery();
                strResult = $"{intRecords} Player Updated";
            }
            catch (Exception err)
            {
                strResult = "ERROR: " + err.Message;
            }
            finally
            {
                conn.Close();
            }
            //return the result
            return strResult;
         }

        //create a method to delete a player
        public string DeletePlayer(int intPlayerID)
        {
            Int32 intRecords = 0;
            string strResult = "";
            //create a sql command string
            string strSQL = "DELETE FROM Players WHERE PlayerID = @PlayerID";
            //create a connection to the database
            SqlConnection conn = new SqlConnection();
            string strConn = GetConnectionString();
            conn.ConnectionString = strConn;

            //bark out the command
            SqlCommand comm = new SqlCommand();
            comm.CommandText = strSQL;
            comm.Connection = conn;

            //fill in the parameters
            comm.Parameters.AddWithValue("@PlayerID", intPlayerID);

            //try to open the connection and delete the record
            try
            {
                conn.Open();
                intRecords = comm.ExecuteNonQuery();
                strResult = $"{intRecords} Player Deleted";
            }
            catch (Exception err)
            {
                strResult = "ERROR: " + err.Message;
            }
            finally
            {
                conn.Close();
            }
            //return the result
            return strResult;
        }
        
        
        

        private string GetConnectionString()
        {
            return @"Server=sql.neit.edu\sqlstudentserver,4500;Database=Dev_202430_AHo;User Id=Dev_202430_AHo;Password=008021468;";
        }

        //create constructors for the classes
        public Players()
        {
            player = "";
            playingsince = DateTime.Now;
            element = "";
            rank = "";
            Feedback = "";
            
        }

    }

}
