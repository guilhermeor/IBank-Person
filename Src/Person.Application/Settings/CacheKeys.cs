using System;

namespace Person.Application.Settings
{
    public static class CacheKeys
    {
        public static string Person(Guid id) => $"person_{DateTime.Now.ToShortDateString()}_{id}";
    }
}
