using GrpcService.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrpcService.Logic
{
    public class DataMockRepository : IRepository
    {
        public IList GetMockData()
        {
            IList list = new List<People>();

            list.Add(new People { Firstname = "Jan", LastName = "Kowalski", City = "Katowice" });
            list.Add(new People { Firstname = "Adam", LastName = "Nowak", City = "Warszawa" });
            list.Add(new People { Firstname = "Ewa", LastName = "Wiśniewska", City = "Wrocław" });

            return list;
        }
    }
}
