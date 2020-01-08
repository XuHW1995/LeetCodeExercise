using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeExercise
{
    public static class ArrayType
    {
        #region 1.排序数组中删除重复元素
        /*
            给定一个排序数组，你需要在原地删除重复出现的元素，使得每个元素只出现一次，返回移除后数组的新长度。
            不要使用额外的数组空间，你必须在原地修改输入数组并在使用 O(1) 额外空间的条件下完成。
         */
        public static int RemoveDuplicates(int[] nums)
        {
            //新数组下标
            int number = 0;
            for (int i = 0; i< nums.Length; i++)
            {
                if (nums[i]!= nums[number])
                {
                    number++;
                    //此处相当于直接在旧数组的基础上利用新数组下标对实现了一个虚拟的新数组
                    nums[number] = nums[i];
                }
            }
            //长度要+1
            number = number + 1;
            return number;
         }
        #endregion

        #region 2.买卖股票的最佳时机
        /*
            给定一个数组，它的第 i 个元素是一支给定股票第 i 天的价格。

            设计一个算法来计算你所能获取的最大利润。你可以尽可能地完成更多的交易（多次买卖一支股票）。

            注意：你不能同时参与多笔交易（你必须在再次购买前出售掉之前的股票）。

            示例 1:

            输入: [7,1,5,3,6,4]
            输出: 7
            解释: 在第 2 天（股票价格 = 1）的时候买入，在第 3 天（股票价格 = 5）的时候卖出, 这笔交易所能获得利润 = 5-1 = 4 。
                 随后，在第 4 天（股票价格 = 3）的时候买入，在第 5 天（股票价格 = 6）的时候卖出, 这笔交易所能获得利润 = 6-3 = 3 。
            示例 2:

            输入: [1,2,3,4,5]
            输出: 4
            解释: 在第 1 天（股票价格 = 1）的时候买入，在第 5 天 （股票价格 = 5）的时候卖出, 这笔交易所能获得利润 = 5-1 = 4 。
                 注意你不能在第 1 天和第 2 天接连购买股票，之后再将它们卖出。
                 因为这样属于同时参与了多笔交易，你必须在再次购买前出售掉之前的股票。
            示例 3:

            输入: [7,6,4,3,1]
            输出: 0
            解释: 在这种情况下, 没有交易完成, 所以最大利润为 0。
         */

        public static int MaxProfit(int[] prices)
        {
            int maxProfit = 0;
            for (int i = 1; i < prices.Length; i++)
            {
                if (prices[i] > prices[i - 1])
                {
                    maxProfit += (prices[i] - prices[i - 1]);
                }
            }
            return maxProfit;
        }
        #endregion

        #region 3.旋转数组
        // 时间复杂度等于0（n*k）
        // 空间复杂度0（1）
        public static void Rotate1(int[] nums, int k)
        {           
            if (k == 0)
            {
                return;
            }
            while(k > 0)
            {
                int last = 0;
                for (int i = nums.Length - 1; i >= 0; i--)
                {
                    if (i == nums.Length - 1)
                    {
                        last = nums[i];
                    }

                    if (i == 0)
                    {
                        nums[0] = last; 
                    }else
                    {
                        nums[i] = nums[i - 1];
                    }
                }
                k = k-1;
            }
        }

        //反转数组
        /*  
            原始数组                  : 1 2 3 4 5 6 7
            反转所有数字后             : 7 6 5 4 3 2 1
            反转前 k 个数字后          : 5 6 7| 4 3 2 1
            反转后 n-k 个数字后        : 5 6 7| 1 2 3 4 --> 结果
         */
        // 时间复杂度等于0（n）
        // 空间复杂度0（1）
        public static void Rotate2(int[] nums, int k)
        {
            int middleIndex = k % nums.Length;
            Reversal(nums, 0, nums.Length - 1);
            Reversal(nums, 0, middleIndex - 1);
            Reversal(nums, middleIndex, nums.Length - 1);
        }

        static void Reversal(int[] nums, int beginIndex, int endIndex)
        {
            while(beginIndex < endIndex)
            {
                int temp = nums[endIndex];
                nums[endIndex] = nums[beginIndex];
                nums[beginIndex] = temp;

                beginIndex++;
                endIndex--;
            }
        }
        #endregion

        #region 存在重复
        /*
            给定一个整数数组，判断是否存在重复元素。
            如果任何值在数组中出现至少两次，函数返回 true。如果数组中每个元素都不相同，则返回 false。
        
            输入: [1,1,1,3,3,4,3,2,4,2]
            输出: true
        */
        //排序后比较相邻元素

        public static bool ContainsDuplicate(int[] nums)
        {
            Array.Sort(nums);
            for (int i = 0; i < nums.Length - 1; ++i)
            {
                if (nums[i] == nums[i + 1]) return true;
            }
            return false;
        }

        #endregion
    }
}
