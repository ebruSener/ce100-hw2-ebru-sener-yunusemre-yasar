using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace hw2_algo_test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestHeapSort_BestCase_1000Inputs()
        {
            // Arrange
            int[] arr = Enumerable.Range(1, 1000).ToArray();

            // Act
            int[] sortedArr = HeapSort(arr);

            // Assert
            CollectionAssert.AreEqual(arr, sortedArr);
        }

        private int[] HeapSort(int[] arr)
        {
            throw new NotImplementedException();
        }
    }
}
