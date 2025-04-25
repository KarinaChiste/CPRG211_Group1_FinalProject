using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPRG211_Group1_FinalProject.Exceptions
{
    class TypeNotSelectedException:Exception
    {
        public TypeNotSelectedException() : base("Type must be selected") { } 
    }
}
