using GMBAcademy.Domain.Entities.Base;

namespace GMBAcademy.Domain.Entities
{
    public class Customer: BaseEntity
    {
        public string Name { get; set; }

        public string Mail { get; set; }

        public string Phone { get; set; }
    }
}
