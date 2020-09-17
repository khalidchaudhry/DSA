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
            string ipAddress = "20EE:FGb8:85a3:0:0:8A2E:0370:7334";
            var ans=IP.ValidIPAddress(ipAddress);
            Console.ReadLine();
        }

        public string ValidIPAddress(string IP)
        {

            string[] ipAddress = IP.Split('.');
            if (ipAddress.Length == 4)
            {
                if (IsValidIPv4Address(ipAddress))
                    return "IPv4";
            }
            ipAddress= IP.Split(':');
            if (ipAddress.Length == 8)
            {
                if (IsValidIPv6Address(ipAddress))
                    return "IPv6";
            }

            return "Neither";
        }

        private bool IsValidIPv6Address(string[] ipAddress)
        {
            for (int i = 0; i < ipAddress.Length; ++i)
            {
                if (ipAddress[i].Length==0 || ipAddress[i].Length > 4)
                    return false;
                for (int j = 0; j < ipAddress[i].Length; ++j)
                {
                    if (
                        (ipAddress[i][j] >= 48 && ipAddress[i][j] <= 57) ||
                        (ipAddress[i][j] >= 65 && ipAddress[i][j] <= 70) ||
                        (ipAddress[i][j] >= 97 && ipAddress[i][j] <= 102)
                        )
                    {
                        continue;
                    }

                    return false;
                }
            }

            return true;
        }

        private bool IsValidIPv4Address(string[] ipAddress)
        {

            for (int i = 0; i < ipAddress.Length; ++i)
            {
                if (ipAddress[i].Length==0 || (ipAddress[i][0] == '0' && ipAddress[i].Length>1))
                    return false;
                if (Int64.TryParse(ipAddress[i], out long result))
                {
                    if (result > 255)
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }

            return true;
        }
    }
}
