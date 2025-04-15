using System.Text.RegularExpressions;
using System.Text;

namespace InventoryManagemenet.API.Services
{
    public class PANCardService : IPANCardService
    {
        private readonly HashSet<string> _generatedPANs = new HashSet<string>();
        private readonly Random _random = new Random();

        public string GeneratePAN()
        {
            string pan;
            do
            {
                pan = GenerateRandomPAN();
            } while (!IsValidPAN(pan) || !_generatedPANs.Add(pan));

            return pan;
        }

        public bool IsValidPAN(string pan)
        {
            string pattern = @"^[A-Z]{3}P[A-Z][0-9]{4}[A-Z]$";
            return Regex.IsMatch(pan, pattern);
        }

        private string GenerateRandomPAN()
        {
            var builder = new StringBuilder();
            for (int i = 0; i < 3; i++)
            {
                builder.Append((char)('A' + _random.Next(0, 26)));
            }
            builder.Append('P');
            builder.Append((char)('A' + _random.Next(0, 26)));
            for (int i = 0; i < 4; i++)
            {
                builder.Append(_random.Next(0, 10));
            }
            builder.Append((char)('A' + _random.Next(0, 26)));
            return builder.ToString();
        }
    }
}
