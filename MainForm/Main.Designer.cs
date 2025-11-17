namespace MainForm
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            labelWelcome = new Label();
            panel1 = new Panel();
            txtIntroduce = new TextBox();
            btnChangepassword = new Button();
            txtProfile = new TextBox();
            txtName = new TextBox();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // labelWelcome
            // 
            labelWelcome.AutoSize = true;
            labelWelcome.Location = new Point(347, 41);
            labelWelcome.Name = "labelWelcome";
            labelWelcome.Size = new Size(125, 20);
            labelWelcome.TabIndex = 0;
            labelWelcome.Text = "Welcome, Abcxyz";
            // 
            // panel1
            // 
            panel1.Controls.Add(txtIntroduce);
            panel1.Controls.Add(btnChangepassword);
            panel1.Controls.Add(txtProfile);
            panel1.Controls.Add(txtName);
            panel1.Controls.Add(pictureBox2);
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(296, 426);
            panel1.TabIndex = 1;
            // 
            // txtIntroduce
            // 
            txtIntroduce.Location = new Point(14, 134);
            txtIntroduce.Multiline = true;
            txtIntroduce.Name = "txtIntroduce";
            txtIntroduce.Size = new Size(261, 214);
            txtIntroduce.TabIndex = 14;
            // 
            // btnChangepassword
            // 
            btnChangepassword.Location = new Point(75, 382);
            btnChangepassword.Name = "btnChangepassword";
            btnChangepassword.Size = new Size(200, 29);
            btnChangepassword.TabIndex = 13;
            btnChangepassword.Text = "Change Password";
            btnChangepassword.UseVisualStyleBackColor = true;
            // 
            // txtProfile
            // 
            txtProfile.Location = new Point(14, 22);
            txtProfile.Name = "txtProfile";
            txtProfile.Size = new Size(247, 27);
            txtProfile.TabIndex = 12;
            txtProfile.Text = "Profile";
            // 
            // txtName
            // 
            txtName.Location = new Point(75, 87);
            txtName.Name = "txtName";
            txtName.ReadOnly = true;
            txtName.Size = new Size(200, 27);
            txtName.TabIndex = 11;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.Transparent;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(14, 366);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(42, 57);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 10;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(14, 74);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(42, 40);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 9;
            pictureBox1.TabStop = false;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Controls.Add(labelWelcome);
            Name = "Main";
            Text = "Main";
            Load += Main_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelWelcome;
        private Panel panel1;
        private TextBox txtName;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        private Button btnChangepassword;
        private TextBox txtProfile;
        private TextBox txtIntroduce;
    }
}
