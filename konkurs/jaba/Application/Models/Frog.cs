using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Models
{
    public class Frog
    {
        public Point Position { get; set; }
        public int CanShootAfter { get; set; }
        public Point Move { get; set; }
        public Point Shoot { get; set; }
        public bool IsAlive { get; set; }

        public Frog()
        {
            this.IsAlive = true;
        }
    }
}
