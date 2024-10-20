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
    class MigratoryBirds
    {
        public static void MainEX(string[] args)
        {
            //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int arrCount = Convert.ToInt32(Console.ReadLine().Trim());

            List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

            int result = ResultMigratoryBirds.migratoryBirds(arr);

            Console.WriteLine(result);
            Console.ReadLine();
            //textWriter.WriteLine(result);

            //textWriter.Flush();
            //textWriter.Close();
        }
    }

    class ResultMigratoryBirds
    {
        public static int migratoryBirds(List<int> arr)
        {
            var result = 0;
            var count = new int[arr.Count];
            foreach (var i in arr)
                count[i - 1]++;

            var max = count.First();
            var index = 0;
            for (int i = 0; i < count.Length; i++)
            {
                if (count[i] > max)
                {
                    max = count[i];
                    index = i;
                    result = index + 1;
                }
                else if (count[i] == max)
                {
                    if (i < index)
                    {
                        index = i;
                        result = index + 1;
                    }
                }
            }

            return result;
        }
    }

    class SolutionMigratoryBirds
    {
        const int BIRD_TYPE_COUNT = 5;
        // Complete the migratoryBirds function below.
        static int migratoryBirds(List<int> arr)
        {
            var counter = new int[BIRD_TYPE_COUNT];
            foreach (var bird in arr)
                counter[bird - 1]++;

            var max = counter.First();
            var resultType = 1;
            for (int i = 1; i < BIRD_TYPE_COUNT; i++)
            {
                if (counter[i] > max)
                {
                    max = counter[i];
                    resultType = i + 1;
                }
            }
            return resultType;
        }
    }
}
