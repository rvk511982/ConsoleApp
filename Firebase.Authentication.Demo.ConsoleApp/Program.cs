// See https://aka.ms/new-console-template for more information

using Firebase.Auth;
using Refit;

namespace Firebase.Authentication.Demo.ConsoleApp
{
    class Program
    {
        private const string API_KEY = "AIzaSyB61I2n7Sp_5mj7WmBTEjCkCxIYz_jhXpg";

        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            //FirebaseAuthConfig firebaseAuthConfig = new FirebaseAuthConfig();
            //firebaseAuthConfig.ApiKey = API_KEY;

            FirebaseAuthProvider firebaseAuthProvider = new FirebaseAuthProvider(new FirebaseConfig(API_KEY));

            // Create new user in firebase
            //var firebaseAuthLink = await firebaseAuthProvider.CreateUserWithEmailAndPasswordAsync("keshav@gmail.com", "test123", "Keshav Anand", false);

            // Login to Firebase
            var firebaseAuthLink = await firebaseAuthProvider.SignInWithEmailAndPasswordAsync("keshav@gmail.com", "test123");

            Console.WriteLine(firebaseAuthLink.FirebaseToken);

            //Console.ReadLine();

            // Use Refit REST API
            IDataService dataService = RestService.For<IDataService>("http://localhost:5121");
            await dataService.GetData(firebaseAuthLink.FirebaseToken);
        }
    }

    public interface IDataService
    {
        [Get("/")]
        Task GetData([Authorize("Bearer")] string token);
    }
}