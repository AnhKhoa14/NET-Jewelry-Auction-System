﻿using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects
{
    public class AuctionRequestDAO
    { 
        public static void CreateAuctionRequest(AuctionRequest auctionRequest)
        {
            try
            {
                using var db = new GroupProjectPRN221();
                db.Users.Attach(auctionRequest.User);
                db.AuctionRequests.Add(auctionRequest);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Read
        public static AuctionRequest GetAuctionRequestById(int id)
        {
            using var db = new GroupProjectPRN221();
            return db.AuctionRequests.SingleOrDefault(a => a.Id == id);
        }

        public static List<AuctionRequest> GetAllAuctionRequest()
        {
            var list = new List<AuctionRequest>();
            try
            {
                using var db = new GroupProjectPRN221();
                list = db.AuctionRequests.Where(a => a.Status == "Approved").ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }

        // Update
        public static void UpdateAuctionRequest(AuctionRequest auctionRequest)
        {
            try
            {
                using var db = new GroupProjectPRN221();
                db.Entry<AuctionRequest>(auctionRequest).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Delete
        public static void DeleteAuctionRequest(AuctionRequest auctionRequest)
        {
            try
            {
                using var db = new GroupProjectPRN221();
                var c = db.AuctionRequests.FirstOrDefault(a => a.Id == auctionRequest.Id);
                if (c != null)
                {
                    c.IsDelete = true;
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception("Auction Request not found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
