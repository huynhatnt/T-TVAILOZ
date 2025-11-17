using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Newtonsoft.Json;

namespace Log_in_Quick
{
    public partial class Register : Form
    {
        // -------------------- Firebase config --------------------
        private readonly IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "QeZOmavzkOYWR4xCkmlaqvkKE6MEa17TT4nRxmqN",
            BasePath = "https://login1001-8d5bb-default-rtdb.firebaseio.com/"
        };
        private IFirebaseClient client;

        public Register()
        {
            InitializeComponent();
            btnRegister.Click += BtnRegister_Click;
            this.Load += Register_Load;
        }

        private void Register_Load(object sender, EventArgs e)
        {
            try
            {
                client = new FireSharp.FirebaseClient(config);
                if (client == null)
                {
                    MessageBox.Show("Không thể kết nối tới Firebase. Kiểm tra cấu hình.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tạo client Firebase: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            SetPlaceholder(txtFirstname, "Firstname");
            SetPlaceholder(txtEmail, "mail@example.com");
            SetPlaceholder(txtPassword, "Password");
            SetPlaceholder(txtConfirmpassword, "Confirm Password");
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
                    if (txt == txtPassword || txt == txtConfirmpassword)
                        txt.UseSystemPasswordChar = true;
                }
            };

            txt.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txt.Text))
                {
                    txt.Text = placeholder;
                    txt.ForeColor = Color.Gray;
                    if (txt == txtPassword || txt == txtConfirmpassword)
                        txt.UseSystemPasswordChar = false;
                }
            };
        }

        // -------------------- Register handler (no OTP) --------------------
        private async void BtnRegister_Click(object sender, EventArgs e)
        {
            string username = txtFirstname.Text?.Trim();
            string email = txtEmail.Text?.Trim();
            string password = txtPassword.Text;
            string confirm = txtConfirmpassword.Text;

            // Basic validation
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(confirm))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!IsValidEmail(email))
            {
                MessageBox.Show("Email không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (password != confirm)
            {
                MessageBox.Show("Mật khẩu và xác nhận mật khẩu không khớp.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra trùng email trên Firebase
            try
            {
                var response = await client.GetAsync("users");
                if (response != null && response.Body != "null")
                {
                    var allUsers = JsonConvert.DeserializeObject<Dictionary<string, User>>(response.Body);
                    if (allUsers != null)
                    {
                        bool exists = allUsers.Values.Any(u => string.Equals(u.email, email, StringComparison.OrdinalIgnoreCase));
                        if (exists)
                        {
                            MessageBox.Show("Email này đã được đăng ký trước đó.", "Trùng email", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi kiểm tra dữ liệu trên Firebase: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Hash password (SHA256)
            string passwordHash = ComputeSha256Hash(password);

            var userObj = new User
            {
                username = username,
                email = email,
                passwordHash = passwordHash,
                createdAt = DateTime.UtcNow.ToString("o")
            };

            // Lưu vào Firebase
            try
            {
                PushResponse push = await client.PushAsync("users/", userObj);
                // Sau khi push thành công lên Firebase
                if (push != null && !string.IsNullOrEmpty(push.Result.name))
                {
                    MessageBox.Show("Đăng ký thành công!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                   
                    this.Invoke((Action)(() =>
                    {
                        var login = new Login(); 
                        login.Show();
                        this.Hide();
                    }));
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Lỗi lưu dữ liệu vào Firebase.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu lên Firebase: " + ex.Message + Environment.NewLine + ex.StackTrace, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearForm()
        {
            txtFirstname.Text = "";
            txtEmail.Text = "";
            txtPassword.Text = "";
            txtConfirmpassword.Text = "";
        }

        #region Helpers

        private static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return false;
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

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