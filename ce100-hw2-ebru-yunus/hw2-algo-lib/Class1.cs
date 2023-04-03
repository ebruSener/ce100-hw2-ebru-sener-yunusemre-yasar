using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw2_algo_lib
{
    public class Class1
    {
        public static void heapSort(int[] arr, int n)
        {
            for (int i = n / 2 - 1; i >= 0; i--)
                heapify(arr, n, i);
            for (int i = n - 1; i >= 0; i--)
            {
                int temp = arr[0];
                arr[0] = arr[i];
                arr[i] = temp;
                heapify(arr, i, 0);
            }
        }
        static void heapify(int[] arr, int n, int i)
        {
            int largest = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;
            if (left < n && arr[left] > arr[largest])
                largest = left;
            if (right < n && arr[right] > arr[largest])
                largest = right;
            if (largest != i)
            {
                int swap = arr[i];
                arr[i] = arr[largest];
                arr[largest] = swap;
                heapify(arr, n, largest);
            }
        }



        public static (int, int[]) MatrixChainOrder(int[] p)
        {
            int n = p.Length - 1;
            int[,] m = new int[n, n];
            int[,] s = new int[n, n];

            for (int l = 2; l <= n; l++)
            {
                for (int i = 0; i < n - l + 1; i++)
                {
                    int j = i + l - 1;
                    m[i, j] = int.MaxValue;
                    for (int k = i; k < j; k++)
                    {
                        int q = m[i, k] + m[k + 1, j] + p[i] * p[k + 1] * p[j + 1];
                        if (q < m[i, j])
                        {
                            m[i, j] = q;
                            s[i, j] = k;
                        }
                    }
                }
            }

            int[] order = new int[n - 1];
            BuildOptimalOrder(s, 0, n - 2, order);

            return (m[0, n - 1], order);
        }

        private static void BuildOptimalOrder(int[,] s, int i, int j, int[] order)
        {
            if (i == j) return;
            int k = s[i, j];
            BuildOptimalOrder(s, i, k, order);
            BuildOptimalOrder(s, k + 1, j, order);
            order[k] = i;
        }









        class MatrixMultiplication
        {
            public static Tuple<int, List<int>> OptimalMultiplicationOrder(int[] dimensions, Dictionary<string, Tuple<int, List<int>>> memo)
            {
                if (dimensions.Length == 2)
                {
                    return Tuple.Create(0, new List<int> { 0, 1 });
                }

                string memoKey = string.Join(",", dimensions);

                if (memo.ContainsKey(memoKey))
                {
                    return memo[memoKey];
                }

                int minScalarMultiplications = int.MaxValue;
                List<int> optimalOrder = new List<int>();

                for (int i = 1; i < dimensions.Length; i++)
                {
                    int[] leftDimensions = new int[i];
                    Array.Copy(dimensions, leftDimensions, i);
                    int[] rightDimensions = new int[dimensions.Length - i];
                    Array.Copy(dimensions, i, rightDimensions, 0, dimensions.Length - i);

                    Tuple<int, List<int>> leftResult = OptimalMultiplicationOrder(leftDimensions, memo);
                    Tuple<int, List<int>> rightResult = OptimalMultiplicationOrder(rightDimensions, memo);
                    int currentMultiplications = leftDimensions[0] * rightDimensions[rightDimensions.Length - 1] * dimensions[dimensions.Length - 1];

                    int totalMultiplications = leftResult.Item1 + rightResult.Item1 + currentMultiplications;

                    if (totalMultiplications < minScalarMultiplications)
                    {
                        minScalarMultiplications = totalMultiplications;
                        optimalOrder = new List<int>(leftResult.Item2);
                        for (int j = 0; j < rightResult.Item2.Count; j++)
                        {
                            optimalOrder.Add(rightResult.Item2[j] + i);
                        }
                    }
                }

                memo[memoKey] = Tuple.Create(minScalarMultiplications, optimalOrder);
                return memo[memoKey];
            }

            static void Main()
            {
                int[] dimensions = { 10, 20, 30, 40 };
                Dictionary<string, Tuple<int, List<int>>> memo = new Dictionary<string, Tuple<int, List<int>>>();
                Tuple<int, List<int>> result = OptimalMultiplicationOrder(dimensions, memo);
                Console.WriteLine("Minimum number of scalar multiplications needed: {0}", result.Item1);
                Console.WriteLine("Optimal order of multiplication: {0}", string.Join(" x ", result.Item2));
            }
        }


        public static int LongestCommonSubsequence(string A, string B)
        {
            int m = A.Length;
            int n = B.Length;
            int[,] dp = new int[m + 1, n + 1];

            for (int i = 1; i <= m; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    if (A[i - 1] == B[j - 1])
                        dp[i, j] = dp[i - 1, j - 1] + 1;
                    else
                        dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
                }
            }

            return dp[m, n];
        }





        class Knapsack
        {
            static int MaxValue(int[] values, int[] weights, int capacity, int n)
            {
                int[,] dp = new int[n + 1, capacity + 1];

                for (int i = 0; i <= n; i++)
                {
                    for (int j = 0; j <= capacity; j++)
                    {
                        if (i == 0 || j == 0)
                        {
                            dp[i, j] = 0;
                        }
                        else if (weights[i - 1] <= j)
                        {
                            dp[i, j] = Math.Max(values[i - 1] + dp[i - 1, j - weights[i - 1]], dp[i - 1, j]);
                        }
                        else
                        {
                            dp[i, j] = dp[i - 1, j];
                        }
                    }
                }

                return dp[n, capacity];
            }

            static void Main()
            {
                int[] values = { 60, 100, 120 };
                int[] weights = { 10, 20, 30 };
                int capacity = 50;
                int n = values.Length;
                int maxVal = MaxValue(values, weights, capacity, n);
                Console.WriteLine("Maximum value that can be obtained is: " + maxVal);
            }
        }


    }
}

