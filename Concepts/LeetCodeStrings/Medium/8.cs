using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeStrings.Medium
{
    public class _8
    {


        public int MyAtoi1(string str)
        {
            StringBuilder sb = new StringBuilder();

            str = str.Trim();
            if (str.Length == 0)
            {
                return 0;
            }

            int i = 0;
            if (str[i] == '-' || str[i] == '+')
            {
                sb.Append(str[0]);
                ++i;
            }

            for (; i < str.Length; i++)
            {
                if (str[i] >= 48 && str[i] <= 57)
                {
                    sb.Append(str[i]);
                }
                else
                {
                    break;
                }
            }

            if (sb.Length == 0)
            {
                return 0;
            }

            if (double.TryParse(sb.ToString(), out double coversionResult))
            {
                if (coversionResult > int.MaxValue)
                {
                    return int.MaxValue;
                }
                else if (coversionResult < int.MinValue)
                {
                    return int.MinValue;
                }

                else
                {
                    return (int)coversionResult;
                }
            }

            return 0;
        }
        public int MyAtoi2(string str)
        {
            int result = 0;
            if (str.Length == 0)
            {
                return result;
            }

            string[] words = str.Split(' ');

            for (int i = 0; i < words.Length; i++)
            {
                if (words[i] == string.Empty)
                    continue;

                if (double.TryParse(words[i], out double coversionResult))
                {
                    if (coversionResult > int.MaxValue)
                    {
                        return int.MaxValue;
                    }
                    else if (coversionResult < int.MinValue)
                    {
                        return int.MinValue;
                    }

                    else
                    {
                        return (int)coversionResult;
                    }
                }
                else
                {
                    if (words[i][0] != '-' || words[i][0] != '+' || words[i][0] < 48 || words[i][0] > 57)
                    {
                        return 0;
                    }

                    else
                    {
                        StringBuilder sb = new StringBuilder();

                        int end = words[i].Length;

                        for (int start = 0; start < end; ++start)
                        {
                            if (words[i][start] == '-' || words[i][start] == '+')
                            {
                                sb.Append(words[i][start]);
                            }
                            else if (words[i][start] == '0')
                            {
                                continue;
                            }
                            else
                            {

                                if (words[i][start] >= 48 || words[i][start] <= 57)
                                {
                                    sb.Append(words[i][start]);
                                }
                                else
                                {
                                    break;
                                }

                            }
                        }

                        int.TryParse(sb.ToString(), out int r);

                        return r;


                    }


                }
            }


            return result;



        }


    }
}
