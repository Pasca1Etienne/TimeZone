using Grpc.Core;
using RPCServer;

namespace RPCServer.Services
{
    public class TimeZoneService : Clock.ClockBase
    {
        public override Task<TimeReply> GetTime(TimeRequest request, ServerCallContext context)
        {
            var currentTime = DateTime.UtcNow;
            return Task.FromResult<TimeReply>(new TimeReply()
            {
                Message = currentTime.Ticks
            });
        }
    }
}
