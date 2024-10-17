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
    class NumberLineJumps
    {        
        public static void MainEX(string[] args)
        {
            //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

            int x1 = Convert.ToInt32(firstMultipleInput[0]);

            int v1 = Convert.ToInt32(firstMultipleInput[1]);

            int x2 = Convert.ToInt32(firstMultipleInput[2]);

            int v2 = Convert.ToInt32(firstMultipleInput[3]);

            string result = ResultNumberLineJumps.kangaroo(x1, v1, x2, v2);


            Console.WriteLine(result);
            Console.ReadLine();
            //textWriter.WriteLine(result);
            //textWriter.Flush();
            //textWriter.Close();
        }
    }

    class ResultNumberLineJumps
    {
        public static string kangaroo(int x1, int v1, int x2, int v2)
        {
            bool isOk = false;
            if (v1 > v2)
            {
                var cnt = 1;
                var d1 = 0;
                var d2 = 0;
                while (true)
                {
                    d1 = x1 + v1 * cnt;
                    d2 = x2 + v2 * cnt;
                    if (d1 >= d2)
                    {
                        if (d1 == d2)
                        {
                            isOk = true;
                        }
                        break;
                    }
                    cnt++;
                }
            }
            string result = isOk ? "YES" : "NO";
            return result;
        }
    }

    class SolvedNumberLineJumps
    {
        public static bool kangaroo(int x1, int v1, int x2, int v2)
        {
            if (v1 <= v2)
                return false;
            return (x2 - x1) % (v1 - v2) == 0;
        }
         
    }

    class SolutionNumberLineJumps
    {
        public static void MainEX(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

            int x1 = Convert.ToInt32(firstMultipleInput[0]);

            int v1 = Convert.ToInt32(firstMultipleInput[1]);

            int x2 = Convert.ToInt32(firstMultipleInput[2]);

            int v2 = Convert.ToInt32(firstMultipleInput[3]);

            var result = SolvedNumberLineJumps.kangaroo(x1, v1, x2, v2);

            textWriter.WriteLine(result ? "YES" : "NO");

            textWriter.Flush();
            textWriter.Close();
        }
    }
}
