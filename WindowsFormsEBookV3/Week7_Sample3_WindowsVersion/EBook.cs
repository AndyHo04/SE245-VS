﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Added this workspace to allow us to use BasicTools and ValidationLibrary
using Week4_Class1;
//Added to use Ebook & Validation items
using Week_6_Sample1_DataValidation;
//Use these namespaces to include DB capabilities for generic components and SQL Server
using System.Data;
using System.Data.SqlClient;


namespace Week_6_Sample1_DataValidation
{
    class EBook: Book   //Welcome to inheritance...Ebook has all that book has, but more!
    {
        private DateTime dateRentalExpires;
        private int bookmarkPage;

        public DateTime DateRentalExpires
        {
            get
            {
                return dateRentalExpires;
            }

            set
            {
                //If the date given IS a future date...
                if (ValidationLibrary.IsAFutureDate(value))
                {
                    dateRentalExpires = value;  //Past Date...store it
                }
                else
                {
                    //Future Date...Store error msg in feedback
                    //**** ONLY WORKS BECAUSE feedback was changed to PROTECTED
                    feedback += "\nERROR: You must enter future dates";
                }
            }
        }



        public int BookmarkPage
        {
            get
            {
                return bookmarkPage;
            }

            set
            {
                //if we have the miimum number of pages needed...
                if (value >= 0 && value <= Pages)
                {
                    bookmarkPage = value;  //store the # of pages
                }
                else
                {
                    //Store an error msg in Feedback
                    feedback += "\nERROR: Sorry you entered an invalid page # for a bookmark.";
                }
            }
        }


        //**************************************************************************************
        //  Ultimate goal is to add a record, BUT first we need to connect to the DB
        //    So that is how we will start this process.
        //**************************************************************************************
        public string AddARecord()
        {
            //Init string var
            string strResult = "";

            //Make a connection object
            SqlConnection Conn = new SqlConnection();

            //Initialize it's properties
            Conn.ConnectionString = @GetConnected();     //Set the Who/What/Where of DB


            //*******************************************************************************************************
            string strSQL = "INSERT INTO EBook (Title, AuthorFirst, AuthorLast, Email, Pages, DatePublished, DateRentalExpires, BookmarkPage) VALUES (@Title, @AuthorFirst, @AuthorLast, @Email, @Pages, @DatePublished, @DateRentalExpires, @BookmarkPage)";
            // Bark out our command
            SqlCommand comm = new SqlCommand();
            comm.CommandText = strSQL;  //Commander knows what to say
            comm.Connection = Conn;     //Where's the phone?  Here it is

            //Fill in the paramters (Has to be created in same sequence as they are used in SQL Statement)
            comm.Parameters.AddWithValue("@Title", Title);
            comm.Parameters.AddWithValue("@AuthorFirst", AuthorFirst);
            comm.Parameters.AddWithValue("@AuthorLast", AuthorLast);
            comm.Parameters.AddWithValue("@Email", Email);
            comm.Parameters.AddWithValue("@Pages", Pages);
            comm.Parameters.AddWithValue("@DatePublished", DatePublished);
            comm.Parameters.AddWithValue("@DateRentalExpires", DateRentalExpires);
            comm.Parameters.AddWithValue("@BookmarkPage", BookmarkPage);

            //*******************************************************************************************************

            //attempt to connect to the server
            try
            {
                Conn.Open();                                        //Open connection to DB - Think of dialing a friend on phone
                int intRecs = comm.ExecuteNonQuery();
                strResult = $"SUCCESS: Inserted {intRecs} records.";       //Report that we made the connection and added a record
                Conn.Close();                                       //Hanging up after phone call
            }
            catch (Exception err)                                   //If we got here, there was a problem connecting to DB
            {
                strResult = "ERROR: " + err.Message;                //Set feedback to state there was an error & error info
            }
            finally
            {

            }

            //Return resulting feedback string
            return strResult;
        }




        //**************************************************************************************
        //  NEW - Part one of drill-down search (Takes search params to narrow the search results
        //**************************************************************************************
        public DataSet SearchEBooks(String strTitle, String strAuthorLast, String strBookID)
        {
            //Create a dataset to return filled
            DataSet ds = new DataSet();


            //Create a command for our SQL statement
            SqlCommand comm = new SqlCommand();


            //Write a Select Statement to perform Search
            String strSQL = "SELECT BookID, Title, AuthorFirst, AuthorLast FROM EBook WHERE 0=0";

            //If the First/Last Name is filled in include it as search criteria
            if (strTitle.Length > 0)
            {
                strSQL += " AND Title LIKE @Title";
                comm.Parameters.AddWithValue("@Title", "%" + strTitle + "%");
            }
            if (strAuthorLast.Length > 0)
            {
                strSQL += " AND AuthorLast LIKE @AuthorLast";
                comm.Parameters.AddWithValue("@AuthorLast", "%" + strAuthorLast + "%");
            }
            if (strBookID.Length > 0)
            {
                strSQL += " AND BookID = @BookID";
                comm.Parameters.AddWithValue("@BookID", strBookID );
            }


            //Create DB tools and Configure
            //*********************************************************************************************
            SqlConnection conn = new SqlConnection();
            //Create the who, what where of the DB
            string strConn = @GetConnected();
            conn.ConnectionString = strConn;

            //Fill in basic info to command object
            comm.Connection = conn;     //tell the commander what connection to use
            comm.CommandText = strSQL;  //tell the command what to say

            //Create Data Adapter
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = comm;    //commander needs a translator(dataAdapter) to speak with datasets

            //*********************************************************************************************

            //Get Data
            conn.Open();                //Open the connection (pick up the phone)
            da.Fill(ds, "EBooks_Temp");     //Fill the dataset with results from database and call it "EBooks_Temp"
            conn.Close();               //Close the connection (hangs up phone)

            //Return the data
            return ds;
        }







        //NEW  - Method that returns a Data Reader filled with all the data
        // of one EBook.  This one EBook is specified by the ID passed
        // to this function
        public SqlDataReader FindOneEBook(int intEBook_ID)
        {
            //Create and Initialize the DB Tools we need
            SqlConnection conn = new SqlConnection();
            SqlCommand comm = new SqlCommand();

            //My Connection String
            string strConn = GetConnected();

            //My SQL command string to pull up one EBook's data
            string sqlString =
           "SELECT * FROM EBook WHERE BookID = @BookID;";

            //Tell the connection object the who, what, where, how
            conn.ConnectionString = strConn;

            //Give the command object info it needs
            comm.Connection = conn;
            comm.CommandText = sqlString;
            comm.Parameters.AddWithValue("@BookID", intEBook_ID);

            //Open the DataBase Connection and Yell our SQL Command
            conn.Open();

            //Return some form of feedback
            return comm.ExecuteReader();   //Return the dataset to be used by others (the calling form)

        }










        //**************************************************************************************
        //  NEW - Utility function so that one string controls all SQL Server Login info
        //**************************************************************************************
        private string GetConnected()
        {
            return @"Server=sql.neit.edu\sqlstudentserver,4500;Database=Dev_202430_AHo;User Id=Dev_202430_AHo;Password=008021468;";
        }




        //Default Constructor
        public EBook(): base()  //Calls the parents constructor
        {
            BookmarkPage = 0;
            dateRentalExpires = DateTime.Now.AddDays(14);
        }

    }
}
