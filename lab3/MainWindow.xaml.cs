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
using System.IO;
using Xceed.Wpf.Toolkit;

namespace lab3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    [Serializable()]
    public partial class MainWindow : Window
    {
        public Canvas canvas = new Canvas();
        public ChildWindow control = new ChildWindow();

        public int leafSizeInt, numberOfStems, numberOfThorns, numberOfLeaves, numberOfFlowers, flowerSize, redInt, greenInt, blueInt;

        public Label rednessText = new Label();
        public Label greennessText = new Label();
        public Label bluenessText = new Label();
        public Label leafSizeText = new Label();
        public Label stemAmountText = new Label();
        public Label thornAmountText = new Label();
        public Label leafAmountText = new Label();
        public Label flowerSizeText = new Label();

        public Slider redSlider = new Slider();
        public Slider greenSlider = new Slider();
        public Slider blueSlider = new Slider();
        public Slider leafSizeSlider = new Slider();
        public Slider stemSlider = new Slider();
        public Slider thornSlider = new Slider();
        public Slider leafSlider = new Slider();
        public Slider flowerSizeSlider = new Slider();

        public MainWindow()
        {
            InitializeComponent();
            this.WindowState = System.Windows.WindowState.Maximized;
            canvas.Background = Brushes.LightSkyBlue;
            canvas.Loaded += new RoutedEventHandler(toolInit);      
            grid.Children.Add(canvas);
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

            double factorY = (points[2].Y - points[0].Y) / numberOfStems; 
            int tiltFactor = 100 / numberOfStems;
            bool allowThorns = true;
            bool allowLeaves = true;

            for (int i = 1; i <= numberOfStems; i++)
            {                
                if (objectCounter["amountOfThorns"] == numberOfThorns)
                {
                    allowThorns = false;
                }
                else {
                    objectCounter["amountOfThorns"]++;
                }
                if (objectCounter["amountOfLeaves"] == numberOfLeaves)
                {
                    allowLeaves = false;
                }
                else
                {
                    objectCounter["amountOfLeaves"]++;
                }

                int tilt = i * tiltFactor;
                points[0] = new Point() { X = points[0].X, Y = points[0].Y + (i * factorY) };
                if (points[0].Y > points[1].Y) {
                    points[0] = new Point() { X = points[0].X, Y = points[1].Y / 4 };
                }

                Color flowerColor = Color.FromRgb((byte) (redInt + random.Next(-40, 40)), 
                                                  (byte) (greenInt + random.Next(-40, 40)), 
                                                  (byte) (blueInt + random.Next(-40, 40)));

                Stem stem = new Stem(canvas, points, tilt, random, leafSizeInt, flowerColor, flowerSize, allowThorns, allowLeaves);                
            }
        }
        void toolInit(object sender, RoutedEventArgs e) {
            control.Name = "ToolWindow";
            control.Caption = "Tools for bouquet";
            control.Left = 0;
            control.Top = 0;
            control.Width = 300;
            control.Margin = new Thickness(0);
            control.IsModal = false;
            control.WindowState = Xceed.Wpf.Toolkit.WindowState.Open;
            Grid.SetRowSpan(control, 3);

            control.Content = new Grid() { Name = "toolWinGrid", Margin = new Thickness(10) };
            Grid theGrid = (Grid)control.Content;
            ColumnDefinition colDef1 = new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) };
            ColumnDefinition colDef2 = new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) };
            ColumnDefinition colDef3 = new ColumnDefinition() { Width = new GridLength(0.4, GridUnitType.Star) };

            RowDefinition rowDef1 = new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) };
            RowDefinition rowDef2 = new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) };
            RowDefinition rowDef3 = new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) };
            RowDefinition rowDef4 = new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) };
            RowDefinition rowDef5 = new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) };
            RowDefinition rowDef6 = new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) };
            RowDefinition rowDef7 = new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) };
            RowDefinition rowDef8 = new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) };
            RowDefinition rowDef9 = new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) };
            RowDefinition rowDef10 = new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) };
            RowDefinition rowDef11 = new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) };
            RowDefinition rowDef12 = new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) };

            theGrid.ColumnDefinitions.Add(colDef1);
            theGrid.ColumnDefinitions.Add(colDef2);
            theGrid.ColumnDefinitions.Add(colDef3);

            theGrid.RowDefinitions.Add(rowDef1);
            theGrid.RowDefinitions.Add(rowDef2);
            theGrid.RowDefinitions.Add(rowDef3);
            theGrid.RowDefinitions.Add(rowDef4);
            theGrid.RowDefinitions.Add(rowDef5);
            theGrid.RowDefinitions.Add(rowDef6);
            theGrid.RowDefinitions.Add(rowDef7);
            theGrid.RowDefinitions.Add(rowDef8);
            theGrid.RowDefinitions.Add(rowDef9);
            theGrid.RowDefinitions.Add(rowDef10);
            theGrid.RowDefinitions.Add(rowDef11);
            theGrid.RowDefinitions.Add(rowDef12);

            // Set the default settings
            string[] settings = {200+"",
                                 50+"",
                                 200+"",
                                 50+"",
                                 60+"",
                                 50+"",
                                 50+"",
                                 50+""};

            Label redness = new Label();
            redness.Content = "Redness";
            Grid.SetRow(redness, 0);
            Grid.SetColumn(redness, 0);

            redSlider.Minimum = 40;
            redSlider.Maximum = 215;
            redSlider.Value = Convert.ToInt32(settings[0]);
            redInt = Convert.ToInt32(redSlider.Value);
            redSlider.ValueChanged += new RoutedPropertyChangedEventHandler<double>(setRedness);
            Grid.SetRow(redSlider, 0);
            Grid.SetColumn(redSlider, 1);

            rednessText.Content = redSlider.Value;
            Grid.SetRow(rednessText, 0);
            Grid.SetColumn(rednessText, 2);

            Label greenness = new Label();
            greenness.Content = "Greenness";
            Grid.SetRow(greenness, 1);
            Grid.SetColumn(greenness, 0);

            greenSlider.Minimum = 40;
            greenSlider.Maximum = 215;
            greenSlider.Value = Convert.ToInt32(settings[1]);
            greenInt = Convert.ToInt32(greenSlider.Value);
            greenSlider.ValueChanged += new RoutedPropertyChangedEventHandler<double>(setGreenness);
            Grid.SetRow(greenSlider, 1);
            Grid.SetColumn(greenSlider, 1);

            greennessText.Content = greenSlider.Value;
            Grid.SetRow(greennessText, 1);
            Grid.SetColumn(greennessText, 2);

            Label blueness = new Label();
            blueness.Content = "Blueness";
            Grid.SetRow(blueness, 2);
            Grid.SetColumn(blueness, 0);

            blueSlider.Minimum = 40;
            blueSlider.Maximum = 215;
            blueSlider.Value = Convert.ToInt32(settings[2]);
            blueInt = Convert.ToInt32(blueSlider.Value);
            blueSlider.ValueChanged += new RoutedPropertyChangedEventHandler<double>(setBlueness);
            Grid.SetRow(blueSlider, 2);
            Grid.SetColumn(blueSlider, 1);

            bluenessText.Content = blueSlider.Value;
            Grid.SetRow(bluenessText, 2);
            Grid.SetColumn(bluenessText, 2);

            Label leafSize = new Label();
            leafSize.Content = "Leaf size";
            Grid.SetRow(leafSize, 3);
            Grid.SetColumn(leafSize, 0);

            leafSizeSlider.Minimum = 20;
            leafSizeSlider.Maximum = 80;
            leafSizeSlider.Value = Convert.ToInt32(settings[3]);
            leafSizeInt = Convert.ToInt32(leafSizeSlider.Value);
            leafSizeSlider.ValueChanged += new RoutedPropertyChangedEventHandler<double>(setLeafSize);
            Grid.SetRow(leafSizeSlider, 3);
            Grid.SetColumn(leafSizeSlider, 1);

            leafSizeText.Content = leafSizeSlider.Value;
            Grid.SetRow(leafSizeText, 3);
            Grid.SetColumn(leafSizeText, 2);

            Label stemAmount= new Label();
            stemAmount.Content = "Amount of stems";
            Grid.SetRow(stemAmount, 4);
            Grid.SetColumn(stemAmount, 0);

            stemSlider.Minimum = 20;
            stemSlider.Maximum = 100;
            stemSlider.Value = Convert.ToInt32(settings[4]);
            numberOfStems = Convert.ToInt32(stemSlider.Value);
            stemSlider.ValueChanged += new RoutedPropertyChangedEventHandler<double>(setNumberOfStems);
            Grid.SetRow(stemSlider, 4);
            Grid.SetColumn(stemSlider, 1);

            stemAmountText.Content = stemSlider.Value;
            Grid.SetRow(stemAmountText, 4);
            Grid.SetColumn(stemAmountText, 2);

            Label thornAmount = new Label();
            thornAmount.Content = "Thorn percentage";
            Grid.SetRow(thornAmount, 5);
            Grid.SetColumn(thornAmount, 0);

            thornSlider.Minimum = 0;
            thornSlider.Maximum = 100;
            thornSlider.Value = Convert.ToInt32(settings[5]);
            numberOfThorns = (Convert.ToInt32(thornSlider.Value) * numberOfStems) / 100;
            thornSlider.ValueChanged += new RoutedPropertyChangedEventHandler<double>(setNumberOfThorns);
            Grid.SetRow(thornSlider, 5);
            Grid.SetColumn(thornSlider, 1);

            thornAmountText.Content = thornSlider.Value + "%";
            Grid.SetRow(thornAmountText, 5);
            Grid.SetColumn(thornAmountText, 2);

            Label leafAmount = new Label();
            leafAmount.Content = "Leaf percentage";
            Grid.SetRow(leafAmount, 6);
            Grid.SetColumn(leafAmount, 0);

            leafSlider.Minimum = 0;
            leafSlider.Maximum = 100;
            leafSlider.Value = Convert.ToInt32(settings[6]);
            numberOfLeaves = (Convert.ToInt32(leafSlider.Value) * numberOfStems) / 100;
            leafSlider.ValueChanged += new RoutedPropertyChangedEventHandler<double>(setNumberOfLeaves);
            Grid.SetRow(leafSlider, 6);
            Grid.SetColumn(leafSlider, 1);

            leafAmountText.Content = leafSlider.Value + "%";
            Grid.SetRow(leafAmountText, 6);
            Grid.SetColumn(leafAmountText, 2);

            Label flowerSizeLabel = new Label();
            flowerSizeLabel.Content = "Flower size";
            Grid.SetRow(flowerSizeLabel, 7);
            Grid.SetColumn(flowerSizeLabel, 0);

            flowerSizeSlider.Minimum = 20;
            flowerSizeSlider.Maximum = 80;
            flowerSizeSlider.Value = Convert.ToInt32(settings[7]);
            flowerSize = Convert.ToInt32(flowerSizeSlider.Value);
            flowerSizeSlider.ValueChanged += new RoutedPropertyChangedEventHandler<double>(setFlowerSize);
            Grid.SetRow(flowerSizeSlider, 7);
            Grid.SetColumn(flowerSizeSlider, 1);


            flowerSizeText.Content = flowerSizeSlider.Value;
            Grid.SetRow(flowerSizeText, 7);
            Grid.SetColumn(flowerSizeText, 2);

            Button generator = new Button();
            generator.Content = "Generate!";
            generator.Click += new RoutedEventHandler(generateBouquet);
            Grid.SetRow(generator, 8);
            Grid.SetColumn(generator, 0);

            Button picSaver = new Button();
            picSaver.Content = "Save picture";
            picSaver.Click += new RoutedEventHandler(savePNG);
            Grid.SetRow(picSaver, 9);
            Grid.SetColumn(picSaver, 0);

            Button settingsSaver = new Button();
            settingsSaver.Content = "Save settings";
            settingsSaver.Click += new RoutedEventHandler(saveSettings);
            Grid.SetRow(settingsSaver, 10);
            Grid.SetColumn(settingsSaver, 0);

            Button settingsLoader = new Button();
            settingsLoader.Content = "Load settings";
            settingsLoader.Click += new RoutedEventHandler(loadSettings);
            Grid.SetRow(settingsLoader, 11);
            Grid.SetColumn(settingsLoader, 0);

            theGrid.Children.Add(redness);
            theGrid.Children.Add(redSlider);
            theGrid.Children.Add(rednessText);
            theGrid.Children.Add(greenness);
            theGrid.Children.Add(greenSlider);
            theGrid.Children.Add(greennessText);
            theGrid.Children.Add(blueness);
            theGrid.Children.Add(blueSlider);
            theGrid.Children.Add(bluenessText);
            theGrid.Children.Add(leafSize);
            theGrid.Children.Add(leafSizeSlider);
            theGrid.Children.Add(leafSizeText);
            theGrid.Children.Add(stemAmount);
            theGrid.Children.Add(stemSlider);
            theGrid.Children.Add(stemAmountText);
            theGrid.Children.Add(thornAmount);
            theGrid.Children.Add(thornSlider);
            theGrid.Children.Add(thornAmountText);
            theGrid.Children.Add(leafAmount);
            theGrid.Children.Add(leafSlider);
            theGrid.Children.Add(leafAmountText);
            theGrid.Children.Add(flowerSizeLabel);
            theGrid.Children.Add(flowerSizeSlider);
            theGrid.Children.Add(flowerSizeText);
            theGrid.Children.Add(generator);
            theGrid.Children.Add(picSaver);
            theGrid.Children.Add(settingsSaver);
            theGrid.Children.Add(settingsLoader);
            
            grid.Children.Add(control);
         
        }

        void setRedness(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            redInt = Convert.ToInt32(e.NewValue);
            rednessText.Content = Convert.ToInt32(e.NewValue);
        }

        void setGreenness(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            greenInt = Convert.ToInt32(e.NewValue);
            greennessText.Content = Convert.ToInt32(e.NewValue);
        }

        void setBlueness(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            blueInt = Convert.ToInt32(e.NewValue);
            bluenessText.Content = Convert.ToInt32(e.NewValue);
        }

        void setLeafSize(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            leafSizeInt = Convert.ToInt32(e.NewValue);
            leafSizeText.Content = Convert.ToInt32(e.NewValue);
        }

        void setNumberOfStems(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            numberOfStems = Convert.ToInt32(e.NewValue);
            stemAmountText.Content = Convert.ToInt32(e.NewValue);
        }

        void setNumberOfThorns(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            numberOfThorns = (Convert.ToInt32(e.NewValue) * numberOfStems) / 100;
            thornAmountText.Content = Convert.ToInt32(e.NewValue) + "%";
        }

        void setNumberOfLeaves(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            numberOfLeaves = (Convert.ToInt32(e.NewValue) * numberOfStems) / 100;
            leafAmountText.Content = Convert.ToInt32(e.NewValue) + "%";
        }

        private void setFlowerSize(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            flowerSize = Convert.ToInt32(e.NewValue);
            flowerSizeText.Content = Convert.ToInt32(e.NewValue);
        }

        private void saveSettings(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.DefaultExt = ".txt";
            dlg.Filter = "Text documents (.txt)|*.txt";
            // Open a default directory if it exists
            string path = "C:\\Users\\Public\\";
            if (Directory.Exists(path))
            {
                dlg.InitialDirectory = path;
            }
            else
            {
                dlg.InitialDirectory = @"C:\";
            }
            if (dlg.ShowDialog() == true)
            {
                string filename = dlg.FileName;

                string[] settings = {redInt+"",
                                     greenInt+"",
                                     blueInt+"",
                                     leafSizeInt+"",
                                     numberOfStems+"",
                                     thornAmountText.Content.ToString().Substring(0, thornAmountText.Content.ToString().Length - 1)+"",
                                     leafAmountText.Content.ToString().Substring(0, leafAmountText.Content.ToString().Length - 1)+"",
                                     flowerSize+""};

                System.IO.File.WriteAllLines(filename, settings);
            }
        }

        private void loadSettings(object sender, RoutedEventArgs e)
        {
            // Create OpenFileDialog
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            // Set filter for file extension and default file extension
            dlg.DefaultExt = ".txt";
            dlg.Filter = "Text documents (.txt)|*.txt";

            // Open a default directory if it exists
            string path = "C:\\Users\\Public\\";
            if (Directory.Exists(path))
            {
                dlg.InitialDirectory = path;
            }
            else
            {
                dlg.InitialDirectory = @"C:\";
            } 

            // Display OpenFileDialog by calling ShowDialog method
            Nullable<bool> result = dlg.ShowDialog();

            // Get the selected file name and display in a TextBox
            if (result == true)
            {
                // Open document
                string filename = dlg.FileName;
                Console.WriteLine(filename);

                string[] settings = System.IO.File.ReadAllLines(filename);

                redSlider.Value = Convert.ToInt32(settings[0]);
                greenSlider.Value = Convert.ToInt32(settings[1]);
                blueSlider.Value = Convert.ToInt32(settings[2]);
                leafSizeSlider.Value = Convert.ToInt32(settings[3]);
                stemSlider.Value = Convert.ToInt32(settings[4]);
                thornSlider.Value = Convert.ToInt32(settings[5]);
                leafSlider.Value = Convert.ToInt32(settings[6]);
                flowerSizeSlider.Value = Convert.ToInt32(settings[7]);
            }
        }

        private void savePNG(object sender, RoutedEventArgs e)
        {
            util.SaveAsPNG(this.canvas, 96, "C:\\Users\\Public\\lab3.png");
        }

        public static class util
        {
            public static void SaveAsPNG(/*Window window,*/ Canvas canvas, int dpi, string filename)
            {
                var rtb = new RenderTargetBitmap(
                    (int)canvas.ActualWidth, // width
                    (int)canvas.ActualWidth, // height
                    dpi, // dpi X
                    dpi, // dpi Y
                    PixelFormats.Pbgra32 // Pixelformat
                    );
                rtb.Render(canvas);
                saveRTBAsPNG(rtb, filename);
            }

            private static void saveRTBAsPNG(RenderTargetBitmap bmp, string filename)
            {
                var enc = new System.Windows.Media.Imaging.PngBitmapEncoder();

                enc.Frames.Add(System.Windows.Media.Imaging.BitmapFrame.Create(bmp));
                using (var stm = System.IO.File.Create(filename))
                {
                    enc.Save(stm);
                }
                Console.WriteLine("You saved a PNG");
            }
        }
    }
}
