using System;
using System.Threading.Tasks;
using CryptologyExam.Services.Interfaces;
using static System.Net.Mime.MediaTypeNames;
using static Xamarin.Essentials.Permissions;

namespace CryptologyExam.Services
{
    public class AtbashService : IAtbashService
    {
        public AtbashService()
        {
        }


        public string DecryptAtbash(string plainText)
        {
            char[] charArray = plainText.ToCharArray();

            for (int i = 0; i < charArray.Length; i++)
            {
                if (char.IsLetter(charArray[i]))
                {
                    // Küçük harfleri çevir
                    if (char.IsLower(charArray[i]))
                    {
                        charArray[i] = (char)('z' - (charArray[i] - 'a'));
                    }
                    // Büyük harfleri çevir
                    else
                    {
                        charArray[i] = (char)('Z' - (charArray[i] - 'A'));
                    }
                }
                // Eğer harf değilse, karakteri değiştirmeye gerek yok
            }

            return new string(charArray);

        }

        public string EncryptAtbash(string plainText)
        {
            char[] karakterler = plainText.ToCharArray();

            for (int i = 0; i < karakterler.Length; i++)
            {
                if (Char.IsLetter(karakterler[i]))
                {
                    char harf = karakterler[i];
                    char sifrelenmisHarf;

                    if (Char.IsUpper(harf))
                    {
                        sifrelenmisHarf = (char)('Z' - (harf - 'A'));
                    }
                    else
                    {
                        sifrelenmisHarf = (char)('z' - (harf - 'a'));
                    }

                    karakterler[i] = sifrelenmisHarf;
                }
            }

            return new string(karakterler);
        }
    }
}

