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
        public void HeapSort_SortsIntArrayInAscendingOrder()
        {
            // Arrange
            int[] unsortedArray = { 5, 2, 9, 3, 1, 7, 8, 6, 4 };
            int[] expectedArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            // Act
            
            Class1.HeapSort(unsortedArray);

            // Assert
            Assert.AreEqual(expectedArray, unsortedArray);
        }
    }

}
