namespace Log_in_Quick
{
    partial class Register
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
            txtFirstname = new TextBox();
            txtPassword = new TextBox();
            txtEmail = new TextBox();
            txtConfirmpassword = new TextBox();
            btnRegister = new Button();
            SuspendLayout();
            // 
            // txtFirstname
            // 
            txtFirstname.Font = new Font("Footlight MT Light", 12F);
            txtFirstname.Location = new Point(209, 37);
            txtFirstname.Name = "txtFirstname";
            txtFirstname.Size = new Size(282, 29);
            txtFirstname.TabIndex = 0;
            txtFirstname.Text = "Username";
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Footlight MT Light", 12F);
            txtPassword.Location = new Point(209, 221);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(282, 29);
            txtPassword.TabIndex = 1;
            txtPassword.Text = "Password";
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Footlight MT Light", 12F);
            txtEmail.Location = new Point(209, 106);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(284, 29);
            txtEmail.TabIndex = 2;
            txtEmail.Text = "mail@example.com";
            // 
            // txtConfirmpassword
            // 
            txtConfirmpassword.Font = new Font("Footlight MT Light", 12F);
            txtConfirmpassword.Location = new Point(209, 278);
            txtConfirmpassword.Name = "txtConfirmpassword";
            txtConfirmpassword.Size = new Size(282, 29);
            txtConfirmpassword.TabIndex = 3;
            txtConfirmpassword.Text = "Confirm Password";
            // 
            // btnRegister
            // 
            btnRegister.Font = new Font("Footlight MT Light", 12F);
            btnRegister.Location = new Point(209, 409);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(94, 29);
            btnRegister.TabIndex = 4;
            btnRegister.Text = "Register";
            btnRegister.UseVisualStyleBackColor = true;
            // 
            // Register
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnRegister);
            Controls.Add(txtConfirmpassword);
            Controls.Add(txtEmail);
            Controls.Add(txtPassword);
            Controls.Add(txtFirstname);
            Name = "Register";
            Text = "Register";
            Load += Register_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtFirstname;
        private TextBox txtPassword;
        private TextBox txtEmail;
        private TextBox txtConfirmpassword;
        private Button btnRegister;
    }
}