﻿using BusinessObjects;
using DataAccessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class AuctionRepository : IAuctionRepository
    {
        public void CreateAuction(Auction auction)
        {
            AuctionDAO.CreateAuction(auction);
        }

        public void DeleteAuction(Auction auction)
        {
            AuctionDAO.DeleteAuction(auction);
        }

        public async Task<List<Auction>> GetAllAuctions()
        {
            return await AuctionDAO.GetAllAuctions();
        }

        public Auction GetAuctionById(int id)
        {
            return AuctionDAO.GetAuctionById(id);
        }

        public void UpdateAuction(Auction auction)
        {
            AuctionDAO.UpdateAuction(auction);
        }
    }
}
