using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeStrings.Medium
{
    public class _93
    {
        public static void _93Main()
        {
            _93 RestoreIpAddress = new _93();
            RestoreIpAddress.RestoreIpAddresses0("25525511135");
        }

        //https://www.youtube.com/watch?v=KU7Ae2513h0
        public IList<string> RestoreIpAddresses0(string s)
        {
            List<string> allIPAddresses = new List<string>();
            RestoreIpAddresses0(s, 0, 0, new int[4], allIPAddresses);

            return allIPAddresses;
        }

        /// <summary>
        /// https://www.youtube.com/watch?v=JfB3BugMht8
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public IList<string> RestoreIpAddresses(string s)
        {
            List<string> result = new List<string>();
            int n = s.Length;
            //!why start at 1 because we want to place dot after ATLEAST one digit
            //!i<4 because we are using i as length of substring. Subpart length can't be greater than 3
            for (int i = 1; i < n && i < 4; i++)
            {
                string first = s.Substring(0, i);
                if (!IsValidPart(first))
                {
                    continue;
                }
                for (int j = 1; i + j < n && j < 4; ++j)
                {
                    string second = s.Substring(i, j);
                    if (!IsValidPart(second))
                    {
                        continue;
                    }

                    for (int k = 1; i + j + k < n && k < 4; ++k)
                    {
                        string third = s.Substring(i + j, k);
                        string fourth = s.Substring(i + j + k);
                        if (!IsValidPart(third) || !IsValidPart(fourth))
                        {
                            continue;
                        }
                        result.Add(first + "." + second + "." + third + "." + fourth);
                    }
                }
            }

            return result;
        }

        private void RestoreIpAddresses0(string rawIPString, int progressIndex, int currentSegment, int[] ipAddressSegments, List<string> allIpAddresses)
        {
            /*
                 If we have filled 4 segments (0, 1, 2, 3) and we are on the 4th,
                 we will only record an answer if the string was decomposed fully
             */
            if (currentSegment == 4 && progressIndex == rawIPString.Length)
            {
                string ipAddress = ipAddressSegments[0] + "." + ipAddressSegments[1] + "." + ipAddressSegments[2] + "." + ipAddressSegments[3];
                allIpAddresses.Add(ipAddress);
            }
            else if (currentSegment == 4)
            {
                return;
            }

            for (int segLength = 1; segLength <= 3 && (progressIndex + segLength) <= rawIPString.Length; segLength++)
            {
                string segmentAsString = rawIPString.Substring(progressIndex, segLength);
                int segmentValue = int.Parse(segmentAsString);
                /// Check the "snapshot's" validity - if invalid break iteration
                if (segmentValue > 255 || (segLength >= 2 && segmentAsString[0] == '0'))
                {
                    break;
                }
                // Add the extracted segment to the working segments
                ipAddressSegments[currentSegment] = segmentValue;

                // Recurse on the segment choice - when finished & we come back here, the next loop iteration will try another segment
                RestoreIpAddresses0(rawIPString, progressIndex + segLength, currentSegment + 1, ipAddressSegments, allIpAddresses);
            }
        }

        private bool IsValidPart(string s)
        {
            //! needed for this input "0279245587303"
            if (s.Length > 3)
            {
                return false;
            }
            //0 is valid but 00,01,000 are not valid
            if (s.StartsWith("0") && s.Length > 1)
            {
                return false;
            }

            int val = int.Parse(s);

            return val >= 0 && val <= 255;
        }
    }
}
