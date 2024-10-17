using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnCS
{
    class SubarrayDivision
    {
        public static void MainEX(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int n = Convert.ToInt32(Console.ReadLine().Trim());

            List<int> s = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(sTemp => Convert.ToInt32(sTemp)).ToList();

            string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

            int d = Convert.ToInt32(firstMultipleInput[0]);

            int m = Convert.ToInt32(firstMultipleInput[1]);

            int result = ResultSubarrayDivision.birthday(s, d, m);

            textWriter.WriteLine(result);

            textWriter.Flush();
            textWriter.Close();
        }
    }

    class ResultSubarrayDivision
    {
        //m크기 만큼 배열의 값을 더했을때 d가나오는 경우의 수를 구하시오 
        // 시간 복잡도로서 문제가 많다...
        public static int birthday(List<int> s, int d, int m)
        {
            var result = 0;

            for (int i = 0; i < s.Count; i++)
            {
                if (i + m > s.Count)
                    break;

                var cnt = 0;
                var sum = 0;
                while (cnt < m)
                {
                    var index = i + cnt;
                    sum += s[index];
                    cnt++;
                }

                if (sum == d)
                    result++;
            }

            return result;
        }
    }

    class SolutionSubarrayDivision
    {
        public static int birthday(List<int> s, int d, int m)
        {
            var result = 0;
            if (m > s.Count)
                return result;
            var sum = 0;
            for(var i = 0; i < m; i++)
                sum += s[i];
            var endpos = m;
            while (true)
            {
                if (sum == d)
                    result++;
                if (endpos >= s.Count)
                    break;
                sum += s[endpos];
                sum -= s[endpos - m];
                endpos++;
            }
            return result;
        }
    }
}
