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
    public partial class SearchPerson : Form
    {
        public SearchPerson()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //get data
            PersonV2 temp = new PersonV2();
            //perform the search
            DataSet ds = temp.SearchPerson(txtFName.Text, txtLName.Text);

            //display the data
            dgvResults.DataSource = ds;
            dgvResults.DataMember = ds.Tables["Person_Table"].ToString();

        }

        //Event Handler Method - When we double click on a row in the datagridview, it will get the ID, search for the whole record, and display it in a new form
        //add parameters
        ///<param name="sender"></param>
        ///<param name="e"></param>
    

        private void dgvResults_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //get the ID from the dgvResults
            string strPerson_ID = dgvResults.Rows[e.RowIndex].Cells[0].Value.ToString();

            //convert string to int
            int intPerson_ID = Convert.ToInt32(strPerson_ID);

            //create the editor form, passing it Person_ID and show it
            Form1 Editor = new Form1(intPerson_ID);
            Editor.ShowDialog();
        }
    }
}
