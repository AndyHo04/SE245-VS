namespace C_Final
{
    partial class Form1
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
            this.btnAddAPlayer = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnSearchAPlayer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAddAPlayer
            // 
            this.btnAddAPlayer.Location = new System.Drawing.Point(152, 118);
            this.btnAddAPlayer.Name = "btnAddAPlayer";
            this.btnAddAPlayer.Size = new System.Drawing.Size(173, 40);
            this.btnAddAPlayer.TabIndex = 0;
            this.btnAddAPlayer.Text = "Add A Player";
            this.btnAddAPlayer.UseVisualStyleBackColor = true;
            this.btnAddAPlayer.Click += new System.EventHandler(this.btnAddAPlayer_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(331, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Player Characters";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(437, 129);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(8, 8);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnSearchAPlayer
            // 
            this.btnSearchAPlayer.Location = new System.Drawing.Point(481, 118);
            this.btnSearchAPlayer.Name = "btnSearchAPlayer";
            this.btnSearchAPlayer.Size = new System.Drawing.Size(173, 40);
            this.btnSearchAPlayer.TabIndex = 3;
            this.btnSearchAPlayer.Text = "Search For A Player";
            this.btnSearchAPlayer.UseVisualStyleBackColor = true;
            this.btnSearchAPlayer.Click += new System.EventHandler(this.btnSearchAPlayer_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSearchAPlayer);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAddAPlayer);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAddAPlayer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnSearchAPlayer;
    }
}

