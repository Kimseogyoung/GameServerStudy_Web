using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proto
{

    public enum EErrorCode
    {
        NO_HANDLING_ERROR = -1,
        OK = 1,


        TIMEOUT = 101,
        PROCESSED = 102, //이미 처리된 요청
        CANCELED_OPERATION = 103,
    }

    public enum ERpcContextState
    {
        NONE = 0,
        LOADED = 1,
    }
}
