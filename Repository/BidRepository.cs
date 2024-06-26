using BusinessObjects;
using DataAccessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class BidRepository : IBidRepository
    {
        public  async Task AddBid(Bid bid) =>await BidDAO.AddBid(bid);
    }
}
