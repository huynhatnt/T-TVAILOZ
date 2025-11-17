using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using MainForm;
namespace Log_in_Quick
{
    public partial class Login : Form
    {
        // Firebase config - ch?nh theo project c?a b?n
        private readonly IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "QeZOmavzkOYWR4xCkmlaqvkKE6MEa17TT4nRxmqN",
            BasePath = "https://login1001-8d5bb-default-rtdb.firebaseio.com/"
        };
        private IFirebaseClient client;

        public Login()
        {
            InitializeComponent();
            // G?n s? ki?n n?u designer chýa g?n
            this.Load += Form1_Load;
            btnLogin.Click += btnLogin_Click;
            btnRegister.Click += btnRegister_Click;
        }

        private void SetPlaceholder(TextBox txt, string placeholder)
        {
            txt.Text = placeholder;
            txt.ForeColor = Color.Gray;

            txt.Enter += (s, e) =>
            {
                if (txt.Text == placeholder)
                {
                    txt.Text = "";
                    txt.ForeColor = Color.Black;

                    if (txt == txtPassword)
                        txt.UseSystemPasswordChar = true;
                }
            };

            txt.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txt.Text))
                {
                    txt.Text = placeholder;
                    txt.ForeColor = Color.Gray;

                    if (txt == txtPassword)
                        txt.UseSystemPasswordChar = false;
                }
            };
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Kh?i t?o Firebase client
            try
            {
                client = new FireSharp.FirebaseClient(config);
                if (client == null)
                {
                    MessageBox.Show("Không th? k?t n?i t?i Firebase. Ki?m tra c?u h?nh.", "L?i", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("L?i khi t?o client Firebase: " + ex.Message, "L?i", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            SetPlaceholder(txtUsername, "Username");
            SetPlaceholder(txtPassword, "Password");
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        // Nút Login: th?c hi?n xác th?c v?i Firebase và chuy?n sang Main n?u thành công
        private async void btnLogin_Click(object sender, EventArgs e)
        {
            string usernameOrEmail = txtUsername.Text?.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(usernameOrEmail) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Vui l?ng nh?p username/email và m?t kh?u.", "Thi?u thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (client == null)
            {
                MessageBox.Show("Chýa k?t n?i t?i Firebase. Vui l?ng th? l?i.", "L?i", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                FirebaseResponse response = await client.GetAsync("users");
                if (response == null || response.Body == "null")
                {
                    MessageBox.Show("Không t?m th?y d? li?u ngý?i dùng.", "L?i", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var allUsers = JsonConvert.DeserializeObject<Dictionary<string, User>>(response.Body);
                if (allUsers == null || allUsers.Count == 0)
                {
                    MessageBox.Show("Không có ngý?i dùng trong h? th?ng.", "L?i", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var user = allUsers.Values.FirstOrDefault(u =>
                    string.Equals(u.username, usernameOrEmail, StringComparison.OrdinalIgnoreCase)
                    || string.Equals(u.email, usernameOrEmail, StringComparison.OrdinalIgnoreCase));

                if (user == null)
                {
                    MessageBox.Show("Không t?m th?y tài kho?n v?i username/email này.", "Ðãng nh?p th?t b?i", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string hashedInput = ComputeSha256Hash(password);
                if (!string.Equals(hashedInput, user.passwordHash, StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("M?t kh?u không ðúng.", "Ðãng nh?p th?t b?i", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                try
                {
                    var main = new Main(usernameOrEmail); // Ho?c new Main();
                    main.StartPosition = FormStartPosition.CenterScreen;
                    main.FormClosed += (s, args) => this.Show();
                    this.Hide();
                    main.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("L?i khi m? Main: " + ex.Message + "\n" + ex.StackTrace);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("L?i khi ki?m tra d? li?u trên Firebase: " + ex.Message, "L?i", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void btnForgot_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
        }

        // M? form Register khi ngý?i dùng b?m ðãng k?
        private void btnRegister_Click(object sender, EventArgs e)
        {
            Register register = new Register();
            register.Show();
            this.Hide();
        }

        #region Helpers

        private static string ComputeSha256Hash(string rawData)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                var builder = new StringBuilder();
                foreach (var b in bytes) builder.Append(b.ToString("x2"));
                return builder.ToString();
            }
        }

        // User model kh?p v?i c?u trúc lýu trên Firebase
        private class User
        {
            public string username { get; set; }
            public string email { get; set; }
            public string passwordHash { get; set; }
            public string createdAt { get; set; }
        }

        #endregion
    }
}