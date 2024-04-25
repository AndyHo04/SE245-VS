namespace WindowsFormsApp1
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.txtAFname = new System.Windows.Forms.TextBox();
            this.txtALname = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtPages = new System.Windows.Forms.TextBox();
            this.txtPrices = new System.Windows.Forms.TextBox();
            this.dtnDatePublished = new System.Windows.Forms.DateTimePicker();
            this.iblFeedback = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(225, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Book Title:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(225, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Author First Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(228, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Author Last Name:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(229, 157);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Author\'s Email:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(230, 200);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Number of  Pages:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(233, 234);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 16);
            this.label6.TabIndex = 5;
            this.label6.Text = "Prices:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(233, 278);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(99, 16);
            this.label7.TabIndex = 6;
            this.label7.Text = "DatePublished:";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(302, 33);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(160, 22);
            this.txtTitle.TabIndex = 7;
            // 
            // txtAFname
            // 
            this.txtAFname.Location = new System.Drawing.Point(347, 75);
            this.txtAFname.Name = "txtAFname";
            this.txtAFname.Size = new System.Drawing.Size(193, 22);
            this.txtAFname.TabIndex = 8;
            // 
            // txtALname
            // 
            this.txtALname.Location = new System.Drawing.Point(350, 114);
            this.txtALname.Name = "txtALname";
            this.txtALname.Size = new System.Drawing.Size(220, 22);
            this.txtALname.TabIndex = 9;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(330, 154);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(191, 22);
            this.txtEmail.TabIndex = 10;
            // 
            // txtPages
            // 
            this.txtPages.Location = new System.Drawing.Point(354, 200);
            this.txtPages.Name = "txtPages";
            this.txtPages.Size = new System.Drawing.Size(100, 22);
            this.txtPages.TabIndex = 11;
            // 
            // txtPrices
            // 
            this.txtPrices.Location = new System.Drawing.Point(287, 234);
            this.txtPrices.Name = "txtPrices";
            this.txtPrices.Size = new System.Drawing.Size(149, 22);
            this.txtPrices.TabIndex = 12;
            // 
            // dtnDatePublished
            // 
            this.dtnDatePublished.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtnDatePublished.Location = new System.Drawing.Point(338, 278);
            this.dtnDatePublished.Name = "dtnDatePublished";
            this.dtnDatePublished.Size = new System.Drawing.Size(200, 22);
            this.dtnDatePublished.TabIndex = 13;
            // 
            // iblFeedback
            // 
            this.iblFeedback.Location = new System.Drawing.Point(-1, 363);
            this.iblFeedback.Multiline = true;
            this.iblFeedback.Name = "iblFeedback";
            this.iblFeedback.Size = new System.Drawing.Size(808, 65);
            this.iblFeedback.TabIndex = 14;
            this.iblFeedback.Text = "Feedback goes here";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(307, 334);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 15;
            this.btnAdd.Text = "Add Book";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.iblFeedback);
            this.Controls.Add(this.dtnDatePublished);
            this.Controls.Add(this.txtPrices);
            this.Controls.Add(this.txtPages);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtALname);
            this.Controls.Add(this.txtAFname);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.TextBox txtAFname;
        private System.Windows.Forms.TextBox txtALname;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtPages;
        private System.Windows.Forms.TextBox txtPrices;
        private System.Windows.Forms.DateTimePicker dtnDatePublished;
        private System.Windows.Forms.TextBox iblFeedback;
        private System.Windows.Forms.Button btnAdd;
    }
}

