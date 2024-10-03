using Google.Cloud.Firestore;

namespace Inferno_Validator.Firebase.Models
{
    [FirestoreData]
    public class Game
    {
        public string Id { get; set; }
        [FirestoreProperty("name")]
        public string Name { get; init; }
        [FirestoreProperty("year")]
        public string Year { get; init; }

        [FirestoreProperty("ticketPrice")]
        public int TicketPrice { get; init; }
    }
}
