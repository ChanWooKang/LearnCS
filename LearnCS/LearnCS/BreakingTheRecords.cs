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
    class BreakingTheRecords
    {
        public static void MainEX(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int n = Convert.ToInt32(Console.ReadLine().Trim());

            List<int> scores = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(scoresTemp => Convert.ToInt32(scoresTemp)).ToList();

            List<int> result = ResultBreakingTheRecords.breakingRecords(scores);

            textWriter.WriteLine(String.Join(" ", result));

            textWriter.Flush();
            textWriter.Close();
        }
    }

    class ResultBreakingTheRecords
    {
        public static List<int> breakingRecords(List<int> scores)
        {
            var min = scores.First();
            var max = scores.First();
            var minCnt = 0;
            var maxCnt = 0;

            for (int i = 1; i < scores.Count; i++)
            {
                if (scores[i] < min)
                {
                    min = scores[i];
                    minCnt++;
                    continue;
                }

                if (scores[i] > max)
                {
                    max = scores[i];
                    maxCnt++;
                    continue;
                }
            }

            var result = new List<int>();
            result.Add(maxCnt);
            result.Add(minCnt);
            return result;
        }
    }

    class SolutionBreakingTheRecords
    {
        public static int[] breakingRecords(int[] scores)
        {
            var minCount = 0;
            var maxCount = 0;
            var minimum = scores[0];
            var maximum = scores[0];
            foreach (var score in scores)
            {
                if(score > maximum)
                {
                    maximum = score;
                    maxCount++;
                }
                else if(score < minimum)
                {
                    minimum = score;
                    minCount++;
                }                   
            }

            return new int[] { maxCount, minCount };
        }
    }
}
