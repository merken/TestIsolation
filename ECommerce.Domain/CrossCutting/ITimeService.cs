using System;

namespace ECommerce.Domain.CrossCutting
{
    public interface ITimeService
    {
        DateTimeOffset Now();
    }
}