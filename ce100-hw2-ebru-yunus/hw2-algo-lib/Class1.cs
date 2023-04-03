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




        public static int MatrixChainOrder(int[] p, int i, int j)
        {
            // Matrix Ai has dimension p[i - 1] x p[i]
            // for i = 1..n
            if (i == j)
                return 0;

            int min = int.MaxValue;

            // place parenthesis at different places
            // between first and last matrix, recursively
            // calculate count of multiplications for each
            // parenthesis placement and return the
            // minimum count
            for (int k = i; k < j; k++)
            {
                int count = MatrixChainOrder(p, i, k)
                            + MatrixChainOrder(p, k + 1, j)
                            + p[i - 1] * p[k] * p[j];

                if (count < min)
                    min = count;
            }

            // Return minimum count
            return min;
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



        public static string LongestCommonSubsquence(string R, string S, int a, int e)
        {
            // Returns length of LCS for X[0..m-1], Y[0..n-1]
            int[,] L = new int[a + 1, e + 1];

            // Following steps build L[m+1][n+1] in
            // bottom up fashion. Note that L[i][j]
            // contains length of LCS of X[0..i-1]
            // and Y[0..j-1]
            for (int i = 0; i <= a; i++)
            {
                for (int j = 0; j <= e; j++)
                {
                    if (i == 0 || j == 0)
                    {
                        L[i, j] = 0;
                    }
                    else if (R[i - 1] == S[j - 1])
                    {
                        L[i, j] = L[i - 1, j - 1] + 1;
                    }
                    else
                    {
                        L[i, j] = Math.Max(L[i - 1, j], L[i, j - 1]);
                    }
                }
            }

            // Following code is used to print LCS
            int index = L[a, e];


            // Create a character array
            // to store the lcs string
            string lcs = string.Empty;



            // Start from the right-most-bottom-most corner
            // and one by one store characters in lcs[]
            int k = a, l = e;
            while (k > 0 && l > 0)
            {
                // If current character in X[] and Y
                // are same, then current character
                // is part of LCS
                if (R[k - 1] == S[l - 1])
                {
                    // Put current character in result
                    lcs = R[k - 1] + lcs;

                    // reduce values of i, j and index
                    k--;
                    l--;
                    index--;
                }

                // If not same, then find the larger of two and
                // go in the direction of larger value
                else if (L[k - 1, l] > L[k, l - 1])
                { k--; }
                else
                { l--; }
            }
            return lcs;
        }







        public class Knapsack_Problem
        {
            // A utility function that returns
            // maximum of two integers
            public static int max(int a, int b)
            {
                return (a > b) ? a : b;
            }


            /**
            *
            *	  @name   knapSack (Knapsack Function)
            *
            *	  @brief Knapsack Function
            *
            *	  Knapsack Function
            *
            *	  @param  [in] W [\b int]  W
            *	  
            *	  @param  [in] wt [\b int]  wt
            *	  
            *	  @param  [in] val [\b int]  val
            *	  
            *	  @param  [in] n [\b int]  n
            *	  
            *	  
            **/


            public static int knapSack(int W, int[] wt, int[] val, int n)
            {

                // Base Case
                if (n == 0 || W == 0)
                    return 0;

                // If weight of the nth item is
                // more than Knapsack capacity W,
                // then this item cannot be
                // included in the optimal solution
                if (wt[n - 1] > W)
                    return knapSack(W, wt,
                                    val, n - 1);

                // Return the maximum of two cases:
                // (1) nth item included
                // (2) not included
                else
                    return max(val[n - 1]
                               + knapSack(W - wt[n - 1], wt,
                                          val, n - 1),
                               knapSack(W, wt, val, n - 1));
            }








       
        }
    }

}