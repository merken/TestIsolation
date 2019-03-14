using System;

namespace ECommerce.Domain.CrossCutting
{
    public interface IEntityValidator<T>
    {
        void Validate(T entity);
    }
}