using ClientForm.Models;
using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientForm.Services
{
    public class RoomService
    {
        private readonly CollectionReference _rooms;

        public RoomService()
        {
            _rooms = FirebaseService.Db.Collection("rooms");
        }

        public async Task<bool> RoomExistsAsync(string roomId)
        {
            if (string.IsNullOrWhiteSpace(roomId)) return false;
            var snap = await _rooms.Document(roomId).GetSnapshotAsync();
            return snap.Exists;
        }

        public async Task<bool> JoinRoomAsync(string roomId, PlayerInfo player)
        {
            var docRef = _rooms.Document(roomId);
            var snap = await docRef.GetSnapshotAsync();
            if (!snap.Exists) return false;

            // add to players subcollection or map
            await docRef.Collection("players").Document(player.Uid).SetAsync(player);
            return true;
        }

        // Listen to room document changes (returns IDisposable, stop by Dispose)
        public FirestoreChangeListener ListenRoom(string roomId, Action<RoomInfo> onChange)
        {
            var docRef = _rooms.Document(roomId);
            var listener = docRef.Listen(snapshot =>
            {
                if (snapshot.Exists)
                {
                    var room = snapshot.ConvertTo<RoomInfo>();
                    onChange?.Invoke(room);
                }
            });

            return listener;
        }
    }
}
