using System;
using System.Globalization;
using System.Security.Cryptography;
using Autofac;
using Console.HashHelper.Core;

namespace Console.HashHelper.Services
{
    public class HashTemplateFactory
    {
        private readonly IContainer _container;

        public HashTemplateFactory(IContainer container)
        {
            _container = container;
        }

        public IHashTemplate GetHashTemplate(string key)
        {
            if (string.IsNullOrEmpty(key))
                throw new ArgumentException("Should not be null", nameof(key));

            string ivariantKey = key.ToLower(CultureInfo.InvariantCulture);

            HashAlgorithm algorithm = _container.ResolveOptionalKeyed<HashAlgorithm>(ivariantKey);

            if (algorithm == null)
                return null;

            return new HashTemplate(algorithm);
        }
    }
}
