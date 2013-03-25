using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftwareAcademy
{
    public class LocalCourse : Course, ILocalCourse
    {
        public string Lab{get;set;}

        public LocalCourse(string name, ITeacher teacher, string lab)
            : base(name, teacher)
        {
            if (lab != null)
            {
                this.Lab = lab;
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

    }
}
