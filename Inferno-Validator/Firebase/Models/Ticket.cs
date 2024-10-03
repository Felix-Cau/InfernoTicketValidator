using Google.Cloud.Firestore;

namespace Inferno_Validator.Firebase.Models
{
    [FirestoreData]
    public class Ticket
    {
        [FirestoreProperty("id")] public string Id { get; init; }
        [FirestoreProperty("firstName")] public string FirstName { get; init; }
        [FirestoreProperty("lastName")] public string LastName { get; init; }
        [FirestoreProperty("factionId")] public string FactionId { get; init; }
        [FirestoreProperty("alignment")] public string Alignment { get; init; }
        [FirestoreProperty("gameId")] public string GameId { get; init; }
        [FirestoreProperty("birthday")] public string DateOfBirth { get; init; }
        [FirestoreProperty("email")] public string Email { get; init; }
        [FirestoreProperty("paymentStatus")] public string PaymentStatus { get; init; }
        [FirestoreProperty("ticketType")] public string TicketType { get; init; }
        [FirestoreProperty("vehicleRegNumber")] public string VehicleRegNumber { get; init; }
    }
}
