using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Cloud.Firestore;

namespace ServerForm.Models
{
    [FirestoreData]
    public class Player
    {
        [FirestoreProperty]
        public string Name { get; set; }

        [FirestoreProperty]
        public int Score { get; set; }

        [FirestoreProperty]
        public string Answer { get; set; }

        [FirestoreProperty]
        public string Status { get; set; } // connected, disconnected
    }
}