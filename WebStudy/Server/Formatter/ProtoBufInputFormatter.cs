using Microsoft.AspNetCore.Mvc.Formatters;
using Protocol;
using ProtoBuf;

namespace WebStudyServer
{
    public class ProtoBufInputFormatter : InputFormatter
    {

        public ProtoBufInputFormatter()
        {
            SupportedMediaTypes.Add(MsgProtocol.ProtoBufContentType);
        }

        public override async Task<InputFormatterResult> ReadRequestBodyAsync(InputFormatterContext context)
        {
            var request = context.HttpContext.Request;
            var result = Serializer.Deserialize(context.ModelType, request.Body);
            return await InputFormatterResult.SuccessAsync(result).ConfigureAwait(false);
        }
    }
}
