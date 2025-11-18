using ClientForm.Models;
using ClientForm.Services;
using Google.Cloud.Firestore;
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
    public partial class QuizForm : Form
    {
        private readonly string _roomId;
        private readonly string _idToken;
        private readonly string _uid;

        private readonly RoomService _roomService;
        private readonly QuizService _quizService;

        private List<Question> _questions;
        private FirestoreChangeListener _listener;

        public QuizForm(string roomId, string idToken, string uid)
        {
            _roomId = roomId;
            _idToken = idToken;
            _uid = uid;

            _roomService = new RoomService();
            _quizService = new QuizService();

            InitializeComponent();
            _ = InitAsync();
        }

        private async Task InitAsync()
        {
            // 🔥 1. Load quizId từ room
            var roomDoc = FirebaseService.Db.Collection("rooms").Document(_roomId);
            var snap = await roomDoc.GetSnapshotAsync();

            if (!snap.Exists)
            {
                MessageBox.Show("Room not found");
                return;
            }

            var room = snap.ConvertTo<RoomInfo>();
            if (string.IsNullOrEmpty(room.quizId))
            {
                MessageBox.Show("Room has no quiz assigned");
                return;
            }

            // 🔥 2. Load all questions từ quiz
            _questions = await _quizService.GetQuestionsAsync(room.quizId);
            if (_questions == null || _questions.Count == 0)
            {
                MessageBox.Show("Quiz has no questions");
                return;
            }

            // 🔥 3. Start listening only to state + index
            _listener = _roomService.ListenRoom(_roomId, UpdateUIFromRoom);
        }

        private void UpdateUIFromRoom(RoomInfo room)
        {
            if (room == null || _questions == null)
                return;

            this.Invoke(new Action(() =>
            {
                lblState.Text = $"State: {room.state}";

                int idx = room.currentQuestionIndex;

                if (idx < 0 || idx >= _questions.Count)
                    return;

                var q = _questions[idx];

                lblQuestion.Text = q.Text;
                rdoA.Text = q.Options.ElementAtOrDefault(0) ?? "";
                rdoB.Text = q.Options.ElementAtOrDefault(1) ?? "";
                rdoC.Text = q.Options.ElementAtOrDefault(2) ?? "";
                rdoD.Text = q.Options.ElementAtOrDefault(3) ?? "";
            }));
        }

        private async void BtnSubmit_Click(object sender, EventArgs e)
        {
            int selected = -1;
            if (rdoA.Checked) selected = 0;
            if (rdoB.Checked) selected = 1;
            if (rdoC.Checked) selected = 2;
            if (rdoD.Checked) selected = 3;

            if (selected == -1)
            {
                MessageBox.Show("Please select an answer");
                return;
            }

            var ans = new UserAnswer
            {
                Uid = _uid,
                SelectedIndex = selected,
                AnsweredAt = Timestamp.GetCurrentTimestamp()
            };

            await _quizService.SubmitAnswerAsync(_roomId, ans);
            MessageBox.Show("Answer submitted");
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            _listener?.StopAsync();
        }
    }
}

