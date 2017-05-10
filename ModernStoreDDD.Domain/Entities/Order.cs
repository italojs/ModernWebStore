using FluentValidator;
using ModernStoreDDD.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebStoreDDD.SheredKernel;

namespace ModernStoreDDD.Domain.Entities
{
    public class Order : Entity
    {
        public Order(decimal deliveryFee, decimal discount, Customer customer)
        {
            Custumer = customer;
            CreationDate = DateTime.Now;
            Number = Guid.NewGuid().ToString().Substring(0,8).ToUpper();
            Status = EOrderStatus.Created;
            Itens = new List<OrderItem>();
            DeliveryFee = deliveryFee;
            Discount = discount;

            Validate();
        }
        #region Fields
        private IList<OrderItem> _itens;
        private Dictionary<string, string> _notafications;
        #endregion

        #region Properties
        public Customer Custumer { get; private set; }
        public DateTime CreationDate { get; private set; }
        public string Number { get; private set; }
        public EOrderStatus Status { get; private set; }
        public IReadOnlyCollection<OrderItem> Itens { get { return Itens.ToArray(); } private set { } }
        public decimal DeliveryFee { get; private set; }
        public decimal Discount { get; private set; }

        public decimal SubTotal() => Itens.Sum(x => x.Total());
        public decimal Total() => SubTotal() + DeliveryFee - Discount;
        #endregion
        public void AddItem(OrderItem item)
        {
            AddNotifications(item.Notifications);//ver qual o sentido dessa linha *******************************
            if (item.IsValid())
            {
                _itens.Add(item);
            }
        }

        private void Validate()
        {
            _notafications = _notafications ?? new Dictionary<string, string>();

            new ValidationContract<Order>(this)
                .IsGreaterThan(x => x.Discount, -1)
                .IsGreaterThan(x => x.DeliveryFee, 0);

        }

    }
}
