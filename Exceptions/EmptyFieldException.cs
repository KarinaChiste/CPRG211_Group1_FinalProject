using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPRG211_Group1_FinalProject.Exceptions
{
    public class EmptyFieldException : Exception
    {
        public EmptyFieldException(string field) : base($"{field} cannot be empty or whitespace") { }
    }
}
