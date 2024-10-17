using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

namespace LearnCS
{
    class Result
    {
        public static int divisibleSumPairs(int n, int k, List<int> ar)
        {
            var mod = new Dictionary<int, int>();
            foreach (var a in ar)
            {
                var remainder = a % k;
                if (!mod.ContainsKey(remainder))
                    mod.Add(remainder, 1);
                else
                    mod[remainder]++;
            }

            var result = 0;
            foreach (var remainder in mod.Keys)
            {
                var counterPart = (k - remainder) % k;
                if (counterPart > remainder || !mod.ContainsKey(counterPart))
                    continue;
                if (remainder == counterPart)
                    result += mod[remainder] * (mod[remainder] - 1) / 2;
                else
                    result += mod[remainder] * mod[remainder];
            }
            Console.WriteLine(result);
            Console.ReadLine();
            return result;
        }
    }


    class Program
    {
        public static void Main(string[] args)
        {
            //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

            int n = Convert.ToInt32(firstMultipleInput[0]);

            int k = Convert.ToInt32(firstMultipleInput[1]);

            List<int> ar = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arTemp => Convert.ToInt32(arTemp)).ToList();

            int result = Result.divisibleSumPairs(n, k, ar);

            //textWriter.WriteLine(result);

            //textWriter.Flush();
            //textWriter.Close();
        }
    }
}
