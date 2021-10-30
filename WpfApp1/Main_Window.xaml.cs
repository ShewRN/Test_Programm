using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Main_Window.xaml
    /// </summary>
    public partial class Main_Window : Window
    {
        Meth_Cabinet meth_cab = new Meth_Cabinet();
        Meth_Class meth_class = new Meth_Class();
        Meth_Sub meth_sub = new Meth_Sub();
        Meth_Stud meth_stud = new Meth_Stud();
        Meth_T meth_t = new Meth_T();
        dbEntities1 db;
        public Main_Window()
        {
            InitializeComponent();
            db = new dbEntities1();
        }
        //сортировка полей на ввод только кириллицы
        private void Word_Check_Stud(object sender, TextCompositionEventArgs e)
        {
            if (meth_stud.Word_Check(e.Text) == false)
            {
                e.Handled = true;
            }
        }
        private void Word_Check_Sub(object sender, TextCompositionEventArgs e)
        {
            if (meth_sub.Word_Check(e.Text) == false)
            {
                e.Handled = true;
            }
        }
        private void Word_Check_T(object sender, TextCompositionEventArgs e)
        {
            if (meth_t.Word_Check(e.Text) == false)
            {
                e.Handled = true;
            }
        }
        //сортировка полей на ввод только чисел
        private void Digit_Check(object sender, TextCompositionEventArgs e)
        {
            if ((meth_cab.Digit_Check(e.Text) == false))
            {
                e.Handled = true;
            }
        }

        //сортировка полей на ввод чисел и кириллицы
        private void WD_Check(object sender, TextCompositionEventArgs e)
        {
            if ((meth_class.WD_Check(e.Text) == false))
            {
                e.Handled = true;
            }
        }

        //STUDENT
        private void Student_Insert(object sender, RoutedEventArgs e)
        {
            if (meth_stud.Add(Student_last.Text, Student_first.Text, Student_middle.Text, Cb_Stud_Class.SelectedItem as Class) == true)
            {
                Student_last.Clear();
                Student_first.Clear();
                Student_middle.Clear();
                Cb_Stud_Class.SelectedIndex = -1;
            }
            Table_Student.ItemsSource = db.Students.ToList();
            Cb_Stud_Class.ItemsSource = db.Classes.ToList();
        }
        private void Student_Delete(object sender, RoutedEventArgs e)
        {
            Student student = Table_Student.SelectedItem as Student;
            if (Table_Student.SelectedItem == null)
            {
                MessageBox.Show("Вы не выбрали строку.", "Основное окно", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            var d_s = db.Students.Where(i => i.id == student.id).FirstOrDefault();
            meth_stud.Delete(student != null ? student.id.ToString() : "0");
            Table_Student.ItemsSource = db.Students.ToList();
            Cb_Stud_Class.ItemsSource = db.Classes.ToList();
        }
        private void Student_Update(object sender, RoutedEventArgs e)
        {
            Student student = Table_Student.SelectedItem as Student;
            if (Table_Student.SelectedItem == null)
            {
                MessageBox.Show("Вы не выбрали строку.", "Основное окно", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            var select = db.Students.Where(i => i.id == student.id).FirstOrDefault();
            if (meth_stud.Update(student != null ? student.id.ToString() : "0", Student_last.Text, Student_first.Text, Student_middle.Text, Cb_Stud_Class.SelectedItem as Class) == true)
            {
                Student_last.Clear();
                Student_first.Clear();
                Student_middle.Clear();
                Cb_Stud_Class.SelectedIndex = -1;
                dbEntities1 db = new dbEntities1();
                Table_Student.ItemsSource = db.Students.ToList();
                Cb_Stud_Class.ItemsSource = db.Classes.ToList();
            }
        }

        //TEACHER
        private void Teacher_Insert(object sender, RoutedEventArgs e)
        {
            if (meth_t.Add(Teacher_last.Text, Teacher_first.Text, Teacher_middle.Text, Cb_T_Cabinet.SelectedItem as Cabinet, Cb_T_Class.SelectedItem as Class, Cb_T_Subject.SelectedItem as Subject, Date.SelectedDate.ToString(), Time.Text) == true)
            {
                Teacher_last.Clear();
                Teacher_first.Clear();
                Teacher_middle.Clear();
                Cb_T_Cabinet.SelectedIndex = -1;
                Cb_T_Class.SelectedIndex = -1;
                Cb_T_Subject.SelectedIndex = -1;
                Date.SelectedDate = null;
                Time.SelectedTime = null;
            }
            Table_Teacher.ItemsSource = db.Teachers.ToList();
            Cb_T_Cabinet.ItemsSource = db.Cabinets.ToList();
            Cb_T_Class.ItemsSource = db.Classes.ToList();
            Cb_T_Subject.ItemsSource = db.Subjects.ToList();
        }
        private void Teacher_Delete(object sender, RoutedEventArgs e)
        {
            Teacher teacher = Table_Teacher.SelectedItem as Teacher;
            if (Table_Teacher.SelectedItem == null)
            {
                MessageBox.Show("Вы не выбрали строку.", "Основное окно", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            var d_t = db.Teachers.Where(i => i.id == teacher.id).FirstOrDefault();
            meth_t.Delete(teacher != null ? teacher.id.ToString() : "0");
            Table_Teacher.ItemsSource = db.Teachers.ToList();
            Cb_T_Cabinet.ItemsSource = db.Cabinets.ToList();
            Cb_T_Class.ItemsSource = db.Classes.ToList();
            Cb_T_Subject.ItemsSource = db.Subjects.ToList();
        }
        private void Teacher_Update(object sender, RoutedEventArgs e)
        {
            Teacher teacher = Table_Teacher.SelectedItem as Teacher;
            if (Table_Teacher.SelectedItem == null)
            {
                MessageBox.Show("Вы не выбрали строку.", "Основное окно", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            var select = db.Teachers.Where(i => i.id == teacher.id).FirstOrDefault();
            if (meth_t.Update(teacher != null ? teacher.id.ToString() : "0", Teacher_last.Text, Teacher_first.Text, Teacher_middle.Text, Cb_T_Cabinet.SelectedItem as Cabinet, Cb_T_Class.SelectedItem as Class, Cb_T_Subject.SelectedItem as Subject, Date.SelectedDate.ToString(), Time.Text) == true)
            {
                Teacher_last.Clear();
                Teacher_first.Clear();
                Teacher_middle.Clear();
                dbEntities1 db = new dbEntities1();
                Table_Teacher.ItemsSource = db.Teachers.ToList();
                Cb_T_Cabinet.SelectedIndex = -1;
                Cb_T_Class.SelectedIndex = -1;
                Cb_T_Subject.SelectedIndex = -1;
                Date.SelectedDate = null;
                Time.SelectedTime = null;
            }
        }

        //SUBJECT
        private void Subject_Insert(object sender, RoutedEventArgs e)
        {
            if (meth_sub.Add(Subject_name.Text) == true)
            {
                Subject_name.Clear();
            }
            Table_Subject.ItemsSource = db.Subjects.ToList();
            Cb_T_Subject.ItemsSource = db.Subjects.ToList();
        }
        private void Subject_Delete(object sender, RoutedEventArgs e)
        {
            Subject subject = Table_Subject.SelectedItem as Subject;
            if (Table_Subject.SelectedItem == null)
            {
                MessageBox.Show("Вы не выбрали строку.", "Основное окно", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            var d_sub = db.Subjects.Where(i => i.id == subject.id).FirstOrDefault();
            meth_sub.Delete(subject != null ? subject.id.ToString() : "0");
            Table_Subject.ItemsSource = db.Subjects.ToList();
            Cb_T_Subject.ItemsSource = db.Subjects.ToList();
        }
        private void Subject_Update(object sender, RoutedEventArgs e)
        {
            Subject subject = Table_Subject.SelectedItem as Subject;
            if (Table_Subject.SelectedItem == null)
            {
                MessageBox.Show("Вы не выбрали строку.", "Основное окно", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            var select = db.Subjects.Where(i => i.id == subject.id).FirstOrDefault();
            if (meth_sub.Update(subject != null ? subject.id.ToString() : "0", Subject_name.Text) == true)
            {
                Subject_name.Clear();
                dbEntities1 db = new dbEntities1();
                Table_Subject.ItemsSource = db.Subjects.ToList();
                Cb_T_Subject.ItemsSource = db.Subjects.ToList();
            }
        }

        //CABINET
        private void Cabinet_Insert(object sender, RoutedEventArgs e)
        {
            if (meth_cab.Add(Cabinet_number.Text) == true)
            {
                Cabinet_number.Clear();
            }
            Table_Cabinet.ItemsSource = db.Cabinets.ToList();
            Cb_T_Cabinet.ItemsSource = db.Cabinets.ToList();
        }
        private void Cabinet_Delete(object sender, RoutedEventArgs e)
        {
            Cabinet cabinet = Table_Cabinet.SelectedItem as Cabinet;
            if (Table_Cabinet.SelectedItem == null)
            {
                MessageBox.Show("Вы не выбрали строку.", "Основное окно", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            var d_cab = db.Cabinets.Where(i => i.id == cabinet.id).FirstOrDefault();
            meth_cab.Delete(cabinet != null ? cabinet.id.ToString() : "0");
            Table_Cabinet.ItemsSource = db.Cabinets.ToList();
            Cb_T_Cabinet.ItemsSource = db.Cabinets.ToList();
        }
        private void Cabinet_Update(object sender, RoutedEventArgs e)
        {
            Cabinet cabinet = Table_Cabinet.SelectedItem as Cabinet;
            if (Table_Cabinet.SelectedItem == null)
            {
                MessageBox.Show("Вы не выбрали строку.", "Основное окно", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            var select = db.Cabinets.Where(i => i.id == cabinet.id).FirstOrDefault();
            if (meth_cab.Update(cabinet != null ? cabinet.id.ToString() : "0", Cabinet_number.Text) == true)
            {
                Cabinet_number.Clear();
                dbEntities1 db = new dbEntities1();
                Table_Cabinet.ItemsSource = db.Cabinets.ToList();
                Cb_T_Cabinet.ItemsSource = db.Cabinets.ToList();
            }
        }

        //CLASS
        private void Class_Insert(object sender, RoutedEventArgs e)
        {
            if (meth_class.Add(Class_number.Text) == true)
            {
                Class_number.Clear();
            }
            Table_Class.ItemsSource = db.Classes.ToList();
            Cb_Stud_Class.ItemsSource = db.Classes.ToList();
            Cb_T_Class.ItemsSource = db.Classes.ToList();
        }
        private void Class_Delete(object sender, RoutedEventArgs e)
        {
            Class clas = Table_Class.SelectedItem as Class;
            if (Table_Class.SelectedItem == null)
            {
                MessageBox.Show("Вы не выбрали строку.", "Основное окно", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            var d_clas = db.Classes.Where(i => i.id == clas.id).FirstOrDefault();
            meth_class.Delete(clas != null ? clas.id.ToString() : "0");
            Table_Class.ItemsSource = db.Classes.ToList();
            Cb_Stud_Class.ItemsSource = db.Classes.ToList();
            Cb_T_Class.ItemsSource = db.Classes.ToList();
        }
        private void Class_Update(object sender, RoutedEventArgs e)
        {
            Class clas = Table_Class.SelectedItem as Class;
            if (Table_Class.SelectedItem == null)
            {
                MessageBox.Show("Вы не выбрали строку.", "Основное окно", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            var select = db.Classes.Where(i => i.id == clas.id).FirstOrDefault();
            if (meth_class.Update(clas != null ? clas.id.ToString() : "0", Class_number.Text) == true)
            {
                Class_number.Clear();
                dbEntities1 db = new dbEntities1();
                Table_Cabinet.ItemsSource = db.Cabinets.ToList();
                Cb_Stud_Class.ItemsSource = db.Classes.ToList();
                Cb_T_Cabinet.ItemsSource = db.Cabinets.ToList();
            }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            db = new dbEntities1();
            Table_Cabinet.ItemsSource = db.Cabinets.ToList();
            Table_Class.ItemsSource = db.Classes.ToList();
            Table_Student.ItemsSource = db.Students.ToList();
            Table_Subject.ItemsSource = db.Subjects.ToList();
            Table_Teacher.ItemsSource = db.Teachers.ToList();
            Cb_Stud_Class.ItemsSource = db.Classes.ToList();
            Cb_T_Cabinet.ItemsSource = db.Cabinets.ToList();
            Cb_T_Class.ItemsSource = db.Classes.ToList();
            Cb_T_Subject.ItemsSource = db.Subjects.ToList();
        }
    }
}