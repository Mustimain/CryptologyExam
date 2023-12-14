using System;
using System.Threading.Tasks;
using CryptologyExam.Services.Interfaces;

namespace CryptologyExam.Services
{
    public class AffineService : IAffineService
    {
        public AffineService()
        {
        }

        public string DecryptAffine(string plainText, int a, int b)
        {
            int aInverse = ModInverse(a, 26);
            string decryptedText = "";

            foreach (char character in plainText)
            {
                if (char.IsLetter(character))
                {
                    char decryptedChar = (char)(((aInverse * (character - 'a' - b + 26)) % 26) + 'a');
                    decryptedText += decryptedChar;
                }
                else
                {
                    decryptedText += character;
                }
            }

            return decryptedText;
        }

        public string EncryptAffine(string plainText, int a, int b)
        {
            string cipherText = "";

            foreach (char character in plainText)
            {
                if (char.IsLetter(character))
                {
                    char encryptedChar = (char)(((a * (character - 'a') + b) % 26) + 'a');
                    cipherText += encryptedChar;
                }
                else
                {
                    cipherText += character;
                }
            }

            return cipherText;
        }


        static int ModInverse(int a, int m)
        {
            a = a % m;
            for (int x = 1; x < m; x++)
            {
                if ((a * x) % m == 1)
                    return x;
            }
            return 1;
        }
    }
}

