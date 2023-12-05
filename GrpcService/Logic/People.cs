using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrpcService.Logic
{
    public class People
    {
        public string Firstname { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is People other)
            {
                return this.Firstname == other.Firstname && this.LastName == other.LastName && this.City == other.City;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.Firstname, this.LastName, this.City);
        }
    }
}
