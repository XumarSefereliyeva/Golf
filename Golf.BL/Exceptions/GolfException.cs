using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Golf.BL.Exceptions
{
    public class GolfException:Exception
    {
        public GolfException():base("Default message")
        {
                
        }
        public GolfException(string errormessage):base(errormessage) 
        {
                
        }
    }
}
