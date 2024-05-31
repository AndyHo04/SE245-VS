using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace C_Final
{
    public partial class AddingPlayer : Form
    {
        public AddingPlayer()
        {
            InitializeComponent();
            btnUpdatePlayer.Enabled = false;
            btnDeletePlayer.Enabled = false;
            btnUpdatePlayer.Visible = false;
            btnDeletePlayer.Visible = false;
        }

        /// NEW - Constructor that Receives an Player ID....this means we need to look up the data and populate fields (View/Edit/Del) <summary>
        /// <param name="sender"></param>
        /// <param name="intPlayerID"></param>
        public AddingPlayer(int intPlayerID)
        {
            InitializeComponent();  //Creates and init's all form objects
            btnAddPlayer.Enabled = false;  //Turn off the Add button
            btnAddPlayer.Visible = false;  //Turn off the Add button


            //create an instance of the player class
            Players temp = new Players();
            SqlDataReader dr = temp.FindOnePlayer(intPlayerID);

            //Use that info to fill out the form
            //Loop thru the records stored in the reader 1 record at a time
            // Note that since this is based on one person's ID, then we
            //  should only have one record
            while (dr.Read())
            {
                txtPlayerName.Text = dr["Player"].ToString();
                dtpPlayingSince.Value = Convert.ToDateTime(dr["PlayingSince"]);
                txtElement.Text = dr["Element"].ToString();
                txtRank.Text = dr["Rank"].ToString();
                txtLives.Text = dr["Lives"].ToString();
                txtDeaths.Text = dr["Deaths"].ToString();
                txtHoursPlayed.Text = dr["HoursPlayed"].ToString();
                txtHealth.Text = dr["Health"].ToString();
                txtStrength.Text = dr["Strength"].ToString();
                txtArmor.Text = dr["Armor"].ToString();
                lblPlayerid1.Text = dr["PlayerID"].ToString();
            }
        }

        private void btnAddPlayer_Click(object sender, EventArgs e)
        {
            Players temp = new Players();
            // Clear the feedback label at the beginning
            lblFeedback.Text = "";

            //assigning the values to the properties
            temp.Player = txtPlayerName.Text;
            temp.PlayingSince = dtpPlayingSince.Value;
            temp.Element = txtElement.Text;
            temp.Rank = txtRank.Text;


            var fields = new Dictionary<string, Tuple<TextBox, Action<string>, Func<string, bool>>>
            {
                { "Lives", new Tuple<TextBox, Action<string>, Func<string, bool>>(txtLives, s => temp.Lives = int.Parse(s), s => int.TryParse(s, out _)) },
                { "Deaths", new Tuple<TextBox, Action<string>, Func<string, bool>>(txtDeaths, s => temp.Deaths = int.Parse(s), s => int.TryParse(s, out _)) },
                { "HoursPlayed", new Tuple<TextBox, Action<string>, Func<string, bool>>(txtHoursPlayed, s => temp.HoursPlayed = double.Parse(s), s => double.TryParse(s, out _)) },
                { "Health", new Tuple<TextBox, Action<string>, Func<string, bool>>(txtHealth, s => temp.Health = double.Parse(s), s => double.TryParse(s, out _)) },
                { "Strength", new Tuple<TextBox, Action<string>, Func<string, bool>>(txtStrength, s => temp.Strength = double.Parse(s), s => double.TryParse(s, out _)) },
                { "Armor", new Tuple<TextBox, Action<string>, Func<string, bool>>(txtArmor, s => temp.Armor = double.Parse(s), s => double.TryParse(s, out _)) },
            };

            foreach (var field in fields)
            {
                if (!field.Value.Item3(field.Value.Item1.Text))
                {
                    lblFeedback.Text += $"\nERROR: Please enter a valid number for {field.Key}";
                    return;
                }
                else
                {
                    field.Value.Item2(field.Value.Item1.Text);
                }
            }
            if (lblFeedback.Text != "")
            {
                return;
            }

            if (temp.Feedback.Contains("ERROR:"))
            {
                lblFeedback.Text = temp.Feedback;
            }
            else
            {
                lblFeedback.Text = temp.InsertPlayer();
            }




        }

        private void btnUpdatePlayer_Click(object sender, EventArgs e)
        {
            Players temp = new Players();
            lblFeedback.Text = "";

            
            temp.PlayerID = Convert.ToInt32(lblPlayerid1.Text);
            temp.Player = txtPlayerName.Text;
            temp.PlayingSince = dtpPlayingSince.Value;
            temp.Element = txtElement.Text;
            temp.Rank = txtRank.Text;

            var fields = new Dictionary<string, Tuple<TextBox, Action<string>, Func<string, bool>>>
            {
                { "Lives", new Tuple<TextBox, Action<string>, Func<string, bool>>(txtLives, s => temp.Lives = int.Parse(s), s => int.TryParse(s, out _)) },
                { "Deaths", new Tuple<TextBox, Action<string>, Func<string, bool>>(txtDeaths, s => temp.Deaths = int.Parse(s), s => int.TryParse(s, out _)) },
                { "HoursPlayed", new Tuple<TextBox, Action<string>, Func<string, bool>>(txtHoursPlayed, s => temp.HoursPlayed = double.Parse(s), s => double.TryParse(s, out _)) },
                { "Health", new Tuple<TextBox, Action<string>, Func<string, bool>>(txtHealth, s => temp.Health = double.Parse(s), s => double.TryParse(s, out _)) },
                { "Strength", new Tuple<TextBox, Action<string>, Func<string, bool>>(txtStrength, s => temp.Strength = double.Parse(s), s => double.TryParse(s, out _)) },
                { "Armor", new Tuple<TextBox, Action<string>, Func<string, bool>>(txtArmor, s => temp.Armor = double.Parse(s), s => double.TryParse(s, out _)) },
            };

            foreach (var field in fields)
            {
                if (!field.Value.Item3(field.Value.Item1.Text))
                {
                    lblFeedback.Text += $"\nERROR: Please enter a valid number for {field.Key}";
                    return;
                }
                else
                {
                    field.Value.Item2(field.Value.Item1.Text);
                }
            }

            if (temp.Feedback.Contains("ERROR:"))
            {
                lblFeedback.Text = temp.Feedback;
            }
            else
            {
                lblFeedback.Text = temp.UpdatePlayer();
            }
        }

        private void btnDeletePlayer_Click(object sender, EventArgs e)
        {
            Int32 intPlayerID = Convert.ToInt32(lblPlayerid1.Text);

            Players temp = new Players();

            //delete the record
            lblFeedback.Text = temp.DeletePlayer(intPlayerID);
        }

       
    }
}
