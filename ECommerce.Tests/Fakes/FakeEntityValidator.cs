using System;
using System.Collections.Generic;
using ECommerce.Domain.CrossCutting;

namespace ECommerce.Tests.Fakes
{
    public class FakeEntityValidator<T> : IEntityValidator<T>
    {
        private EntityValidationException<T> exception;

        public FakeEntityValidator<T> WithValidationMessage(string message)
        {
            this.exception = new EntityValidationException<T>(message);
            return this;
        }

        public void Validate(T entity)
        {
            if (this.exception != null)
                throw this.exception;
        }
    }

    public class FakeEntityQueueValidator<T> : IEntityValidator<T>
    {
        private Queue<EntityValidationException<T>> exceptionQueue;

        public FakeEntityQueueValidator() { this.exceptionQueue = new Queue<EntityValidationException<T>>(); }

        public FakeEntityQueueValidator<T> AddValidationMessage(string message)
        {
            this.exceptionQueue.Enqueue(new EntityValidationException<T>(message));
            return this;
        }

        public void Validate(T entity)
        {
            EntityValidationException<T> exception = null;
            if (this.exceptionQueue.TryDequeue(out exception))
            {
                throw exception;
            }
            throw new InvalidOperationException("Fake queue was empty");
        }
    }
}