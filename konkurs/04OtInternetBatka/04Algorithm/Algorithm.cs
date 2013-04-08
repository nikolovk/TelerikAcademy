using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04Algorithm
{
    class Algorithm
    {
        private static Dictionary<int, List<int>> adjacencyList = new Dictionary<int, List<int>>();
        private static Dictionary<int, Url> pages = new Dictionary<int, Url>();
        static void Main(string[] args)
        {
            //read list of pages and connection
            StreamReader adjacencyFile = new StreamReader("adjacency.txt");
            using (adjacencyFile)
            {
                string line = adjacencyFile.ReadLine();

                while (line != null)
                {
                    string[] lineSplit = line.Split(':');
                    List<int> destList = new List<int>();
                    string[] destination = lineSplit[1].Split(',');
                    for (int i = 0; i < destination.Length; i++)
                    {
                        destList.Add(int.Parse(destination[i]));
                    }
                    adjacencyList.Add(int.Parse(lineSplit[0]), destList);
                    line = adjacencyFile.ReadLine();
                }
            }
            StreamReader pagesFile = new StreamReader("pages.txt");
            using (pagesFile)
            {
                string line = pagesFile.ReadLine();

                while (line != null)
                {
                    string[] lineSplit = line.Split('|');
                    Url page = new Url();
                    string[] address = lineSplit[1].Split(';');
                    page.FullUrl = address[0];
                    page.Href = address[1];

                    pages.Add(int.Parse(lineSplit[0]), page);
                    line = pagesFile.ReadLine();
                }
            }

            // read input
            string startUrl = Console.ReadLine();
            string endUrl = Console.ReadLine();
            int startId = pages.FirstOrDefault(a => a.Value.Href == startUrl).Key;
            int endId = pages.FirstOrDefault(a => a.Value.Href == endUrl).Key;


            // Search 
            List<int> path = MakeSearch(startId, endId);
            for (int i = 1; i < path.Count; i++)
            {
                Console.WriteLine(pages[path[i]].Href);
            }
        }

        private static List<int> MakeSearch(int start, int searched)
        {
            Queue queue = new Queue();
            List<int> path = new List<int>();
            queue.Enqueue(new Tuple<int,List<int>>(start,new List<int>{start}));
            HashSet<int> visited= new HashSet<int>();
            visited.Add(start);
            while (queue.Count > 0)
            {
                Tuple<int, List<int>> element = queue.Dequeue() as Tuple<int, List<int>>;
                if (element.Item1 == searched)
                {
                    path = element.Item2;
                    break;
                }
                if (adjacencyList.ContainsKey(element.Item1))
                {
                    foreach (var link in adjacencyList[element.Item1])
                    {
                        if (!visited.Contains(link))
                        {
                            visited.Add(link);
                            List<int> currentPath = element.Item2.ConvertAll(a => a);
                            currentPath.Add(link);
                            queue.Enqueue(new Tuple<int, List<int>>(link, currentPath));
                        }
                    }
                }
            }
            return path;
        }
    }
}
