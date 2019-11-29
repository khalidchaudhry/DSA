using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            var linkedList = new LinkedList();
            linkedList.head = new Node(1);
            var second = new Node(2);
            linkedList.head.next = second;
            var third = new Node(3);
            second.next = third;
            var fourth = new Node(4);
            third.next = fourth;
            var five = new Node(5);
            fourth.next = five;
            var six = new Node(6);
            five.next = six;

            var linkedList2 = new LinkedList();
            linkedList2.head = new Node(6);
            var second2 = new Node(5);
            linkedList2.head.next = second2;
            var third2 = new Node(4);
            second2.next = third2;
            var fourth2 = new Node(3);
            third2.next = fourth2;
            var five2 = new Node(2);
            fourth2.next = five2;
            var six2 = new Node(1);
            five2.next = six2;

            var temp1 = linkedList.head;
            var temp2 = linkedList2.head;

            Recursion(temp1,temp2);
            //var flag = false;
            //while (temp1 != null)
            //{
            //    var value = Recursion(temp2);

            //    if (temp1.data != value)
            //    {
            //        Console.WriteLine($"Data not in reverse:{temp2.data}");
            //        flag = true;
            //        break;
            //    }
            //    temp1 = temp1.next;
            //}

            //if (flag == false)
            //{
            //    Console.WriteLine($"Data in reverse:{temp2.data}");

            //}



        }

        public static void  Recursion(Node head,Node head2)
        {
          
            if (head== null)
            {
                return ;
            }

            var data2 = head2.data;

            Recursion(head.next,head2.next);

            if (head.data != data2)
            {
                Console.WriteLine("Data not equal");
            }
            
            Console.WriteLine(head.data);
          
           

        }
    }
    public class LinkedList
    {
        public Node head;
    }

    public class Node
    {
        public int data;
        public Node next;
        public Node(int d)
        {
            data = d;
            next = null;
        }
    }
}
