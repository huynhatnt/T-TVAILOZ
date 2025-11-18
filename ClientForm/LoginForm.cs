using ClientForm.Models;
using Google.Cloud.Firestore;
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
using static System.ActivationContext;



namespace ClientForm.Forms
{
    public partial class LoginForm : Form
    {
        private readonly AuthService _auth = new AuthService();

        public LoginForm()
        {
            InitializeComponent();
        }

        private async void BtnLogin_Click(object sender, EventArgs e)
        {
            btnLogin.Enabled = false;
            lblError.Text = "";
            string email = txtEmail.Text.Trim();
            string pass = txtPassword.Text;

            var res = await _auth.LoginAsync(email, pass);
            if (!res.Success)
            {
                lblError.Text = "Login failed";
                btnLogin.Enabled = true;
                return;
            }

            Program.CurrentUser = new ClientUser
            {
                Uid = res.LocalId,
                Email = email,
                IdToken = res.IdToken,
                DisplayName = email
            };

            var lobby = new LobbyForm(res.IdToken, res.LocalId);
            lobby.Show();
            Hide();
        }

        private void LinkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var reg = new RegisterForm();
            reg.ShowDialog();
        }
    }
}
