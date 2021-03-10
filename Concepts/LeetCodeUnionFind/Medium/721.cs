using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeUnionFind.Medium
{
    public class _721
    {

        public static void _721Main()
        {
            _721 Main = new _721();
            List<IList<string>> accounts = new List<IList<string>>();
            accounts.Add(new List<string>() { "John", "johnsmith@mail.com", "john00@mail.com" });
            accounts.Add(new List<string>() { "John", "johnnybravo@mail.com" });
            accounts.Add(new List<string>() { "John", "johnsmith@mail.com", "john_newyork@mail.com" });
            accounts.Add(new List<string>() { "Mary", "mary@mail.com"});

            var ans=Main.AccountsMerge0(accounts);
            Console.ReadLine();
        }

        public IList<IList<string>> AccountsMerge0(IList<IList<string>> accounts)
        {

            Dictionary<string, string> emailUserName = new Dictionary<string, string>();
            Dictionary<string, int> emailComponentId = new Dictionary<string, int>();

            UF uf = new UF(10000);
            int idx = 0;
            foreach (List<string> account in accounts)
            {
                string name = account[0];
                for (int i = 1; i < account.Count; ++i)
                {
                    emailUserName[account[i]] = name;

                    if (!emailComponentId.ContainsKey(account[i]))
                    {
                        emailComponentId.Add(account[i], idx++);
                    }

                    uf.Union(emailComponentId[account[1]], emailComponentId[account[i]]);
                }
            }
            //! Component Id and emails that belong to that component. 
            Dictionary<int, List<string>> idEmails = new Dictionary<int, List<string>>();

            foreach (var keyValue in emailUserName)
            {
                int u = emailComponentId[keyValue.Key];
                int pu = uf.FindSet(u);
                if (!idEmails.ContainsKey(pu))
                {
                    idEmails.Add(pu, new List<string>());
                }
                idEmails[pu].Add(keyValue.Key);
            }
            List<IList<string>> result = new List<IList<string>>();
            foreach (var keyValue in idEmails)
            {
                string email = keyValue.Value[0];
                string userName = emailUserName[email];
                keyValue.Value.Sort(string.CompareOrdinal);
                keyValue.Value.Insert(0, userName);
                result.Add(keyValue.Value);
            }

            return result;
        }
    }
}

