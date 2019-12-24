using System;

namespace GMBAcademy.Domain.Entities.Base
{
    public interface IEntity
    {
        Guid Id { get; set; }
        bool IsActive { get; set; }
    }
}