using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Text.RegularExpressions;

namespace WpfApp1
{
    public class Meth_Cabinet
    {
        public bool Digit_Check(string text)
        {
            Regex regex = new Regex("[^0-9]+");
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
                int conv_number = Convert.ToInt32(number);
                Cabinet cabinet = new Cabinet();
                if (string.IsNullOrWhiteSpace(number))
                {
                    MessageBox.Show("Вы не заполнили поле.", "Основное окно", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else if (db.Cabinets.Where(i => i.number == conv_number).FirstOrDefault() != null)
                {
                    MessageBox.Show("Такой кабинет уже есть в списке.", "Основное окно", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else
                {
                    cabinet.number = conv_number;
                    db.Cabinets.Add(cabinet);
                    db.SaveChanges();
                    MessageBox.Show("Кабинет добавлен.", "Основное окно", MessageBoxButton.OK, MessageBoxImage.Information);
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
                var d_cab = db.Cabinets.Where(i => i.id == num).FirstOrDefault();
                if (d_cab == null)
                {
                    MessageBox.Show("Вы не выбрали строку.", "Основное окно", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else
                {
                    db.Cabinets.Remove(d_cab);
                    db.SaveChanges();
                    MessageBox.Show("Кабинет удален.", "Основное окно", MessageBoxButton.OK, MessageBoxImage.Information);
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
                int num = Convert.ToInt32(id),
                    conv_number = Convert.ToInt32(number);
                                var u_cab = db.Cabinets.Where(u => u.id == num).FirstOrDefault();
                if (string.IsNullOrWhiteSpace(number))
                {
                    MessageBox.Show("Вы не заполнили поле.", "Основное окно", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else if (db.Cabinets.Where(i => i.number == conv_number).FirstOrDefault() != null)
                {
                    MessageBox.Show("Такой кабинет уже есть в списке.", "Основное окно", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }

                else if (u_cab == null)
                {
                    MessageBox.Show("Вы не выбрали строку.", "Основное окно", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                u_cab.number = conv_number;
                db.SaveChanges();
                MessageBox.Show("Кабинет изменен", "Основное окно", MessageBoxButton.OK, MessageBoxImage.Information);
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
