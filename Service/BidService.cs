using BusinessObjects;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class BidService:IBidService
    {
        private readonly IBidRepository _bidRepository;
        public BidService()
        {
            _bidRepository = new BidRepository();
        }
        public  async Task AddBid(Bid bid) => await _bidRepository.AddBid(bid);
    }
}
