using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace LinqPLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            const int n = 10000000;
            int[] mas = new int[n];
            Random rnd = new Random();
            Stopwatch stopWatch = new Stopwatch();
            for (int i = 0; i < mas.Length; i++)
            {
                mas[i] = rnd.Next();
            }
            //LINQ
            //четные
            stopWatch.Start();
            int[] masRes = mas.Where(x => x % 2 == 0).ToArray();
            stopWatch.Stop();

            foreach (int i in masRes.Take(10).OrderBy(x => x))
                Console.WriteLine(i);
            Console.WriteLine("time 1 = " + stopWatch.Elapsed.TotalSeconds);
            Console.WriteLine("-------------------------------------");

            //нечетные
            stopWatch.Restart();
            masRes = mas.Where(x => x % 2 == 1).ToArray();
            stopWatch.Stop();

            foreach (int i in masRes.Take(10).OrderBy(x => x))
                Console.WriteLine(i);
            Console.WriteLine("time 2 = " + stopWatch.Elapsed.TotalSeconds);
            Console.WriteLine("-------------------------------------");

            //сумма 6
            int firstNum, lastNum;
            stopWatch.Restart();
            masRes = mas.Where(x =>
            {
                string temp = x.ToString();
                firstNum = Convert.ToInt32(temp.Substring(0, 1));
                lastNum = Convert.ToInt32(temp.Substring(temp.Length - 1, 1));
                return (firstNum + lastNum == 6);
            }).ToArray();
            stopWatch.Stop();

            foreach (int i in masRes.Take(10).OrderBy(x => x))
                Console.WriteLine(i);
            Console.WriteLine("time 3 = " + stopWatch.Elapsed.TotalSeconds);
            Console.WriteLine("-------------------------------------");

            //три 6
            stopWatch.Restart();
            masRes = mas.Where(x => x.ToString().Contains("666")).ToArray();
            stopWatch.Stop();

            foreach (int i in masRes.Take(10).OrderBy(x => x))
                Console.WriteLine(i);
            Console.WriteLine("time 4 = " + stopWatch.Elapsed.TotalSeconds);
            Console.WriteLine("-------------------------------------");


            //PLINQ
            //четные
            stopWatch.Restart();
            masRes = mas.AsParallel().Where(x => x % 2 == 0).ToArray();
            stopWatch.Stop();

            foreach (int i in masRes.Take(10).OrderBy(x => x))
                Console.WriteLine(i);
            Console.WriteLine("time 1 = " + stopWatch.Elapsed.TotalSeconds);
            Console.WriteLine("-------------------------------------");

            //нечетные
            stopWatch.Restart();
            masRes = mas.AsParallel().Where(x => x % 2 == 1).ToArray();
            stopWatch.Stop();

            foreach (int i in masRes.Take(10).OrderBy(x => x))
                Console.WriteLine(i);
            Console.WriteLine("time 2 = " + stopWatch.Elapsed.TotalSeconds);
            Console.WriteLine("-------------------------------------");

            //сумма 6
            stopWatch.Restart();
            masRes = mas.AsParallel().Where(x =>
            {
                string temp = x.ToString();
                firstNum = Convert.ToInt32(temp.Substring(0, 1));
                lastNum = Convert.ToInt32(temp.Substring(temp.Length - 1, 1));
                return (firstNum + lastNum == 6);
            }).ToArray();
            stopWatch.Stop();

            foreach (int i in masRes.Take(10).OrderBy(x => x))
                Console.WriteLine(i);
            Console.WriteLine("time 3 = " + stopWatch.Elapsed.TotalSeconds);
            Console.WriteLine("-------------------------------------");

            //три 6
            stopWatch.Restart();
            masRes = mas.AsParallel().Where(x => x.ToString().Contains("666")).ToArray();
            stopWatch.Stop();

            foreach (int i in masRes.Take(10).OrderBy(x => x))
                Console.WriteLine(i);
            Console.WriteLine("time 4 = " + stopWatch.Elapsed.TotalSeconds);
            Console.WriteLine("-------------------------------------");
        }
    }
}
