using Google.Apis.Auth.OAuth2;
using Google.Cloud.Firestore;
using Inferno_Validator.Firebase;
using Inferno_Validator.Firebase.Models;
using Newtonsoft.Json;

namespace Inferno_Validator.Models
{
    public class GameRepository : IGameRepository
    {
        private readonly FirestoreDb firestoreDb;
        public GameRepository(FirebaseCredentials credentials)
        {
            var serializeObject = JsonConvert.SerializeObject(credentials);

            firestoreDb = new FirestoreDbBuilder
            {
                Credential = GoogleCredential.FromJson(serializeObject),
                ProjectId = credentials.project_id
            }.Build();
        }

        //Async method to get collection of games from Firestore.
        public async Task<IEnumerable<Game>> GetGamesAsync()
        {
            var gameSnapshot = await firestoreDb.Collection("games").GetSnapshotAsync();
            var games = gameSnapshot.Select(documentSnapshot =>
            {
                var convertedGame = documentSnapshot.ConvertTo<Game>();
                convertedGame.Id = documentSnapshot.Id;
                return convertedGame;
            });
            return games;
        }
    }
}
