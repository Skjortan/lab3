using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace lab3
{
    public class Thorn
    {
        public Thorn(Canvas canvas, int tilt, Point activePoint, string stemColor)
        {
            Rectangle thorn = new Rectangle();
            thorn.Width = 15;
            thorn.Height = 15;
            thorn.RenderTransform = new RotateTransform(tilt+45, thorn.Width / 2, thorn.Height / 2);

            if (stemColor == "Green")
            {
                thorn.Fill = Brushes.Green;
            }
            else
            {
                thorn.Fill = Brushes.ForestGreen;
            }

            Canvas.SetLeft(thorn, activePoint.X - 7.5);
            Canvas.SetTop(thorn, activePoint.Y - 7.5);

            canvas.Children.Add(thorn);
            Console.WriteLine("Added a thorn! " + tilt);
        }
    }
}
