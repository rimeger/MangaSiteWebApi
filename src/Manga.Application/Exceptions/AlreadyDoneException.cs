using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manga.Application.Exceptions
{
    public class AlreadyDoneException : Exception
    {
        public AlreadyDoneException(string message) : base(message) { }
    }
}
