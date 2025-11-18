using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientForm
{
    public static class FirebaseService
    {
        private static FirestoreDb _db;

        // Path to your downloaded service account json
        private const string ServiceAccountPath = "firebase/firebase-key.json";

        // TODO: replace with your project id
        private const string ProjectId = "quizuit";

        public static FirestoreDb Db
        {
            get
            {
                if (_db == null)
                {
                    // Initialize Firebase admin app once
                    try
                    {
                        FirebaseApp.Create(new AppOptions()
                        {
                            Credential = GoogleCredential.FromFile(ServiceAccountPath)
                        });
                    }
                    catch (InvalidOperationException)
                    {
                        // Already created
                    }
                    Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", ServiceAccountPath);
                    _db = FirestoreDb.Create(ProjectId);
                }
                return _db;
            }
        }
    }
}
