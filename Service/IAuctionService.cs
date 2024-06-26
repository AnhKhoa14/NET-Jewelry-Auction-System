﻿using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
	public interface IAuctionService
	{
        public Task<List<Auction>> GetAllAuctions();
        public Auction GetAuctionById(int id);
        public void CreateAuction(Auction auction);
        public void UpdateAuction(Auction auction);
        public void DeleteAuction(Auction auction);
    }
}
