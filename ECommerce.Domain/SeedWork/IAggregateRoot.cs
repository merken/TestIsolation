using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using ECommerce.Domain.CrossCutting;

namespace ECommerce.Domain.SeedWork
{
    public interface IAggregateRoot
    {
        int Id { get; }
    }
}