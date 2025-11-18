using ServerForm.Firebase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServerForm.Forms
{
    public partial class MonitorForm : Form
    {
        private RoomRepository roomRepo;

        public MonitorForm()
        {
            InitializeComponent();
            roomRepo = new RoomRepository();
        }

        private void btnListen_Click(object sender, EventArgs e)
        {
            string roomId = txtRoomId.Text.Trim();

            if (string.IsNullOrEmpty(roomId))
            {
                MessageBox.Show("Please enter a valid Room ID.");
                return;
            }


            MessageBox.Show($"Connecting to Room ID: {roomId}...");

            try
            {
                roomRepo.ListenRoom(roomId, room =>
                {
                    // Khi listener nhận được dữ liệu lần đầu tiên => coi như kết nối thành công
                    Invoke(new Action(() =>
                    {
                        // Thông báo kết nối thành công (chỉ hiển thị 1 lần)
                        lblStatus.Text = $"Connected to Room: {roomId}";

                        // Cập nhật DataGrid
                        dataGridPlayers.Rows.Clear();
                        if (room.players != null)
                        {
                            foreach (var p in room.players)
                            {
                                dataGridPlayers.Rows.Add(
                                    p.Key,
                                    p.Value.Name,
                                    p.Value.Score,
                                    p.Value.Status,
                                    p.Value.Answer
                                );
                            }
                        }
                    }));
                });

                // Nếu ListenRoom không ném lỗi ngay lập tức, coi như đăng ký listener thành công
                lblStatus.Text = "Listening for updates...";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to connect: {ex.Message}");
            }

        }
    }
}