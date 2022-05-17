using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для AddGoodsPage.xaml
    /// </summary>
    public partial class AddGoodsPage : Page
    {
        Goods goods { get; set; }
        public AddGoodsPage()
        {
            InitializeComponent();
            goods = new Goods();
            MainGrid.DataContext = goods;
        }

        private void AddImage(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if ((bool)openFileDialog.ShowDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png";
                goods.Image = File.ReadAllBytes(openFileDialog.FileName);
            }
            var name = openFileDialog.FileName.Split('\\');
            var button = sender as Button;
            button.Content = name.Last();
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if(!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void AddGoods(object sender, RoutedEventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(goods.Name) && !string.IsNullOrWhiteSpace(goods.Description)
                                                      && !string.IsNullOrWhiteSpace(goods.Cost.ToString())
                                                      && goods.Image != null)
            {
                Context._con.Goods.Add(goods);
                Context._con.SaveChanges();
                MessageBox.Show("Товар успешно добавлен!");
                NavigationService.Navigate(new GoodsPage());
            }
        }

        private void GoBack(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
