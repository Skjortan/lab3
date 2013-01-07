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
    public class Flower
    {
        public Flower(Canvas canvas, Random random, Point activePoint, Color flowerColor) // Should also receive a color
        {
            PathFigure myPathFigure = new PathFigure();
            myPathFigure.StartPoint = activePoint;

            int chooseFlower = random.Next(101);
            if (chooseFlower < 50)
            {
                myPathFigure.Segments.Add(
                    new BezierSegment(
                        new Point(activePoint.X - 10, activePoint.Y - 10),
                        new Point(activePoint.X - 10, activePoint.Y - 28),
                        new Point(activePoint.X, activePoint.Y - 30),
                        true));

                myPathFigure.Segments.Add(
                    new BezierSegment(
                        new Point(activePoint.X + 10, activePoint.Y - 28),
                        new Point(activePoint.X + 10, activePoint.Y - 10),
                        new Point(activePoint.X, activePoint.Y),
                        true));
            }
            else
            {
                myPathFigure.Segments.Add(
                    new BezierSegment(
                        new Point(activePoint.X - 10, activePoint.Y - 10),
                        new Point(activePoint.X - 10, activePoint.Y - 20),
                        new Point(activePoint.X, activePoint.Y - 30),
                        true));

                myPathFigure.Segments.Add(
                    new BezierSegment(
                        new Point(activePoint.X + 10, activePoint.Y - 20),
                        new Point(activePoint.X + 10, activePoint.Y - 10),
                        new Point(activePoint.X, activePoint.Y),
                        true));
            }

            PathGeometry myPathGeometry = new PathGeometry();
            myPathGeometry.Figures.Add(myPathFigure);

            int i = 0;
            while(i <= 360)
            {
                RotateTransform myRotateTransform = new RotateTransform(i);
                myRotateTransform.CenterX = activePoint.X;
                myRotateTransform.CenterY = activePoint.Y;
                Path path = new Path();
                Canvas.SetZIndex(path, 10);

                canvas.Children.Add(new Path() { Fill = new SolidColorBrush(flowerColor),
                                                 Stroke = Brushes.Black,
                                                 StrokeThickness = 1,
                                                 Data = myPathGeometry, 
                                                 RenderTransform = myRotateTransform });
                i = i + random.Next(90);
                if (i > 360)
                {
                    break;
                }
            }

            // Add center of flower
            PathFigure myCenterFigure = new PathFigure();
            myCenterFigure.StartPoint = new Point(activePoint.X - 5, activePoint.Y);

            myCenterFigure.Segments.Add(
                new ArcSegment(
                    new Point(activePoint.X + 5, activePoint.Y),
                    new Size(5, 5),
                    45,
                    true,
                    SweepDirection.Clockwise,
                    true));
            myCenterFigure.Segments.Add(
                new ArcSegment(
                    new Point(activePoint.X - 5, activePoint.Y),
                    new Size(5, 5),
                    45,
                    true,
                    SweepDirection.Clockwise,
                    true));

            PathGeometry myCenterGeometry = new PathGeometry();
            myCenterGeometry.Figures.Add(myCenterFigure);

            canvas.Children.Add(new Path() { Fill = Brushes.Yellow,                                             
                                             Data = myCenterGeometry });
        }
    }
}
