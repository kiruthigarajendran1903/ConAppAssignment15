using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConAppAssignment15
{
    /// <summary>
    /// This File is about Comparison of Quick Sort and Merge Sort
    /// </summary>
    internal class Program
    {
      
            public static void QuickSort(int[] array)
            {
                QuickSort(array, 0, array.Length - 1);
            }

            private static void QuickSort(int[] array, int left, int right)
            {
                if (left < right)
                {
                    int pivotIndex = Partition(array, left, right);
                    QuickSort(array, left, pivotIndex - 1);
                    QuickSort(array, pivotIndex + 1, right);

                }
            }

            private static int Partition(int[] array, int left, int right)
            {
                int pivot = array[right];
                int i = left - 1;
                for (int j = left; j < right; j++)
                {
                    if (array[j] < pivot)
                    {
                        i++;
                        Swap(array, i, j);
                    }
                }
                Swap(array, i + 1, right);
                return i + 1;
            }

            private static void Swap(int[] array, int i, int j)
            {
                int temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }

        public static void MergeSort(int[] arr)
        {
            MergeSort(arr, 0, arr.Length - 1);
        }

        private static void MergeSort(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int mid = (left + right) / 2;
                MergeSort(arr, left, mid);
                MergeSort(arr, mid + 1, right);
                Merge(arr, left, mid, right);
            }
        }

        private static void Merge(int[] arr, int left, int mid, int right)
        {
            int n1 = mid - left + 1;
            int n2 = right - mid;
            int[] leftArray = new int[n1];
            int[] rightArray = new int[n2];
            Array.Copy(arr, left, leftArray, 0, n1);
            Array.Copy(arr, mid + 1, rightArray, 0, n2);
            int i = 0;
            int j = 0;
            int k = left;
            while (i < n1 && j < n2)
            {
                if (leftArray[i] <= rightArray[j])
                {
                    arr[k] = leftArray[i];
                    i++;
                }
                else
                {
                    arr[k] = rightArray[j];
                    j++;
                }
                k++;
            }
            while (i < n1)
            {
                arr[k] = leftArray[i];
                i++;
                k++;
            }
            while (j < n2)
            {
                arr[k] = rightArray[j];
                j++;
                k++;
            }

        }
        static bool IsSorted(int[] arr)
        {
            int n = arr.Length;
            for (int i = 1; i < n; i++)
            {
                if (arr[i] < arr[i - 1])
                    return false;
            }
            return true;
        }

        public static void print(int[] arr)
            {
                foreach (var item in arr)
                {
                    Console.WriteLine(item + " ");
                }
                Console.WriteLine("\n");
            }

            static void Main(string[] args)
            {
            int[] arr1 = {-3,5,8,23,67,-9,-1,4,6,8,3,2,4 };
            int[] arr2 = { -3, 5, 8, 23, 67, -9, -1, 4, 6, 8, 3, 2, 4 };
            Stopwatch stopwatch = new Stopwatch();
            Console.WriteLine("Print without Qucik Sort");
            print(arr1);
            stopwatch.Start();
            QuickSort(arr1);
            stopwatch.Stop();
            Console.WriteLine("After Quick Sort");
            print(arr1);
            Console.WriteLine($"array sorted or not :\t{IsSorted(arr1)}");
            Console.WriteLine($"Time taken to sort {arr1.Length} in Quick sort: {stopwatch.Elapsed.TotalMilliseconds} milliseconds");


            Console.WriteLine("print without Merge sort");
            print(arr2);

            Stopwatch stopwatch2 = new Stopwatch();
            stopwatch2.Start();
            MergeSort(arr2);
            stopwatch2.Stop();
            Console.WriteLine("After Merge Sort");
            print(arr2);
            Console.WriteLine($"array sorted or not :\t {IsSorted(arr2)}");
            Console.WriteLine($"Time taken to sort {arr2.Length}in Merge sort: {stopwatch2.Elapsed.TotalMilliseconds} milliseconds");
            Console.ReadKey();

        }
    }
    }


