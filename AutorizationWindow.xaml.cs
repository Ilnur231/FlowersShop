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

namespace FlowersCompany
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        FlowersEntities2 BD = new FlowersEntities2();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SignInButton_Click(object sender, RoutedEventArgs e)
        {
            if (LoginTB.Text == "" || PasswordPB.Password == null)
            {
                MessageBox.Show("Вы не ввели все данные, пожалуйста заполните все и повторите попытку");
            }
            else
            {
                var users = BD.User.Where(a => a.Login == LoginTB.Text && a.Password == PasswordPB.Password).FirstOrDefault();
                if (users != null)
                {
                    DataOutput DO = new DataOutput();
                    DO.Show();
                    Hide();
                }
                else
                {
                    MessageBox.Show("Пользователь не был найден, попробуйте ввести данные еще раз");
                    LoginTB.Clear();
                    PasswordPB.Clear();
                }
            }
            
       }
    


        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            Close();
        }
    }
}
