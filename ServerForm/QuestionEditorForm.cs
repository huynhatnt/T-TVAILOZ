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
    public partial class QuestionEditorForm : Form
    {
        public Question Question { get; private set; }

        private void UpdateCorrectAnswerOptions()
        {
            cbCorrect.Items.Clear();
            cbCorrect.Items.AddRange(new string[]
            {
                txtA1.Text.Trim(),
                txtA2.Text.Trim(),
                txtA3.Text.Trim(),
                txtA4.Text.Trim()
            });
        }

        private void txtA1_TextChanged(object sender, EventArgs e) => UpdateCorrectAnswerOptions();
        private void txtA2_TextChanged(object sender, EventArgs e) => UpdateCorrectAnswerOptions();
        private void txtA3_TextChanged(object sender, EventArgs e) => UpdateCorrectAnswerOptions();
        private void txtA4_TextChanged(object sender, EventArgs e) => UpdateCorrectAnswerOptions();

        public QuestionEditorForm(Question question)
        {
            InitializeComponent();

            if (question == null)
            {
                Question = new Question
                {
                    Answers = new List<string>()
                };
            }
            else
            {
                Question = question;
            }

            txtQuestionText.Text = Question.Text;

            if (Question.Answers.Count == 4)
            {
                txtA1.Text = Question.Answers[0];
                txtA2.Text = Question.Answers[1];
                txtA3.Text = Question.Answers[2];
                txtA4.Text = Question.Answers[3];
                cbCorrect.SelectedIndex = Question.CorrectIndex;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            Question.Text = txtQuestionText.Text.Trim();
            Question.Answers = new List<string>()
            {
                txtA1.Text.Trim(),
                txtA2.Text.Trim(),
                txtA3.Text.Trim(),
                txtA4.Text.Trim()
            };

            if (cbCorrect.SelectedIndex >= 0)
            {
                Question.CorrectIndex = cbCorrect.SelectedIndex;
            }
            else
            {
                MessageBox.Show("Please select the correct answer.");
                return;
            }

            DialogResult = DialogResult.OK;
            Close();

        }
    }
}
