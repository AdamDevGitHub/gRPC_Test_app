using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrpcService.Interfaces
{
    public interface IRepository
    {
        public IList GetMockData();
    }
}
