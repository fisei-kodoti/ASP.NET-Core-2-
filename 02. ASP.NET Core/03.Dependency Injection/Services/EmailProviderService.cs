using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _03.Dependency_Injection.Services
{
    public class EmailProviderAService : IEmailProviderService
    {
        public string Send()
        {
            //throw new NotImplementedException();
            return this.GetType().Name;// Retorna el nombre de la clase
        }
    }

    public class EmailProviderBService : IEmailProviderService
    {
        public string Send()
        {
            //throw new NotImplementedException();
            return this.GetType().Name;// Retorna el nombre de la clase
        }
    }
}
