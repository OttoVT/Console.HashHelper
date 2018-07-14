using System;
using System.Collections.Generic;
using System.Text;

namespace Console.HashHelper.Core
{
    public interface IHashTemplateFactory
    {
        IHashTemplate GetHashTemplate(string key);
    }
}
