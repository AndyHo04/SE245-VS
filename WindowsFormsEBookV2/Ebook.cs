using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace WindowsFormsBook
{
    public class Book {
            private string title;
            private string authorFirst;
            private string authorLast;
            private string email;
            private DateTime datePublished;
            private int pages;
            private double price;
            private string feedback;

            public string Title {
                get { return title; }
                set { 
                if (ValidationLibrary.IsItFilledIn (value, 2))
                    {
                        title = value;
                    } else
                    {
                        feedback += "\nERROR: Title must be at least 2 characters long";
                    }
                 }
            }

            public string AuthorFirst {
                get { return authorFirst; }
                set
                {
                if (ValidationLibrary.IsItFilledIn(value, 2))
                    {
                        authorFirst = value;
                    }
                else
                    {
                        feedback += "\nERROR: Author First Name must be at least 2 characters long";
                    }
                }
            }

            public string AuthorLast {
                get { return authorLast; }
                set
                {
                if (ValidationLibrary.IsItFilledIn(value, 2))
                    {
                        authorLast = value;
                    }
                else
                    {
                        feedback += "\nERROR: Author Last Name must be at least 2 characters long";
                    }
                }
            }

            public string Email {
                get { return email; }
                set {
                    if (ValidationLibrary.IsValidEmail (value)) {
                        email = value;
                    } else {
                        email = "Invalid email Provided";
                    }
                }
            }

            public DateTime DatePublished
            {
                get { return datePublished; }
                set
                {
                    if (ValidationLibrary.IsAPastDate(value))
                    {
                        datePublished = value;
                    }
                    else
                    {
                        feedback += "\nERROR: Date Published must be in the past";
                    }
                }
            }

            public int Pages {
                get { return pages; }
                set {
                    if (ValidationLibrary.IsMinimumAmount (value, 1))
                        pages = value;
                    else
                        pages = 0;
                }
            }

            public double Price {
                get { return price; }
                set {
                    if (ValidationLibrary.IsMinimumAmount (value, 1))
                        price = value;
                    else
                        price = 0;
                }
            }
            
            public string Feedback { 
            
            get { return feedback; }
            set
            {
              
                feedback = value;

            }

            }


        }
    class Ebook : Book
    {
        private DateTime dateRentalExpires;
        private int bookmarkPage;

        public DateTime DateRentalExpires
        {
            get { return dateRentalExpires; }
            set
            {
                if (ValidationLibrary.IsAFutureDate(value))
                {
                    dateRentalExpires = value;
                }
                else
                {
                    Feedback += "\nERROR: Rental date must be in the future";
                }
            }
        }
        public int BookmarkPage
        {
            get { return bookmarkPage; }
            set
            {
                if (ValidationLibrary.IsMinimumAmount(value, 1))
                {
                    bookmarkPage = value;
                }
                else
                {

                    Feedback += "\nERROR: Bookmark page must be less than the total number of pages";

                }
            }
        }
       
        public string AddARecord()
        {
            //Init string var
            string strResult = "";

            //Make a connection object
            SqlConnection Conn = new SqlConnection();

            //Initialize it's properties
            Conn.ConnectionString = @"Server=sql.neit.edu,4500;Database=Dev_202430_AHo;User Id=Dev_202430_AHo;Password=008021468;";     //Set the Who/What/Where of DB

            //Intsert data into sql server
            string strSQL = "INSERT INTO Ebook (Title, AuthorFirst, AuthorLast, Email, DatePublished, Pages, Price, DateRentalExpires, BookmarkPage) VALUES (@Title, @AuthorFirst, @AuthorLast, @Email, @DatePublished, @Pages, @Price, @DateRentalExpires, @BookmarkPage)";
            SqlCommand comm = new SqlCommand();
            comm.CommandText = strSQL;
            comm.Connection = Conn;

            //Fill in the paramters
            comm.Parameters.AddWithValue("@Title", Title);
            comm.Parameters.AddWithValue("@AuthorFirst", AuthorFirst);
            comm.Parameters.AddWithValue("@AuthorLast", AuthorLast);
            comm.Parameters.AddWithValue("@Email", Email);
            comm.Parameters.AddWithValue("@DatePublished", DatePublished);
            comm.Parameters.AddWithValue("@Pages", Pages);
            comm.Parameters.AddWithValue("@Price", Price);
            comm.Parameters.AddWithValue("@DateRentalExpires", DateRentalExpires);
            comm.Parameters.AddWithValue("@BookmarkPage", BookmarkPage);
            //attempt to connect to the server
            try
            {
                Conn.Open();                                        //Open connection to DB - Think of dialing a friend on phone
                int IntRecs = comm.ExecuteNonQuery();               // Actually run the command (Non Query)
                strResult = $"SUCCESS: Inserted {IntRecs} record."; //Report that we have made the connection
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

        public Ebook() : base()
        {
            dateRentalExpires = DateTime.Now.AddDays(14);
            bookmarkPage = 0;

        }
    }
      
}