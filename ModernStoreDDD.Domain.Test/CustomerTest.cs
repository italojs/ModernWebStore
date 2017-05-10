using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModernStoreDDD.Domain.Entities;

namespace ModernStoreDDD.Domain.Test
{
    [TestClass]
    public class CustomerTest
    {
        private readonly User user = new User("usuario", "password");

        [TestMethod]
        [TestCategory("Customer - New Customer")]
        public void Given_A_Invalid_Customer_Should_Return_A_Notification()
        { 
            Customer customer = new Customer(user, "", "", "Italose.com");
            Assert.IsFalse(customer.IsValid());
        }

        [TestMethod]
        [TestCategory("Customer - New Customer")]
        public void Given_A_Invalid_Email_Should_Return_A_Notification()
        {
            Customer customer = new Customer(user, "italo", "oliveira", "Italose.com");
            Assert.IsFalse(customer.IsValid());
        }

        [TestMethod]
        [TestCategory("Customer - New Customer")]
        public void Given_A_Invalid_FirstName_Should_Return_A_Notification()
        {
            Customer customer = new Customer(user, "", "oliveira", "Italo@testese.com");
            Assert.IsFalse(customer.IsValid());
        }

        [TestMethod]
        [TestCategory("Customer - New Customer")]
        public void Given_A_Invalid_LastName_Should_Return_A_Notification()
        {
            Customer customer = new Customer(user, "italo", "", "Italo@testese.com");
            Assert.IsFalse(customer.IsValid());
        }
    }
}
