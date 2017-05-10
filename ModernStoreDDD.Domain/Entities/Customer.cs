using FluentValidator;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModernStoreDDD.Domain.Entities
{
    public class Customer : Notifiable
    {
        #region Contructors
        public Customer(User user, string firstName, string lastName, string email)
        {
            Id = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            User = user;

            Validate();
        }
        #endregion

        #region Fields
        private Dictionary<string, string> _notafications;
        #endregion

        #region Properties
        //Guid está sendo usado apenas para testes, ele gera um numero randomico que dificilmente vai se repetir
        public Guid Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateTime? BirthDay { get; private set; }
        public string Email { get; private set; }
        public User User { get; private set; }
        #endregion

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }

        public void SetBirthDay(DateTime birthDay)
        {
            //validação
            BirthDay = birthDay;
        }

        private void Validate()
        {
            _notafications = _notafications ?? new Dictionary<string, string>();

            new ValidationContract<Customer>(this)
                .IsRequired(x => x.FirstName)
                .HasMaxLenght(x => x.FirstName, 60)
                .HasMinLenght(x => x.FirstName, 2);

            new ValidationContract<Customer>(this)
                .IsRequired(x => x.LastName)
                .HasMaxLenght(x => x.LastName, 60)
                .HasMinLenght(x => x.LastName, 2);

            new ValidationContract<Customer>(this)
                .IsEmail(x => x.Email,"este Email é invalido");

        }
    }
}
