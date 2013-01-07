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
    public class Leaf
    {
        public Leaf(Canvas canvas, Random random, Point activePoint, int leafSize) 
        {
            PathFigure myPathFigure = new PathFigure();
            myPathFigure.StartPoint = activePoint;

            int chooseDirection = random.Next(101);
            if (chooseDirection <= 50)
            {
                myPathFigure.Segments.Add(
                    new BezierSegment(
                        new Point(activePoint.X + random.Next(21), activePoint.Y - random.Next(15, 21)),
                        new Point(activePoint.X + random.Next(31), activePoint.Y - random.Next(11)),
                        new Point(activePoint.X + random.Next(leafSize - 10, leafSize + 10), activePoint.Y),
                        true));
                myPathFigure.Segments.Add(
                    new BezierSegment(
                        new Point(activePoint.X + random.Next(21), activePoint.Y + random.Next(15, 21)),
                        new Point(activePoint.X + random.Next(11), activePoint.Y + random.Next(11)),
                        new Point(activePoint.X, activePoint.Y),
                        true));
            }
            else
            {
                myPathFigure.Segments.Add(
                    new BezierSegment(
                        new Point(activePoint.X - random.Next(21), activePoint.Y - random.Next(15, 21)),
                        new Point(activePoint.X - random.Next(31), activePoint.Y - random.Next(11)),
                        new Point(activePoint.X - random.Next(leafSize - 10, leafSize + 10), activePoint.Y),
                        true));
                myPathFigure.Segments.Add(
                    new BezierSegment(
                        new Point(activePoint.X - random.Next(21), activePoint.Y + random.Next(15, 21)),
                        new Point(activePoint.X - random.Next(11), activePoint.Y + random.Next(11)),
                        new Point(activePoint.X, activePoint.Y),
                        true));
            }

            PathGeometry myPathGeometry = new PathGeometry();
            myPathGeometry.Figures.Add(myPathFigure);

            Path myPath = new Path();
            myPath.Fill = Brushes.DarkGreen;
            myPath.Stroke = Brushes.DarkGreen;
            myPath.StrokeThickness = 2;
            myPath.Data = myPathGeometry;

            RotateTransform myRotateTransform = new RotateTransform(random.Next(-25, 25));
            myRotateTransform.CenterX = activePoint.X;
            myRotateTransform.CenterY = activePoint.Y;

            myPath.RenderTransform = myRotateTransform;

            canvas.Children.Add(myPath);
        }
    }
}
