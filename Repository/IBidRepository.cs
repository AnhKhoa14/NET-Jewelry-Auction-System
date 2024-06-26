using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IBidRepository
    {
        public Task AddBid(Bid bid);
        //Test nen chua tao may cai duoi nay. 2h roi :v
    }
}
