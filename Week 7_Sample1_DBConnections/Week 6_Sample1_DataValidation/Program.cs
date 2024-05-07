using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week4_Class1;

namespace Week_6_Sample1_DataValidation
{
    class Program
    {
        static void Main(string[] args)
        {

            bool blnResult = false;

            EBook temp = new EBook();


            Console.Write("\nPlease enter the title: ");
            temp.Title = Console.ReadLine();

            Console.Write("\nPlease enter the Author's First Name: ");
            temp.AuthorFirst = Console.ReadLine();

            Console.Write("\nPlease enter the Author's Last Name: ");
            temp.AuthorLast = Console.ReadLine();

            Console.Write("\nPlease enter the Author's Email: ");
            temp.Email = Console.ReadLine();


            do
            {
                Console.Write("\nPlease enter the Date Published: ");
                DateTime dtTempDate;
                blnResult = DateTime.TryParse(Console.ReadLine(), out dtTempDate);

                if (blnResult == false)
                {
                    Console.Write("\nSorry incorrect date format.  Please try again. (Ex: 10/31/2000) ");
                }
                else
                {
                    temp.DatePublished = dtTempDate;
                }

            } while (blnResult == false);



            do
            {
                Console.Write("\nPlease enter the # of pages: ");
                int intTempPages;
                blnResult = Int32.TryParse(Console.ReadLine(), out intTempPages);

                if (blnResult == false)
                {
                    Console.Write("\nSorry incorrect page #.  Please try again. (Ex: 214) ");
                }
                else
                {
                    temp.Pages = intTempPages;
                }

            } while (blnResult == false);


            do
            {
                Console.Write("\nPlease enter the Cost of the book : $");
                double dblTempPrice;
                blnResult = Double.TryParse(Console.ReadLine(), out dblTempPrice);

                if (blnResult == false)
                {
                    Console.Write("\nSorry incorrect price.  Please try again. (Ex: 19.50) ");
                }
                else
                {
                    temp.Price = dblTempPrice;
                }

            } while (blnResult == false);



            //*****************************************************************
            //Set Rental Expiration to two weeks from today
            temp.DateRentalExpires = DateTime.Today.AddDays(14);

            //Get the page # to bookmark
            do
            {
                Console.Write("\nPlease enter the page # we want to bookmark: ");       //Prompt for info
                int intTempBookMark;
                blnResult = Int32.TryParse(Console.ReadLine(), out intTempBookMark);       //Get input and try to convert to Int

                if (blnResult == false)
                {
                    Console.Write("\nSorry incorrect page #.  Please try again. (Ex: 214) ");   //if error, display error msg
                }
                else
                {
                    temp.BookmarkPage = intTempBookMark;                                          // else...set bookmark
                }

            } while (blnResult == false);

            //*****************************************************************






            //NEW...Look for Errors listed in Feedback...If none found, SAVE THE DATA IN DB
            if (!temp.Feedback.Contains("ERROR:"))
            {
                string strFeedback = temp.AddARecord();     //Attempt to add a record
                Console.WriteLine(strFeedback);           //Display results of this attempt


                //Console.Write("\n\nWe now have the following book:");
                //Console.Write($"\n Title: {temp.Title}");
                //Console.Write($"\n Written by {temp.AuthorFirst} {temp.AuthorLast}");
                //Console.Write($"\n Email: {temp.Email}");
                //Console.Write($"\n Published: {temp.DatePublished.ToShortDateString()}");
                //Console.Write($"\n Pages: {temp.Pages}");
                //Console.Write($"\n Price: ${temp.Price}");
                //Console.Write($"\n Return by: {temp.DateRentalExpires.ToShortDateString()}");
                //Console.Write($"\n Last Page Read: {temp.BookmarkPage}");

            }
            else
            {
                //Else...Display Error Messages
                Console.WriteLine(temp.Feedback);
            }

            BasicTools.Pause();





        }
    }
}
