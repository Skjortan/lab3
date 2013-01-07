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
using Xceed.Wpf.Toolkit;

namespace lab3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        public Canvas canvas = new Canvas();
        public ChildWindow control = new ChildWindow();

        public int leafSizeInt, numberOfStems, numberOfThorns, numberOfLeaves, redInt, greenInt, blueInt;

        public MainWindow()
        {
            InitializeComponent();
            this.WindowState = System.Windows.WindowState.Maximized;
            canvas.Background = Brushes.LightSkyBlue;
            canvas.Loaded += new RoutedEventHandler(toolInit);      
            grid.Children.Add(canvas);

            //Testing for Git
            //toolInit();            
        }
        void generateBouquet(object sender, RoutedEventArgs e) {
            canvas.Children.Clear();

            Random random = new Random();

            var objectCounter = new Dictionary<string, int>();
            objectCounter.Add("amountOfStems", 0);
            objectCounter.Add("amountOfThorns",0);
            objectCounter.Add("amountOfLeaves", 0);

            List<Point> points = new List<Point>();
            Point minPoint = new Point()     { X = canvas.ActualWidth / 4,              //Min points (0)
                                               Y = (canvas.ActualHeight - 100) / 4 };
            Point maxPoint = new Point()     { X = (canvas.ActualWidth / 4) * 3,        //Max points (1)
                                               Y = canvas.ActualHeight - 100 };
            Point waistPoint = new Point()   { X = canvas.ActualWidth / 2,              //Waist point (2)
                                               Y = canvas.ActualHeight - 100};
            Point bottomCenter = new Point() { X = canvas.ActualWidth / 2,              //Bottom center point (3)
                                               Y = canvas.ActualHeight };
            points.Add(minPoint);
            points.Add(maxPoint);
            points.Add(waistPoint);
            points.Add(bottomCenter);            

            //int numberOfStems = 70;
            //double minimumY = waistPoint.Y / 4; // = points[0].Y
            double factorY = (points[2].Y - points[0].Y) / numberOfStems;
            //double factorY = (waistPoint.Y - minimumY) / numberOfStems;

            //double minimumYFactor = 100 / minimumY;
            int tiltFactor = 100 / numberOfStems;
            for (int i = 0; i <= numberOfStems; i++)
            {
                int tilt = i * tiltFactor;
                points[0] = new Point() { X = points[0].X, Y = points[0].Y + (i * factorY) };
                if (points[0].Y > points[1].Y) {
                    points[0] = new Point() { X = points[0].X, Y = points[1].Y / 4 };
                }
                //points[0].Y = points[0].Y + (i * factorY);

                Color flowerColor = Color.FromRgb((byte) (redInt + random.Next(-40, 40)), 
                                                  (byte) (greenInt + random.Next(-40, 40)), 
                                                  (byte) (blueInt + random.Next(-40, 40)));

                Stem stem = new Stem(canvas, points, tilt, random, leafSizeInt, flowerColor);                
            }
        }
        void toolInit(object sender, RoutedEventArgs e) {
            control.Name = "ToolWindow";
            control.Caption = "Tools for boquet";
            //toolWin.Height = 250;
            control.Left = 10;
            control.Top = 50;
            control.Width = 260;
            control.Margin = new Thickness(0);
            control.IsModal = false;
            control.WindowState = Xceed.Wpf.Toolkit.WindowState.Open;
            Grid.SetRowSpan(control, 3);
            /*
            control.Caption = "Tools";
            control.Name = "toolControl";
            control.Left = 0;
            control.Top = 0;
            control.IsModal = false;
            control.WindowState = Xceed.Wpf.Toolkit.WindowState.Open;
             */

            //Grid toolGrid = new Grid();

            control.Content = new Grid() { Name = "toolWinGrid", Margin = new Thickness(10) };
            Grid theGrid = (Grid)control.Content;
            ColumnDefinition colDef1 = new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) };
            ColumnDefinition colDef2 = new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) };

            RowDefinition rowDef1 = new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) };
            RowDefinition rowDef2 = new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) };
            RowDefinition rowDef3 = new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) };
            RowDefinition rowDef4 = new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) };
            RowDefinition rowDef5 = new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) };
            RowDefinition rowDef6 = new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) };
            RowDefinition rowDef7 = new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) };
            RowDefinition rowDef8 = new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) };

            theGrid.ColumnDefinitions.Add(colDef1);
            theGrid.ColumnDefinitions.Add(colDef2);

            theGrid.RowDefinitions.Add(rowDef1);
            theGrid.RowDefinitions.Add(rowDef2);
            theGrid.RowDefinitions.Add(rowDef3);
            theGrid.RowDefinitions.Add(rowDef4);
            theGrid.RowDefinitions.Add(rowDef5);
            theGrid.RowDefinitions.Add(rowDef6);
            theGrid.RowDefinitions.Add(rowDef7);
            theGrid.RowDefinitions.Add(rowDef8);

            Label redness = new Label();
            redness.Content = "Redness";
            Grid.SetRow(redness, 0);
            Grid.SetColumn(redness, 0);

            Slider redSlider = new Slider();
            redSlider.Minimum = 40;
            redSlider.Maximum = 215;
            redSlider.Value = 200;
            redInt = Convert.ToInt32(redSlider.Value);
            redSlider.ValueChanged += new RoutedPropertyChangedEventHandler<double>(setRedness);
            Grid.SetRow(redSlider, 0);
            Grid.SetColumn(redSlider, 1);

            Label greenness = new Label();
            greenness.Content = "Greenness";
            Grid.SetRow(greenness, 1);
            Grid.SetColumn(greenness, 0);

            Slider greenSlider = new Slider();
            greenSlider.Minimum = 40;
            greenSlider.Maximum = 215;
            greenSlider.Value = 50;
            greenInt = Convert.ToInt32(greenSlider.Value);
            greenSlider.ValueChanged += new RoutedPropertyChangedEventHandler<double>(setGreenness);
            Grid.SetRow(greenSlider, 1);
            Grid.SetColumn(greenSlider, 1);

            Label blueness = new Label();
            blueness.Content = "Blueness";
            Grid.SetRow(blueness, 2);
            Grid.SetColumn(blueness, 0);

            Slider blueSlider = new Slider();
            blueSlider.Minimum = 40;
            blueSlider.Maximum = 215;
            blueSlider.Value = 200;
            blueInt = Convert.ToInt32(blueSlider.Value);
            blueSlider.ValueChanged += new RoutedPropertyChangedEventHandler<double>(setBlueness);
            Grid.SetRow(blueSlider, 2);
            Grid.SetColumn(blueSlider, 1);

            Label leafSize = new Label();
            leafSize.Content = "Leaf size";
            Grid.SetRow(leafSize, 3);
            Grid.SetColumn(leafSize, 0);

            Slider leafSizeSlider = new Slider();
            leafSizeSlider.Minimum = 20;
            leafSizeSlider.Maximum = 80;
            leafSizeSlider.Value = 50;
            leafSizeInt = Convert.ToInt32(leafSizeSlider.Value);
            leafSizeSlider.ValueChanged += new RoutedPropertyChangedEventHandler<double>(setLeafSize);
            Grid.SetRow(leafSizeSlider, 3);
            Grid.SetColumn(leafSizeSlider, 1);

            Label stemAmount= new Label();
            stemAmount.Content = "Amount of stems";
            Grid.SetRow(stemAmount, 4);
            Grid.SetColumn(stemAmount, 0);

            Slider stemSlider = new Slider();
            stemSlider.Minimum = 20;
            stemSlider.Maximum = 100;
            stemSlider.Value = 60;
            numberOfStems = Convert.ToInt32(stemSlider.Value);
            stemSlider.ValueChanged += new RoutedPropertyChangedEventHandler<double>(setNumberOfStems);
            Grid.SetRow(stemSlider, 4);
            Grid.SetColumn(stemSlider, 1);

            Label thornAmount = new Label();
            thornAmount.Content = "Amount of thorns";
            Grid.SetRow(thornAmount, 5);
            Grid.SetColumn(thornAmount, 0);

            Slider thornSlider = new Slider();
            thornSlider.Minimum = 0;
            thornSlider.Maximum = 100;
            thornSlider.Value = 50;
            numberOfThorns = Convert.ToInt32(thornSlider.Value);
            thornSlider.ValueChanged += new RoutedPropertyChangedEventHandler<double>(setNumberOfThorns);
            Grid.SetRow(thornSlider, 5);
            Grid.SetColumn(thornSlider, 1);

            Label leafAmount = new Label();
            leafAmount.Content = "Amount of leaves";
            Grid.SetRow(leafAmount, 6);
            Grid.SetColumn(leafAmount, 0);

            Slider leafSlider = new Slider();
            leafSlider.Minimum = 0;
            leafSlider.Maximum = 100;
            leafSlider.Value = 50;
            numberOfLeaves = Convert.ToInt32(leafSlider.Value);
            leafSlider.ValueChanged += new RoutedPropertyChangedEventHandler<double>(setNumberOfLeaves);
            Grid.SetRow(leafSlider, 6);
            Grid.SetColumn(leafSlider, 1);

            Button generator = new Button();
            generator.Content = "Generate!";
            generator.Click += new RoutedEventHandler(generateBouquet);
            Grid.SetRow(generator, 7);
            Grid.SetColumn(generator, 0);

            theGrid.Children.Add(redness);
            theGrid.Children.Add(redSlider);
            theGrid.Children.Add(greenness);
            theGrid.Children.Add(greenSlider);
            theGrid.Children.Add(blueness);
            theGrid.Children.Add(blueSlider);
            theGrid.Children.Add(leafSize);
            theGrid.Children.Add(leafSizeSlider);
            theGrid.Children.Add(stemAmount);
            theGrid.Children.Add(stemSlider);
            theGrid.Children.Add(thornAmount);
            theGrid.Children.Add(thornSlider);
            theGrid.Children.Add(leafAmount);
            theGrid.Children.Add(leafSlider);
            theGrid.Children.Add(generator);
            //toolGrid.Children.Add(generator);
            //control.Content = toolGrid;
            
            grid.Children.Add(control);
         
        }

        void setRedness(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            redInt = Convert.ToInt32(e.NewValue);
        }

        void setGreenness(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            greenInt = Convert.ToInt32(e.NewValue);
        }

        void setBlueness(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            blueInt = Convert.ToInt32(e.NewValue);
        }

        void setLeafSize(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            leafSizeInt = Convert.ToInt32(e.NewValue);
        }

        void setNumberOfStems(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            numberOfStems = Convert.ToInt32(e.NewValue);
        }

        void setNumberOfThorns(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            numberOfThorns = Convert.ToInt32(e.NewValue);
        }

        void setNumberOfLeaves(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            numberOfLeaves = Convert.ToInt32(e.NewValue);
        }
    }
}
