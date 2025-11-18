using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Cloud.Firestore;
using ServerForm.Models;

namespace ServerForm.Firebase
{
    public class QuizRepository
    {
        private readonly CollectionReference _quizRef;

        public QuizRepository()
        {
            _quizRef = FirestoreService.GetDB().Collection("quizzes");
        }

        public async Task CreateQuiz(Quiz quiz)
        {
            if (quiz == null) throw new ArgumentNullException(nameof(quiz));

            // generate id
            quiz.QuizId = _quizRef.Document().Id;

            // Save entire quiz doc (including Questions array if present)
            await _quizRef.Document(quiz.QuizId).SetAsync(quiz);

            // Also write questions into subcollection "questions" for compatibility
            if (quiz.Questions != null && quiz.Questions.Count > 0)
            {
                var qCol = _quizRef.Document(quiz.QuizId).Collection("questions");
                foreach (var q in quiz.Questions)
                {
                    // use existing Id or generate new doc id
                    var qId = string.IsNullOrWhiteSpace(q.Id) ? qCol.Document().Id : q.Id;
                    q.Id = qId;
                    await qCol.Document(qId).SetAsync(q);
                }
            }
        }

        public async Task UpdateQuiz(Quiz quiz)
        {
            await _quizRef.Document(quiz.QuizId).SetAsync(quiz);
        }

        public async Task DeleteQuiz(string quizId)
        {
            await _quizRef.Document(quizId).DeleteAsync();
        }

        public async Task<List<Quiz>> GetAllQuizzes()
        {
            QuerySnapshot snap = await _quizRef.GetSnapshotAsync();
            return snap.Documents.Select(d => d.ConvertTo<Quiz>()).ToList();
        }
        public async Task<List<Question>> GetQuestions(string quizId)
        {
            DocumentSnapshot snap = await _quizRef.Document(quizId).GetSnapshotAsync();

            if (!snap.Exists)
                return new List<Question>();

            Quiz quiz = snap.ConvertTo<Quiz>();
            return quiz.Questions ?? new List<Question>();
        }
    }
}
