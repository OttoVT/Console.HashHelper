using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Autofac;
using Console.HashHelper.Core;
using Console.HashHelper.Core.Constants;

namespace Console.HashHelper.Modules
{
    public class SevicesModule : Module
    {
        public SevicesModule()
        {
        }

        protected override void Load(ContainerBuilder builder)
        {
            #region HashFunctions

            builder.RegisterInstance(SHA1.Create()).Keyed<HashAlgorithm>(HashFunctionNames.Sha1);
            builder.RegisterInstance(SHA256.Create()).Keyed<HashAlgorithm>(HashFunctionNames.Sha2);
            builder.RegisterInstance(MD5.Create()).Keyed<HashAlgorithm>(HashFunctionNames.Md5);

            #endregion
        }
    }
}
