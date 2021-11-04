using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeDesign.Medium
{
    public class _284
    {
        class PeekingIterator
        {
            /*
                1 ,         2,           3
                ^     
             _iterator
              
             intial State
             
             _iterator=1
             _next=_iterator.Current
             _hasNext=true 
             State 0 
             











              
             
             */


            //! in C# iterators refers to the first element of the list/array.
            private int _next;// refers to the next element in IEnumerable
            private bool _hasNext;
            private IEnumerator<int> _iterator;
            public PeekingIterator(IEnumerator<int> iterator)
            {
                _iterator = iterator;//!Iterator pointing to first element in C#
                
                //if (!iterator.MoveNext())
                //{
                //    throw new Exception("Empty collection");   
                //}

                _next=_iterator.Current;//! setting the next as the current element , iterator is pointing to 
                _hasNext = true; //! as _next is true we are setting the property _hasnext true as well 

            }

            // Returns the next element in the iteration without advancing the iterator.
            public int Peek()
            {
                if (_hasNext == false) throw new InvalidOperationException("No element is next");

                return _next;
            }

            // Returns the next element in the iteration and advances the iterator.
            public int Next()
            {   
                int previous = _next;

                if (_iterator.MoveNext())
                    _next = _iterator.Current;
                else
                {
                    _hasNext = false;
                }

                return previous;
            }

            // Returns false if the iterator is refering to the end of the array of true otherwise.
            public bool HasNext()
            {
                return _hasNext;
            }
        }


    }
}
