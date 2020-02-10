using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeStrings.Easy
{
    class _1108
    {
        public string DefangIPaddr(string address)
        {
            if (string.IsNullOrEmpty(address))
                return string.Empty;

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < address.Length; i++)
            {
                if (address[i].Equals('.'))
                {
                    sb.Append('[');
                    sb.Append(address[i]);
                    sb.Append(']');
                }
                else
                {
                    sb.Append(address[i]);
                }
            }

            return sb.ToString();
        }
        public string DefangIPaddr2(string address)
        {
            return address.Replace(".","[.]");
        }

    }
}
