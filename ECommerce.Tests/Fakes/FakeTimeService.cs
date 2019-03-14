using System;
using ECommerce.Domain.CrossCutting;

namespace ECommerce.Tests.Fakes
{
    public class FakeTimeService : ITimeService
    {
        private DateTimeOffset now;
        public FakeTimeService WithNowTime(DateTimeOffset now)
        {
            this.now = now;
            return this;
        }

        public DateTimeOffset Now()
        {
            return this.now;
        }
    }
}
