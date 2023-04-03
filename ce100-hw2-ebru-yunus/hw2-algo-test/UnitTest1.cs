using hw2_algo_lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using static hw2_algo_lib.Class1;

namespace hw2_algo_test
{


    [TestClass]
    public class HeapSortTests
    {
        [TestMethod]
        public void HeapSoTest1()
        {
            int[] array = new int[] { 104, 98, 15, 49, 20 };
            int n = array.Length;
            int[] expected = new int[] { 15, 20, 49, 98, 104 };

            Class1.heapSort(array, n);
            CollectionAssert.AreEqual(expected, array);
        }

        [TestMethod]
        public void HeapSoTest2()
        {
            int[] array = new int[] { 104, 98, 15, 49, 20 };
            int n = array.Length;
            int[] expected = new int[] { 15, 20, 49, 98, 104 };

            Class1.heapSort(array, n);
            CollectionAssert.AreEqual(expected, array);
        }

        [TestMethod]
        public void HeapSoTest3()
        {
            int[] array = new int[] { 348, 546, 781, 233, 460, 904 };
            int n = array.Length;
            int[] expected = new int[] { 233, 348, 460, 546, 781, 904 };

            Class1.heapSort(array, n);
            CollectionAssert.AreEqual(expected, array);
        }


        [TestMethod]
        public void MatrixChainOrder_TestMethod1()
        {
            int[] arr = new int[] { 1, 2, 5, 7, 9 };
            int n = arr.Length;
            int res = Class1.MatrixChainOrder(arr, 1, n - 1);
            Assert.AreEqual(res, 108);
        }

        [TestMethod]
        public void MatrixChainOrder_TestMethod2()
        {
            int[] arr = new int[] { 4, 6, 8, 1, 7 };
            int n = arr.Length;
            int res = Class1.MatrixChainOrder(arr, 1, n - 1);
            Assert.AreEqual(res, 100);
        }

        [TestMethod]
        public void MatrixChainOrder_TestMethod3()
        {
            int[] arr = new int[] { 1, 5, 4, 7, 8 };
            int n = arr.Length;
            int res = Class1.MatrixChainOrder(arr, 1, n - 1);
            Assert.AreEqual(res, 104);
        }



        [TestMethod]
        public void LongestCommonSubsquence_TestMethod1()
        {
            string s1 = "YUDKSGJSDFJLAIAROASDGAPAPPAFSKALSF";
            string s2 = "TPETIPWETDLGJSGJKHOEAFWIEFJSCBVBMN";


            int m = s1.Length;
            int n = s2.Length;
            string result = Class1.LongestCommonSubsquence(s1, s2, m, n);
            string expected = "DGJSJOAFF";
            Assert.AreEqual(result, expected);
        }


        [TestMethod]
        public void LongestCommonSubsquence_TestMethod2()
        {
            string s1 = "TWEIOWHFGHSAJFGASKWQAJSHF";
            string s2 = "AFVJHAFJWAUAABJXZ";


            int m = s1.Length;
            int n = s2.Length;
            string result = Class1.LongestCommonSubsquence(s1, s2, m, n);
            string expected = "FHAFWAJ";
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void LongestCommonSubsquence_TestMethod3()
        {
            string s1 = "TASFHAJSF";
            string s2 = "ASKJFAKLFG";


            int m = s1.Length;
            int n = s2.Length;
            string result = Class1.LongestCommonSubsquence(s1, s2, m, n);
            string expected = "ASFAF";
            Assert.AreEqual(result, expected);
        }


        [TestMethod]
        public void Knapsack_test_1()
        {
            int[] val = new int[] { 6000, 10000, 12000 };
            int[] wt = new int[] { 1000, 2000, 3000 };
            int W = 5000;
            int n = val.Length;

            int actual = Knapsack_Problem.knapSack(W, wt, val, n);
            int res = 22000;
            Assert.AreEqual(actual, res);
        }

        [TestMethod]
        public void Knapsack_test_2()
        {
            int[] val = new int[] { 100, 300, 400, 500, 600 };
            int[] wt = new int[] { 100, 200, 300, 400, 500 };
            int W = 800;
            int n = val.Length;

            int actual = Knapsack_Problem.knapSack(W, wt, val, n);
            int res = 1000;
            Assert.AreEqual(actual, res);
        }

        [TestMethod]
        public void Knapsack_test_3()
        {
            int[] val = new int[] { 4000, 2500, 8700, 1300 };
            int[] wt = new int[] { 1500, 3400, 1200, 4700 };
            int W = 7500;
            int n = val.Length;

            int actual = Knapsack_Problem.knapSack(W, wt, val, n);
            int res = 15200;
            Assert.AreEqual(actual, res);
           










        }
    }
}
