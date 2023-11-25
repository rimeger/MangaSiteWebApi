using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manga.Application.Exceptions
{
    public class InvalidCredentials : Exception
    {
        public InvalidCredentials(string message) : base(message) { }
    }
}
