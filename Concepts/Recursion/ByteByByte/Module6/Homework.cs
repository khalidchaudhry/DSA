using System;
using System.Collections.Generic;
using System.Text;

namespace Recursion.ByteByByte.Module6
{
    public class Homework
    {
        /*
         Search in Rotated Array. You are given a sorted array that has been rotated. An array can be
         rotated by splitting it at any point and swapping the two halves. Write a function to determine the
         index of the smallest item in the array. Your solution should take O(log n) time.             
         */
        public int RotatedArraySearch(int[] arr)
        {
            int lo = 0;
            int hi = arr.Length - 1;

            //array is already sorted 
            if (arr[lo] < arr[hi] || arr.Length == 1)
            {
                return lo;
            }
            return BinarySearch(arr, lo, hi);
        }

        private int BinarySearch(int[] arr, int lo, int hi)
        {
            int mid = lo + (hi - lo) / 2;

            if (arr[mid] > arr[mid + 1])
                return mid + 1;
            //left side of an array is strictly increasing so we need to search on the right side
            else if (arr[lo] < arr[mid])
            {
                return BinarySearch(arr, mid + 1, hi);
            }
            else
            {
                return BinarySearch(arr, lo, mid);
            }

        }

        /* Given a tree, write a function that converts the tree into an inorder doubly linked list by modifying the pointers.*/
        public Node TreeToLinkedList(Node root)
        {
             //https://stackoverflow.com/questions/7848312/recursive-pass-in-object-by-reference-java
            //!HOWEVER, you can't reassign a reference and expect it to propagate back up the call stack. 
           
            Wrapper wrapper = new Wrapper();
            wrapper.Head = null;
            wrapper.Prev = null;

            TreeToLinkedList(root, wrapper);
            return wrapper.Head;
        }


        /*
         Given a string compress it to the minimum length string that can be achieved. Expect the
         compressed output to be of the form of “abdddddabdddddabdddddabddddd” ‑> “4[ab5[d]]”                                 
         */


        private void TreeToLinkedList(Node node, Wrapper wrapper)
        {
            if (node == null)
                return;
            TreeToLinkedList(node.left, wrapper);
            if (wrapper.Prev == null)
            {
                wrapper.Head = node;
                wrapper.Prev = node;
            }
            else
            {
                node.left = wrapper.Prev;
                wrapper.Prev.right = node;
                wrapper.Prev = node;
            }

            TreeToLinkedList(node.right, wrapper);
        }
    }

    public class Wrapper
    {
        public Node Head { get; set; }
        public Node Prev { get; set; }
    }
}
