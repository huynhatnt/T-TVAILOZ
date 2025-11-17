namespace Log_in_Quick
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            btnLogin = new Button();
            btnForgot = new Button();
            btnRegister = new Button();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // txtUsername
            // 
            txtUsername.Font = new Font("Footlight MT Light", 12F);
            txtUsername.Location = new Point(195, 122);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(381, 29);
            txtUsername.TabIndex = 2;
            txtUsername.Text = "Username";
            txtUsername.TextChanged += txtUsername_TextChanged;
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Footlight MT Light", 12F);
            txtPassword.Location = new Point(195, 172);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(381, 29);
            txtPassword.TabIndex = 3;
            txtPassword.Text = "Password";
            // 
            // btnLogin
            // 
            btnLogin.Font = new Font("Footlight MT Light", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLogin.Location = new Point(261, 293);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(147, 71);
            btnLogin.TabIndex = 4;
            btnLogin.Text = "Log In";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnForgot
            // 
            btnForgot.Font = new Font("Footlight MT Light", 12F);
            btnForgot.Location = new Point(59, 246);
            btnForgot.Name = "btnForgot";
            btnForgot.Size = new Size(252, 29);
            btnForgot.TabIndex = 5;
            btnForgot.Text = "Forgot password? Click here";
            btnForgot.UseVisualStyleBackColor = true;
            btnForgot.Click += btnForgot_Click;
            // 
            // btnRegister
            // 
            btnRegister.Font = new Font("Footlight MT Light", 12F);
            btnRegister.Location = new Point(363, 246);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(265, 29);
            btnRegister.TabIndex = 6;
            btnRegister.Text = "New user? Register here";
            btnRegister.UseVisualStyleBackColor = true;
            btnRegister.Click += btnRegister_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(132, 111);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(42, 40);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 7;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.Transparent;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(132, 157);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(42, 57);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 8;
            pictureBox2.TabStop = false;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.AutoScroll = true;
            panel1.BackgroundImage = Properties.Resources.Hồng_và_Màu_kem_Minh_họa_Lớp_Khoa_học_Giáo_dục_Bài_thuyết_trình;
            panel1.BackgroundImageLayout = ImageLayout.Stretch;
            panel1.Controls.Add(txtUsername);
            panel1.Controls.Add(btnLogin);
            panel1.Controls.Add(btnForgot);
            panel1.Controls.Add(pictureBox2);
            panel1.Controls.Add(txtPassword);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(btnRegister);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(705, 396);
            panel1.TabIndex = 9;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Snow;
            BackgroundImage = Properties.Resources.Hồng_và_Màu_kem_Minh_họa_Lớp_Khoa_học_Giáo_dục_Bài_thuyết_trình;
            BackgroundImageLayout = ImageLayout.Zoom;
            ClientSize = new Size(705, 396);
            Controls.Add(panel1);
            Name = "Login";
            Text = "Log_in";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Button btnLogin;
        private Button btnForgot;
        private Button btnRegister;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Panel panel1;
    }
}
