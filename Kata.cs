 using System;
using System.Linq;
using System.Text;

namespace dojo
{

    }
    public class Kata
    {
        public static string Pattern(int n)
        {
            var result = new StringBuilder(string.Empty);

            if (n < 1)
            {
                return result.ToString();
            }

            for(var i=1; i<=n; i++)
            {
                for(var j=1; j<=i; j++)
                {
                    result.Append(i.ToString());
                }
                result.Append("\n");
            }
    
            return result.ToString().Trim();
        }

        public static string PatternDescending(int n)
        {
            var result = new StringBuilder(string.Empty);
            if (n < 1)
            {
                return result.ToString();
            }

            for (var i = 1; i <= n ; i++)
            {
                for (var j = n; j >= i; j--)
                {
                    result.Append(j.ToString());
                }

                result.Append("\n");
            }

            return result.ToString().Trim();
        }

        public static int[] MakeArray(int n)
        {
            var count = 0;
            var num = n;
            do
            {
                num /= 10;
                count++;
            } while (num > 0);

            var arrNum = new int[count];
            for (var i = 0; i < arrNum.Length; i++)
            {
                arrNum[i] = n % 10;
                n /= 10;
            }

            return arrNum;

        }

        public static void RotateForMax(int n)
        {
            var arrNum = MakeArray(n);
            Console.WriteLine(string.Concat(arrNum));

            var interArr = arrNum.Skip(1).ToArray();
            var first = arrNum[0];

            for (var i = 0; i < interArr.Length-1; i++)
            {
                arrNum[i] = interArr[i];
            }

            arrNum[^1] = first;

            Console.WriteLine(string.Concat(arrNum));

        }

    }