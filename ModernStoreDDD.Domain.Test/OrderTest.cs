using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModernStoreDDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModernStoreDDD.Domain.Test
{
    [TestClass]
    public class OrderTest
    {

        [TestMethod]
        [TestCategory("Order - new Order")]
        public void Givens_An_Out_Of_Stock_Product_It_Should_Return_An_Error()
        {
            User user = new User("italojs", "senha");
            Customer customer = new Customer(user, "italo", "oliveira", "Italo@teste.com");

            Product prod = new Product("mouse", 99, 100, "image.jpg");
            Product prod1 = new Product("teclado", 20, 10, "image.jpg");
            Product prod2 = new Product("monitor", 979, 160, "image.jpg");

            Order order = new Order(10, 0, customer);
            order.AddItem(new OrderItem(prod, 1000));
            order.AddItem(new OrderItem(prod1, 1));
            order.AddItem(new OrderItem(prod2, 10));

            Assert.IsFalse(order.IsValid());
        }
    }
}
