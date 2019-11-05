using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeExercise
{
    class SortAlgorithm
    {
        static void Main(string[] args)
        {
            int[] testArr = { 1, 3, 2, 0, 4};

            //BubbleSort(testArr); 
            //SelectSort(testArr);
            MergeSort(testArr);
            //QuickSort(testArr);

            printArr(testArr);
        }
        static void printArr(int[] arrs)
        {
            for (int i = 0; i < arrs.Length; i++)
            {
                Console.WriteLine(arrs[i]);
            }

            Console.Read();
        }

        static void swap(int[] arrs, int i, int j)
        {
            int temp = arrs[i];
            arrs[i] = arrs[j];
            arrs[j] = temp;
        }

        #region 冒泡算法 时间复杂度O(n^2)
        //升序
        static void BubbleSort(int[] arrs)
        {
            bool flag = true; //交换标记
            for(int i = 0; i < arrs.Length - 1; i++) //每轮比n-1次
            {
                if (flag == false) break;   //如果一整轮都没有进行位置交换，说明以有序，退出循环
                flag = false;

                //第一轮从最后一个数arrs[lenght - 1]往前比较，比到arrs[0]
                for (int j = arrs.Length - 1; j > i; j--)
                {
                    if (arrs[j] < arrs[j - 1])
                    {
                        //交换顺序
                        swap(arrs, j, j - 1);
                        flag = true;
                    }
                }
            }
        }
        #endregion

        #region 选择排序 时间复杂度O(n^2) 新增了一个minindex，减少了数组换位的次数
        static void SelectSort(int[] arrs)
        {
            int minIndex = 0;  //最小值标记，由于最小值永远在左边，所以需要从左往右去遍历
            for (int i = 0; i < arrs.Length - 1; i++)
            {
                minIndex = i;
                for (int j = i + 1; j< arrs.Length; j++) 
                {
                    if (arrs[j] < arrs[minIndex])// 从左边依次往右比较
                    {
                        minIndex = j;
                    }
                }

                //每一层遍历后会选出这一层中最小的index
                if (minIndex != i)
                {
                    swap(arrs, i, minIndex);  //保证每层遍历之后arrs[i]都是最小的
                }
            }
        }
        #endregion

        #region 归并排序  时间复杂度O(n^2) 空间复杂度为O(n)
        static void MergeSort(int[] arrs)
        {
            mSort(arrs, 0, arrs.Length - 1);
        }

        //
        static void  mSort(int[] arrs, int left, int right)
        {
            int mid = (left + right) / 2;

            mSort(arrs, left, mid);
            mSort(arrs, mid + 1, right);

            
        }

        static void merge()
        {

        }
        #endregion

        #region 快速排序 时间复杂度O(nlgn)，不稳定排序
        public static void QuickSort(int[] arr)
        {
            if (arr == null || arr.Length == 0)
                return;
            quickSort(arr, 0, arr.Length - 1);
        }

        private static void quickSort(int[] arr, int left, int right)
        {
            if (left >= right)
                return;
            int pivotPos = partition(arr, left, right);
            quickSort(arr, left, pivotPos - 1);
            quickSort(arr, pivotPos + 1, right);
        }

        private static int partition(int[] arr, int left, int right)
        {
            int pivotKey = arr[left];

            while (left < right)
            {
                while (left < right && arr[right] >= pivotKey)
                    right--;
                arr[left] = arr[right]; //把小的移动到左边
                while (left < right && arr[left] <= pivotKey)
                    left++;
                arr[right] = arr[left]; //把大的移动到右边
            }
            arr[left] = pivotKey; //最后把pivot赋值到中间
            return left;
        }
        #endregion
    }
}
