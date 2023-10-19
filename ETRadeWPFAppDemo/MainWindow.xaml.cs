using ETRadeWPFAppDemo.DAL;
using ETRadeWPFAppDemo.Entities;
using MaterialDesignThemes.Wpf;
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
            grdMain.Children.Add(dgwListByName);
            
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
            //--------------
            List<string> buttonsName = new List<string>()
            {
                "Baverage1",
                "Baverage2",
                "Baverage3",
                "Baverage4",
                "Baverage5",
                "Baverage6",
                "Baverage7",
                "Baverage8",
                "Baverage9",
                "Baverage10",
                "Baverage11",
                "Baverage12"
            };

            List<string> buttonImages = new List<string>()
            {
                "/ETRadeWPFAppDemo;component/Assets/chai.png",
                "/ETRadeWPFAppDemo;component/Assets/chang.png",
                "/ETRadeWPFAppDemo;component/Assets/guarana.png",
                "/ETRadeWPFAppDemo;component/Assets/sasquatchAle.png",
                "/ETRadeWPFAppDemo;component/Assets/steeleyeStout.png",
                "/ETRadeWPFAppDemo;component/Assets/Blaye.png",
                "/ETRadeWPFAppDemo;component/Assets/chartreuseVerte.png",
                "/ETRadeWPFAppDemo;component/Assets/ipohCoffee.png",
                "/ETRadeWPFAppDemo;component/Assets/.png",
                "/ETRadeWPFAppDemo;component/Assets/outbackLager.png",
                "/ETRadeWPFAppDemo;component/Assets/klosterbier.png",
                "/ETRadeWPFAppDemo;component/Assets/lakkalikööri.png"
            };

            //******************************

            //--------------------------------------------------

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

                Button button = new Button()
                {
                    Width = 280,
                    Height = 230,
                    BorderThickness = new Thickness(0),
                    Background = new SolidColorBrush(Colors.White),
                    Tag = product
                };

                button.Click += ProductDetails_Click;

                string buttonName = buttonsName[row * 2 + col];

                //----------------------------------------

                string BaverageButtonImage = buttonImages[row * 2 + col];

                Uri BaverageImageUri = new Uri(BaverageButtonImage, UriKind.RelativeOrAbsolute);

                BitmapImage bitmapImage = new BitmapImage(BaverageImageUri);

                Image BaverageImageControl = new Image()
                {
                    Width = 280,
                    Height = 140,
                    Margin = new Thickness(0, 0, 0, 0)
                };

                BaverageImageControl.Source = bitmapImage;


                //----------------------------------------
                border.Child = button;
                
                StackPanel stackPanel = new StackPanel()
                {
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    Width = 280,
                    Height = 230
                };

                stackPanel.Children.Add(BaverageImageControl);

                TextBlock textBlockProductName = new TextBlock()
                {
                    Text = product.ProductName,
                    Margin = new Thickness(0, 30, 65, 0),
                    Width = 190,
                    Height = 20,
                    Background = Brushes.White
                };

                TextBlock textBlockUnitPriceAndQuantityPerUnit = new TextBlock()
                {
                    Text = $"{product.QuantityPerUnit}                          {product.UnitPrice:F2}$ ",
                    Width = 250,
                    Height = 20,
                    Margin = new Thickness(0, 15, 10, 0),
                    Background = Brushes.White
                };

                



                stackPanel.Children.Add(textBlockProductName);
                stackPanel.Children.Add(textBlockUnitPriceAndQuantityPerUnit);



                button.Content = stackPanel;

                grdCategory.Children.Add(border);
                

                col++;
                if (col >= 2) // İki ürün yan yana olduğunda, bir sonraki satıra geçmek için
                {
                    col = 0;
                    row++;
                }
            }
            //--------------
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
            //---------------------
            List<string> buttonsName = new List<string>()
            {
                "Condiment1",
                "Condiment2",
                "Condiment3",
                "Condiment4",
                "Condiment5",
                "Condiment6",
                "Condiment7",
                "Condiment8",
                "Condiment9",
                "Condiment10",
                "Condiment11",
                "Condiment12"
            };

            List<string> buttonImages = new List<string>()
            {
                "/ETRadeWPFAppDemo;component/Assets/aniseedSyrup.png",
                "/ETRadeWPFAppDemo;component/Assets/cajunSeasoning.png",
                "/ETRadeWPFAppDemo;component/Assets/gumboMix.png",
                "/ETRadeWPFAppDemo;component/Assets/boysenberry.png",
                "/ETRadeWPFAppDemo;component/Assets/northwoodsCranberrySauce.png",
                "/ETRadeWPFAppDemo;component/Assets/.png",
                "/ETRadeWPFAppDemo;component/Assets/.png",
                "/ETRadeWPFAppDemo;component/Assets/sirop.png",
                "/ETRadeWPFAppDemo;component/Assets/.png",
                "/ETRadeWPFAppDemo;component/Assets/pepper.png",
                "/ETRadeWPFAppDemo;component/Assets/Okra.png",
                "/ETRadeWPFAppDemo;component/Assets/grüne.png"
            };

            //******************************

            //--------------------------------------------------

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

                Button button = new Button()
                {
                    Width = 280,
                    Height = 230,
                    BorderThickness = new Thickness(0),
                    Background = new SolidColorBrush(Colors.White),
                    Tag = product
                };

                button.Click += ProductDetails_Click;

                string buttonName = buttonsName[row * 2 + col];

                //----------------------------------------

                string CondimentButtonImage = buttonImages[row * 2 + col];

                Uri CondimentImageUri = new Uri(CondimentButtonImage, UriKind.RelativeOrAbsolute);

                BitmapImage bitmapImage = new BitmapImage(CondimentImageUri);

                Image CondimentImageControl = new Image()
                {
                    Width = 280,
                    Height = 140,
                    Margin = new Thickness(0, 0, 0, 0)
                };

                CondimentImageControl.Source = bitmapImage;


                //----------------------------------------
                border.Child = button;
                
                StackPanel stackPanel = new StackPanel()
                {
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    Width = 280,
                    Height = 230
                };

                stackPanel.Children.Add(CondimentImageControl);

                TextBlock textBlockProductName = new TextBlock()
                {
                    Text = product.ProductName,
                    Margin = new Thickness(0, 30, 65, 0),
                    Width = 190,
                    Height = 20,
                    Background = Brushes.White
                };

                TextBlock textBlockUnitPriceAndQuantityPerUnit = new TextBlock()
                {
                    Text = $"{product.QuantityPerUnit}                          {product.UnitPrice:F2}$ ",
                    Width = 250,
                    Height = 20,
                    Margin = new Thickness(0, 15, 10, 0),
                    Background = Brushes.White
                };



                stackPanel.Children.Add(textBlockProductName);
                stackPanel.Children.Add(textBlockUnitPriceAndQuantityPerUnit);



                button.Content = stackPanel;

                grdCategory.Children.Add(border);

                col++;
                if (col >= 2) // İki ürün yan yana olduğunda, bir sonraki satıra geçmek için
                {
                    col = 0;
                    row++;
                }
            }
            //---------------------
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
            //--------------------------
            List<string> buttonsName = new List<string>()
            {
                "Confections1",
                "Confections2",
                "Confections3",
                "Confections4",
                "Confections5",
                "Confections6",
                "Confections7",
                "Confections8",
                "Confections9",
                "Confections10",
                "Confections11",
                "Confections12",
                "Confections12"
            };

            List<string> buttonImages = new List<string>()
            {
                "/ETRadeWPFAppDemo;component/Assets/pavlova.png",
                "/ETRadeWPFAppDemo;component/Assets/choclateBiscuits.png",
                "/ETRadeWPFAppDemo;component/Assets/marmalade.png",
                "/ETRadeWPFAppDemo;component/Assets/scones.png",
                "/ETRadeWPFAppDemo;component/Assets/NougatCreme.png",
                "/ETRadeWPFAppDemo;component/Assets/gummibears.png",
                "/ETRadeWPFAppDemo;component/Assets/schoggiSchokolade.png",
                "/ETRadeWPFAppDemo;component/Assets/.png",
                "/ETRadeWPFAppDemo;component/Assets/chocolate.png",
                "/ETRadeWPFAppDemo;component/Assets/.png",
                "/ETRadeWPFAppDemo;component/Assets/valkoinenSuklaa.png",
                "/ETRadeWPFAppDemo;component/Assets/tarteAuSucre.png",
                "/ETRadeWPFAppDemo;component/Assets/scottishLongbreads.png"
            };

            //******************************

            //--------------------------------------------------

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

                Button button = new Button()
                {
                    Width = 280,
                    Height = 230,
                    BorderThickness = new Thickness(0),
                    Background = new SolidColorBrush(Colors.White),
                    Tag = product
                };

                button.Click += ProductDetails_Click;

                string buttonName = buttonsName[row * 2 + col];

                //----------------------------------------

                string ConfectionsButtonImage = buttonImages[row * 2 + col];

                Uri ConfectionsImageUri = new Uri(ConfectionsButtonImage, UriKind.RelativeOrAbsolute);

                BitmapImage bitmapImage = new BitmapImage(ConfectionsImageUri);

                Image ConfectionsImageControl = new Image()
                {
                    Width = 280,
                    Height = 140,
                    Margin = new Thickness(0, 0, 0, 0)
                };

                ConfectionsImageControl.Source = bitmapImage;


                //----------------------------------------
                border.Child = button;
           
                StackPanel stackPanel = new StackPanel()
                {
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    Width = 280,
                    Height = 230
                };

                stackPanel.Children.Add(ConfectionsImageControl);

                TextBlock textBlockProductName = new TextBlock()
                {
                    Text = product.ProductName,
                    Margin = new Thickness(0, 30, 65, 0),
                    Width = 190,
                    Height = 20,
                    Background = Brushes.White
                };

                TextBlock textBlockUnitPriceAndQuantityPerUnit = new TextBlock()
                {
                    Text = $"{product.QuantityPerUnit}                          {product.UnitPrice:F2}$ ",
                    Width = 250,
                    Height = 20,
                    Margin = new Thickness(0, 15, 10, 0),
                    Background = Brushes.White
                };



                stackPanel.Children.Add(textBlockProductName);
                stackPanel.Children.Add(textBlockUnitPriceAndQuantityPerUnit);



                button.Content = stackPanel;

                grdCategory.Children.Add(border);

                col++;
                if (col >= 2) // İki ürün yan yana olduğunda, bir sonraki satıra geçmek için
                {
                    col = 0;
                    row++;
                }
            }
            //--------------------------
            grdMain.Children.Add(scrollViewer);
        }

        //---

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
            //------------------------------
            List<string> buttonsName = new List<string>()
            {
                "dairyProducts1",
                "dairyProducts2",
                "dairyProducts3",
                "dairyProducts4",
                "dairyProducts5",
                "dairyProducts6",
                "dairyProducts7",
                "dairyProducts8",
                "dairyProducts9",
                "dairyProducts10"
            };

            List<string> buttonImages = new List<string>()
            {
                "/ETRadeWPFAppDemo;component/Assets/quesoCabrales.png",
                "/ETRadeWPFAppDemo;component/Assets/QuesoManchegoLaPastora.png",
                "/ETRadeWPFAppDemo;component/Assets/gorgonzolaTelinok.png",
                "/ETRadeWPFAppDemo;component/Assets/MascarponeFabiola.png",
                "/ETRadeWPFAppDemo;component/Assets/Geitost.png",
                "/ETRadeWPFAppDemo;component/Assets/.png",
                "/ETRadeWPFAppDemo;component/Assets/camembertPierrot.png",
                "/ETRadeWPFAppDemo;component/Assets/Gudbrandsdalsost.png",
                "/ETRadeWPFAppDemo;component/Assets/Flotemysost.png",
                "/ETRadeWPFAppDemo;component/Assets/mozzarellaDiGiovanni.png"
            };

            //******************************

            //--------------------------------------------------

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

                Button button = new Button()
                {
                    Width = 280,
                    Height = 230,
                    BorderThickness = new Thickness(0),
                    Background = new SolidColorBrush(Colors.White),
                    Tag = product
                };

                button.Click += ProductDetails_Click;

                string buttonName = buttonsName[row * 2 + col];

                //----------------------------------------

                string dairyProductsButtonImage = buttonImages[row * 2 + col];

                Uri dairyProductsImageUri = new Uri(dairyProductsButtonImage, UriKind.RelativeOrAbsolute);

                BitmapImage bitmapImage = new BitmapImage(dairyProductsImageUri);

                Image dairyProductsImageControl = new Image()
                {
                    Width = 280,
                    Height = 140,
                    Margin = new Thickness(0, 0, 0, 0)
                };

                dairyProductsImageControl.Source = bitmapImage;


                //----------------------------------------
                border.Child = button;
                
                StackPanel stackPanel = new StackPanel()
                {
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    Width = 280,
                    Height = 230
                };

                stackPanel.Children.Add(dairyProductsImageControl);

                TextBlock textBlockProductName = new TextBlock()
                {
                    Text = product.ProductName,
                    Margin = new Thickness(0, 30, 65, 0),
                    Width = 190,
                    Height = 20,
                    Background = Brushes.White
                };

                TextBlock textBlockUnitPriceAndQuantityPerUnit = new TextBlock()
                {
                    Text = $"{product.QuantityPerUnit}                          {product.UnitPrice:F2}$ ",
                    Width = 250,
                    Height = 20,
                    Margin = new Thickness(0, 15, 10, 0),
                    Background = Brushes.White
                };



                stackPanel.Children.Add(textBlockProductName);
                stackPanel.Children.Add(textBlockUnitPriceAndQuantityPerUnit);



                button.Content = stackPanel;

                grdCategory.Children.Add(border);

                col++;
                if (col >= 2) // İki ürün yan yana olduğunda, bir sonraki satıra geçmek için
                {
                    col = 0;
                    row++;
                }
            }
            //------------------------------
            grdMain.Children.Add(scrollViewer);
        }

        //---

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
            //---------------------------------------
            List<string> buttonsName = new List<string>()
            {
                "GrainsCereals1",
                "GrainsCereals2",
                "GrainsCereals3",
                "GrainsCereals4",
                "GrainsCereals5",
                "GrainsCereals6",
                "GrainsCereals7"
            };

            List<string> buttonImages = new List<string>()
            {
                "/ETRadeWPFAppDemo;component/Assets/knackebröd.png",
                "/ETRadeWPFAppDemo;component/Assets/Tunnbröd.png",
                "/ETRadeWPFAppDemo;component/Assets/SingaporeanHokkienFriedMee.png",
                "",
                "/ETRadeWPFAppDemo;component/Assets/GrocchiDiNonna.png",
                "/ETRadeWPFAppDemo;component/Assets/RavioliAngelo.png",
                "/ETRadeWPFAppDemo;component/Assets/WimmersGute.png"
            };

            //******************************

            //--------------------------------------------------

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

                Button button = new Button()
                {
                    Width = 280,
                    Height = 230,
                    BorderThickness = new Thickness(0),
                    Background = new SolidColorBrush(Colors.White),
                    Tag = product
                };

                button.Click += ProductDetails_Click;

                string buttonName = buttonsName[row * 2 + col];

                //----------------------------------------

                string GrainsCerealsButtonImage = buttonImages[row * 2 + col];

                Uri GrainsCerealsImageUri = new Uri(GrainsCerealsButtonImage, UriKind.RelativeOrAbsolute);

                BitmapImage bitmapImage = new BitmapImage(GrainsCerealsImageUri);

                Image GrainsCerealsImageControl = new Image()
                {
                    Width = 280,
                    Height = 140,
                    Margin = new Thickness(0, 0, 0, 0)
                };

                GrainsCerealsImageControl.Source = bitmapImage;


                //----------------------------------------
                border.Child = button;
                
                StackPanel stackPanel = new StackPanel()
                {
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    Width = 280,
                    Height = 230
                };

                stackPanel.Children.Add(GrainsCerealsImageControl);

                TextBlock textBlockProductName = new TextBlock()
                {
                    Text = product.ProductName,
                    Margin = new Thickness(0, 30, 65, 0),
                    Width = 190,
                    Height = 20,
                    Background = Brushes.White
                };

                TextBlock textBlockUnitPriceAndQuantityPerUnit = new TextBlock()
                {
                    Text = $"{product.QuantityPerUnit}                          {product.UnitPrice:F2}$ ",
                    Width = 250,
                    Height = 20,
                    Margin = new Thickness(0, 15, 10, 0),
                    Background = Brushes.White
                };



                stackPanel.Children.Add(textBlockProductName);
                stackPanel.Children.Add(textBlockUnitPriceAndQuantityPerUnit);



                button.Content = stackPanel;

                grdCategory.Children.Add(border);

                col++;
                if (col >= 2) // İki ürün yan yana olduğunda, bir sonraki satıra geçmek için
                {
                    col = 0;
                    row++;
                }
            }
            //---------------------------------------
            grdMain.Children.Add(scrollViewer);
        }

        //---

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
            //---------------
            List<string> buttonsName = new List<string>()
            {
                "MeatPoultry1",
                "MeatPoultry2",
                "MeatPoultry3",
                "MeatPoultry4",
                "MeatPoultry5",
                "MeatPoultry6"
            };

            List<string> buttonImages = new List<string>()
            {
                "/ETRadeWPFAppDemo;component/Assets/Seafood.png",
                "/ETRadeWPFAppDemo;component/Assets/Mutton.png",
                "/ETRadeWPFAppDemo;component/Assets/ThüringerRostbratwurst.png",
                "/ETRadeWPFAppDemo;component/Assets/PerthPasties.png",
                "/ETRadeWPFAppDemo;component/Assets/Tourtiere.png",
                "/ETRadeWPFAppDemo;component/Assets/PateChinois.png"
            };

            //******************************

            //--------------------------------------------------

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

                Button button = new Button()
                {
                    Width = 280,
                    Height = 230,
                    BorderThickness = new Thickness(0),
                    Background = new SolidColorBrush(Colors.White),
                    Tag = product
                };

                button.Click += ProductDetails_Click;

                string buttonName = buttonsName[row * 2 + col];

                //----------------------------------------

                string MeatPoultryButtonImage = buttonImages[row * 2 + col];

                Uri MeatPoultryImageUri = new Uri(MeatPoultryButtonImage, UriKind.RelativeOrAbsolute);

                BitmapImage bitmapImage = new BitmapImage(MeatPoultryImageUri);

                Image MeatPoultryImageControl = new Image()
                {
                    Width = 280,
                    Height = 140,
                    //VerticalAlignment = VerticalAlignment.Top,
                    //HorizontalAlignment = HorizontalAlignment.Center,
                    Margin = new Thickness(0, 0, 0, 0)
                };

                MeatPoultryImageControl.Source = bitmapImage;


                //----------------------------------------
                border.Child = button;
                //**************
                //if (buttonName == "MeatPoultryBtn1")
                //{
                //    button.Click += MeatPoultryBtn1_Click;   // coming soon
                //};
                //**************
                StackPanel stackPanel = new StackPanel()
                {
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    Width = 280,
                    Height = 230
                };

                stackPanel.Children.Add(MeatPoultryImageControl);

                TextBlock textBlockProductName = new TextBlock()
                {
                    Text = product.ProductName,
                    Margin = new Thickness(0, 30, 65, 0),
                    Width = 190,
                    Height = 20,
                    Background = Brushes.White
                };

                TextBlock textBlockUnitPriceAndQuantityPerUnit = new TextBlock()
                {
                    Text = $"{product.QuantityPerUnit}                          {product.UnitPrice:F2}$ ",
                    Width = 250,
                    Height = 20,
                    Margin = new Thickness(0, 15, 10, 0),
                    Background = Brushes.White
                };



                stackPanel.Children.Add(textBlockProductName);
                stackPanel.Children.Add(textBlockUnitPriceAndQuantityPerUnit);



                button.Content = stackPanel;

                grdCategory.Children.Add(border);

                col++;
                if (col >= 2) // İki ürün yan yana olduğunda, bir sonraki satıra geçmek için
                {
                    col = 0;
                    row++;
                }
            }
            //--------------
            grdMain.Children.Add(scrollViewer);
        }

        //---

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

            //------------------------------

            

            //******************************

            List<string> buttonsName = new List<string>()
            {
                "Producee1",
                "Producee2",
                "Producee3",
                "Producee4",
                "Producee5"
            };

            List<string> buttonImages = new List<string>()
            {
                "/ETRadeWPFAppDemo;component/Assets/OrcanicDriedPears.png",
                "/ETRadeWPFAppDemo;component/Assets/Tofu.png",
                "/ETRadeWPFAppDemo;component/Assets/RössleSauerkraut.png",
                "/ETRadeWPFAppDemo;component/Assets/DriedApples.png",
                "/ETRadeWPFAppDemo;component/Assets/LonglifeTofu.png"
            };

            //******************************

            //--------------------------------------------------

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

                Button button = new Button()
                {
                    Width = 280,
                    Height = 230,
                    BorderThickness = new Thickness(0),
                    Background = new SolidColorBrush(Colors.White),
                    Tag = product
                };

                //bir buton ProductDetails'e bağlanacak bir tanesi de BasketButonuna

                button.Click += ProductDetails_Click;

                string buttonName = buttonsName[row * 2 + col];

                //----------------------------------------

                string ProduceeButtonImage = buttonImages[row * 2 + col];

                Uri ProduceeImageUri = new Uri(ProduceeButtonImage, UriKind.RelativeOrAbsolute);

                BitmapImage bitmapImage = new BitmapImage(ProduceeImageUri);

                Image ProduceeImageControl = new Image()
                {
                    Width = 280,
                    Height = 140,
                    //VerticalAlignment = VerticalAlignment.Top,
                    //HorizontalAlignment = HorizontalAlignment.Center,
                    Margin = new Thickness(0, 0, 0, 0)
                };

                ProduceeImageControl.Source = bitmapImage;
                

                //----------------------------------------
                border.Child = button;
                
                StackPanel stackPanel = new StackPanel()
                {
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    Width = 280,
                    Height = 230
                };

                stackPanel.Children.Add(ProduceeImageControl);

                TextBlock textBlockProductName = new TextBlock()
                {
                    Text = product.ProductName,
                    Margin = new Thickness(0, 30, 65, 0),
                    Width = 190,
                    Height = 20,
                    Background = Brushes.White
                };

                TextBlock textBlockUnitPriceAndQuantityPerUnit = new TextBlock()
                {
                    Text = $"{product.QuantityPerUnit}                          {product.UnitPrice:F2}$ ",
                    Width = 250,
                    Height = 20,
                    Margin = new Thickness(0, 15, 10, 0),
                    Background = Brushes.White
                };



                stackPanel.Children.Add(textBlockProductName);
                stackPanel.Children.Add(textBlockUnitPriceAndQuantityPerUnit);



                button.Content = stackPanel;

                grdCategory.Children.Add(border);

                col++;
                if (col >= 2) // İki ürün yan yana olduğunda, bir sonraki satıra geçmek için
                {
                    col = 0;
                    row++;
                }
            }
            grdMain.Children.Add(scrollViewer);
            //------------------------------
            
        }

        object TagValue; // genel değişken: ürün bilgilerinin tutulduğu değişken

        private void ProductDetails_Click(object sender, RoutedEventArgs e)// For all products
        {
            grdMain.Children.Clear();

            List<UIElement> elementsToKeep = ElementsToKeep();

            var zIndex = 1;
            foreach (var element in elementsToKeep)
            {
                grdMain.Children.Add(element);

                Panel.SetZIndex(element, zIndex++);
            }

            Button button = (Button)sender;
            Product product = (Product)button.Tag;
            TagValue = button.Tag;
            ScrollViewer scrollViewer = new ScrollViewer()
            {

            };

            Grid grdProducts = new Grid()
            {
                Width = double.NaN,
                Height = double.NaN,
                Background = Brushes.Red
            };

            

            Border border = new Border()
            {
                Width = 300,
                Height = 400,
                Background = Brushes.White,
                Margin = new Thickness(0, 0, 650, 0),
                CornerRadius = new CornerRadius(20),
                //Child = iimage
            };

            Line line = new Line()
            {
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(170, 0, 0, 100),
                X1 = 100,
                Y1 = 0,
                X2 = 600,
                Y2 = 0,
                Stroke = Brushes.Black,
                StrokeThickness = 1
            };

            TextBox text = new TextBox()
            {
                Text = product.ProductName,
                FontFamily = new FontFamily("Franklin Gothic Medium"),
                FontSize = 24,
                Width = 400,
                Height = 90,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(100, 40, 0, 350),
                IsReadOnly = true,
                TextWrapping = TextWrapping.Wrap,
                BorderThickness = new Thickness(0)
            };

            TextBox price = new TextBox()
            {
                Text = $"${product.UnitPrice:F2}",
                FontSize = 24,
                FontFamily = new FontFamily("Arial"),
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Width = 90,
                Height = 40,
                IsReadOnly = true,
                Margin = new Thickness(0, 0, 150, 0)
            };

            Border buyBorder = GetBuyBorderr();
            Border basketBorder = GetBasketBorder();

            ProductsCounter productsCounter = new ProductsCounter(grdProducts);


            grdProducts.Children.Add(scrollViewer);

            grdProducts.Children.Add(price);

            grdProducts.Children.Add(text);

            grdProducts.Children.Add(line);

            grdProducts.Children.Add(border);

            grdProducts.Children.Add(buyBorder);

            grdProducts.Children.Add(basketBorder);

            grdMain.Children.Add(grdProducts);
        }

        //----------------------------------------------------
        public Grid ProductsDetailsGrid(Product tagValue)
        {
            List<Product> products = _productDal.GetAllProducts();
            
            Button button = new Button()
            {

            };


            ScrollViewer scrollViewer = new ScrollViewer()
            {
               
            };
            
            Grid grid = new Grid()
            {
                Width = double.NaN,
                Height = double.NaN,
                Background = Brushes.Red
            };

            grid.Tag = tagValue;

            grid.Children.Add(scrollViewer);

            grdMain.Children.Add(grid);

            return grid;
        }
        //----------------------------------------------------

        //************SeaFoodsButtons****************

        //private void seaFoodBtn1_Click(object sender, RoutedEventArgs e)
        //{
        //    grdMain.Children.Clear();

        //    List<UIElement> elementsToKeep = ElementsToKeep();

        //    var zIndex = 1;
        //    foreach (var element in elementsToKeep)
        //    {
        //        grdMain.Children.Add(element);

        //        Panel.SetZIndex(element, zIndex++);
        //    }

        //    Grid grdProducts = ProductsDetailsGrid();

        //    //--------------------------

        //    List<string> buttonsName = new List<string>()
        //    {
        //        "seaFoodBtn1",
        //        "seaFoodBtn2",
        //        "seaFoodBtn3",
        //        "seaFoodBtn4",
        //        "seaFoodBtn5",
        //        "seaFoodBtn6",
        //        "seaFoodBtn7",
        //        "seaFoodBtn8",
        //        "seaFoodBtn9",
        //        "seaFoodBtn10",
        //        "seaFoodBtn11",
        //        "seaFoodBtn12"
        //    };

        //    List<Product> filteredProducts = _productDal.GetByCategory(8);

        //    foreach (var product in filteredProducts)
        //    {
        //        if (product.ProductName == "Ikura")
        //        {
        //            string image = "/ETRadeWPFAppDemo;component/Assets/Ikurajpeg.PNG";

        //            Image iimage = new Image()
        //            {
        //                Source = new BitmapImage(new Uri(image, UriKind.RelativeOrAbsolute)),
        //                Width = 380,
        //                Height = 880,
        //                Stretch = Stretch.Uniform,
        //                HorizontalAlignment = HorizontalAlignment.Left,
        //                VerticalAlignment = VerticalAlignment.Center,
        //            };

        //            Border border = new Border()
        //            {
        //                Width = 300,
        //                Height = 400,
        //                Background = Brushes.White,
        //                Margin = new Thickness(0, 0, 650, 0),
        //                CornerRadius = new CornerRadius(20),
        //                Child = iimage
        //            };

        //            Line line = new Line()
        //            {
        //                VerticalAlignment = VerticalAlignment.Center,
        //                HorizontalAlignment = HorizontalAlignment.Center,
        //                Margin = new Thickness(170, 0, 0, 100),
        //                X1 = 100,
        //                Y1 = 0,
        //                X2 = 600,
        //                Y2 = 0,
        //                Stroke = Brushes.Black,
        //                StrokeThickness = 1
        //            };

        //            TextBox text = new TextBox()
        //            {
        //                Text = product.ProductName,
        //                FontFamily = new FontFamily("Franklin Gothic Medium"),
        //                FontSize = 24,
        //                Width = 400,
        //                Height = 90,
        //                HorizontalAlignment = HorizontalAlignment.Center,
        //                VerticalAlignment = VerticalAlignment.Center,
        //                Margin = new Thickness(100, 40, 0, 350),
        //                IsReadOnly = true,
        //                TextWrapping = TextWrapping.Wrap,
        //                BorderThickness = new Thickness(0)
        //            };

        //            TextBox price = new TextBox()
        //            {
        //                Text = $"${product.UnitPrice:F2}",
        //                FontSize = 24,
        //                FontFamily = new FontFamily("Arial"),
        //                HorizontalAlignment = HorizontalAlignment.Center,
        //                VerticalAlignment = VerticalAlignment.Center,
        //                Width = 90,
        //                Height = 40,
        //                IsReadOnly = true,
        //                Margin = new Thickness(0, 0, 150, 0)
        //            };

        //            grdProducts.Children.Add(price);

        //            grdProducts.Children.Add(text);

        //            grdProducts.Children.Add(line);

        //            grdProducts.Children.Add(border);
        //        }
        //    }

        //    //--------------------------

        //    //string image = "/ETRadeWPFAppDemo;component/Assets/Seafood.png";


        //    //Image iimage = new Image()
        //    //{
        //    //    Source = new BitmapImage(new Uri(image, UriKind.RelativeOrAbsolute)),
        //    //    Width = 380,
        //    //    Height = 880,
        //    //    Stretch = Stretch.Uniform,
        //    //    HorizontalAlignment = HorizontalAlignment.Left,
        //    //    VerticalAlignment = VerticalAlignment.Center,

        //    //};

        //    //Border border = new Border()
        //    //{
        //    //    Width = 300,
        //    //    Height = 400,
        //    //    Background = Brushes.White,
        //    //    Margin = new Thickness(0, 0, 650, 0),
        //    //    CornerRadius = new CornerRadius(20)
        //    //};

        //    //border.Child = iimage;

        //    //Line line = new Line()
        //    //{
        //    //    VerticalAlignment = VerticalAlignment.Center,
        //    //    HorizontalAlignment = HorizontalAlignment.Center,
        //    //    Margin = new Thickness(170, 0, 0, 100),
        //    //    X1 = 100,
        //    //    Y1 = 0,
        //    //    X2 = 600,
        //    //    Y2 = 0,
        //    //    Stroke = Brushes.Black,
        //    //    StrokeThickness = 1
        //    //};

        //    //TextBox text = new TextBox()
        //    //{
        //    //    Text = "deneme text'i \r\n alt satıra geçildi.",
        //    //    FontFamily = new FontFamily("Franklin Gothic Medium"),
        //    //    FontSize = 24,
        //    //    Width = 400,
        //    //    Height = 90,
        //    //    HorizontalAlignment = HorizontalAlignment.Center,
        //    //    VerticalAlignment = VerticalAlignment.Center,
        //    //    Margin = new Thickness(100, 40, 0, 350),
        //    //    IsReadOnly = true,
        //    //    TextWrapping = TextWrapping.Wrap,
        //    //    BorderThickness = new Thickness(0)
        //    //};

        //    //TextBox price = new TextBox()
        //    //{
        //    //    Text = $"{product.QuantityPerUnit}                          {product.UnitPrice:F2}$ ",
        //    //    FontSize = 24,
        //    //    FontFamily = new FontFamily("Arial"),
        //    //    HorizontalAlignment = HorizontalAlignment.Center,
        //    //    VerticalAlignment = VerticalAlignment.Center,
        //    //    Width = 90,
        //    //    Height = 40,
        //    //    IsReadOnly = true,
        //    //    Margin = new Thickness(0, 0, 150, 0)
        //    //};



        //    //--------------------------------
        //    Border buyButton = GetBuyBorderr();

        //    //Border buyBorder = new Border()
        //    //{
        //    //    Name = "brdrBuy",
        //    //    VerticalAlignment = VerticalAlignment.Center,
        //    //    HorizontalAlignment = HorizontalAlignment.Center,
        //    //    Width = 200,
        //    //    Height = 50,
        //    //    Background = Brushes.Aqua,
        //    //    CornerRadius = new CornerRadius(20),
        //    //    Margin = new Thickness(260, 200, 0, 0),
        //    //    Child = buyButton
        //    //};

        //    //------ (+ , - ) kod bloğu------

        ////ProductsCounter productsCounter = new ProductsCounter(grdProducts);

        //    //-------------------------------


        //    //Border basketBorder = GetBasketBorder();

        //    //grdProducts.Children.Add(basketBorder);
        //    //grdProducts.Children.Add(buyButton);
        //    //--------------------------------


        //    //grdProducts.Children.Add(price);

        //    //grdProducts.Children.Add(text);

        //    //grdProducts.Children.Add(line);

        //    //grdProducts.Children.Add(border);

        //}

        //**********************

        //private static Button GetBuyButton()
        //{
        //    Border border = new Border()
        //    {
        //        Width = 200,
        //        Height = 50,
        //        Background = Brushes.Aqua,
        //        CornerRadius = new CornerRadius(20),        
        //        Margin = new Thickness(260, 300, 0, 0),
        //    };

        //    Button buyButton = new Button()
        //    {
        //        Name = "btnBuy",
        //        Margin = new Thickness(260, 300, 0, 0),
        //        Width = 180,
        //        Height = 40,
                
        //        Background = Brushes.Aqua,
        //        BorderThickness = new Thickness(0),
        //        Content = "BUY"
                
        //    };

            

        //    return buyButton;
        //}


        private Border GetBasketBorder()
        {
            Button basketButton = new Button()
            {
                Name = "btnBasket",
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                Width = 180,
                Height = 40,
                Background = Brushes.Aqua,
                BorderThickness = new Thickness(0),
                Content = "Add to card"
            };

            basketButton.Click += AddToCardButton_Click;

            Border basketBorder = new Border()
            {
                Name = "brdrBasket",
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                Width = 200,
                Height = 50,
                Background = Brushes.Aqua,
                CornerRadius = new CornerRadius(20),
                Margin = new Thickness(260, 400, 0, 0),
                Child = basketButton
            };
            return basketBorder;
        }

        private Border GetBuyBorderr()
        {
            Button buyButton = new Button()
            {
                Name = "btnBuy",
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                Width = 180,
                Height = 40,
                Background = Brushes.Aqua,
                BorderThickness = new Thickness(0),
                Content = "Buy"
            };

            buyButton.Click += AddToCardButton_Click;

            Border buyBorder = new Border()
            {
                Name = "brdrBasket",
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                Width = 200,
                Height = 50,
                Background = Brushes.Aqua,
                CornerRadius = new CornerRadius(20),
                Margin = new Thickness(260, 300, 0, 0),
                Child = buyButton
            };
            return buyBorder;
        }

        private void AddToCardButton_Click(object sender, RoutedEventArgs e)
        {

            //Grid orderProductsGrd = ProductsDetailsGrid();

            //orderProductsGrd.Visibility = Visibility.Collapsed;

            List<Product> orderProducts = new List<Product>();

            if (TagValue != null)
            {
                Product product = TagValue as Product;
                orderProducts.Add(product);

            }

        }

        //**************************

        //*******************************************

        private void Seafoods_Click(object sender, RoutedEventArgs e)
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

            //******************************

            List<string> buttonsName = new List<string>()
            {
                "seaFoodBtn1",
                "seaFoodBtn2",
                "seaFoodBtn3",
                "seaFoodBtn4",
                "seaFoodBtn5",
                "seaFoodBtn6",
                "seaFoodBtn7",
                "seaFoodBtn8",
                "seaFoodBtn9",
                "seaFoodBtn10",
                "seaFoodBtn11",
                "seaFoodBtn12"
            };

            List<string> buttonImages = new List<string>()
            {
                "/ETRadeWPFAppDemo;component/Assets/Ikurajpeg.PNG",
                "/ETRadeWPFAppDemo;component/Assets/Kombu.png",
                "",
                "",
                "/ETRadeWPFAppDemo;component/Assets/InlagdSill.png",
                "/ETRadeWPFAppDemo;component/Assets/gravadLax.png",
                "/ETRadeWPFAppDemo;component/Assets/BostonCrabMeat.png",
                "/ETRadeWPFAppDemo;component/Assets/Jack'sNewEnglandClamChowder.png",
                "",
                "",
                "/ETRadeWPFAppDemo;component/Assets/EscargotsDeBourgogne.png",
                "/ETRadeWPFAppDemo;component/Assets/RödKaviar.png"
            };

            //******************************

            //--------------------------------------------------

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

                Button button = new Button()
                {
                    Width = 280,
                    Height = 230,
                    BorderThickness = new Thickness(0),
                    Background = new SolidColorBrush(Colors.White),
                    Tag = product
                };

                button.Click += ProductDetails_Click;

                string buttonName = buttonsName[row * 2 + col];

                //----------------------------------------

                string seaFoodButtonImage = buttonImages[row * 2 + col];

                Uri seaFoodImageUri = new Uri(seaFoodButtonImage, UriKind.RelativeOrAbsolute);

                BitmapImage bitmapImage = new BitmapImage(seaFoodImageUri);

                Image seaFoodImageControl = new Image()
                {
                    Width = 280,
                    Height = 140,
                    Margin = new Thickness(0,0,0,0)
                };
                
                seaFoodImageControl.Source = bitmapImage;

                //----------------------------------------
                border.Child = button;
                
                
                //**************
                StackPanel stackPanel = new StackPanel()
                {
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    Width = 280,
                    Height = 230 
                };

                stackPanel.Children.Add(seaFoodImageControl);

                TextBlock textBlockProductName = new TextBlock()
                {
                    Text = product.ProductName,
                    Margin = new Thickness(0, 30, 65, 0),
                    Width = 190,
                    Height = 20,
                    Background = Brushes.White
                };

                TextBlock textBlockUnitPriceAndQuantityPerUnit = new TextBlock()
                {
                    Text = $"{product.QuantityPerUnit}                          {product.UnitPrice:F2}$ ",
                    Width = 250,
                    Height = 20,
                    Margin = new Thickness(0, 15, 10, 0),
                    Background = Brushes.White
                };

                

                stackPanel.Children.Add(textBlockProductName);
                stackPanel.Children.Add(textBlockUnitPriceAndQuantityPerUnit);
                
                

                button.Content = stackPanel;

                grdCategory.Children.Add(border);

                col++;
                if (col >= 2) // İki ürün yan yana olduğunda, bir sonraki satıra geçmek için
                {
                    col = 0;
                    row++;
                }
            }
            grdMain.Children.Add(scrollViewer);
            
            //--------------------------------------------------

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

                //--
                Uri imageUri = new Uri(imagePath, UriKind.RelativeOrAbsolute); // It represent the resource of image

                BitmapImage bitmapImage = new BitmapImage(imageUri);
                
                Image imageControl = new Image();//Here, you can control the image size

                imageControl.Source = bitmapImage;
                //--

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
                    button.Click += Seafoods_Click;
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
            grdMain.Children.Clear();

            List<UIElement> elementsToKeep = ElementsToKeep();

            var zIndex = 1;
            foreach (var element in elementsToKeep)
            {
                grdMain.Children.Add(element);

                Panel.SetZIndex(element, zIndex++);
            }

            //List<Product> orderProducts = new List<Product>();

            //grdMain.Children.Add(border);

        }

        //******* ürün miktarını arttırıp azaltan kod bloğu****************

        public class ProductsCounter
        {
            private int labelContent = 1;
            private Label label;

            public ProductsCounter(Grid grid)
            {
                label = new Label()
                {

                    Content = labelContent.ToString(),
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    Margin = new Thickness(825, 200, 0, 0),
                    Background = Brushes.Red,
                    Foreground = Brushes.Black,
                    Padding = new Thickness(5)
                };


                Button plusButton = new Button()
                {
                    Name = "tryButton",
                    Width = 25,
                    Height = 25,
                    //Background = Brushes.Red,
                    Margin = new Thickness(900, 200, 0, 0),
                    BorderThickness = new Thickness(0),
                    BorderBrush = Brushes.Transparent,
                    Background = Brushes.Transparent,

                    Content = new Border()
                    {
                        Width = 20,
                        Height = 20,

                        Background = Brushes.LightGray,
                        CornerRadius = new CornerRadius(10),

                        Child = new System.Windows.Shapes.Path()
                        {
                            Data = Geometry.Parse("M 5,10 L 15,10 M 10,5 L 10,15"),

                            Stroke = Brushes.Black,
                            StrokeThickness = 1
                        }
                    }
                };


                Button negativeButton = new Button()
                {
                    Name = "tryButtonn",
                    Width = 25,
                    Height = 25,
                    BorderThickness = new Thickness(0),
                    BorderBrush = Brushes.Transparent,
                    Background = Brushes.Transparent,
                    Margin = new Thickness(750, 200, 0, 0),

                    Content = new Border()
                    {
                        Width = 20,
                        Height = 20,

                        Background = Brushes.LightGray,
                        CornerRadius = new CornerRadius(10),

                        Child = new System.Windows.Shapes.Path()
                        {
                            Data = Geometry.Parse("M 5,10 L 15,10"),
                            Stroke = Brushes.Black,
                            StrokeThickness = 1
                        }
                    }
                };


                if (plusButton.Name == "tryButton")
                {
                    plusButton.Click += PlusButton_Click;
                }

                if (negativeButton.Name == "tryButtonn")
                {
                    negativeButton.Click += NegativeButton_Click;
                }



                grid.Children.Add(label);
                grid.Children.Add(plusButton);

                grid.Children.Add(negativeButton);
            }

            private void NegativeButton_Click(object sender, RoutedEventArgs e)
            {
                if (labelContent > 1)
                {
                    labelContent--;
                    label.Content = labelContent.ToString();
                }


            }

            private void PlusButton_Click(object sender, RoutedEventArgs e)
            {
                labelContent++;
                label.Content = labelContent.ToString();
            }
        }

        //*****************************************************************

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

                Button button = new Button()
                {
                    Width = 280,
                    Height = 230,
                    BorderThickness = new Thickness(0),
                    Background = new SolidColorBrush(Colors.White)
                };
                border.Child = button;

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
                    Text = $"{product.UnitPrice:F2}$",
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

                

                button.Content = stackPanel;

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

      

        //----sepet üzerindeki sipariş sayısı----------

        //public Label GetLabel()
        //{
            
        //    Label label = new Label()
        //    {
        //        Width = 20, Height = 20,
        //        VerticalAlignment = VerticalAlignment.Top, HorizontalAlignment = HorizontalAlignment.Right,
        //        Background = Brushes.Khaki,
        //        Content = 0
        //    };
        //    return label;


        //}

    }
}