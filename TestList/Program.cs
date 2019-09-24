using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> 一堆数字 = new List<int>();
            一堆数字.Add(54);
            一堆数字.Add(23);
            一堆数字.Add(14);
            一堆数字.Add(2);
            一堆数字.Add(5);
            一堆数字.Add(3);


            一堆数字.RemoveAt(4);
            foreach (var item in 一堆数字)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }
    }
}
