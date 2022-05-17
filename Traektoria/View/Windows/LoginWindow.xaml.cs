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
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public static User curUser { get; set; }

        public LoginWindow()
        {
            InitializeComponent();
        }

        private void Login(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(LoginTB.Text) && !string.IsNullOrWhiteSpace(PasswordTB.Password))
            {
                var user = Context._con.User.ToList()
                                            .Where(p => p.Login == LoginTB.Text && p.Password == PasswordTB.Password)
                                            .FirstOrDefault();
                if (user != null)
                {
                    curUser = user;
                    MessageBox.Show($"Вы авторизовались под пользователем {user.FIO}");
                    MainMenu mainMenu = new MainMenu();
                    mainMenu.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Пользователь не найден!");
                }
            }
            else
            {
                MessageBox.Show("Сначала заполните все поля!");
            }
        }

        private void ToRegister(object sender, RoutedEventArgs e)
        {
            RegisterWindow registerWindow = new RegisterWindow();
            registerWindow.Show();
            this.Close();
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
