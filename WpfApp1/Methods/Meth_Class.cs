using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Text.RegularExpressions;

namespace WpfApp1
{
    public class Meth_Class
    {
        public bool WD_Check(string text)
        {
            Regex regex = new Regex("[^0-9А-ЯЁа-яё]+");
            bool check = regex.IsMatch(text);
            if (check == true)
            {
                return false;
            }
            else return true;
        }
        public bool Add(string number)
        {
            dbEntities1 db = new dbEntities1();
            try
            {
                Class clas = new Class();
                if (string.IsNullOrWhiteSpace(number))
                {
                    MessageBox.Show("Вы не заполнили поле.", "Основное окно", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else if (db.Classes.Where(i => i.number == number).FirstOrDefault() != null)
                {
                    MessageBox.Show("Такой класс уже есть в списке.", "Основное окно", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else
                {
                    clas.number = number;
                    db.Classes.Add(clas);
                    db.SaveChanges();
                    MessageBox.Show("Класс добавлен.", "Основное окно", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch
            {
                MessageBox.Show("Внесите корректные значения", "Основное окно", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;

            }
            return true;
        }
        public bool Delete(string id)
        {
            dbEntities1 db = new dbEntities1();
            try
            {
                int num = Convert.ToInt32(id);
                var d_clas = db.Classes.Where(i => i.id == num).FirstOrDefault();
                if (d_clas == null)
                {
                    MessageBox.Show("Вы не выбрали строку.", "Основное окно", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else
                {
                    db.Classes.Remove(d_clas);
                    db.SaveChanges();
                    MessageBox.Show("Класс удален.", "Основное окно", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch
            {
                MessageBox.Show("Внесите корректные значения.", "Основное окно", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }
        public bool Update(string id, string number)
        {
            dbEntities1 db = new dbEntities1();
            try
            {
                int num = Convert.ToInt32(id);
                var u_clas = db.Classes.Where(u => u.id == num).FirstOrDefault();
                if (string.IsNullOrWhiteSpace(number))
                {
                    MessageBox.Show("Вы не заполнили поле.", "Основное окно", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else if (db.Classes.Where(i => i.number == number).FirstOrDefault() != null)
                {
                    MessageBox.Show("Такой класс уже есть в списке.", "Основное окно", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else if (u_clas == null)
                {
                    MessageBox.Show("Вы не выбрали строку.", "Основное окно", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                u_clas.number = number;
                db.SaveChanges();
                MessageBox.Show("Класс изменен", "Основное окно", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch
            {
                MessageBox.Show("Введите корректные значения.", "Основное окно", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }
    }
}
