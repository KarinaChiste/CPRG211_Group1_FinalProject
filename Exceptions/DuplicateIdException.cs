using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPRG211_Group1_FinalProject.Exceptions
{
    class DuplicateIdException:Exception
    {
        public DuplicateIdException() : base("ID is already being used. Please enter unique ID.") {  }
    }
}
