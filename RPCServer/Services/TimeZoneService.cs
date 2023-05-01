using Grpc.Core;
using RPCServer;
using RPCServer.Models.TimeZoneMapper;

namespace RPCServer.Services
{
    public class TimeZoneService : Clock.ClockBase
    {
        private ITimeZoneMapper _timezoneMapper;

        public TimeZoneService(ITimeZoneMapper timezoneMapper)
        {
            _timezoneMapper = timezoneMapper;
        }

        public override Task<TimeReply> GetTime(TimeRequest request, ServerCallContext context)
        {
            var timeShift = _timezoneMapper.GetTimeDifference(request.Timezone);
            var currentTime = DateTime.UtcNow.AddHours(timeShift);
            return Task.FromResult<TimeReply>(new TimeReply()
            {
                Message = currentTime.Ticks
            });
        }
    }
}
