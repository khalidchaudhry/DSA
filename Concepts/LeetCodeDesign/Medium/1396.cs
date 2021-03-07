using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeDesign.Medium
{
    public class _1396
    {
    }
    public class UndergroundSystem
    {
        Dictionary<int, (string src, int t1)> _checkin;
        Dictionary<(string src, string dest), (int sum, int count)> _checkout;

        public UndergroundSystem()
        {
            _checkin = new Dictionary<int, (string src, int t1)>();
            _checkout = new Dictionary<(string src, string dest), (int sum, int count)>();

        }
        public void CheckIn(int id, string stationName, int t)
        {
            if (!_checkin.ContainsKey(id))
            {
                _checkin.Add(id, (stationName, t));
            }
        }
        public void CheckOut(int id, string stationName, int t)
        {

            string dest = stationName;
            int t2 = t;

            (string src, int t1) = _checkin[id];
            _checkin.Remove(id);

            if (!_checkout.ContainsKey((src, dest)))
            {
                _checkout.Add((src, dest), (0, 0));
            }
            //! we can't modify tuple directly like that ..... _checkout[(src, dest)].sum
            (int currSum, int currCount) = _checkout[(src, dest)];
            //! t2-t1 to add duration of the user id to existing time bw src and dest 
            _checkout[(src, dest)] = (currSum + t2 - t1, ++currCount);
        }

        public double GetAverageTime(string startStation, string endStation)
        {
            return (double)_checkout[(startStation, endStation)].sum / _checkout[(startStation, endStation)].count;
        }
    }
}
