using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftwareAcademy
{
    public class OffsiteCourse : Course, IOffsiteCourse
    {
        public string Town{get;set;}

                public OffsiteCourse(string name, ITeacher teacher, string town)
            : base(name, teacher)
        {
            if (town != null)
            {
                this.Town = town;
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

    }
}
