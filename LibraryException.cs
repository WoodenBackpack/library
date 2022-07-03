using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    internal class LibraryException : Exception
    {
        public LibraryException(string message) : base(message) { }
    }
}
