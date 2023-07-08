using System;

namespace OurApp.Services
{
    public class DataTimeProvider : IDateTimeProvider
    {
        public DateTime Now => DateTime.Now;
    }
}