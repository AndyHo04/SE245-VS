using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace C_Final
{
    public partial class SearchingPlayer : Form
    {
        public SearchingPlayer()
        {
            InitializeComponent();
        }

        private void btnSearchPlayer_Click(object sender, EventArgs e)
        {
            //get data from the form
            Players temp = new Players();

            //perform the search we created
            DataSet ds = temp.SearchForAPlayer(txtPlayerName.Text, dtpPlayingSince.Value, txtRank.Text);

            //display the data
            dgvResults.DataSource = ds;
            dgvResults.DataMember = ds.Tables["Players_temp"].ToString();

        }

        private void dgvResults_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            //gather the info from the selected row and then chooses the data
            string strPlayerID = dgvResults.Rows[e.RowIndex].Cells[0].Value.ToString();

            //convert string to int
            Int32 intPlayerID = Convert.ToInt32(strPlayerID);

            //create an instance of the form
            AddingPlayer Editor = new AddingPlayer(intPlayerID);
            Editor.ShowDialog();
        }
    }
}
