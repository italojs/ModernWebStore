using FluentValidator;
using System.Collections.Generic;
using WebStoreDDD.SheredKernel;

namespace ModernStoreDDD.Domain.Entities
{
    public class OrderItem : Entity
    {
        public OrderItem(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
            Price = Product.Price;

            Validate();
        }

        private Dictionary<string, string> _notafications;

        public Product Product { get; private set; }
        public int Quantity { get; private set; }
        public decimal Price { get; private set; }

        public decimal Total() => Price * Quantity;

        private void Validate()
        {
            _notafications = _notafications ?? new Dictionary<string, string>();

            new ValidationContract<OrderItem>(this)
                .IsGreaterThan(x => x.Quantity, 0)
                .IsGreaterOrEqualsThan(x => x.Product.QuantityOnHand, Quantity, "Não temos tantos produtos assim em estoque");

            Product.DecreseQuantityOnHand(Quantity);
        }

    }
}
