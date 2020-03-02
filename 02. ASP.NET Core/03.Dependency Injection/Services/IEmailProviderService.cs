using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _03.Dependency_Injection.Services
{
    public interface IEmailProviderService
    {
        string Send();
    }
}
