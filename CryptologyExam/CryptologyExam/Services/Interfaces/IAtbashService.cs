using System;
using System.Threading.Tasks;

namespace CryptologyExam.Services.Interfaces
{
    public interface IAtbashService
    {
        string EncryptAtbash(string plainText);
        string DecryptAtbash(string plainText);
    }
}

