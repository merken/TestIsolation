using System;

namespace ECommerce.Domain.CrossCutting
{
    public class EntityValidationException<T> : Exception
    {
        public EntityValidationException(string message) : base($"Entity {typeof(T)} is invalid because {message}")
        {
        }
    }
}