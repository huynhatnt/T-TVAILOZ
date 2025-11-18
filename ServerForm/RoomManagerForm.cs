using ServerForm.Firebase;
using ServerForm.Models;
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
    public partial class RoomManagerForm : Form
    {
        private QuizRepository quizRepo;
        private RoomRepository roomRepo;

        public RoomManagerForm()
        {
            InitializeComponent();
            quizRepo = new QuizRepository();
            roomRepo = new RoomRepository();
        }

        private async void RoomManagerForm_Load(object sender, EventArgs e)
        {
            var quizzes = await quizRepo.GetAllQuizzes();

            cmbQuizList.DataSource = quizzes;
            cmbQuizList.DisplayMember = "Title";
        }

        private async void btnCreateRoom_Click(object sender, EventArgs e)
        {

            if (cmbQuizList.SelectedItem is Quiz quiz)
            {
                string customId = Guid.NewGuid().ToString("N").Substring(0, 8);
                string roomId = await roomRepo.CreateRoom(quiz.QuizId, customId);
                txtRoomIdResult.Text = roomId;
                MessageBox.Show($"Room created successfully! ID: {roomId}");
            }

        }
    }
}