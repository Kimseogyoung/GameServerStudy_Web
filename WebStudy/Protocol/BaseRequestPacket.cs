namespace Protocol
{
    public interface IReqPacket
    {
        public string GetProtocolName();
    }

    public abstract class BaseRequestPacket
    {
        public abstract string GetProtocolName();
        public RequestInfoPacket Info { get; set; } = new();

    }

    public class RequestInfoPacket
    {
        public int Seq { get; set; }
    }
}
