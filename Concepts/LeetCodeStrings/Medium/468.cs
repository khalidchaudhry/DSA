using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeStrings.Medium
{
    public class _468
    {
        public static void _468Main()
        {
            _468 IP = new _468();
            string ipAddress = "2001:0db8:85a3:0:0:8A2E:0370:7334";
            var ans = IP.ValidIPAddress(ipAddress);
            Console.ReadLine();
        }

        public string ValidIPAddress(string IP)
        {
            string[] ipAddress = IP.Split('.');
            if (ipAddress.Length == 4)
            {
                return ValidIPv4Address(ipAddress);
            }
            ipAddress = IP.Split(':');
            if (ipAddress.Length == 8)
            {
                return ValidIPv6Address(ipAddress);
            }

            return "Neither";
        }

        private string ValidIPv6Address(string[] ipAddress)
        {
            string hexdigits = "0123456789abcdefABCDEF";
            foreach (string token in ipAddress)
            {
                // Validate hexadecimal in range (0, 2**16):
                // 1. at least one and not more than 4 hexdigits in one chunk
                if (token.Length == 0 || token.Length > 4)
                    return "Neither";
                // 2. only hexdigits are allowed: 0-9, a-f, A-F
                foreach (char c in token)
                {
                    if (hexdigits.IndexOf(c) == -1)
                        return "Neither";
                }
            }
            return "IPv6";
        }

        private string ValidIPv4Address(string[] ipAddress)
        {
            foreach (string token in ipAddress)
            {
                // 1. length of chunk is between 1 and 3
                if (token.Length == 0 || token.Length > 3) return "Neither";
                // 2. no extra leading zeros
                if (token[0] == '0' && token.Length != 1) return "Neither";
                // 3. only digits are allowed
                foreach (char ch in token)
                {
                    if (!char.IsDigit(ch))
                        return "Neither";
                }
                // 4. less than 255
                if (Int32.Parse(token) > 255) return "Neither";
            }
            return "IPV4";
        }
    }
}
