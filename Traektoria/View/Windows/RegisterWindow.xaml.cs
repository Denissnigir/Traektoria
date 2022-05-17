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
using Traektoria.Model;

namespace Traektoria.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        User user;
        
        public RegisterWindow()
        {
            InitializeComponent();
            user = new User();
            MainGrid.DataContext = user;
        }

        private void Register(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(user.FIO) && !string.IsNullOrWhiteSpace(user.Phone)
                                                     && !string.IsNullOrWhiteSpace(user.Login)
                                                     && !string.IsNullOrWhiteSpace(user.Password)
                                                     && !string.IsNullOrWhiteSpace(user.Email))
            {
                Context._con.User.Add(user);
                Context._con.SaveChanges();
                MessageBox.Show("Вы успешно зарегистрированы!");
                LoginWindow loginWindow = new LoginWindow();
                loginWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Сначала заполните все поля!");
            }
        }

        private void CloseApp(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show(
                "Вы точно хотите выйти?",
                "Подтверждение",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }
    }
}
