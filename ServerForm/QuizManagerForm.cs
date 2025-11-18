using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ServerForm.Firebase;
using ServerForm.Models;

namespace ServerForm.Forms
{
    public partial class QuizManagerForm : Form
    {
        private QuizRepository quizRepo;

        public QuizManagerForm()
        {
            InitializeComponent();
            quizRepo = new QuizRepository();
        }

        private async void QuizManagerForm_Load(object sender, EventArgs e)
        {
            await LoadQuizzes();
        }

        private async Task LoadQuizzes()
        {
            var list = await quizRepo.GetAllQuizzes();

            listBoxQuizzes.DataSource = null;
            listBoxQuizzes.DataSource = list;
            listBoxQuizzes.DisplayMember = "Title";
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            QuizEditorForm editor = new QuizEditorForm(null);
            if (editor.ShowDialog() == DialogResult.OK)
            {
                await quizRepo.CreateQuiz(editor.Quiz);
                await LoadQuizzes();
            }
        }

        private async void btnEdit_Click(object sender, EventArgs e)
        {
            if (listBoxQuizzes.SelectedItem is Quiz quiz)
            {
                QuizEditorForm editor = new QuizEditorForm(quiz);
                if (editor.ShowDialog() == DialogResult.OK)
                {
                    await quizRepo.UpdateQuiz(editor.Quiz);
                    await LoadQuizzes();
                }
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (listBoxQuizzes.SelectedItem is Quiz quiz)
            {
                await quizRepo.DeleteQuiz(quiz.QuizId);
                await LoadQuizzes();
            }
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await LoadQuizzes();
        }
    }
}

