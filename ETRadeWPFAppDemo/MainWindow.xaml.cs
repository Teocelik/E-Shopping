using ETRadeWPFAppDemo.DAL;
using ETRadeWPFAppDemo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

namespace ETRadeWPFAppDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        ProductDal _productDal = new ProductDal();
        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
            ButtonCloseMenu.Visibility = Visibility.Visible;
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Visible;
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
        }

        private void ButtonHome_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonOrders_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonSearch_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonSingIn_Click(object sender, RoutedEventArgs e)
        {

        }




        private void TbxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            //ListByName metodunu çağırarak textbox'a göre gelen ürünleri yeni bir Product nesnesi tutan listeye atadım(filteredProducts)
            List<Product> filteredProducts = _productDal.ListByName(TbxSearch.Text);

            //Şimdi'de ListBox'ın ItemsSource özelliğine veri kaynağını bağladım.

            ListProductByName.ItemsSource = filteredProducts;

            //Eğer filtrelenen ürün varsa gridi göster yoksa gösterme 
            dgwListByName.Visibility = filteredProducts.Count > 0 && !string.IsNullOrWhiteSpace(TbxSearch.Text) ? Visibility.Visible : Visibility.Collapsed;

            dgwMessage.Visibility = filteredProducts.Count == 0 && !string.IsNullOrWhiteSpace(tbMessage.Text) ? Visibility.Visible : Visibility.Collapsed;

        }

        private void ButtonBasket_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnBaverages_Click(object sender, RoutedEventArgs e)
        {
            brdrCategories.Visibility = Visibility.Collapsed;

            List<Product> filteredProducts = _productDal.GetBaveragesCategory(1);

            Grid grdCategory = new Grid()
            {
                
                Margin = new Thickness(40, 100, 0, 40),
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center
            };
            grdCategory.Visibility = Visibility.Visible;

            ScrollViewer scrollViewer = new ScrollViewer()
            {
                Width = 700,
                Height = 400,
                VerticalScrollBarVisibility = ScrollBarVisibility.Auto
            };
            scrollViewer.Content = grdCategory;

            int row = 0;
            int col = 0;

            foreach (var product in filteredProducts)
            {
                Border border = new Border()
                {
                    Width = 300,
                    Height = 250,
                    VerticalAlignment = VerticalAlignment.Top,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    Margin = new Thickness(0 + col * 320, 0 + row * 260, 0, 0),
                    Background = Brushes.White,
                    CornerRadius = new CornerRadius(10)
                };

                StackPanel stackPanel = new StackPanel();

                TextBlock textBlockProductName = new TextBlock()
                {
                    Text = product.ProductName,
                    Margin = new Thickness(10, 150, 10, 0),
                    Width = 250,
                    Height = 40,
                    Background = Brushes.White
                };

                TextBlock textBlockUnitPrice = new TextBlock()
                {
                    Text = product.UnitPrice.ToString("F2"),
                    Width = 90,
                    Height = 50,
                    Margin = new Thickness(160, 10, 0, 0),
                    Background = Brushes.White
                };

                TextBlock textBlockQuantityPerUnit = new TextBlock()
                {
                    Text = product.QuantityPerUnit,
                    Width = 150,
                    Background = Brushes.White,
                    Height = 50,
                    Margin = new Thickness(-100, -50, 0, 0)
                };

                stackPanel.Children.Add(textBlockProductName);
                stackPanel.Children.Add(textBlockUnitPrice);
                stackPanel.Children.Add(textBlockQuantityPerUnit);

                border.Child = stackPanel;

                grdCategory.Children.Add(border);

                col++;
                if (col >= 2) // İki ürün yan yana olduğunda, bir sonraki satıra geçmek için
                {
                    col = 0;
                    row++;
                }
            }

            grdMain.Children.Add(scrollViewer);
        }

    }
}