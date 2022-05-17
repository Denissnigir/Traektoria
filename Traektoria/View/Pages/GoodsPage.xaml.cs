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
using Traektoria.Model;

namespace Traektoria.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для GoodsPage.xaml
    /// </summary>
    public partial class GoodsPage : Page
    {
        List<Goods> goods = new List<Goods>();
        public GoodsPage()
        {
            InitializeComponent();
            goods = Context._con.Goods.ToList();
            GoodsLB.ItemsSource = goods;
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            var context = (sender as Button).DataContext as Goods;
            if (MessageBox.Show(
                $"Вы точно удалить {context.Name}?",
                "Подтверждение",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Context._con.Goods.Remove(context);
                Context._con.SaveChanges();
                MessageBox.Show("Товар успешно удалён!");
            }
        }

        private void ToAddGoodsPage(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddGoodsPage());
        }
    }
}
