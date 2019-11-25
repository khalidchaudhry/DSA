using System;
using System.Runtime.CompilerServices;

namespace OverridingEquals
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var phoneNumber1 = new PhoneNumber {AreaCode="408",Exchange="623",SubscriberNumber="0889"};
            var phoneNumber2 = new PhoneNumber { AreaCode = "408", Exchange = "623", SubscriberNumber = "0889" };
            var phoneNumber3 = new PhoneNumber { AreaCode = "425", Exchange = "749", SubscriberNumber = "0553" };
            // Equals operator is based on reference equality
            Console.WriteLine(phoneNumber1.Equals(phoneNumber2));
            //If we ever want to be certain that we are performing a reference equality check, 
            // we can call the following static method:
            Console.WriteLine(Object.ReferenceEquals(phoneNumber1,phoneNumber2));
            // An overloaded version of Equals that takes a PhoneNumber, allowing us to bypass the unnecessary casting 
            // when a PhoneNumber is provided
            Console.WriteLine(phoneNumber1.Equals(phoneNumber2));

            
            Console.ReadLine();

        }
    }
    public class PhoneNumber
    {
        // First part of a phone number: (XXX) 000-0000
        public string AreaCode { get; set; }
        // Second part of a phone number: (000) XXX-0000
        public string Exchange { get; set; }
        // Third part of a phone number: (000) 000-XXXX
        public string SubscriberNumber { get; set; }

        public  bool Equals(PhoneNumber phoneNumber)
        {
            return IsEqual(phoneNumber);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null,obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return IsEqual((PhoneNumber)obj);

        }
        private bool IsEqual(PhoneNumber number)
        {
            // A pure implementation of value equality that avoids the routine checks above
            // We use String.Equals to really drive home our fear of an improperly overridden "=="
            return String.Equals(AreaCode, number.AreaCode)
                && String.Equals(Exchange, number.Exchange)
                && String.Equals(SubscriberNumber, number.SubscriberNumber);
        }
        public override int GetHashCode()
        {
            unchecked
            {
                // Choose large primes to avoid hashing collisions
                const int HashingBase = (int)2166136261;
                const int HashingMultiplier = 16777619;

                int hash = HashingBase;
                hash = (hash * HashingMultiplier) ^ (!Object.ReferenceEquals(null, AreaCode) ? AreaCode.GetHashCode() : 0);
                hash = (hash * HashingMultiplier) ^ (!Object.ReferenceEquals(null, Exchange) ? Exchange.GetHashCode() : 0);
                hash = (hash * HashingMultiplier) ^ (!Object.ReferenceEquals(null, SubscriberNumber) ? SubscriberNumber.GetHashCode() : 0);
                return hash;
            }
        }

    }

}
