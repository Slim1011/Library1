using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library1.Models
{
    public class ClientException : Exception
    {
        public ClientException(string name): base(name)
        {

        }
    }
}
