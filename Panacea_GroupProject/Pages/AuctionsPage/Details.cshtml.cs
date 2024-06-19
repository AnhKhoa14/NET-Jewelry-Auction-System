﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects;
using DataAccessObjects;

namespace Panacea_GroupProject.Pages.AuctionsPage
{
    public class DetailsModel : PageModel
    {
        private readonly DataAccessObjects.GroupProjectPRN221 _context;

        public DetailsModel(DataAccessObjects.GroupProjectPRN221 context)
        {
            _context = context;
        }

        public Auction Auction { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Auction = await _context.Auctions
                .Include(a => a.Jewelry).FirstOrDefaultAsync(m => m.Id == id);

            if (Auction == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
