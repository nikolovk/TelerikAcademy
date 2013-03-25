using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyRPG
{
    public class Rock : StaticObject, IResource
    {
        private int quantity;
        public Rock(int hitPoints, Point position)
            : base(position)
        {
            this.HitPoints = hitPoints;
            this.Quantity = hitPoints / 2;
        }



        public int Quantity
        {
            get
            {
                return this.quantity;
            }
            private set
            {
                this.quantity = value;
            }
        }

        public ResourceType Type
        {
            get
            {
                return ResourceType.Stone;
            } 
        }
    }
}
