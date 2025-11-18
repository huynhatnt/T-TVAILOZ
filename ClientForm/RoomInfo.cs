using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientForm.Models
{
    [FirestoreData]
    public class PlayerInfo
    {
        [FirestoreProperty]
        public string Uid { get; set; }
        [FirestoreProperty]
        public string Name { get; set; }
        [FirestoreProperty]
        public int Score { get; set; }
        [FirestoreProperty]
        public int Answer { get; set; } = -1;
    }

    [FirestoreData]
    public class RoomInfo
    {
        [FirestoreProperty]
        public string roomId { get; set; }

        [FirestoreProperty]
        public string hostId { get; set; }

        [FirestoreProperty]
        public string state { get; set; } // waiting / running / ended

        [FirestoreProperty]
        public int currentQuestionIndex { get; set; }

        [FirestoreProperty]
        public List<Question> questions { get; set; }

        [FirestoreProperty]
        public Dictionary<string, PlayerInfo> players { get; set; }
        [FirestoreProperty]
        public string quizId { get; set; }
    }


}
