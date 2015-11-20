using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TS3Connection
{
    class TS3Exception : Exception
    {

        public TS3Exception() : base()
        {
        }

        public TS3Exception(String message) : base(message)
        {
        }
    }
}
