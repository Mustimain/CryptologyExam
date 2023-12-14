using System;
using System.Threading.Tasks;
using CryptologyExam.Services.Interfaces;
using static Xamarin.Essentials.Permissions;

namespace CryptologyExam.Services
{
    public class SezarService : ISezarService
    {
        public SezarService()
        {
        }

        public string DecryptSezar(string plainText, int scrollAmount)
        {
            char[] karakterler = plainText.ToCharArray();

            for (int i = 0; i < karakterler.Length; i++)
            {
                if (Char.IsLetter(karakterler[i]))
                {
                    char harf = karakterler[i];
                    char orijinalHarf;

                    if (Char.IsUpper(harf))
                    {
                        orijinalHarf = (char)('A' + (harf - 'A' - scrollAmount + 26) % 26);
                    }
                    else
                    {
                        orijinalHarf = (char)('a' + (harf - 'a' - scrollAmount + 26) % 26);
                    }

                    karakterler[i] = orijinalHarf;
                }
            }

            return new string(karakterler);
        }

        public string EncryptSezar(string plainText, int scrollAmount)
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
                        sifrelenmisHarf = (char)('A' + (harf - 'A' + scrollAmount) % 26);
                    }
                    else
                    {
                        sifrelenmisHarf = (char)('a' + (harf - 'a' + scrollAmount) % 26);
                    }

                    karakterler[i] = sifrelenmisHarf;
                }
            }

            return new string(karakterler);
        }
    }
}

