using FluentValidator;
using System;

namespace WebStoreDDD.SheredKernel
{
    public abstract class Entity : Notifiable
    {
        protected Entity()
        {
            Id = Guid.NewGuid();
        }
        protected Guid Id { get; set; }
    }
}
