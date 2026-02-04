using System;

namespace PasswordGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            const string uppercase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string lowercase = "abcdefghijklmnopqrstuvwxyz";
            const string digits = "0123456789";
            const string symbols = "!@#$%^&*()_+-=[]{}|;:,.<>?";

            Console.Write("Include uppercase letters? (y/n): ");
            bool includeUpper = Console.ReadLine().ToLower() == "y";

            Console.Write("Include lowercase letters? (y/n): ");
            bool includeLower = Console.ReadLine().ToLower() == "y";

            Console.Write("Include numbers? (y/n): ");
            bool includeDigits = Console.ReadLine().ToLower() == "y";

            Console.Write("Include special characters? (y/n): ");
            bool includeSymbols = Console.ReadLine().ToLower() == "y";

            string allChars = "";
            if (includeUpper) allChars += uppercase;
            if (includeLower) allChars += lowercase;
            if (includeDigits) allChars += digits;
            if (includeSymbols) allChars += symbols;

            if (allChars.Length == 0)
            {
                Console.WriteLine("Error: At least one character type must be selected.");
                return;
            }

            Random random = new Random();

            Console.Write("Enter password length: ");
            string input = Console.ReadLine();

            if (!int.TryParse(input, out int length) || length <= 0)
            {
                Console.WriteLine("Invalid input. Password length must be a positive integer.");
                return;
            }

            char[] password = new char[length];
            for (int i = 0; i < length; i++)
            {
                password[i] = allChars[random.Next(allChars.Length)];
            }

            Console.WriteLine("Generated password: " + new string(password));

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}