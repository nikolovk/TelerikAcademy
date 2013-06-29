using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;


namespace Application.Models
{
    public class FieldModel
    {
        public int Radius { get; set; }
        public Frog MyFrog { get; set; }
        public Frog EnemyFrog { get; set; }
        public int BulletsCount { get; set; }
        public List<Bullet> Bullets { get; set; }
        public List<Point> HitPoints { get; set; }

        public FieldModel()
        {

        }

        public void Init()
        {
            this.Radius = 100;
            this.MyFrog = new Frog()
            {
                Position = new Point() { X = -80, Y = 0 },
                CanShootAfter = 0
            };
            this.EnemyFrog = new Frog()
            {
                Position = new Point() { X = 80, Y = 0 },
                CanShootAfter = 0
            };
            this.Bullets = new List<Bullet>();
        }

        public void CollisionDetector()
        {
            double distanceToCenterMyFrog = this.FindDistance(this.MyFrog.Position, new Point() { X = 0, Y = 0 });
            if (distanceToCenterMyFrog + 3.5 >= this.Radius)
            {
                this.MyFrog.IsAlive = false;
            }

            double distanceToCenterEnemyFrog = this.FindDistance(this.EnemyFrog.Position, new Point() { X = 0, Y = 0 });
            if (distanceToCenterEnemyFrog + 3.5 >= this.Radius)
            {
                this.EnemyFrog.IsAlive = false;
            }

            double distanceBetweenEnemies = this.FindDistance(this.EnemyFrog.Position, this.MyFrog.Position);
            if (distanceBetweenEnemies <= 7)
            {
                this.EnemyFrog.IsAlive = false;
                this.MyFrog.IsAlive = false;
            }

            if (this.HitPoints != null)
            {
                for (int i = 0; i < this.HitPoints.Count; i++)
                {
                    if (this.FindDistance(this.MyFrog.Position, this.HitPoints[i]) < 3.5)
                    {
                        this.MyFrog.IsAlive = false;
                    }
                    if (this.FindDistance(this.EnemyFrog.Position, this.HitPoints[i]) < 3.5)
                    {
                        this.EnemyFrog.IsAlive = false;
                    }
                }
            }

            if (this.Bullets.Count > 0)
            {
                for (int i = 0; i < this.Bullets.Count; i++)
                {
                    if (this.FindDistance(this.Bullets[0].From, new Point() {X=0,Y=0 }) > this.Radius)
                    {
                        this.Bullets.Remove(this.Bullets[i]);
                        this.BulletsCount--;
                    }
                }
            }
        }

        public void MoveAllBullets(int oldCount)
        {
            this.HitPoints = new List<Point>();
            for (int i = 0; i < this.Bullets.Count; i++)
            {
                double deltaX = this.Bullets[i].To.X - this.Bullets[i].From.X;
                double deltaY = this.Bullets[i].To.Y - this.Bullets[i].From.Y;
                if (i < oldCount)
                {
                    for (int j = 1; j <= 10; j++)
                    {
                        this.HitPoints.Add(new Point()
                        {
                            X = this.Bullets[i].From.X + j * deltaX / 10,
                            Y = this.Bullets[i].From.Y + j * deltaY / 10,
                        });
                    }
                }
                else
                {
                    for (int j = 6; j <= 10; j++)
                    {
                        this.HitPoints.Add(new Point()
                        {
                            X = this.Bullets[i].From.X + j * deltaX / 10,
                            Y = this.Bullets[i].From.Y + j * deltaY / 10,
                        });
                    }
                }
                this.Bullets[i].From.X += deltaX;
                this.Bullets[i].From.Y += deltaY;
                this.Bullets[i].To.X += deltaX;
                this.Bullets[i].To.Y += deltaY;
            }
        }

        public void ShootEnemyFrog()
        {
            if (this.EnemyFrog.Shoot != null && this.EnemyFrog.CanShootAfter == 0)
            {
                double shootDistance = this.FindDistance(this.EnemyFrog.Position, this.EnemyFrog.Shoot);
                double deltaX = this.EnemyFrog.Shoot.X - this.EnemyFrog.Position.X;
                double deltaY = this.EnemyFrog.Shoot.Y - this.EnemyFrog.Position.Y;
                double coeficient = shootDistance / 10;

                if (coeficient > 0)
                {
                    this.Bullets.Add(new Bullet()
                    {
                        From = new Point() { X = this.EnemyFrog.Position.X, Y = this.EnemyFrog.Position.Y },
                        To = new Point() { X = this.EnemyFrog.Position.X + deltaX / coeficient, Y = this.EnemyFrog.Position.Y + deltaY / coeficient }
                    });
                    this.BulletsCount++;
                    this.EnemyFrog.CanShootAfter = 8;
                }
                else
                {
                    this.EnemyFrog.CanShootAfter--;
                }
            }
            else
            {
                this.EnemyFrog.CanShootAfter--;
            }
            if (this.EnemyFrog.CanShootAfter < 0)
            {
                this.EnemyFrog.CanShootAfter = 0;
            }
        }

        public void ShootMyFrog()
        {
            if (this.MyFrog.Shoot != null && this.MyFrog.CanShootAfter == 0)
            {
                double shootDistance = this.FindDistance(this.MyFrog.Position, this.MyFrog.Shoot);
                double deltaX = this.MyFrog.Shoot.X - this.MyFrog.Position.X;
                double deltaY = this.MyFrog.Shoot.Y - this.MyFrog.Position.Y;
                double coeficient = shootDistance / 10;

                if (coeficient > 0)
                {
                    this.Bullets.Add(new Bullet()
                    {
                        From = new Point() { X = this.MyFrog.Position.X, Y = this.MyFrog.Position.Y },
                        To = new Point() { X = this.MyFrog.Position.X + deltaX / coeficient, Y = this.MyFrog.Position.Y + deltaY / coeficient }
                    });
                    this.BulletsCount++;
                    this.MyFrog.CanShootAfter = 8;
                }
                else
                {
                    this.MyFrog.CanShootAfter--;
                }
            }
            else
            {
                this.MyFrog.CanShootAfter--;
            }
            if (this.MyFrog.CanShootAfter < 0)
            {
                this.MyFrog.CanShootAfter = 0;
            }
        }

        public void PlayMyMove()
        {
            double moveDistance = this.FindDistance(this.MyFrog.Position, this.MyFrog.Move);
            double deltaX = this.MyFrog.Move.X - this.MyFrog.Position.X;
            double deltaY = this.MyFrog.Move.Y - this.MyFrog.Position.Y;
            double coeficient = 1;
            if (moveDistance > 2)
            {
                coeficient = moveDistance / 2;
            }
            if (coeficient != 0)
            {
                this.MyFrog.Position.X += deltaX / coeficient;
                this.MyFrog.Position.Y += deltaY / coeficient;
            }
            else
            {
                this.MyFrog.Position.X += deltaX;
                this.MyFrog.Position.Y += deltaY;
            }
        }

        public void PlayEnemyMove()
        {
            double moveDistance = this.FindDistance(this.EnemyFrog.Position, this.EnemyFrog.Move);
            double deltaX = this.EnemyFrog.Move.X - this.EnemyFrog.Position.X;
            double deltaY = this.EnemyFrog.Move.Y - this.EnemyFrog.Position.Y;
            double coeficient = 1;
            if (moveDistance > 2)
            {
                coeficient = moveDistance / 2;
            }
            if (coeficient != 0)
            {
                this.EnemyFrog.Position.X += deltaX / coeficient;
                this.EnemyFrog.Position.Y += deltaY / coeficient;
            }
            else
            {
                this.EnemyFrog.Position.X += deltaX;
                this.EnemyFrog.Position.Y += deltaY;
            }
        }

        public void CalculateEnemyFrogMove()
        {
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = @"C:\_Jaba\Jaba2.exe"; // Specify exe name.
            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;
            start.RedirectStandardInput = true;
            using (Process process = Process.Start(start))
            {
                using (StreamWriter writer = process.StandardInput)
                {
                    writer.WriteLine(this.Radius);
                    writer.WriteLine(this.EnemyFrog.Position.X + " " + this.EnemyFrog.Position.Y + " " + this.EnemyFrog.CanShootAfter);
                    writer.WriteLine(this.MyFrog.Position.X + " " + this.MyFrog.Position.Y + " " + this.MyFrog.CanShootAfter);
                    writer.WriteLine(this.BulletsCount);
                    if (this.BulletsCount > 0)
                    {
                        for (int i = 0; i < this.BulletsCount; i++)
                        {
                            writer.WriteLine(this.Bullets[i].From.X + " " + this.Bullets[i].From.Y + " " + this.Bullets[i].To.X + " " + this.Bullets[i].To.Y);
                        }
                    }
                    //
                    // Read in all the text from the process with the StreamReader.
                    //
                    using (StreamReader reader = process.StandardOutput)
                    {
                        string moveLine = reader.ReadLine();
                        if (moveLine.Length > 1)
                        {
                            string[] move = moveLine.Split(' ');
                            this.EnemyFrog.Move = new Point() { X = double.Parse(move[1]), Y = double.Parse(move[2]) };
                        }
                        string shootLine = reader.ReadLine();
                        if (shootLine.Length > 1)
                        {
                            //this.BulletsCount++;
                            string[] shoot = shootLine.Split(' ');
                            this.EnemyFrog.Shoot = new Point() { X = double.Parse(shoot[1]), Y = double.Parse(shoot[2]) };
                        }
                    }
                }
            }
        }

        public void CalculateMyFrogMove()
        {
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = @"C:\_Jaba\Jaba1.exe"; // Specify exe name.
            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;
            start.RedirectStandardInput = true;

            //
            // Start the process.
            //
            using (Process process = Process.Start(start))
            {
                using (StreamWriter writer = process.StandardInput)
                {
                    writer.WriteLine(this.Radius);
                    writer.WriteLine(this.MyFrog.Position.X + " " + this.MyFrog.Position.Y + " " + this.MyFrog.CanShootAfter);
                    writer.WriteLine(this.EnemyFrog.Position.X + " " + this.EnemyFrog.Position.Y + " " + this.EnemyFrog.CanShootAfter);
                    writer.WriteLine(this.BulletsCount);
                    if (this.BulletsCount > 0)
                    {
                        for (int i = 0; i < this.BulletsCount; i++)
                        {
                            writer.WriteLine(this.Bullets[i].From.X + " " + this.Bullets[i].From.Y + " " + this.Bullets[i].To.X + " " + this.Bullets[i].To.Y);
                        }
                    }
                    //
                    // Read in all the text from the process with the StreamReader.
                    //
                    using (StreamReader reader = process.StandardOutput)
                    {
                        string moveLine = reader.ReadLine();
                        if (moveLine.Length > 1)
                        {
                            string[] move = moveLine.Split(' ');
                            this.MyFrog.Move = new Point() { X = double.Parse(move[1]), Y = double.Parse(move[2]) };
                        }
                        string shootLine = reader.ReadLine();
                        if (shootLine.Length > 1)
                        {
                            string[] shoot = shootLine.Split(' ');
                            this.MyFrog.Shoot = new Point() { X = double.Parse(shoot[1]), Y = double.Parse(shoot[2]) };
                        }
                    }
                }
            }
        }


        private double FindDistance(Point pointA, Point pointB)
        {
            double distance = Math.Sqrt((pointA.X - pointB.X) * (pointA.X - pointB.X) + (pointA.Y - pointB.Y) * (pointA.Y - pointB.Y));
            return distance;
        }
    }
}