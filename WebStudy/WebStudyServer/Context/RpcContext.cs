using Proto;

namespace WebStudyServer
{
    public class RpcContext
    {
        public string SessionId { get; private set; } = string.Empty;

        public ulong AccountId { get; private set; }

        public ulong PlayerId { get; private set; }

        public string Ip { get; private set; } = string.Empty;

        public int ShardId { get; private set; }

        public DateTime ServerTime { get; private set; } = DateTime.UtcNow;

        public DateTime PlayerTime { get; private set; } = DateTime.UtcNow;

        public int Seq { get; private set; }


        public RpcContext()
        {

        }

        public void Init()
        {
            if (_state == ERpcContextState.LOADED)
            {
                return;
            }

            _state = ERpcContextState.LOADED;

            // TODO: 세션 로드

            // TODO: 플레이어 정보 로드

            // TODO: 요청 정보 로드
        }

        private ERpcContextState _state = ERpcContextState.NONE;
    }
}
