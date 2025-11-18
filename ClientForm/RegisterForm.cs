using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ClientForm.Forms
{
    public partial class RegisterForm : Form
    {
        private readonly AuthService _auth = new AuthService();

        public RegisterForm()
        {
            InitializeComponent();
        }

        private async void BtnRegister_Click(object sender, EventArgs e)
        {
            btnRegister.Enabled = false;
            lblError.Text = "";

            string email = txtEmail.Text.Trim();
            string pass = txtPassword.Text;
            string name = txtDisplayName.Text.Trim();

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(pass) || string.IsNullOrEmpty(name))
            {
                lblError.Text = "Please enter all fields.";
                btnRegister.Enabled = true;
                return;
            }

            var res = await _auth.RegisterAsync(email, pass, name);
            if (!res.Success)
            {
                lblError.Text = $"Register failed: {res.Error}";
                btnRegister.Enabled = true;
                return;
            }

            MessageBox.Show("Registered successfully. Please login.");
            Close();
        }
    }
}

