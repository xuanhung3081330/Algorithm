using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;



namespace Algorithm
{
    class Program

    {

        static void Main(string[] args)
        {
            int[] nums = { -2, -2, -2, 1, 1, 4, 4 };
            var draft = ThreeSum(nums);

            Console.ReadLine();
        }



        private static int draft(int x)
        {
            if (x > Math.Pow(-2, 31) && x < Math.Pow(2, 31))
            {
                int result;
                if (x < 0)
                {
                    int y = Math.Abs(x);
                    string s = null;
                    int number;

                    while (y != 0)

                    {

                        int k = y % 10;

                        y = y / 10;

                        s += k.ToString();

                    }

                    Int32.TryParse(s, out number);



                    result = 0 - number;



                    return result;

                }



                string a = null;

                int numberDraft;

                while (x != 0)

                {

                    int k = x % 10;

                    x = x / 10;

                    a += k.ToString();

                }

                Int32.TryParse(a, out numberDraft);



                return numberDraft;

            }



            return 0;

        }



        private static IList<IList<int>> ThreeSum(int[] nums)
        {
            //var numsLst = nums.ToList();   
            //IList<IList<int>> result = new List<IList<int>>();
            //for (var i = 0; i < numsLst.Count; i++)
            //{
            //    if (i == numsLst.Count - 2 || i == numsLst.Count - 1)
            //    {
            //        break;
            //    }

            //    for (var j = i + 1; j < numsLst.Count; j++)
            //    {
            //        if (j == numsLst.Count - 1) break;
            //        var subLst = numsLst.GetRange(j, 2);
            //        if (numsLst[i] + subLst[0] + subLst[1] == 0)
            //        {
            //            List<int> resultSubArr = new List<int>();
            //            resultSubArr.Add(numsLst[i]);
            //            resultSubArr.Add(subLst[0]);
            //            resultSubArr.Add(subLst[1]);
            //            resultSubArr.Sort();
            //            if (result.Any(item => item.SequenceEqual(resultSubArr)))
            //            {
            //                continue;
            //            }
            //            result.Add(resultSubArr);
            //        }
            //    }
            //}
            //return result;

            //////////////////////////////////////
            //if (nums.Length < 3) return new List<IList<int>>();
            //Array.Sort(nums); // sort method
            //HashSet<IList<int>> set = new HashSet<IList<int>>();
            //// -2, -1, 0, 1, 2, 3
            //for (int i = 0; i < nums.Length - 2; i++)
            //{
            //    // next index of i
            //    int j = i + 1;
            //    // last index in nums
            //    int k = nums.Length - 1;
            //    // loop
            //    while(j < k)
            //    {
            //        // sum and compare if it's equal to 0
            //        int sum = nums[i] + nums[j] + nums[k];
            //        if (sum == 0)
            //        {
            //            if (set.Any(item => item.SequenceEqual(new List<int> { nums[i], nums[j], nums[k] })))
            //            {
            //                ++j;
            //                --k;
            //                continue;
            //            }
            //            set.Add(new List<int>
            //            {
            //                nums[i], nums[j++], nums[k--]
            //            });
            //        }
            //        else if (sum > 0) k--;
            //        else if (sum < 0) j++;
            //    }
            //}
            //return set.ToList();


            ///////////////////////////////////
            // Declare the list of lists that will contain our result
            IList<IList<int>> result = new List<IList<int>>();

            // The edge case
            if (nums.Length <= 2) return result;

            /*
             Here we declare 3 indexes. This is how it works.
            -4 -2 -3 -1 0 0 0 2 3 10 21
            s   l                     r

            s - start index, l - left index, r - right index
             */
            int start = 0, left, right;

            // The target is that the number we are looking for to be composed out of 2 numbers from our array.
            int target;

            /*
             The start goes from 0 to (length - 2) because
            -4 -2 -3 -1 0 0 0 2 3 10 21
                                s  l  r
             */
            while (start < nums.Length - 2)
            {
                target = nums[start] * -1;
                left = start + 1;
                right = nums.Length - 1;

                /*
                 Now, the start index is fixed and we move the left and right indexes to find those two number
                which summed up will be the opposite of nums[start]
                 */
                while (left < right)
                {
                    if (nums[left] + nums[right] > target)
                    {
                        --right;
                    }
                    else if (nums[left] + nums[right] < target)
                    {
                        ++left;
                    }
                    else
                    {
                        List<int> oneSolution = new List<int>
                        {
                            nums[start], nums[left], nums[right]
                        };
                        result.Add(oneSolution);

                        /*
                         Now, in order to generate different solutions, we have to jump over repetitive (Lặp đi lặp lại) values in the array.
                         */
                        while (left < right && nums[left] == oneSolution[1])
                            ++left;
                        while (left < right && nums[right] == oneSolution[2])
                            --right;
                    }
                }

                // Now we do the same thing to the start index.
                int currentStartNumber = nums[start];
                while (start < nums.Length - 2 && nums[start] == currentStartNumber)
                    ++start;
            }
            return result;
        }
        // Example [-2 -2 -2 1 1 4 4]
        // 1. start = 0, left = 1, right = 6
        // 1. nums[start] = -2, nums[left] = -2, nums[right] = 4
        // 1. (-2, -2, 4)
        // 2. start = 0, left = 3, right = 4
        // 2. nums[start] = -2, nums[left] = 1, nums[right] = 1
        // 2. (-2, 1, 1)
    }
}

