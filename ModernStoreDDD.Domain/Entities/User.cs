using System;
using System.Collections.Generic;
using System.Text;

namespace ModernStoreDDD.Domain.Entities
{
    public class User
    {
        public User(string userName, string passWord)
        {
            UserName = userName;
            PassWord = passWord;
        }

        public string UserName { get; private set; }
        public string PassWord { get; private set; }
        public bool IsActive { get; private set; }

        public void Activete() => IsActive = true;
        public void Desactivate() => IsActive = false;

    }
}
