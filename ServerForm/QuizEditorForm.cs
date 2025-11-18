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
    public partial class QuizEditorForm : Form
    {
        public Quiz Quiz { get; private set; }

        public QuizEditorForm(Quiz quiz)
        {
            InitializeComponent();

            if (quiz == null)
            {
                Quiz = new Quiz
                {
                    Questions = new List<Question>()
                };
            }
            else
            {
                Quiz = quiz;
            }

            txtTitle.Text = Quiz.Title;
            LoadQuestionList();
        }

        private void LoadQuestionList()
        {
            listQuestions.DataSource = null;
            listQuestions.DataSource = Quiz.Questions;
            listQuestions.DisplayMember = "Text";
        }

        private void btnAddQ_Click(object sender, EventArgs e)
        {
            QuestionEditorForm qEditor = new QuestionEditorForm(null);

            if (qEditor.ShowDialog() == DialogResult.OK)
            {
                Quiz.Questions.Add(qEditor.Question);
                LoadQuestionList();
            }
        }

        private void btnEditQ_Click(object sender, EventArgs e)
        {
            if (listQuestions.SelectedItem is Question q)
            {
                QuestionEditorForm qEditor = new QuestionEditorForm(q);

                if (qEditor.ShowDialog() == DialogResult.OK)
                {
                    LoadQuestionList();
                }
            }
        }

        private void btnDeleteQ_Click(object sender, EventArgs e)
        {
            if (listQuestions.SelectedItem is Question q)
            {
                Quiz.Questions.Remove(q);
                LoadQuestionList();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Quiz.Title = txtTitle.Text.Trim();

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}