using System;
using System.Collections.Generic;
using System.Text;

namespace PracticingRecursionInJava.LinkedList
{
    class _17
    {
        public bool Equal(ListNode n1,ListNode n2)
        {
            if (n1 == null && n2 == null)
                return true;
            if (n1 != null && n2 == null)
                return false;
            if (n1 == null && n2 != null)
                return true;

            return Equal(n1.next, n2.next) && n1.val == n2.val;

        }
    }
}
