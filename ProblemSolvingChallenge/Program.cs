using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace ProblemSolvingChallenge
{
    class Program
    {
        static void Main(string[] args)
        { 
            string x = GeneratePalindrome(19);
            Console.WriteLine("Palindrome  : " + x);

            string[] items = { "apples", "oranges", "flowers", "apples" };
            

            string[] output = Unique(items);

            Console.WriteLine("Unique array elements using LINQ : " + string.Join(",", output));

            int[] numbers = { 1,2,6,4,7,3,9,33,0,5,26};
            MinMax(numbers);

            int[,] array2D = new int[,] { { 1, 2 }, { 3, 4 }, { 5, 6 }, { 7, 8 } };

            Transpose(array2D);

            Console.WriteLine(FindFaultyBucket(8));




        }
        //Problem 0
        public static string GeneratePalindrome(int input)
        {
            int dividerNumber = 0;
            int halfPalindromeLength = 0;
            string Plindrome="";
            if (input %2 == 0)
            {
                halfPalindromeLength = input / 2;
            }
            else
            {
                halfPalindromeLength = (input-1) / 2;
            }
            if(halfPalindromeLength <= 9) { 
            for(int x = 1; x <= halfPalindromeLength; x++)
            {
                Plindrome += x;
            }
            Plindrome += dividerNumber;

            for (int x = halfPalindromeLength; x > 0; x--)
            {
               Plindrome += x;
            }
            }
            else
            {
                Console.WriteLine("Enter a valid number");
            }
            return Plindrome;
        }
        //Problem 1
        public static string[] Unique(string[] input )
        {
            IEnumerable<string> uniqueItems = input.GroupBy(i => i).Where(g => g.Count() == 1).Select(g => g.Key);
            return uniqueItems.Cast<string>().ToArray();
        }
        //Problem 2
        public static void MinMax(int[] input)
        {
            // int first;
            int i,secondMaximum, secondMinimum;

            // There should be atleast two elements
            if (input.Length< 2)
            {
                Console.Write(" Invalid Input ");
            }

            int maximum = secondMaximum = int.MinValue;
            int minimum = secondMinimum = int.MaxValue;

            // Find the maximum element
            for (i = 0; i < input.Length; i++)
            {
                maximum = Math.Max(maximum, input[i]);
                minimum = Math.Min(minimum, input[i]);
            }
             
            for (i = 0; i < input.Length; i++)
            {
                if (input[i] != maximum)
                    secondMaximum = Math.Max(secondMaximum, input[i]);
                if (input[i] != minimum)
                    secondMinimum = Math.Min(secondMinimum, input[i]);
            }
            Console.WriteLine("Index of maximum sum : " + "[" + Array.IndexOf(input, secondMaximum) +","+ Array.IndexOf(input, maximum)+"]");
            Console.WriteLine("Index of minimum sum : " + "[" + Array.IndexOf(input, secondMinimum) + "," + Array.IndexOf(input, minimum) + "]");

        }
        //Problem 3
        // Fill the A from the source of water
        // Empty the A into the B - leaving 2 litres in the A.
        // Pour away the contents of the B.
        // Fill the B with the 2 litres from the A - leaving 2 litres in the B.
        // Fill the A from the source of water.
        // Fill the remaining 1 litre space in the B from the A.
        // Leaving 4 litres in the A.

        //Problem 4
        public static void Transpose(int[,] matrix)
        {
            int w = matrix.GetLength(0);
            int h = matrix.GetLength(1);

            int[,] result = new int[h, w];

            for (int i = 0; i < w; i++)
            {
                for (int j = 0; j < h; j++)
                {
                    result[j, i] = matrix[i, j];
                }
            }
            Console.Write("\n\nMatrix before Transpose:\n");
            for (int i = 0; i < w; i++)
            {
                Console.Write("\n");
                for (int j = 0; j < h; j++)
                    Console.Write("{0}\t", matrix[i, j]);
            }

            for (int i = 0; i < w; i++)
            {
                for (int j = 0; j < h; j++)
                {

                    result[j, i] = matrix[i, j];
                }
            }

            Console.Write("\n\nMatrix after Transpose: ");
            for (int i  = 0; i < h; i++)
            {
                Console.Write("\n");
                for (int j = 0; j < w; j++)
                {
                    Console.Write("{0}\t", result[i, j]);
                }
            }

        }

        //Problem 5
        // Divide the buckets into three parts.
        // suppose they are 8 buckets , will divide them into three parts 3 + 3 + 2
        // if the two parts of equal buckets (3,3) are equal then the third part will have 
        // the faulty bucket , will compare the two buckets and less one will be the faulty
        // if one of two equal buckets (3,3) is less than the other , then will get the less part
        // then will divide this group to two parts (2,1)
        // check if the two buckets are equal then the third one is the faulty bucket
        public static int FindFaultyBucket(int N)
        {
            if (N == 0)
                return 0;
            if (N == 1)
                return 0;
            float numberOfBuckets = N;
            return (FindFaultyBucket((int)Math.Ceiling(numberOfBuckets / 3.0)) + 1);
        }

    }
}
