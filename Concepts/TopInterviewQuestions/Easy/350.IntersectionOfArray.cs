using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopInterviewQuestions.Easy
{
    public class IntersectionOfArray
    {
        public int[] Intersect(int[] nums1, int[] nums2)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();

            List<int> lst = new List<int>();

            for (int i = 0; i < nums1.Length; i++)
            {
                if (dict.ContainsKey(nums1[i]))
                {
                    dict[nums1[i]]++;
                }
                else
                {
                    dict.Add(nums1[i],1);
                }
            }
            for (int i = 0; i < nums2.Length; i++)
            {
                if (dict.ContainsKey(nums2[i])&&dict[nums2[i]]>0)
                {
                    lst.Add(nums2[i]);
                    dict[nums2[i]]--;
                }               
            }

            return lst.ToArray();

        }

        // When arrays are sorted
        public int[] Intersect2(int[] nums1, int[] nums2)
        {
            nums1.OrderBy(x=>x);
            nums2.OrderBy(x => x);

            List<int> lst = new List<int>();
            int num1Length = nums1.Length;
            int num2Length = nums2.Length;

            int i =0;
            int j = 0;

            while (i < num1Length && j < num2Length)
            {
                if (nums1[i] > nums2[j])
                {
                    ++j;

                }
                else if (nums1[i] < nums2[j])
                {
                    ++i;
                }

                else {

                    lst.Add(nums1[i]);
                    ++i;
                    ++j;
                }
            }
            

            return lst.ToArray();

        }

        public int[] Union(int[] nums1, int[] nums2)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();

            List<int> lst = new List<int>();

            for (int i = 0; i < nums1.Length; i++)
            {
                if (dict.ContainsKey(nums1[i]))
                {
                    dict[nums1[i]]++;
                }
                else
                {
                    dict.Add(nums1[i], 1);
                }
            }
            for (int i = 0; i < nums2.Length; i++)
            {
                if (dict.ContainsKey(nums2[i]) && dict[nums2[i]] > 0)
                {
                    lst.Add(nums2[i]);
                    dict[nums2[i]]--;
                }
            }

            foreach (var item in dict)
            {
                for (int i = 0; i < item.Value; i++)
                {
                    lst.Add(item.Key);
                }
            }

            return lst.ToArray();

        }


    }
}
