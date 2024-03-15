using System;
using Volo.Abp.DependencyInjection;

namespace Bizimgoz.Monitoring.Helpers.TimeStampConverters
{
    public class TimeStampConverter : ITransientDependency
    {
        readonly string timeZoneId = "Turkey Standard Time";
        public string Convert(string TimeStampString)
        {
            if (long.TryParse(TimeStampString, out long unixTimeStamp))
            {
                TimeSpan timeSpan = TimeSpan.FromSeconds(unixTimeStamp);
                TimeZoneInfo timeZone = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
                DateTimeOffset unixEpoch = new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero);
                DateTimeOffset dateTimeOffset = unixEpoch.Add(timeSpan).ToOffset(timeZone.GetUtcOffset(unixEpoch));

                return dateTimeOffset.ToString();
            }
            else
            {
                return "invalid time";
            }
        }
    }
}
