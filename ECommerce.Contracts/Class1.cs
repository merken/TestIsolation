using System;
using System.Collections.Generic;

namespace ECommerce.Contracts
{
    public interface IRepository
    {

    }

    public class PagingInfo
    {
        public int Page { get; set; }
        public int Size { get; set; }
    }

    public interface IRepository<T> : IRepository
    {
        T GetById(int id);
        ICollection<T> GetAll(PagingInfo pagingInfo = null);
    }

    public interface ICustomerRepository
    {
    }
}
