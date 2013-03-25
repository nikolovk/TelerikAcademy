using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftwareAcademy
{
    public class Teacher : ITeacher
    {
        public string Name{get;set;}
        public List<ICourse> Courses {get;private set;}

        public Teacher(string name)
        {
            if (name !=null)
            {
                this.Name = name;
                this.Courses = new List<ICourse>();
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        public void AddCourse(ICourse course)
        {
            this.Courses.Add(course);
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.Append("Teacher: ");
            output.Append("Name=");
            output.Append(this.Name);
     //       output.Append(";");
            if (this.Courses.Count > 0)
            {
                output.Append("; Courses=[");
                foreach (ICourse course in this.Courses)
                {
                    output.Append(course.Name);
                    output.Append(", ");
                }
                output.Length -= 2;
                output.Append("]");
            }
            return output.ToString();
        }
    }
}
