using Google.Apis.Auth.OAuth2;
using Google.Cloud.Firestore;
using Microsoft.Azure.WebJobs;
using Newtonsoft.Json;

namespace Inferno_Validator.Firebase
{
    public static class FirebaseHelper
    {
        public static List<T> ConvertToList<T>(this QuerySnapshot snapshot) =>
            snapshot.Documents.Select(snapshotDocument => snapshotDocument.ConvertTo<T>()).ToList();

        public static T ConvertTo<T>(this DocumentSnapshot snapshot) =>
            snapshot.ConvertTo<T>();
    }
}
