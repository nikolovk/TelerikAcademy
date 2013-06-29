using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jaba
{
    public class Algorithm
    {
        public static int BulletsCount { get; set; }
        public static Bullet[] Bullets { get; set; }
        public static int Radius {get;set;}
        public static Frog MyFrog { get; set; }
        public static Frog EnemyFrog { get; set; }
        public static List<Point> Dangerous { get; set; }

        static void Main(string[] args)
        {
            Dangerous = new List<Point>();
            ReadInput();
            if (Dangerous.Count > 0)
            {
                Point escapePoint = FindEscapeDirection();
                Console.WriteLine("move " + escapePoint.X + " " + escapePoint.Y);
            }
            else
            {
                Console.WriteLine("move 0 0");
            }
            double distanceToEnemy = FindDistance(MyFrog.Position, EnemyFrog.Position);
            if ((distanceToEnemy > 56 || distanceToEnemy < 23.5) && MyFrog.CanShootAfter == 0)
            {
                Console.WriteLine("shoot " + EnemyFrog.Position.X + " " + EnemyFrog.Position.Y);
            }
            else
            {
                Console.WriteLine();
            }
        }

        private static Point FindEscapeDirection()
        {
            Point escapePoint = new Point();
            if (Dangerous.Count == 1)
            {
                double deltaX = MyFrog.Position.X - Dangerous[0].X;
                double deltaY = MyFrog.Position.Y - Dangerous[0].Y;
                escapePoint.X = MyFrog.Position.X + deltaX;
                escapePoint.Y = MyFrog.Position.Y + deltaY;
            }
            else
            {
                double deltaX = Dangerous[0].Y - Dangerous[1].Y;
                double deltaY = Dangerous[0].X - Dangerous[1].X;
                escapePoint.X = MyFrog.Position.X - 2*deltaX;
                escapePoint.Y = MyFrog.Position.Y + 2*deltaY;
            }

            return escapePoint;
        }



        private static void ReadInput()
        {
            Radius = int.Parse(Console.ReadLine());
            string[] lineMyFrog = Console.ReadLine().Split(' ');
            MyFrog = new Frog() 
            { 
                Position = new Point() { X = double.Parse(lineMyFrog[0]), Y = double.Parse(lineMyFrog[1]) }, 
                CanShootAfter = int.Parse(lineMyFrog[2]) 
            };
            string[] lineEnemyFrog = Console.ReadLine().Split(' ');
            EnemyFrog = new Frog()
            {
                Position = new Point() { X = double.Parse(lineEnemyFrog[0]), Y = double.Parse(lineEnemyFrog[1]) },
                CanShootAfter = int.Parse(lineEnemyFrog[2])
            };
            BulletsCount = int.Parse(Console.ReadLine());
            if (BulletsCount > 0)
            {
                Bullets = new Bullet[BulletsCount];
                for (int i = 0; i < BulletsCount; i++)
                {
                    string[] line = Console.ReadLine().Split(' ');
                    Bullets[i] = new Bullet()
                    {
                        From = new Point() { X = double.Parse(line[0]), Y = double.Parse(line[1]) },
                        To = new Point() { X = double.Parse(line[2]), Y = double.Parse(line[3]) }
                    };
                    FindDangerousPoints(Bullets[i]);
                }
            }
        }

        private static void FindDangerousPoints(Bullet bullet)
        {
            double deltaX = (bullet.To.X - bullet.From.X) / 10;
            double deltaY = (bullet.To.Y - bullet.From.Y) / 10;
            double oldDistance = FindDistance(bullet.From, MyFrog.Position);
            Point point = new Point() { X = bullet.From.X + deltaX, Y = bullet.From.Y + deltaY };
            double currentDistance = FindDistance(point, MyFrog.Position);
            if (oldDistance > currentDistance && currentDistance < 30)
            {
                bool dangerousAdded = false;
                while (oldDistance > currentDistance)
                {
                    var oldPoint = new Point() { X = point.X, Y = point.Y };
                    if (currentDistance < 4.5)
                    {
                        Dangerous.Add(oldPoint);
                        dangerousAdded = true;
                    }
                    oldDistance = currentDistance;
                    point.X += deltaX;
                    point.Y += deltaY;
                    currentDistance = FindDistance(point, MyFrog.Position);
                }
                if (dangerousAdded)
                {
                    Dangerous.Add(point);
                }              
            }
        }

        private static double FindDistance(Point pointA, Point pointB)
        {
            double distance = Math.Sqrt((pointA.X - pointB.X) * (pointA.X - pointB.X) + (pointA.Y - pointB.Y) * (pointA.Y - pointB.Y));
            return distance;
        }
    }
}
