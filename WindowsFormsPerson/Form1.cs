using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace WindowsFormsPerson
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public Form1(int intPerson_ID)
        {
            InitializeComponent();

            //create the person object
            PersonV2 temp = new PersonV2();
            SqlDataReader dr = temp.FindOnePerson(intPerson_ID);

            //use the datareader to get the data from the database
            while (dr.Read())
            {
                //Take the Name(s) from the datareader and copy them
                // into the appropriate text fields
                txtFName.Text = dr["FirstName"].ToString();
                txtMName.Text = dr["MiddleName"].ToString();
                txtLName.Text = dr["LastName"].ToString();
                txtStreet1.Text = dr["Street1"].ToString();
                txtStreet2.Text = dr["Street2"].ToString();
                txtCity.Text = dr["City"].ToString();
                txtState.Text = dr["State"].ToString();
                txtZip.Text = dr["Zip"].ToString();
                txtPhone.Text = dr["Phone"].ToString();
                txtEmail.Text = dr["Email"].ToString();
                txtCellPhone.Text = dr["CellPhone"].ToString();
                txtInstagramUrl.Text = dr["InstagramUrl"].ToString();

                lblPersonID.Text = dr["PersonID"].ToString();
            }




        }

        private void Button_Click(object sender, EventArgs e)
        {
            //Create the person object
            PersonV2 temp = new PersonV2();
          

            
         
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
            temp.CellPhone = txtCellPhone.Text;
            temp.InstagramUrl = txtInstagramUrl.Text;





            /*
            //display the person object
            PerFeedback.Text = "First Name: " + temp.FirstName + "- Middle Name: " + temp.MiddleName + "- Last Name: " + temp.LastName + "- Street1: " 
            + temp.Street1 + "- Street2: " + temp.Street2 + "- City: " + temp.City + "- State: " + temp.State + "- Zip: " + temp.Zip + "- Phone: " 
            + temp.Phone + "- Email: " + temp.Email + "- Cell Phone:" + temp2.CellPhone + "- Instagram URL:" + temp2.InstagramUrl;
            */
            //NEW...Look for Errors listed in Feedback...If none found, SAVE THE DATA IN DB
            if (!temp.PerFeedback.Contains("ERROR:"))
            {
               PerFeedback.Text = temp.AddARecord();

               
            }
            else
            {
                //Else...Display Error Messages
                PerFeedback.Text = temp.PerFeedback;
            }


        }

        private void btnUpdate_Person_Click(object sender, EventArgs e)
        {
            PersonV2 temp = new PersonV2();
            //Getting the strings from the form and setting them in object
            temp.PersonID = Convert.ToInt32(lblPersonID.Text);
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
            temp.CellPhone = txtCellPhone.Text;
            temp.InstagramUrl = txtInstagramUrl.Text;

            if (!temp.PerFeedback.Contains("ERROR:"))
            {
                PerFeedback.Text = temp.UpdatePerson();
            }
            else
            {
                PerFeedback.Text = temp.PerFeedback;
            }

        }
        /// <summary>
        /// Form code to delete a record based on its ID
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Person_Click(object sender, EventArgs e)
        {
            Int32 intPerson_ID = Convert.ToInt32(lblPersonID.Text);

            PersonV2 temp = new PersonV2();
           
            //get the Person_ID and pass it to the delete method
            PerFeedback.Text = temp.DeletePerson(intPerson_ID);
        }
    }


}
