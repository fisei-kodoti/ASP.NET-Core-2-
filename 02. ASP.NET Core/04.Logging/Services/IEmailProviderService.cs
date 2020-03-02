using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _04.Logging.Services
{
    public interface IEmailProviderService
    {
        string Send();
    }
}
