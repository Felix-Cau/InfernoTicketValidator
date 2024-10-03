using Google.Apis.Auth.OAuth2;
using Google.Cloud.Firestore;
using Inferno_Validator.Firebase;
using Inferno_Validator.Firebase.Models;
using Inferno_Validator.Pages;
using Newtonsoft.Json;

namespace Inferno_Validator.Models
{
    public class TicketRepository : ITicketRepository
    {
        private readonly FirestoreDb firestoreDb;
        public TicketRepository(FirebaseCredentials credentials)
        {
            var serializeObject = JsonConvert.SerializeObject(credentials);

            firestoreDb = new FirestoreDbBuilder
            {
                Credential = GoogleCredential.FromJson(serializeObject),
                ProjectId = credentials.project_id
            }.Build();
        }

        //Async method to get collection of tickets from Firestore.
        public async Task<IEnumerable<Ticket>> GetTicketsAsync()
        {
            var ticketSnapshot = await firestoreDb.Collection("tickets").WhereEqualTo("gameId", SearchBlazor.SelectedGame).GetSnapshotAsync();
            var tickets = ticketSnapshot.ConvertToList<Ticket>();
            return tickets;
        }
    }
}
