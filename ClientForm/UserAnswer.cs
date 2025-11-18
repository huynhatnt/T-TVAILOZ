using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientForm.Models
{
    [FirestoreData]
    public class UserAnswer
    {
        [FirestoreProperty]
        public string Uid { get; set; }
        [FirestoreProperty]
        public int SelectedIndex { get; set; }
        [FirestoreProperty]
        public Timestamp AnsweredAt { get; set; }
    }
}
