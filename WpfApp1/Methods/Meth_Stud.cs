using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Text.RegularExpressions;

namespace WpfApp1
{
    public class Meth_Stud
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

        public bool Add(string last, string first, string middle, Class clas)
        {
            dbEntities1 db = new dbEntities1();
            Student student = new Student();
            try
            {
                if (string.IsNullOrWhiteSpace(last) || string.IsNullOrWhiteSpace(first) || string.IsNullOrWhiteSpace(middle))
                {
                    MessageBox.Show("Заполнены не все поля.", "Основное окно", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else if (clas == null)
                {
                    MessageBox.Show("Вы не выбрали класс", "Основное окно", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                student.last_name = last;
                student.first_name = first;
                student.middle_name = middle;
                student.id_class = clas.id;
                db.Students.Add(student);
                db.SaveChanges();
                MessageBox.Show("Ученик добавлен", "Основное окно", MessageBoxButton.OK, MessageBoxImage.Information);
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
                var d_s = db.Students.Where(i => i.id == num).FirstOrDefault();
                if (d_s == null)
                {
                    MessageBox.Show("Вы не выбрали строку.", "Основное окно", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else
                {
                    db.Students.Remove(d_s);
                    db.SaveChanges();
                    MessageBox.Show("Ученик удалён", "Основное окно", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch
            {
                MessageBox.Show("Введите корректные значения.", "Основное окно", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }
        public bool Update(string id, string last, string first, string middle, Class clas)
        {
            dbEntities1 db = new dbEntities1();
            try
            {
                int num = Convert.ToInt32(id);
                var u_s = db.Students.Where(u => u.id == num).FirstOrDefault();
                if (u_s == null)
                {
                    MessageBox.Show("Вы не выбрали строку.", "Основное окно", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else if (string.IsNullOrWhiteSpace(last) || string.IsNullOrWhiteSpace(first) || string.IsNullOrWhiteSpace(middle))
                {
                    MessageBox.Show("Заполнены не все поля.", "Основное окно", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else if (clas == null)
                {
                    MessageBox.Show("Вы не выбрали класс", "Основное окно", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                u_s.last_name = last;
                u_s.first_name = first;
                u_s.middle_name = middle;
                u_s.id_class = clas.id;
                db.SaveChanges();
                MessageBox.Show("Ученик изменён", "Основное окно", MessageBoxButton.OK, MessageBoxImage.Information);
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
