using Firebase.Auth;
using Google.Cloud.Firestore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ClientForm
{
    public class AuthService
    {
        // TODO: replace with your Web API key (Project Settings -> General)
        private const string ApiKey = "AIzaSyASZyb4H_nmMW2mkwUm2XvhlrULQGZlBWw";
        private readonly HttpClient _http = new HttpClient();

        public async Task<AuthResult> RegisterAsync(string email, string password, string displayName)
        {
            var url = $"https://identitytoolkit.googleapis.com/v1/accounts:signUp?key={ApiKey}";
            var payload = new { email = email, password = password, returnSecureToken = true };
            var resp = await _http.PostAsync(url, new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json"));
            var json = await resp.Content.ReadAsStringAsync();
            if (!resp.IsSuccessStatusCode) return new AuthResult { Success = false, Error = json };

            dynamic parsed = JsonConvert.DeserializeObject(json);
            string idToken = parsed.idToken;
            string localId = parsed.localId;

            // write basic profile into Firestore (users collection) using Admin credential via FirebaseService
            var userDoc = new
            {
                uid = localId,
                email = email,
                displayName = displayName,
                createdAt = DateTime.UtcNow
            };
            // use Google.Cloud.Firestore to write profile
            var docRef = FirebaseService.Db.Collection("users").Document(localId);
            await docRef.SetAsync(userDoc);

            return new AuthResult { Success = true, IdToken = idToken, LocalId = localId };
        }

        public async Task<AuthResult> LoginAsync(string email, string password)
        {
            var url = $"https://identitytoolkit.googleapis.com/v1/accounts:signInWithPassword?key={ApiKey}";
            var payload = new { email = email, password = password, returnSecureToken = true };
            var resp = await _http.PostAsync(url, new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json"));
            var json = await resp.Content.ReadAsStringAsync();
            if (!resp.IsSuccessStatusCode) return new AuthResult { Success = false, Error = json };

            dynamic parsed = JsonConvert.DeserializeObject(json);
            string idToken = parsed.idToken;
            string localId = parsed.localId;

            return new AuthResult { Success = true, IdToken = idToken, LocalId = localId };
        }
    }

    public class AuthResult
    {
        public bool Success { get; set; }
        public string IdToken { get; set; }   // JWT
        public string LocalId { get; set; }   // uid
        public string Error { get; set; }
    }
}
