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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class Authoriazation : Window
    {
        dbEntities1 db;
        public Authoriazation()
        {
            InitializeComponent();
            db = new dbEntities1();
        }

        private void Auth_Enter(object sender, RoutedEventArgs e)
        {
            Meth_Auth meth_auth = new Meth_Auth();
            if (meth_auth.Enter(Auth_Login.Text, Auth_Password.Password) == true)
            {
                Hide();
                new Main_Window().ShowDialog();
                Application.Current.Shutdown();
            }
        }
    }
}
