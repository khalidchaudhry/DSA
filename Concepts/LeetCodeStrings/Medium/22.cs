using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeStrings.Medium
{
    public class _22
    {
        // https://github.com/bephrem1/backtobackswe/blob/master/Dynamic%20Programming%2C%20Recursion%2C%20%26%20Backtracking/GenerateNMatchedParenStrings/GenerateNMatchedParenStrings.java
        public IList<string> GenerateParenthesis(int n)
        {
            List<string> results = new List<string>();
            StringBuilder sb = new StringBuilder();
            GenerateParenthesisHelper(n, n, "", results);
            return results;

        }

        private void GenerateParenthesisHelper(int numLeftParenthsisNeeded, int numRightParenthsisNeeded, string sparenStringInProgress, List<string> results)
        {
            /*
               The recursion has bottomed out.
               We have used all left and right parens necessary within constraints up
               to this point. Therefore, the answer we add will be a valid parent string.

               We can add this answer and then backtrack so the previous call can exhaust
               more possibilities and express more answers...and then return to its caller,
               etc. etc.
               Yeah...this is what backtracking is all about.
             */
            if (numLeftParenthsisNeeded == 0 && numRightParenthsisNeeded == 0)
            {
                results.Add(sparenStringInProgress);
                return;
            }

            /*
                 At each frame of the recursion we have 2 things we can do:
                 1.) Insert a left parenthesis
                 2.) Insert a right parenthesis
                 These represent all of the possibilities of paths we can take from this
                 respective call. The path that we can take all depends on the state coming
                 into this call.
             */

            /*
                Can we insert a left parenthesis? Only if we have lefts remaining to insert
                at this point in the recursion
             */

            if (numLeftParenthsisNeeded > 0)
            {
                /*
                   numLeftParensNeeded - 1 ->       We are using a left paren
                   numRightParensNeeded ->          We did not use a right paren
                   parenStringInProgress + "(" ->   We append a left paren to the string in progress
                   result ->                        Just pass the result list along for the next call to use
                 */
                GenerateParenthesisHelper(numLeftParenthsisNeeded - 1, numRightParenthsisNeeded, sparenStringInProgress + "(", results);
            }
            /*
               Can we insert a right parenthesis? Only if the number of left parens needed
               is less than then number of right parens needed.

               This means that there are open left parenthesis to close OTHERWISE WE CANNOT
               USE A RIGHT TO CLOSE ANYTHING. We would lose balance.
             */
            if (numLeftParenthsisNeeded < numRightParenthsisNeeded)
            {
                /*
                    numLeftParensNeeded ->           We did not use a left paren
                    numRightParensNeeded - 1 ->      We used a right paren
                    parenStringInProgress + ")" ->   We append a right paren to the string in progress
                    result ->                        Just pass the result list along for the next call to use
                  */

                GenerateParenthesisHelper(numLeftParenthsisNeeded, numRightParenthsisNeeded - 1, sparenStringInProgress + ")", results);
            }
        }
    }

}

