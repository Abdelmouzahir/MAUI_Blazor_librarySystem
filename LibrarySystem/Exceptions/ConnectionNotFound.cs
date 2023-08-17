using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Exceptions
{
    internal class ConnectionNotFound : Exception
    {
        //this exception is thrown when the connection is not found
        public ConnectionNotFound() : base("Sorry! we cannot find the connection! ")
        {
        }

        
    }
}
