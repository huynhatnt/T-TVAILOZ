using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServerForm.Firebase
{
    public static class FirestoreService
    {
        private static FirestoreDb _db;

        public static void Initialize()
        {
            string credentialPath = Path.Combine(Application.StartupPath, "firebase-key.json");
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", credentialPath);

            _db = FirestoreDb.Create("quizuit");
        }

        public static FirestoreDb GetDB()
        {
            return _db;
        }
    }
}
