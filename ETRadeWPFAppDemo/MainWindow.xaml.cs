using ETRadeWPFAppDemo.DAL;
using ETRadeWPFAppDemo.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
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
using static System.Net.Mime.MediaTypeNames;
using Image = System.Windows.Controls.Image;

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
            CategoriesMenu();
        }


        public List<UIElement> ElementsToKeep()
        {
            List<UIElement> elementsToKeep = new List<UIElement>();

            elementsToKeep.Add(grdHorizontal);
            elementsToKeep.Add(GridMenu);
            //elementsToKeep.Add(brdrCategories);

            return elementsToKeep;
            
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
            grdMain.Children.Clear();
            grdMain.Children.Add(grdHorizontal);
            grdMain.Children.Add(GridMenu);
            

            CategoriesMenu();


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

        //------------------------------------------------------------------



        private void Baverage_Click(object sender, RoutedEventArgs e)
        {
            grdMain.Children.Clear();

            List<UIElement> elementsToKeep = ElementsToKeep();

            var zIndex = 1;
            foreach (var element in elementsToKeep)
            {
                grdMain.Children.Add(element);

                Panel.SetZIndex(element, zIndex++);
            }



            List<Product> filteredProducts = _productDal.GetByCategory(1);

            ScrollViewer scrollViewer = FilteredByCategoriesMethod(filteredProducts);

            grdMain.Children.Add(scrollViewer);
        }

        //---

        private void Condiment_Click(object sender, RoutedEventArgs e)
        {
            grdMain.Children.Clear();

            List<UIElement> elementsToKeep = ElementsToKeep();

            var zIndex = 1;
            foreach (var element in elementsToKeep)
            {
                grdMain.Children.Add(element);

                Panel.SetZIndex(element, zIndex++);
            }



            List<Product> filteredProducts = _productDal.GetByCategory(2);

            ScrollViewer scrollViewer = FilteredByCategoriesMethod(filteredProducts);

            grdMain.Children.Add(scrollViewer);
        }

        //--

        private void Confections_Click(object sender, RoutedEventArgs e)
        {
            grdMain.Children.Clear();

            List<UIElement> elementsToKeep = ElementsToKeep();

            var zIndex = 1;
            foreach (var element in elementsToKeep)
            {
                grdMain.Children.Add(element);

                Panel.SetZIndex(element, zIndex++);
            }



            List<Product> filteredProducts = _productDal.GetByCategory(3);

            ScrollViewer scrollViewer = FilteredByCategoriesMethod(filteredProducts);

            grdMain.Children.Add(scrollViewer);
        }

        private void dairyProducts_Click(object sender, RoutedEventArgs e)
        {
            grdMain.Children.Clear();

            List<UIElement> elementsToKeep = ElementsToKeep();

            var zIndex = 1;
            foreach (var element in elementsToKeep)
            {
                grdMain.Children.Add(element);

                Panel.SetZIndex(element, zIndex++);
            }



            List<Product> filteredProducts = _productDal.GetByCategory(4);

            ScrollViewer scrollViewer = FilteredByCategoriesMethod(filteredProducts);

            grdMain.Children.Add(scrollViewer);
        }


        private void GrainsCereals_Click(object sender, RoutedEventArgs e)
        {
            grdMain.Children.Clear();

            List<UIElement> elementsToKeep = ElementsToKeep();

            var zIndex = 1;
            foreach (var element in elementsToKeep)
            {
                grdMain.Children.Add(element);

                Panel.SetZIndex(element, zIndex++);
            }



            List<Product> filteredProducts = _productDal.GetByCategory(5);

            ScrollViewer scrollViewer = FilteredByCategoriesMethod(filteredProducts);

            grdMain.Children.Add(scrollViewer);
        }

        private void MeatPoultry_Click(object sender, RoutedEventArgs e)
        {
            grdMain.Children.Clear();

            List<UIElement> elementsToKeep = ElementsToKeep();

            var zIndex = 1;
            foreach (var element in elementsToKeep)
            {
                grdMain.Children.Add(element);

                Panel.SetZIndex(element, zIndex++);
            }



            List<Product> filteredProducts = _productDal.GetByCategory(6);

            ScrollViewer scrollViewer = FilteredByCategoriesMethod(filteredProducts);

            grdMain.Children.Add(scrollViewer);
        }


        private void Producee_Click(object sender, RoutedEventArgs e)
        {
            grdMain.Children.Clear();

            List<UIElement> elementsToKeep = ElementsToKeep();

            var zIndex = 1;
            foreach (var element in elementsToKeep)
            {
                grdMain.Children.Add(element);

                Panel.SetZIndex(element, zIndex++);
            }



            List<Product> filteredProducts = _productDal.GetByCategory(7);

            ScrollViewer scrollViewer = FilteredByCategoriesMethod(filteredProducts);

            grdMain.Children.Add(scrollViewer);
        }

        private void Seafood_Click(object sender, RoutedEventArgs e)
        {
            grdMain.Children.Clear();

            List<UIElement> elementsToKeep = ElementsToKeep();

            var zIndex = 1;
            foreach (var element in elementsToKeep)
            {
                grdMain.Children.Add(element);

                Panel.SetZIndex(element, zIndex++);
            }



            List<Product> filteredProducts = _productDal.GetByCategory(8);

            ScrollViewer scrollViewer = FilteredByCategoriesMethod(filteredProducts);

            grdMain.Children.Add(scrollViewer);
        }



        










        public void CategoriesMenu()
        {
            List<Category> categories = _productDal.GetCategories();

            List<string> imagePaths = new List<string>()
            {

                "/ETRadeWPFAppDemo;component/Assets/Baverage.png",
                "/ETRadeWPFAppDemo;component/Assets/Condiment.png",
                "/ETRadeWPFAppDemo;component/Assets/Confections.png",
                "/ETRadeWPFAppDemo;component/Assets/dairyProducts.png",
                "/ETRadeWPFAppDemo;component/Assets/GrainsCereals.png",
                "/ETRadeWPFAppDemo;component/Assets/MeatPoultry.png",
                "/ETRadeWPFAppDemo;component/Assets/Producee.png",
                "/ETRadeWPFAppDemo;component/Assets/Seafood.png"
            };

            List<string> buttonsName = new List<string>()
            {
                "Baverage",
                "Condiment",
                "Confections",
                "dairyProducts",
                "GrainsCereals",
                "MeatPoultry",
                "Producee",
                "Seafood"
            };
                

            int row = 0;
            int col = 0;
            int roww = 0; // for image count
            Grid grdCategories = new Grid()
            {
                Width = Double.NaN, // = Auto
                Height = Double.NaN,
                Background = new SolidColorBrush(Colors.Red)
            };

            ScrollViewer scrollViewer = new ScrollViewer()
            {
                //Height = 400,
                Margin = new Thickness(20, 80, 0, 0)
            };

            scrollViewer.Content = grdCategories;

            grdMain.Children.Add(scrollViewer);


            Border bigBorder = new Border()
            {
                MinHeight = 350
            };

            StackPanel stackPanel = new StackPanel();

            foreach (Category category in categories)
            {
                string imagePath = imagePaths[roww * 1 + col];

                string buttonName = buttonsName[roww * 1 + col];
                
                roww++;

                Uri imageUri = new Uri(imagePath, UriKind.RelativeOrAbsolute);

                BitmapImage bitmapImage = new BitmapImage(imageUri);

                Image imageControl = new Image();

                imageControl.Source = bitmapImage;
                
                Border border = new Border()
                {
                    Width = 600,
                    Height = 200,
                    Margin = new Thickness(0 + col * 0, 20 + row * 30, 0, 0),
                    CornerRadius = new CornerRadius(20),
                    Background = new SolidColorBrush(Colors.White)
                };

                Button button = new Button()
                {
                    Width = 580,
                    Height = 180,
                    BorderThickness = new Thickness(0),
                    Background = new SolidColorBrush(Colors.White)
                };
                button.Content = imageControl;

                //---------------------------------------------

                if (buttonName == "Baverage")
                {
                    button.Click += Baverage_Click;
                }

                if (buttonName == "Condiment")
                {
                    button.Click += Condiment_Click;
                }

                if (buttonName == "Confections")
                {
                    button.Click += Confections_Click;
                }

                if (buttonName == "dairyProducts")
                {
                    button.Click += dairyProducts_Click;
                }

                if (buttonName == "GrainsCereals")
                {
                    button.Click += GrainsCereals_Click;
                }

                if (buttonName == "MeatPoultry")
                {
                    button.Click += MeatPoultry_Click;
                }

                if (buttonName == "Producee")
                {
                    button.Click += Producee_Click;
                }

                if (buttonName == "Seafood")
                {
                    button.Click += Seafood_Click;
                }

                //----------------------------------------------

                border.Child = button;

                stackPanel.Children.Add(border);

                col++;
                if (col >= 1)
                {
                    col = 0;
                    Margin = new Thickness(20);
                    //row++;
                }
            }
            bigBorder.Child = stackPanel;
            grdCategories.Children.Add(bigBorder);
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
            //brdrCategories.Visibility = Visibility.Collapsed;

            //grdMain.Children.Clear();

            //List<UIElement> elementsToKeep = ElementsToKeep();

            //var zIndex = 1;
            //foreach (var element in elementsToKeep)
            //{
            //    grdMain.Children.Add(element);

            //    Panel.SetZIndex(element, zIndex++);
            //}



            //List<Product> filteredProducts = _productDal.GetByCategory(1);

            //ScrollViewer scrollViewer = FilteredByCategoriesMethod(filteredProducts);

            //grdMain.Children.Add(scrollViewer);
        }

        //---------------------------------------------------------------------------------------
        private static ScrollViewer FilteredByCategoriesMethod(List<Product> filteredProducts)
        {
            Grid grdCategory = new Grid()
            {

                Margin = new Thickness(40, 100, 0, 40),
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center
            };
            grdCategory.Visibility = Visibility.Visible;

            ScrollViewer scrollViewer = new ScrollViewer()
            {
                Width = Double.NaN, // = Auto
                Height = Double.NaN,
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
            
            return scrollViewer;


            // if you will use this method don't forget to add this method's end "grdMain.Children.Add(scrollViewer)" 
        }
        //---------------------------------------------------------------------------------------

        private void btnCondiments_Click(object sender, RoutedEventArgs e)
        {
            //brdrCategories.Visibility = Visibility.Collapsed;

            grdMain.Children.Clear();

            List<UIElement> elementsToKeep = ElementsToKeep();

            var zIndex = 1;
            foreach (var element in elementsToKeep)
            {
                grdMain.Children.Add(element);

                Panel.SetZIndex(element, zIndex++);
            }

            List<Product> filteredProducts = _productDal.GetByCategory(2);

            ScrollViewer scrollViewer = FilteredByCategoriesMethod(filteredProducts);

            grdMain.Children.Add(scrollViewer);



        }

        private void btnConfections_Click(object sender, RoutedEventArgs e)
        {
            //brdrCategories.Visibility = Visibility.Collapsed;

            grdMain.Children.Clear();

            List<UIElement> elementsToKeep = ElementsToKeep();

            var zIndex = 1;
            foreach (var element in elementsToKeep)
            {
                grdMain.Children.Add(element);

                Panel.SetZIndex(element, zIndex++);
            }

            List<Product> filteredProducts = _productDal.GetByCategory(3);

            ScrollViewer scrollViewer = FilteredByCategoriesMethod(filteredProducts);

            grdMain.Children.Add(scrollViewer);
        }

























    }
}