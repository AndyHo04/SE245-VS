using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week4_Class1 {
    class Program {
        public class Book {
            private string title;
            private string authorFirst;
            private string authorLast;
            private string email;
            private DateTime datePublished;
            private int pages;
            private double price;

            public string Title {
                get { return title; }
                set { title = value; }
            }

            public string AuthorFirst {
                get { return authorFirst; }
                set { authorFirst = value; }
            }

            public string AuthorLast {
                get { return authorLast; }
                set { authorLast = value; }
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

            public DateTime DatePublished {
                get { return datePublished; }
                set {
                    if (ValidationLibrary.IsDateValid (value)) {
                        datePublished = value;
                    } else {
                        datePublished = DateTime.Parse ("1/1/1900 12:00 am");
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
        }

        static void Main (string[] args) {
            bool blnResult = false;
            Book temp = new Book ();

            Console.Write ("\nPlease enter the title: ");
            temp.Title = Console.ReadLine ();

            Console.Write ("\nPlease enter the Author's First Name: ");
            temp.AuthorFirst = Console.ReadLine ();

            Console.Write ("\nPlease enter the Author's Last Name: ");
            temp.AuthorLast = Console.ReadLine ();

            Console.Write ("\nPlease enter the Author's Email: ");
            temp.Email = Console.ReadLine ();

            do {
                Console.Write ("\nPlease enter the Date Published: ");
                blnResult = DateTime.TryParse (Console.ReadLine (), out temp.DatePublished);
                if (!blnResult) {
                    Console.Write ("\nSorry incorrect date format. (Ex: 10/31/2000) ");
                }
            } while (!blnResult);

            do {
                Console.Write ("\nPlease enter the # of pages: ");
                blnResult = int.TryParse (Console.ReadLine (), out temp.Pages);
                if (!blnResult) {
                    Console.Write ("\nSorry incorrect page #. Please try again. (Ex: > 214) ");
                }
            } while (!blnResult);

            do {
                Console.Write ("\nPlease enter the Price: ");
                blnResult = double.TryParse (Console.ReadLine (), out temp.Price);
                if (!blnResult) {
                    Console.Write ("\nSorry incorrect price. Please try again. (Ex: 19.50) ");
                }
            } while (!blnResult);

            do {
                Console.Write ("\nPlease enter the # of pages: ");
                blnResult = Int32.TryParse (Console.ReadLine (), out temp.Pages);
                if (!blnResult) {
                    Console.Write ("\nSorry incorrect page #. Please try again. (Ex: 214) ");
                }
            } while (!blnResult);

            Console Write ("In\nWe now have the following book:");
            Console Write ($"\n Title: {temp.Title}");
            Console Write ($"\n Written by {temp.AuthorFirst} {temp.AuthorLast}");
            Console Write ($"\n Email: {temp.Email}");
            Console Write ($"\n Published: {temp.DatePublished. ToShortDateString()}");
            Console Write ($"\n Pages: {temp.Pages}");
            Console Write ($"\n Price: ${temp.Price}");

            Console.ReadLine (); // Added to prevent console from closing immediately
        }
    }
}