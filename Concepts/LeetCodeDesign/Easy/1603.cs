using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeDesign.Easy
{
    public class _1603
    {


    }

    public class ParkingSystem
    {

        Dictionary<int, int> _carTypeCapacity;
        public ParkingSystem(int big, int medium, int small)
        {
            _carTypeCapacity = new Dictionary<int, int>();

            _carTypeCapacity.Add(1, big);
            _carTypeCapacity.Add(2, medium);
            _carTypeCapacity.Add(3, small);
        }

        public bool AddCar(int carType)
        {

            if (!_carTypeCapacity.ContainsKey(carType) || _carTypeCapacity[carType] == 0)
                return false;

            _carTypeCapacity[carType] = _carTypeCapacity[carType] - 1;

            return true;
        }
    }
}
