using System;
using System.Threading.Tasks;

namespace CryptologyExam.Services.Interfaces
{
    public interface IAffineService
    {
        string EncryptAffine(string plainText, int a, int b);
        string DecryptAffine(string plainText, int a, int b);
    }
}

