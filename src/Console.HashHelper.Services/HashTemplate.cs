using System;
using System.Security.Cryptography;
using Console.HashHelper.Core;

namespace Console.HashHelper.Services
{
    public class HashTemplate : IHashTemplate, IDisposable
    {
        private readonly HashAlgorithm _hashAlgorithm;

        public HashTemplate(HashAlgorithm hashAlgorithm)
        {
            _hashAlgorithm = hashAlgorithm;
        }

        public byte[] GetHash(byte[] arg, int startFrom = 0, int? count = null)
        {
            if (arg == null || arg.Length == 0)
                throw  new ArgumentException("Should not be null or empty", nameof(arg));

            if (startFrom < 0 && arg.Length > startFrom)
                throw new ArgumentException($"Should not be less than zero and greater than {arg.Length}", nameof(startFrom));

            count = count ?? arg.Length;

            if (count < 0 || startFrom + count > arg.Length)
                throw new ArgumentException($"Should not be less than zero and greater than {nameof(arg.Length)}", 
                    nameof(count));


            byte[] computedHash = _hashAlgorithm.ComputeHash(arg, startFrom, count.Value);

            return computedHash;
        }

        public void Dispose()
        {
            _hashAlgorithm?.Dispose();
        }
    }
}
