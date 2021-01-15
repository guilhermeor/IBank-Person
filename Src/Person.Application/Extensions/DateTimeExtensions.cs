using Microsoft.Extensions.Caching.Distributed;
using System;

namespace Person.Application.Extensions
{
    public static class DateTimeExtensions
    {
        public static DistributedCacheEntryOptions UntilMidnight(this DateTime dateTime)
        {
            var untilMidnight = DateTime.Today.AddDays(1.0) - dateTime;
            return new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(untilMidnight.TotalSeconds)
            };
        }
    }
}
