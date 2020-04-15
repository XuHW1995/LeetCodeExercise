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

        #region 2.买卖股票的最佳时机2
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

        #region 4.存在重复
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

        #region 5.只出现一次的数字
        /*
            给定一个非空整数数组，除了某个元素只出现一次以外，其余每个元素均出现两次。找出那个只出现了一次的元素。

            说明：

            你的算法应该具有线性时间复杂度。 你可以不使用额外空间来实现吗？

            示例 1:

            输入: [2,2,1]
            输出: 1
             */
        public static int SingleNumber(int[] nums)
        {
            HashSet<int> tempList = new HashSet<int>();
            foreach (int value in nums)
            {
                if (tempList.Contains(value))
                {
                    tempList.Remove(value);
                }
                else
                {
                    tempList.Add(value);
                }
            }

            return tempList.First();
        }
        #endregion

        #region 6.俩个数集的交集2

        public static int[] Intersect(int[] nums1, int[] nums2)
        {
            //遍历第一个数组，把所有元素的出现次数记录在表里
            Dictionary<int, int> value2Count = new Dictionary<int, int>(); 
            for (int i = 0; i< nums1.Length; i++)
            {
                if (!value2Count.ContainsKey(nums1[i]))
                {
                    value2Count.Add(nums1[i], 1);
                }
                else
                {
                    value2Count[nums1[i]] = value2Count[nums1[i]] + 1;
                }
            }

            //遍历第二个数组，找到相同的元素，且出现次数大于0，存入结果数组
            List<int> temp = new List<int>();
            for (int j = 0; j < nums2.Length; j++)
            {
                if (value2Count.ContainsKey(nums2[j])
                    && value2Count[nums2[j]] > 0)
                {
                    value2Count[nums2[j]] = value2Count[nums2[j]] - 1;
                    temp.Add(nums2[j]);
                }
            }

            return temp.ToArray();
        }
        #endregion

        #region 7.加1
        /*
            给定一个由整数组成的非空数组所表示的非负整数，在该数的基础上加一。
            最高位数字存放在数组的首位， 数组中每个元素只存储单个数字。
            你可以假设除了整数 0 之外，这个整数不会以零开头。

            示例 1:
            输入: [1,2,3]
            输出: [1,2,4]
            解释: 输入数组表示数字 123。
         */
        //取巧方法，数组不能超过9位数，不然会超出int限制
        public static int[] PlusOne(int[] digits)
        {
            int num = 0;
            for (int i = digits.Length - 1; i >= 0 ; i--)
            {
                num += digits[i] * (int)Math.Pow(10, digits.Length - 1 - i);
            }
            num = num + 1;
            List<int> newList = new List<int>();
            for (int weight = num.ToString().Length- 1; weight >=0 ; weight --)
            {
                newList.Add((num / (int)Math.Pow(10, weight)) % 10);
            }

            return newList.ToArray();
        }

        public static int[] PlusOne2(int[] digits)
        {
            bool isUp = false;
            for (int i = digits.Length - 1; i >= 0; i--)
            {
                //个位+1
                if (i == digits.Length - 1)
                {
                    isUp = digits[i] + 1 > 9 ? true : false;
                    digits[i] = (digits[i] + 1) % 10;
                }
                else
                {
                    if (isUp)
                    {
                        isUp = digits[i] + 1 > 9 ? true : false;
                        digits[i] = (digits[i] + 1) % 10;
                    }
                    else
                    {
                        return digits;
                    }
                }
            }

            //如果最后一位还需要进位，结果数组长度+1
            if (isUp)
            {
                digits = new int[digits.Length + 1];//首位扩充
                digits[0] = 1;
            }

            return digits;
        }
        #endregion

        #region 8.移动零
        /*
            给定一个数组 nums，编写一个函数将所有 0 移动到数组的末尾，同时保持非零元素的相对顺序。
            示例:
            输入: [0,1,0,3,12]
            输出: [1,3,12,0,0]
        */

        //双指针
        //时间复杂度：O(n)，空间复杂度O(1)
        public static void MoveZeroes(int[] nums)
        {
            //非0元素个数，相当于虚拟数组下标
            int notZeroCount = 0;
            for(int i = 0; i< nums.Length;i++)
            {
                //非0元素放在原数组的对应位置
                //由于i是快指针，所以不会出现原数据丢失的情况
                if (nums[i] != 0)
                {
                    nums[notZeroCount] = nums[i];
                    notZeroCount++;
                }
            }

            //非0元素个数之后的数据全部置为0
            for (int i = notZeroCount; i < nums.Length; i++)
            {
                nums[i] = 0;
            }

        }
        #endregion

        #region 9.俩数之和
        public static int[] TwoSum(int[] nums, int target)
        {
            Dictionary<int, int> numValue2Index = new Dictionary<int, int>();
            for (int i = 0; i<nums.Length; i++)
            {
                if (numValue2Index.ContainsKey(target - nums[i]))
                {
                    return new int[] { i, numValue2Index[target - nums[i]] };
                }
                
                numValue2Index[nums[i]] = i;
            }

            return null;
        }
        #endregion
    }
}