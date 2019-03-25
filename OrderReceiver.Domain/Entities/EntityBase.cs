using System;
using System.ComponentModel.DataAnnotations;

namespace OrderReceiver.Domain.Entities
{
    public class EntityBase
    {
        public EntityBase()
        {
            this.Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }       
    }
}
