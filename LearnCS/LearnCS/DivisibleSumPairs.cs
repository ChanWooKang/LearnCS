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
    class DivisibleSumPairs
    {
        public static void MainEX(string[] args)
        {
            //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

            int n = Convert.ToInt32(firstMultipleInput[0]);

            int k = Convert.ToInt32(firstMultipleInput[1]);

            List<int> ar = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arTemp => Convert.ToInt32(arTemp)).ToList();

            int result = ResultDivisibleSumPairs.divisibleSumPairs(n, k, ar);

            //textWriter.WriteLine(result);

            //textWriter.Flush();
            //textWriter.Close();
        }
    }

    class ResultDivisibleSumPairs
    {
        public static int divisibleSumPairs(int n, int k, List<int> ar)
        {
            var result = 0;
            var index = 0;
            var addIndex = index + 1;
            while (true)
            {
                if (addIndex > n - 1)
                {
                    if (index < n - 1)
                    {
                        index++;
                        addIndex = index + 1;
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
                var sum = ar[index] + ar[addIndex];

                if (sum % k == 0)
                {
                    result++;
                }


                addIndex++;
            }
            return result;
        }
    }

    class SolutionDivisibleSumPairs
    {
        public static int divisibleSumPairs(int n, int k, List<int> ar)
        {
            var mod = new Dictionary<int, int>();
            foreach(var a in ar)
            {
                var remainder = a % k;
                if(!mod.ContainsKey(remainder))
                    mod.Add(remainder, 1);
                else
                    mod[remainder]++;
            }

            var result = 0;
            foreach(var remainder in mod.Keys)
            {
                var counterPart = (k - remainder) % k;
                if (counterPart > remainder || !mod.ContainsKey(counterPart))
                    continue;
                if (remainder == counterPart)
                    result += mod[remainder] * (mod[remainder] - 1) / 2;
                else
                    result += mod[remainder] * mod[remainder];
            }
            return result;
        }
    }
}
