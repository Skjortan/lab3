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
    public class Stem
    {
        bool stop = false;

        public Stem(Canvas canvas, List<Point>points, int tilt, Random random, int leafSize, Color flowerColor, int flowerSize, bool allowThorns, bool allowLeaves, bool allowFlowers) {            
            Line stem = new Line();

            //Randomize stem color, 50/50 percent chance
            if (random.Next(101) <= 50)
            {
                stem.Stroke = Brushes.Green;
            }
            else
            {
                stem.Stroke = Brushes.ForestGreen;
            }
            stem.StrokeThickness = 5;

            //Decide whether to grow to the left or right
            string direction;
            if (random.Next(101) < 50)
            {
                stem.X1 = points[3].X - random.Next(101); //Starts from the left, Grows to the right
                direction = "right";
            }
            else {
                stem.X1 = points[3].X + random.Next(101); //Starts from the right, Grows to the left
                direction = "left";
            }
            stem.Y1 = points[3].Y - random.Next(51);
            stem.X2 = points[2].X;
            stem.Y2 = points[2].Y;
            canvas.Children.Add(stem);

            Point activePoint = new Point();
            activePoint = points[2];
            while(stop == false) {
                int action = random.Next(101);
                if (action <= 60)
                {
                    activePoint = stemPiece(canvas, points, tilt, random, activePoint, direction, stem.Stroke);
                }
                else if (action > 60 && action <= 73)
                {
                    Branch branch = new Branch(canvas, points, random, activePoint, direction, leafSize, allowLeaves);
                }
                else if (action > 73 && action <= 86)
                {
                    if (allowLeaves)
                    {
                        Leaf leaf = new Leaf(canvas, random, activePoint, leafSize);
                    }
                }
                else if(action > 86 && action <= 98)
                {
                    if (allowThorns)
                    {
                        Thorn thorn = new Thorn(canvas, random, activePoint, stem.Stroke);
                    }
                }
                else if (action > 98)
                {
                    if (allowFlowers)
                    {
                        Flower flower = new Flower(canvas, random, activePoint, flowerColor, flowerSize);
                    }
                    stop = true;
                }                         
            }
            if (allowFlowers)
            {
                Flower finalFlower = new Flower(canvas, random, activePoint, flowerColor, flowerSize);
            }
        }
        public Point stemPiece(Canvas canvas, 
                               List<Point> points,
                               int tilt,
                               Random random,                               
                               Point startPoint, 
                               string direction,
                               Brush stemStroke)
        {
            Line stem = new Line();
            stem.Stroke = stemStroke;
            stem.StrokeThickness = 5;
            stem.X1 = startPoint.X;
            stem.Y1 = startPoint.Y;

            if (direction == "left")
            {
                stem.X2 = stem.X1 - random.Next(tilt); //Grows to the left
                if (stem.X2 < points[0].X) { //If it grows too far to the left
                    stem.X2 = points[0].X;
                    stop = true;
                }
            }
            else {
                stem.X2 = stem.X1 + random.Next(tilt); //Grows to the right
                if (stem.X2 > points[1].X) { //If it grows too far to the right
                    stem.X2 = points[1].X;
                    stop = true;
                }
            }
            stem.Y2 = stem.Y1 - random.Next(51);
            if (stem.Y2 < points[0].Y)
            {
                stem.Y2 = points[0].Y;
                stop = true;
            }                
                       
            canvas.Children.Add(stem);

            Point activePoint = new Point() { X = stem.X2, Y = stem.Y2 };
            return activePoint;
        }
    }
}
