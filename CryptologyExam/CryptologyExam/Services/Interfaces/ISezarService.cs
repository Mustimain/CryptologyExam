using System;
using System.Threading.Tasks;

namespace CryptologyExam.Services.Interfaces
{
    public interface ISezarService
    {
        string EncryptSezar(string plainText, int scrollAmount);
        string DecryptSezar(string plainText, int scrollAmount);
    }
}

