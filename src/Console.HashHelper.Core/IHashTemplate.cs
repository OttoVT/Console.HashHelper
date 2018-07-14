using System;

namespace Console.HashHelper.Core
{
    public interface IHashTemplate : IDisposable
    {
        byte[] GetHash(byte[] arg, int startFrom = 0, int? count = null);
    }
}
