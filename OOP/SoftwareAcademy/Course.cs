using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftwareAcademy
{
    public abstract class Course : ICourse
    {
        public string Name { get;set; }
        public ITeacher Teacher {get;set;}
        public List<string> Topics { get; protected set; }

        public Course(string name, ITeacher teacher)
        {
            if (name != null)
            {
                this.Teacher = teacher;
                this.Name = name;
                this.Topics = new List<string>();
            }
            else
            {
                throw new ArgumentNullException();
            }
        }


        public void AddTopic(string topic)
        {
            this.Topics.Add(topic);
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            if (this is LocalCourse)
            {
                output.Append("LocalCourse: ");
            }
            else
            {
                output.Append("OffsiteCourse: ");
            }
            output.Append("Name=");
            output.Append(this.Name);
            output.Append("; ");
            if (this.Teacher != null)
            {
                output.Append("Teacher=");
                output.Append(this.Teacher.Name);
                output.Append("; ");
            }
            if (this.Topics.Count > 0)
            {
                output.Append("Topics=[");
                foreach (string topic in this.Topics)
                {
                    output.Append(topic);
                    output.Append(", ");
                }
                output.Length -= 2;
                output.Append("]; ");
            }
            if (this is ILocalCourse)
            {
                output.Append("Lab=");
                output.Append((this as ILocalCourse).Lab);
                //output.Append(";");
            }
            else
            {
                output.Append("Town=");
                output.Append((this as IOffsiteCourse).Town);
                //output.Append(";");
            }
            return output.ToString();
        }
    }
}
