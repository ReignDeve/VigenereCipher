using System;
using System.Linq;

namespace VigenereCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            // Prompt the user for the plaintext and the cipher key
            Console.Write("Enter the plaintext: ");
            string plaintext = Console.ReadLine();
            Console.Write("Enter the cipher key: ");
            string key = Console.ReadLine();

            // Convert the plaintext and key to upper case
            plaintext = plaintext.ToUpper();
            key = key.ToUpper();

            // Pad the key with the necessary number of characters to match the length of the plaintext
            key = key.PadRight(plaintext.Length, key[0]);

            // Convert the plaintext and key to arrays of characters
            char[] plaintextChars = plaintext.ToCharArray();
            char[] keyChars = key.ToCharArray();

            // Create an array to hold the ciphertext characters
            char[] ciphertextChars = new char[plaintextChars.Length];

            // Encrypt the plaintext using the Vigenère cipher
            for (int i = 0; i < plaintextChars.Length; i++)
            {
                int plaintextCharValue = (int)plaintextChars[i] - 65;
                int keyCharValue = (int)keyChars[i] - 65;
                int ciphertextCharValue = (plaintextCharValue + keyCharValue) % 26;
                ciphertextChars[i] = (char)(ciphertextCharValue + 65);
            }

            // Convert the ciphertext character array to a string and print it to the console
            string ciphertext = new string(ciphertextChars);
            Console.WriteLine($"Ciphertext: {ciphertext}");
        }
    }
}