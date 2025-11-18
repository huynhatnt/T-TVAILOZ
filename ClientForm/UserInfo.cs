using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientForm.Models
{
    [FirestoreData]
    public class UserInfo
    {
        [FirestoreProperty]
        public string uid { get; set; }
        [FirestoreProperty]
        public string email { get; set; }
        [FirestoreProperty]
        public string displayName { get; set; }
    }
}
