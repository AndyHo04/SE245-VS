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
            PersonV2 temp2 = new PersonV2();
            Customer temp3 = new Customer();

            
         
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
            temp2.CellPhone = txtCellPhone.Text;
            temp2.InstagramUrl = txtInstagramUrl.Text;
            temp3.CustomerSince = dtnDateSince.Value;
            double purchases = 0;
            if (double.TryParse(txtTotalPurchases.Text, out purchases) == true)
            {
                temp3.TotalPurchases = purchases;
            }
            else
            {
                temp3.TotalPurchases = 0;
            }
            temp3.DiscountMember = boolDiscountMember.Checked;
            int rewards = 0;
            if (int.TryParse(txtRewardsEarned.Text, out rewards) == true)
            {
                temp3.RewardsEarned = rewards;
            }
            else
            {
               temp3.RewardsEarned = 0;
            }

            

          

            //display the person object
            PerFeedback.Text = "First Name: " + temp.FirstName + "- Middle Name: " + temp.MiddleName + "- Last Name: " + temp.LastName + "- Street1: " 
            + temp.Street1 + "- Street2: " + temp.Street2 + "- City: " + temp.City + "- State: " + temp.State + "- Zip: " + temp.Zip + "- Phone: " 
            + temp.Phone + "- Email: " + temp.Email + "- Cell Phone:" + temp2.CellPhone + "- Instagram URL:" + temp2.InstagramUrl + "- Customer Since:" + temp3.CustomerSince +
            "- Total Purchases:" + temp3.TotalPurchases + "- Discount Member:" + temp3.DiscountMember + "- Rewards Earned:" + temp3.RewardsEarned;
                              

        }

        
    }

   
}
