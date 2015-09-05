using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Linq_Foreach_Perf_Comparison
{
    class Program
    {
        static void Main(string[] args)
        {
            var initialList = new List<int>();
            for (var i = 0; i < 1000; i++)
            {
                initialList.Add(i);
            }
            //GoLoop(initialList);
            GoLinq(initialList);
            Console.ReadKey();

        }

        public static void GoLoop(List<int> initialList )
        {
            initialList.Clear();
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var builtString = string.Empty;
            foreach (var i in initialList)
            {
                builtString = builtString += i.ToString();
            }
            stopwatch.Stop();
            Console.WriteLine("Foreach time elapsed : " + stopwatch.Elapsed);
        }

        public static void GoLinq(List<int> initialList)
        {
            initialList.Clear();
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var builtString = initialList.Aggregate(string.Empty, (current, i) => current += i.ToString());
            stopwatch.Stop();
            Console.WriteLine("Linq time elapsed : " + stopwatch.Elapsed);
        }
    }
}
