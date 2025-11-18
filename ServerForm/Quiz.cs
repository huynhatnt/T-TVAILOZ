using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Cloud.Firestore;

namespace ServerForm.Models
{
    [FirestoreData]
    public class Quiz
    {
        [FirestoreProperty]
        public string QuizId { get; set; }

        [FirestoreProperty]
        public string Title { get; set; }

        [FirestoreProperty]
        public List<Question> Questions { get; set; }
    }
}