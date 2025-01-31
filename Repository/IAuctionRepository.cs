﻿using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
	public interface IAuctionRepository
	{
		public List<Auction> GetAllAuctions();
		public Auction GetAuctionById(int id);
		public void CreateAuction(Auction auction);
		public void UpdateAuction(Auction auction);
		public void DeleteAuction(Auction auction);
		public List<Bid> GetBidForAuction(int auctionId);
		public void UpdateAuctionStatus(int auctionId, string status);
		public List<Auction> GetAuctionByUserID(int id);
		public List<Auction> GetAuctionByStatus(string status);
		public List<Auction> GetAuctionByJewelryId(int id);
	}
}
