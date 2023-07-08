using System;

namespace OurApp.Services
{
    public interface IDateTimeProvider
    {
        public DateTime Now { get; }
    }
}