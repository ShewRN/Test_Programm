using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp1
{
    public class Meth_Auth
    {
        public bool Enter(string login, string password)
        {
            dbEntities1 db = new dbEntities1();
            if (login == "" || password == "")
            {
                MessageBox.Show("Вы не заполнили все поля", "Авторизация", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            var auth_check = db.Users.FirstOrDefault(ch => ch.login == login && ch.password == password);
            if (auth_check == null)
            {
                MessageBox.Show("Логин или пароль введены не верно", "Авторизация", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }
    }
}
