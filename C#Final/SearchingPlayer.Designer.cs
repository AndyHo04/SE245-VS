namespace C_Final
{
    partial class SearchingPlayer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtPlayerName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpPlayingSince = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.txtRank = new System.Windows.Forms.TextBox();
            this.dgvResults = new System.Windows.Forms.DataGridView();
            this.btnSearchPlayer = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Player Name:";
            // 
            // txtPlayerName
            // 
            this.txtPlayerName.Location = new System.Drawing.Point(96, 86);
            this.txtPlayerName.Name = "txtPlayerName";
            this.txtPlayerName.Size = new System.Drawing.Size(145, 22);
            this.txtPlayerName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(324, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Search For Player";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(267, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Playing Since:";
            // 
            // dtpPlayingSince
            // 
            this.dtpPlayingSince.Location = new System.Drawing.Point(365, 86);
            this.dtpPlayingSince.Name = "dtpPlayingSince";
            this.dtpPlayingSince.Size = new System.Drawing.Size(221, 22);
            this.dtpPlayingSince.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(604, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "Rank:";
            // 
            // txtRank
            // 
            this.txtRank.Location = new System.Drawing.Point(652, 87);
            this.txtRank.Name = "txtRank";
            this.txtRank.Size = new System.Drawing.Size(112, 22);
            this.txtRank.TabIndex = 6;
            // 
            // dgvResults
            // 
            this.dgvResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResults.Location = new System.Drawing.Point(4, 194);
            this.dgvResults.Name = "dgvResults";
            this.dgvResults.RowHeadersWidth = 51;
            this.dgvResults.RowTemplate.Height = 24;
            this.dgvResults.Size = new System.Drawing.Size(799, 262);
            this.dgvResults.TabIndex = 7;
            this.dgvResults.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvResults_CellDoubleClick);
            // 
            // btnSearchPlayer
            // 
            this.btnSearchPlayer.Location = new System.Drawing.Point(350, 140);
            this.btnSearchPlayer.Name = "btnSearchPlayer";
            this.btnSearchPlayer.Size = new System.Drawing.Size(122, 36);
            this.btnSearchPlayer.TabIndex = 8;
            this.btnSearchPlayer.Text = "Search Player";
            this.btnSearchPlayer.UseVisualStyleBackColor = true;
            this.btnSearchPlayer.Click += new System.EventHandler(this.btnSearchPlayer_Click);
            // 
            // SearchingPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSearchPlayer);
            this.Controls.Add(this.dgvResults);
            this.Controls.Add(this.txtRank);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtpPlayingSince);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPlayerName);
            this.Controls.Add(this.label1);
            this.Name = "SearchingPlayer";
            this.Text = "Searching Player";
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPlayerName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpPlayingSince;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtRank;
        private System.Windows.Forms.DataGridView dgvResults;
        private System.Windows.Forms.Button btnSearchPlayer;
    }
}