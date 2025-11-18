using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Cloud.Firestore;

namespace ServerForm.Models
{
    [FirestoreData]
    public class Question
    {
        [FirestoreProperty]
        public string Id { get; set; }

        [FirestoreProperty]
        public string Text { get; set; }

        [FirestoreProperty]
        public List<string> Answers { get; set; }

        [FirestoreProperty]
        public int CorrectIndex { get; set; }
    }
}
