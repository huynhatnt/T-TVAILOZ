using ClientForm.Models;
using ClientForm.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ClientForm.Forms
{
    public partial class LobbyForm : Form
    {
        private readonly string _idToken;
        private readonly string _uid;
        private readonly RoomService _roomService;

        public LobbyForm(string idToken, string uid)
        {
            _idToken = idToken;
            _uid = uid;
            _roomService = new RoomService();

            InitializeComponent();
        }

        private async void BtnJoin_Click(object sender, EventArgs e)
        {
            string roomId = txtRoomId.Text.Trim();
            if (string.IsNullOrEmpty(roomId))
            {
                MessageBox.Show("Enter room id");
                return;
            }

            bool exists = await _roomService.RoomExistsAsync(roomId);
            if (!exists)
            {
                MessageBox.Show("Room not found");
                return;
            }

            var player = new PlayerInfo
            {
                Uid = _uid,
                Name = Program.CurrentUser.DisplayName,
                Score = 0,
                Answer = -1
            };

            var ok = await _roomService.JoinRoomAsync(roomId, player);
            if (!ok)
            {
                MessageBox.Show("Failed to join");
                return;
            }

            var quizForm = new QuizForm(roomId, _idToken, _uid);
            quizForm.Show();
            Hide();
        }
    }
}
