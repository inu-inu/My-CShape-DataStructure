using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace My_CShape_DataStructure.LeetCode
{
    internal class LeetCodeTest
    {
        public Stopwatch Stopwatch { get; set; }
        public void LC217_ContainsDuplicate()
        {
            Stopwatch = new Stopwatch();
            Stopwatch.Start();

            ///https://leetcode.cn/problems/contains-duplicate/?envType=study-plan&id=shu-ju-jie-gou-ru-men&plan=data-structures&plan_progress=4zguvrg

            #region Linq(My)
            //double[] nums = { 1, 2, 3, 4, 5, 6, 7, 1 };
            //List<List<double>> res = new List<List<double>>();
            //bool result = false;
            //for (int i = 0; i < nums.Count(); i++)
            //{
            //    if (res.Any(x => x.FirstOrDefault() == nums[i]))
            //    {
            //        var a = res.First(x => x.FirstOrDefault() == nums[i]);
            //        if (++a[1] == 2)
            //        {
            //            result = true; break;
            //        }
            //    }
            //    else
            //    {
            //        res.Add(new List<double> { nums[i], 1 });
            //    }
            //}
            //Console.WriteLine(result);
            #endregion

            #region HashSet(unique value)
            //double[] nums = { 1, 2, 3, 4, 5, 6, 7, 1 };
            //var res = new HashSet<double>();
            //bool result = false;
            //foreach (var item in nums)
            //{
            //    res.Add(item);
            //}
            //if (res.Count() != nums.Count())
            //{
            //    result = true;
            //}
            //Console.WriteLine(result);
            #endregion

            #region Sort
            //double[] nums = { 1, 2, 3, 4, 5, 6, 7 };
            //Array.Sort(nums);
            //bool result = false;
            //for (int i = 0; i < nums.Count() - 1; i++)
            //{
            //    if (nums[i] == nums[i + 1]) { result = true; break; }
            //}
            //Console.WriteLine(result);
            #endregion

            Stopwatch.Stop();
            Console.WriteLine($"Time:{Stopwatch.Elapsed.TotalMilliseconds}");
        }
        public void LC219_ContainsNearbyDuplicate()
        {
            Console.WriteLine("LC219_ContainsNearbyDuplicate");
            Stopwatch = new Stopwatch();
            Stopwatch.Start();

            ///https://leetcode.cn/problems/contains-duplicate-ii/description/
            int[] nums = { 1, 2, 3, 4, 1, 5, 6 };
            int k = 2;

            #region My(Give range, ajuest related value)
            //bool res = false;
            //for (int i = 0; i < nums.Length; i++)
            //{
            //    for (int j = i + 1; j <= i + k; j++)
            //    {
            //        if (j == nums.Length) break;
            //        if (j < 0) { continue; }
            //        if (nums[j] == nums[i])
            //        {
            //            res = true;
            //            break;
            //        }
            //    }
            //}
            //Console.WriteLine(res);
            #endregion

            #region HashSet(Get same value, ajuest distance)=>SlideWindow
            var hashSet = new HashSet<int>();
            bool res = false;
            for (int i = 0; i < nums.Length; i++)
            {
                if (hashSet.Contains(nums[i])) { res = true; break; }
                hashSet.Add(nums[i]);
                if (hashSet.Count > k) { hashSet.Remove(nums[i - k]); }
            }
            Console.WriteLine(res);
            #endregion

            Stopwatch.Stop();
            Console.WriteLine($"Time:{Stopwatch.Elapsed.TotalMilliseconds}");
        }
        public void LC220_ContainsNearbyAlmostDuplicate()
        {

        }
    }
}
