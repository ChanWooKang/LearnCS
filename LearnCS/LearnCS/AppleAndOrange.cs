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
    class AppleAndOrange
    {
        public static void MainEX(string[] args)
        {
            string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

            int s = Convert.ToInt32(firstMultipleInput[0]);

            int t = Convert.ToInt32(firstMultipleInput[1]);

            string[] secondMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

            int a = Convert.ToInt32(secondMultipleInput[0]);

            int b = Convert.ToInt32(secondMultipleInput[1]);

            string[] thirdMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

            int m = Convert.ToInt32(thirdMultipleInput[0]);

            int n = Convert.ToInt32(thirdMultipleInput[1]);

            List<int> apples = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(applesTemp => Convert.ToInt32(applesTemp)).ToList();

            List<int> oranges = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(orangesTemp => Convert.ToInt32(orangesTemp)).ToList();

            ResultAppleAndOrange.countApplesAndOranges(s, t, a, b, apples, oranges);
        }
    }

    class ResultAppleAndOrange
    {
        public static void countApplesAndOranges(int s, int t, int a, int b, List<int> apples, List<int> oranges)
        {
            int resultApple = 0;
            int resultOrange = 0;
            int i = 0;
            for (; i < apples.Count; i++)
            {
                if (FruitFallInHouse(s, t, a, apples[i], true))
                {
                    resultApple++;
                }
            }

            for (i = 0; i < oranges.Count; i++)
            {
                if (FruitFallInHouse(s, t, b, oranges[i], false))
                {
                    resultOrange++;
                }
            }

            Console.WriteLine(resultApple);
            Console.WriteLine(resultOrange);
            Console.ReadLine();

        }

        static bool FruitFallInHouse(int start, int end, int treePos, int distance, bool isApple)
        {            
            bool isInside = false;
            int fallPos = treePos + distance;
            if (isApple)
            {
                isInside = fallPos >= start && fallPos <= end;
            }
            else
            {
                isInside = fallPos >= start && fallPos <= end;
            }
            return isInside;
        }
    }

    class SolvedAppleAndOrange
    {
        public static void countApplesAndOranges(int s, int t, int a, int b, List<int> apples, List<int> oranges)
        {
            //make s < t
            if(s > t)
            {
                int temp = s;
                s = t;
                t = temp;
            }

            Console.WriteLine(InSection(s, t, a, apples));
            Console.WriteLine(InSection(s, t, b, oranges));
        }

        static int InSection(int s, int t, int a, List<int> arr)
        {
            var result = 0;
            foreach (var item in arr)
            {
                var landing = a + item;
                if (landing >= s && landing <= t)
                    result++;
            }

            return result;
        }
    }
}
