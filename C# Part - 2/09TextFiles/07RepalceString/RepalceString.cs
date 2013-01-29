using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;


class ReplaceString
{
    static void Main()
    {
        List<string> container = new List<string>();
        StreamReader reader = new StreamReader("..//..//input.txt");
        StreamWriter writer = new StreamWriter("..//..//output.txt");
        using (reader)
        {
            using (writer)
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    writer.WriteLine(line.Replace("start", "finish"));
                    line = reader.ReadLine();
                }
            }
        }
    }
}