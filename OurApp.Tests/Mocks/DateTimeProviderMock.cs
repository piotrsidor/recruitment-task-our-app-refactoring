using System;
using Moq;
using OurApp.Services;

namespace OurApp.Tests.Mocks
{
    public class DateTimeProviderMock : Mock<IDateTimeProvider>
    {
        public DateTimeProviderMock MockNow()
        {
            Setup(x => x.Now)
                .Returns(new DateTime(2023, 7, 8));

            return this;
        }
    }
}