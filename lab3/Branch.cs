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
    public class Branch
    {
        bool stop = false;

        public Branch(Canvas canvas, List<Point> points, Random random, Point activePoint, string direction, int leafSize, bool allowLeaves) {
            
            while (stop == false)
            {
                int action = random.Next(101);
                if (action >= 20) {
                    activePoint = branchPiece(canvas, points, random, activePoint, direction);
                }
                else if (action < 20 && action >= 10)
                {
                    if (allowLeaves)
                    {
                        Leaf leaf = new Leaf(canvas, random, activePoint, leafSize);
                    }
                }
                else
                {
                    stop = true;
                }
            }
        }
        public Point branchPiece(Canvas canvas, 
                                 List<Point> points,
                                 Random random,                     
                                 Point startPoint,
                                 string direction) 
        {
            Line branch = new Line();
            branch.Stroke = Brushes.Green;
            branch.StrokeThickness = 2;
            branch.X1 = startPoint.X;
            branch.Y1 = startPoint.Y;

            if (direction == "left")
            {
                branch.X2 = branch.X1 - random.Next(26); //Grows to the left
                if (branch.X2 < points[0].X)
                { //If it grows too far to the left
                    branch.X2 = points[0].X;
                    stop = true;
                }
            }
            else
            {
                branch.X2 = branch.X1 + random.Next(26); //Grows to the right
                if (branch.X2 > points[1].X)
                { //If it grows too far to the right
                    branch.X2 = points[1].X;
                    stop = true;
                }
            }
            branch.Y2 = branch.Y1 - random.Next(26);
            if (branch.Y2 < points[0].Y)
            {
                branch.Y2 = points[0].Y;
                stop = true;
            }
            canvas.Children.Add(branch);

            Point activePoint = new Point() { X = branch.X2, Y = branch.Y2 };
            return activePoint;
        }
    }
}
