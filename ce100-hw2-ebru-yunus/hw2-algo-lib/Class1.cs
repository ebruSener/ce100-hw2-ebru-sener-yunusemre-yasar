using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw2_algo_lib
{
    public class Class1
    {
        public static int[] HeapSort(int[] arr)
        {
            int n = arr.Length;

            // Build max heap from unsorted array
            for (int i = n / 2 - 1; i >= 0; i--)
            {
                Heapify(arr, n, i);
            }

            // Heap sort by repeatedly extracting the maximum element
            for (int i = n - 1; i > 0; i--)
            {
                // Move current root to end
                int temp = arr[0];
                arr[0] = arr[i];
                arr[i] = temp;

                // Max heapify the reduced heap
                Heapify(arr, i, 0);
            }

            return arr;
        }

        private static void Heapify(int[] arr, int n, int i)
        {
            int largest = i; // Initialize largest as root
            int left = 2 * i + 1;
            int right = 2 * i + 2;

            // If left child is larger than root
            if (left < n && arr[left] > arr[largest])
            {
                largest = left;
            }

            // If right child is larger than largest so far
            if (right < n && arr[right] > arr[largest])
            {
                largest = right;
            }

            // If largest is not root
            if (largest != i)
            {
                int swap = arr[i];
                arr[i] = arr[largest];
                arr[largest] = swap;

                // Recursively heapify the affected sub-tree
                Heapify(arr, n, largest);
            }
        }





    }
}
