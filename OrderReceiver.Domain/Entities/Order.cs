using OrderReceiver.Domain.Error;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OrderReceiver.Domain.Entities
{
    public class Order : EntityBase
    {
        public Order()
        {
            this.OrderItems = new List<OrderItem>();
        }

        public virtual IList<OrderItem> OrderItems { get; set; }

        public string Number { get; set; }

        [ForeignKey("Customer")]
        public Guid CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        public DateTime? CreationDate { get; set; }        

        public List<ApplicationError> IsValid()
        {
            List<ApplicationError> errors = new List<ApplicationError>();

            if (string.IsNullOrEmpty(Number))
                errors.Add(new ApplicationError("Numero deve ser preenchido."));
            if (CustomerId == Guid.Empty)
                errors.Add(new ApplicationError("Cliente deve ser preenchido."));

            if (this.OrderItems.Count > 0)
            {
                var contItem = 1;
                foreach (var item in OrderItems)
                {
                    if (item.ProductId == null || item.ProductId == Guid.Empty)
                        errors.Add(new ApplicationError($"Produto do item {contItem} deve ser preenchido."));

                    if (item.Quantity <= 0)
                        errors.Add(new ApplicationError($"Quantidade do item {contItem} deve ser preenchida."));

                    if (item.UnitPrice <= 0)
                        errors.Add(new ApplicationError($"Preço do item {contItem} deve ser preenchido."));

                    contItem++;
                }
            }

            return errors;
        }
    }
}
