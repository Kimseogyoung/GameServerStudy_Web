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
    public enum ESessionState
    {
        NONE = 0,
        ACTIVE = 1,
        EXPIRED = 2
    }

    public enum EAccountState
    {
        NONE = 0,
        ACTIVE = 1,
    }

    public enum EChannelState
    {
        NONE = 0,
        ACTIVE = 1
    }

    public enum EChannelType
    {
        NONE = 0,
        GUEST = 1
    }

    public enum EDeviceState
    {
        NONE = 0,
        ACTIVE = 1
    }
}
