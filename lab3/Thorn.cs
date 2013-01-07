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
        public Thorn(Canvas canvas, Random random, int tilt, Point activePoint, Brush stemColor)
        {
            PathFigure myPathFigure = new PathFigure();
            myPathFigure.StartPoint = activePoint;

            int chooseDirection = random.Next(101);
            if (chooseDirection < 50) // Grow to the right
            {
                myPathFigure.Segments.Add(
                    new BezierSegment(
                        new Point(activePoint.X + 1, activePoint.Y - 6),
                        new Point(activePoint.X + 6, activePoint.Y - 1),
                        new Point(activePoint.X + 6, activePoint.Y + 5),
                        true));

                myPathFigure.Segments.Add(
                    new BezierSegment(
                        new Point(activePoint.X + 2, activePoint.Y),
                        new Point(activePoint.X + 1, activePoint.Y + 2),
                        new Point(activePoint.X, activePoint.Y),
                        true));
            }
            else // Grow to the left
            {
                myPathFigure.Segments.Add(
                    new BezierSegment(
                        new Point(activePoint.X - 1, activePoint.Y - 6),
                        new Point(activePoint.X - 6, activePoint.Y - 1),
                        new Point(activePoint.X - 6, activePoint.Y + 5),
                        true));

                myPathFigure.Segments.Add(
                    new BezierSegment(
                        new Point(activePoint.X - 2, activePoint.Y),
                        new Point(activePoint.X - 1, activePoint.Y + 2),
                        new Point(activePoint.X, activePoint.Y),
                        true));
            }

            PathGeometry myPathGeometry = new PathGeometry();
            myPathGeometry.Figures.Add(myPathFigure);

            canvas.Children.Add(new Path() { Fill = Brushes.DarkOliveGreen,
                                             Stroke = Brushes.DarkOliveGreen,
                                             StrokeThickness = 1,
                                             Data = myPathGeometry,
                                             /*RenderTransform = myRotateTransform*/ });



            /*
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
             * */
        }
    }
}
