﻿namespace Protocol
{
    public abstract class BaseResponsePacket
    {
        public ResponseResultPacket Result { get; set; } = new();
    }

    public class ResponseResultPacket
    {
        public int Code { get; set; }
        public int Msg { get; set; }
    }
}
