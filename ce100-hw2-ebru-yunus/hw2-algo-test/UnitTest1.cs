using hw2_algo_lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

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

    }
}
