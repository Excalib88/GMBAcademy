using System;
using System.Collections.Generic;
using System.Text;

namespace GMBAcademy.Domain.Entities.Base
{
    public class BaseEntity: IEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public bool IsActive { get; set; } = true;
    }
}
