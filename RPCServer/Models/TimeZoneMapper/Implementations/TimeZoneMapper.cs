namespace RPCServer.Models.TimeZoneMapper.Implementations
{
    public class TimeZoneMapper : ITimeZoneMapper
    {
        public int GetTimeDifference(string timezone)
        {
            return timezone.ToUpper() switch
            {
                "BST" => 1,
                "WAT" => 1,
                "WEST" => 1,
                "CEST" => 2,
                "MSK" => 3,
                "KST" => 9,
                "JST" => 9,
                "AEST" => 10,
                "PDT" => -7,
                "EDT" => -4,
                _ => 0
            };
        }
    }
}
