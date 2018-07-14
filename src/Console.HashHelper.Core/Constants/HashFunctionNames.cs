using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace Console.HashHelper.Core.Constants
{
    public static class HashFunctionNames
    {
        public const string Sha1 = "sha1";
        public const string Sha2 = "sha2";
        public const string Md5 = "md5";

        public static IEnumerable<string> GetSupportedHashFunctions()
        {
            var supportedValues = typeof(HashFunctionNames)
                .GetFields(BindingFlags.Public)
                .Select(x => (string)x.GetValue(null));

            return supportedValues;
        }
    }
}
