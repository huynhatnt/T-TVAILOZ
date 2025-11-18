using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Google.Cloud.Firestore;
using ServerForm.Models;

namespace ServerForm.Firebase
{
    public class RoomRepository
    {
        private readonly CollectionReference _roomRef;

        public RoomRepository()
        {
            _roomRef = FirestoreService.GetDB().Collection("rooms");
        }

        public async Task<string> CreateRoom(string quizId, string roomId)
        {
            // optional: load questions to put inside room
            var quizRepo = new QuizRepository();
            var questions = await quizRepo.GetQuestions(quizId); // returns list from doc or subcollection

            Room room = new Room
            {
                roomId = roomId,
                quizId = quizId,
                state = "waiting",
                currentQuestionIndex = 0,
                players = new Dictionary<string, Player>(),
                questions = questions
            };

            await _roomRef.Document(room.roomId).SetAsync(room);
            return room.roomId;
        }


        public async Task UpdateRoom(Room room)
        {
            await _roomRef.Document(room.roomId).SetAsync(room);
        }

        // Set next question index
        public async Task SetQuestionIndex(string roomId, int qIndex)
        {
            await _roomRef.Document(roomId)
                .UpdateAsync("currentQuestionIndex", qIndex);
        }

        // Listening to room changes (realtime)
        public void ListenRoom(string roomId, Action<Room> onChange)
        {
            _roomRef.Document(roomId).Listen(snapshot =>
            {
                if (snapshot.Exists)
                {
                    var room = snapshot.ConvertTo<Room>();
                    onChange(room);
                }
            });
        }
    }
}
