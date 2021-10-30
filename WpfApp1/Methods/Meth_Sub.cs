using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Text.RegularExpressions;

namespace WpfApp1
{
    public class Meth_Sub
    {
        public bool Word_Check(string text)
        {
            Regex regex = new Regex("[^А-ЯЁа-яё]+");
            bool check = regex.IsMatch(text);
            if (check == true)
            {
                return false;
            }
            else return true;
        }
        public bool Add(string name)
        {
            dbEntities1 db = new dbEntities1();
            try
            {
                Subject subject = new Subject();
                if (string.IsNullOrWhiteSpace(name))
                {
                    MessageBox.Show("Вы не заполнили поле.", "Основное окно", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else if (db.Subjects.Where(i => i.name == name).FirstOrDefault() != null)
                {
                    MessageBox.Show("Такой предмет уже есть в списке.", "Основное окно", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else
                {
                    subject.name = name;
                    db.Subjects.Add(subject);
                    db.SaveChanges();
                    MessageBox.Show("Предмет добавлен.", "Основное окно", MessageBoxButton.OK, MessageBoxImage.Information);
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
                var d_sub = db.Subjects.Where(i => i.id == num).FirstOrDefault();
                if (d_sub == null)
                {
                    MessageBox.Show("Вы не выбрали строку.", "Основное окно", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else
                {
                    db.Subjects.Remove(d_sub);
                    db.SaveChanges();
                    MessageBox.Show("Предмет удален.", "Основное окно", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch
            {
                MessageBox.Show("Внесите корректные значения.", "Основное окно", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }
        public bool Update(string id, string name)
        {
            dbEntities1 db = new dbEntities1();
            try
            {
                int num = Convert.ToInt32(id);
                var u_sub = db.Subjects.Where(u => u.id == num).FirstOrDefault();
                if (string.IsNullOrWhiteSpace(name))
                {
                    MessageBox.Show("Вы не заполнили поле.", "Основное окно", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else if (db.Subjects.Where(i => i.name == name).FirstOrDefault() != null)
                {
                    MessageBox.Show("Такой предмет уже есть в списке.", "Основное окно", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else if (u_sub == null)
                {
                    MessageBox.Show("Вы не выбрали строку.", "Основное окно", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                u_sub.name = name;
                db.SaveChanges();
                MessageBox.Show("Предемет изменен", "Основное окно", MessageBoxButton.OK, MessageBoxImage.Information);
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
