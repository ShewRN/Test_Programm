using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Text.RegularExpressions;

namespace WpfApp1
{
    public class Meth_T
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

        public bool Add(string last, string first, string middle, Cabinet cabinet, Class clas, Subject subject, string date, string time)
        {
            dbEntities1 db = new dbEntities1();
            Teacher teacher = new Teacher();
            try
            {
                if (string.IsNullOrWhiteSpace(last) || string.IsNullOrWhiteSpace(first) || string.IsNullOrWhiteSpace(middle) || string.IsNullOrWhiteSpace(date) || string.IsNullOrWhiteSpace(time))
                {
                    MessageBox.Show("Заполнены не все поля.", "Основное окно", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else if (cabinet == null || clas == null || subject == null)
                {
                    MessageBox.Show("Вы выбрали не все элементы", "Основное окно", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                DateTime.TryParse(date, out DateTime conv_date);
                teacher.last_name = last;
                teacher.first_name = first;
                teacher.middle_name = middle;
                teacher.id_cabinet = cabinet.id;
                teacher.id_class = clas.id;
                teacher.id_subject = subject.id;
                teacher.date = conv_date;
                teacher.time = time;
                db.Teachers.Add(teacher);
                db.SaveChanges();
                MessageBox.Show("Учитель добавлен", "Основное окно", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch
            {
                MessageBox.Show("Введите корректные значения.", "Основное окно", MessageBoxButton.OK, MessageBoxImage.Error);
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
                var d_t = db.Teachers.Where(i => i.id == num).FirstOrDefault();
                if (d_t == null)
                {
                    MessageBox.Show("Вы не выбрали строку.", "Основное окно", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else
                {
                    db.Teachers.Remove(d_t);
                    db.SaveChanges();
                    MessageBox.Show("Учитель удалён", "Основное окно", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch
            {
                MessageBox.Show("Введите корректные значения.", "Основное окно", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }
        public bool Update(string id, string last, string first, string middle, Cabinet cabinet, Class clas, Subject subject, string date, string time)
        {
            dbEntities1 db = new dbEntities1();
            try
            {
                int num = Convert.ToInt32(id);
                var u_t = db.Teachers.Where(u => u.id == num).FirstOrDefault();
                if (u_t == null)
                {
                    MessageBox.Show("Вы не выбрали строку.", "Основное окно", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else if (string.IsNullOrWhiteSpace(last) || string.IsNullOrWhiteSpace(first) || string.IsNullOrWhiteSpace(middle) || string.IsNullOrWhiteSpace(date) || string.IsNullOrWhiteSpace(time))
                {
                    MessageBox.Show("Заполнены не все поля.", "Основное окно", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else if (cabinet == null || clas == null || subject == null)
                {
                    MessageBox.Show("Вы выбрали не все элементы", "Основное окно", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                DateTime.TryParse(date, out DateTime conv_date);
                u_t.last_name = last;
                u_t.first_name = first;
                u_t.middle_name = middle;
                u_t.id_cabinet = cabinet.id;
                u_t.id_class = clas.id;
                u_t.id_subject = subject.id;
                u_t.date = conv_date;
                u_t.time = time;
                db.SaveChanges();
                MessageBox.Show("Учитель изменён", "Основное окно", MessageBoxButton.OK, MessageBoxImage.Information);
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
