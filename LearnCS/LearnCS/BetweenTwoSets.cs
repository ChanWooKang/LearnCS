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
    class BetweenTwoSets
    {
        public static void MainEX(string[] args)
        {
            //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

            int n = Convert.ToInt32(firstMultipleInput[0]);

            int m = Convert.ToInt32(firstMultipleInput[1]);

            List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

            List<int> brr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(brrTemp => Convert.ToInt32(brrTemp)).ToList();

            int total = ResultBetweenTwoSets.getTotalX(arr, brr);


            Console.WriteLine(total);
            Console.ReadLine();
            //textWriter.WriteLine(total);

            //textWriter.Flush();
            //textWriter.Close();
        }
    }

    class ResultBetweenTwoSets
    {
       
        public static int getTotalX(List<int> a, List<int> b)
        {
            a.Sort();
            b.Sort();
            if (a.Last() > b.First())
                return 0;
            
            int lcm = a.First();
            for (int i = 1; i < a.Count; i++)
                lcm = LCM(lcm, a[i]);

            int gcd = b.First();
            for(int i = 1; i < b.Count; i++)
                gcd = GCD(gcd, b[i]);

            var result = 0;
            var lcmResult = lcm;
            while(lcmResult <= b.First())
            {
                if(gcd % lcmResult == 0)
                    result++;
                lcmResult += lcm;
            }
            return result;
        }

        static int GCD(int a, int b)
        {
            var r = 0;
            while(b != 0)
            {
                r = a % b;
                a = b;
                b = r;
            }
            return a;
        }

        static int LCM(int a, int b)
        {
            return (a * b) / GCD(a, b);
        }
    }
}
