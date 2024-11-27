using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protocol
{
    public class AuthSignUpResPacket : BaseResponsePacket
    {
        public string SessionKey { get; set; }
    }

    public class AuthSignInResPacket : BaseResponsePacket
    {
        public string SessionKey { get; set; }
    }
}
