using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeDesign.Medium
{
    class _348
    {
    }

    public class TicTacToe
    {

        /** Initialize your data structure here. */
        int[] rows;
        int[] cols;
        int leftDiag;
        int rightDiag;
        int n;
        public TicTacToe(int n)
        {

            rows = new int[n];
            cols = new int[n];
            leftDiag = 0;
            rightDiag = 0;
            this.n = n;
        }

        /** Player {player} makes a move at ({row}, {col}).
            @param row The row of the board.
            @param col The column of the board.
            @param player The player, can be either 1 or 2.
            @return The current winning condition, can be either:
                    0: No one wins.
                    1: Player 1 wins.
                    2: Player 2 wins. */
        public int Move(int row, int col, int player)
        {

            int move = player == 1 ? 1 : -1;
            rows[row] += move;
            cols[col] += move;
            if (row == col)
                leftDiag += move;
            if (row == n - col - 1)
                rightDiag += move;

            if (rows[row] == n || cols[col] == n || leftDiag == n || rightDiag == n)
                return 1;
            if (rows[row] == -n || cols[col] == -n || leftDiag == -n || rightDiag == -n)
                return 2;

            return 0;


        }
    }
}
