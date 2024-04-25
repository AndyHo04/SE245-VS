using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsBook
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //Fill in the Text property of the Feedback Variable with the book title, price, and date publiished with some descriptive text/strings
            // the "value" property of a DateTimePicker returns a DateTime variable. We converted it to a string variable in order to append it to a string/text.
            //iblFeedback.Text = "BooK Added: " + txtTitle.Text + "($ " + txtPrice.Text + ") - Published " + dtpDatePublished.Value.ToString(); 

            Book temp = new Book(); // Create Instance
            temp.Feedback = "";   //Initialize feedback var

            //Title
            if (ValidationLibrary.IsItFilledIn(txtTitle.Text) == false)
            {
                temp.Feedback += "ERROR: Title is required.\n";
            }
            else
            {
                temp.Title = txtTitle.Text;
            }
           
            double tPrice = 0;     //create and initalize price
            if (double.TryParse(txtPrice.Text, out tPrice) == true)
            {
                //if conversion is sucessful, set this property
                temp.Price = tPrice;
            }
            else
            {
                //else, append an error msg
                temp.Feedback += "ERROR: Price is not properly formatted. EX:5.98";
            }

            temp.DatePublished = dtpDatePublished.Value; //store the value (DateTime) in the DatePublished property

            if (temp.Feedback.Contains("ERROR"))
            {
                //If there are errors, show the error msgs in order to prompt fixes
                iblFeedback.Text = temp.Feedback;
            }
            else
            {
                iblFeedback.Text = "Book Added: " + temp.Title + "($ " + temp.Price.ToString() + ") - Published " + dtpDatePublished.Value.ToString();
            }
        }
    }
}
