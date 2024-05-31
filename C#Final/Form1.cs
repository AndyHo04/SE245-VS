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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAddAPlayer_Click(object sender, EventArgs e)
        {
            AddingPlayer temp = new AddingPlayer();
            temp.Show();
        }

        private void btnSearchAPlayer_Click(object sender, EventArgs e)
        {
            SearchingPlayer temp = new SearchingPlayer();
            temp.Show();
        }
    }
}
