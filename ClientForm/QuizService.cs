using ClientForm.Models;
using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientForm.Services
{
    public class QuizService
    {
        public async Task<List<Question>> GetQuestionsAsync(string quizId)
        {
            if (string.IsNullOrWhiteSpace(quizId))
                return new List<Question>();

            var docRef = FirebaseService.Db.Collection("quizzes").Document(quizId);

            // 1) Try subcollection "questions"
            try
            {
                var qSnap = await docRef.Collection("questions").GetSnapshotAsync();
                if (qSnap != null && qSnap.Count > 0)
                {
                    var questionsFromSub = qSnap.Documents
                        .Select(d =>
                        {
                            var q = d.ConvertTo<Question>();
                            if (string.IsNullOrEmpty(q.Id))
                                q.Id = d.Id;
                            return q;
                        })
                        .ToList();
                    if (questionsFromSub.Count > 0)
                        return questionsFromSub;
                }
            }
            catch
            {
                // ignore and fallback to reading document field
            }

            // 2) Fallback: read Questions array saved directly on the quiz document
            try
            {
                var doc = await docRef.GetSnapshotAsync();
                if (!doc.Exists) return new List<Question>();

                var dict = doc.ToDictionary();
                if (dict.TryGetValue("Questions", out var qObj)) { /* parse JSON to List<Question> */ }
            }
            catch
            {
                // ignore
            }

            return new List<Question>();
        }

        public async Task SubmitAnswerAsync(string roomId, UserAnswer answer)
        {
            var playerDoc = FirebaseService.Db.Collection("rooms").Document(roomId).Collection("players").Document(answer.Uid);
            var updates = new Dictionary<string, object>
            {
                { "answer", answer.SelectedIndex },
                { "answeredAt", answer.AnsweredAt }
            };
            await playerDoc.UpdateAsync(updates);
        }
    }
}
