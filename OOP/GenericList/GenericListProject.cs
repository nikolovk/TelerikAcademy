using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericList
{
    class GenericListProject
    {
        static void Main(string[] args)
        {
            GenericList<int> testList = new GenericList<int>(5);
            testList.AddElement(55);
            testList.AddElement(550);
            testList.AddElement(-55);
            testList.AddElement(564565);
            testList.AddElement(-568);
            testList.AddElement(5500);
            testList.AddElement(5858645);
            testList.AddElement(4444);
            Console.WriteLine(testList.SearchByValue(-568));
            Console.WriteLine(testList.ReadElement(1));
            testList.RemoveElement(1);
            testList.InsertAtPosition(2, -696969);
            Console.WriteLine(testList.Max());
            Console.WriteLine(testList.Min());
        }
    }
}
