using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPRG211_Group1_FinalProject.Exceptions
{ 
    public class InvalidFormatException : Exception
    {
        public InvalidFormatException(string message) : base(message) { }
    }
}
