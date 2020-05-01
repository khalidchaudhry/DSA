using System;
using System.Collections.Generic;
using System.Text;

namespace PracticingRecursionInJava.LinkedList
{
    public class _5
    {
        public bool ItemInList(ListNode node, int item)
        {
            if (node == null)
                return false;
            else
            {
                if (node.val == item)
                    return true;
                else
                {
                    return ItemInList(node.next,item);
                }

            }


        }

    }
}
