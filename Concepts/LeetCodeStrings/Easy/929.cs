using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeStrings.Easy
{
    class _929
    {
        public int NumUniqueEmails(string[] emails)
        {
            HashSet<string> hs = new HashSet<string>();

            foreach (string email in emails)
            {
                // string.IndexOf returns the index of the first character in the string. 
                // string.Substring(x,y) extracts the string from index x till the y length
                // we can use IndexOf in substring as it gives the correct lenght we need to extract. 

                string localName = email.Substring(0, email.IndexOf("@")).Replace(".", string.Empty);

                int indexOf = localName.IndexOf("+");
                // Important . Check if Index does not return -1
                if (indexOf != -1)
                {
                    localName = localName.Substring(0, indexOf);
                }

                string validEmail = localName + email.Substring(email.IndexOf("@"));
                if (!hs.Contains(validEmail))
                {
                    hs.Add(validEmail);
                }
            }

            return hs.Count;
        }


        public int NumUniqueEmails2(string[] emails)
        {
            HashSet<string> hs = new HashSet<string>();

            foreach (string email in emails)
            {
                string[] items = email.Split("@");

                string localName = items[0].Replace(".", string.Empty);

                int indexOf = localName.IndexOf("+");

                if (indexOf != -1)
                {
                    localName = localName.Substring(0, indexOf);
                }

                string validEmail = string.Concat(localName, "@", items[1]);

                if (!hs.Contains(validEmail))
                {
                    hs.Add(validEmail);
                }

            }

            return hs.Count;
        }

    }
}
