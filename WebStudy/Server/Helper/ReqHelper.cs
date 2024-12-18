using Proto;

namespace WebStudyServer.Helper
{
    // 요청 데이터가 유효한지 검증하는 헬퍼 클래스
    public static class ReqHelper
    {
        public static void Valid(bool isValid, EErrorCode errorCode, Func<dynamic> getArgsFunc = null)
            => Valid(isValid, (int)errorCode, errorCode.ToString(), getArgsFunc);

        public static void Valid(bool isValid, int errorCode, string message, Func<dynamic> getArgsFunc = null)
        {
            if (!isValid)
            {
                dynamic args = null;
                if (getArgsFunc != null)
                {
                    args = getArgsFunc();
                }

                throw new GameException(errorCode, message, args);
            }
        }

        public static void ValidParam(bool isValid, string message, Func<dynamic> getArgsFunc = null)
        {
            Valid(isValid, (int)EErrorCode.PARAM, message, getArgsFunc);
        }

        public static void ValidContext(bool isValid, string message, Func<dynamic> getArgsFunc = null)
        {
            Valid(isValid, (int)EErrorCode.CONTEXT, message, getArgsFunc);
        }

        public static void ValidProto(bool isValid, string message, Func<dynamic> getArgsFunc = null)
        {
            Valid(isValid, (int)EErrorCode.PROTO, message, getArgsFunc);
        }
    }
}
