using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ServerForm.Models
{
    [FirestoreData]
    public class Room
    {
        [FirestoreProperty]
        public string roomId { get; set; }

        [FirestoreProperty]
        public string quizId { get; set; }

        [FirestoreProperty]
        public string state { get; set; } // waiting, running, ended

        [FirestoreProperty]
        public int currentQuestionIndex { get; set; } = 0;

        [FirestoreProperty]
        public Dictionary<string, Player> players { get; set; }

        [FirestoreProperty]
        public List<Question> questions { get; set; }
    }
}
