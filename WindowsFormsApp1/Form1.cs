using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsBook;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            //Fill the Text property of the Feedback variable with the book title, price, and date published with some descriptive text/string
            //the "Value" property of the DateTimePicker returns a DateTime variable. We converted it to a string in order to append it to string/text.
            //iblFeedback.Text = "Book Title " + txtTitle.Text + " costs " + txtPrice.Text + " and was published on " + dtpDatePublished.Value.ToString();

            Book temp = new Book(); // create a new instance of the Book class
            temp.Feedback = ""; // clear out the feedback variable

            temp.Title = txtTitle.Text; // set the title property to the value in the txtTitle textbox
            temp.AuthorFirst = txtAFname.Text; // set the authorFirst property to the value in the txtAuthorFirst textbox
            temp.AuthorLast = txtALname.Text; // set the authorLast property to the value in the txtAuthorLast textbox
            temp.Email = txtEmail.Text; // set the email property to the value in the txtEmail textbox
            temp.DatePublished = dtnDatePublished.Value; // set the datePublished property to the value in the dtpDatePublished DateTimePicker
            
            int tPages = 0; // create an integer variable to hold the number of pages
            if (int.TryParse(txtPages.Text, out tPages)) // try to convert the value in the txtPages textbox to an integer
            {
                temp.Pages = tPages; // if successful, set the pages property to the value in the txtPages textbox
            }
            else
            {
                temp.Feedback += "ERROR:Pages must be a number."; // if unsuccessful, add an error message to the feedback variable
            }

            double tPrice = 0; // create a double variable to hold the price
            if (double.TryParse(txtPrices.Text, out tPrice)) // try to convert the value in the txtPrice textbox to a double
            {
                temp.Price = tPrice; // if successful, set the price property to the value in the txtPrice textbox
            }
            else
            {
                temp.Feedback += "ERROR:Price is not properly formatted EX:5.98."; // if unsuccessful, add an error message to the feedback variable
            }
          
         
           
            if (temp.Feedback.Contains("ERROR")) // check to see if the feedback variable contains the word "ERROR"
            {
                iblFeedback.Text = temp.Feedback; // if it does, display the feedback variable in the iblFeedback textbox
                return; // exit the event handler
            }
            else
            {
                iblFeedback.Text = "Book Title: " + temp.Title +  "-($ " + temp.Price.ToString() + ")- Author: " + temp.AuthorFirst + " " + temp.AuthorLast + "- Email: " + temp.Email + "- Date Published: " + temp.DatePublished.ToString() + "- Pages: " + temp.Pages.ToString();// display the feedback variable in the iblFeedback textbox

            }
        }


    }
}
