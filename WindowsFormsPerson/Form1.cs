using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsPerson
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, EventArgs e)
        {
            //Create the person object
            Person temp = new Person();
         
            //append the person object with the textboxes
            temp.FirstName = txtFName.Text;
            temp.MiddleName = txtMName.Text;
            temp.LastName = txtLName.Text;
            temp.Street1 = txtStreet1.Text;
            temp.Street2 = txtStreet2.Text;
            temp.City = txtCity.Text;
            temp.State = txtState.Text;
            temp.Zip = txtZip.Text;
            temp.Email = txtEmail.Text;
            temp.Phone = txtPhone.Text;

            //display the person object
            PerFeedback.Text = "First Name: " + temp.FirstName + "- Middle Name: " + temp.MiddleName + "- Last Name: " + temp.LastName + "- Street1: " + temp.Street1 + "- Street2: " + temp.Street2 + "- City: " + temp.City + "- State: " + temp.State + "- Zip: " + temp.Zip + "- Phone: " + temp.Phone + "- Email: " + temp.Email;
                              

        }
    }
}
