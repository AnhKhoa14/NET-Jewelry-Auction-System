using BusinessObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Panacea_GroupProject.Helpers;
using Service;
using System;
using System.Security.Claims;
using System.Linq;

namespace Panacea_GroupProject.Pages.Template
{
    public class AuctionsModel : PageModel
    {
        private readonly IUserService _userService;
        private readonly IAuctionService _auctionService;
        private readonly IBidService _bidService;
        private readonly IUserAuctionService _userAuctionService;

        public AuctionsModel(IUserAuctionService userAuctionService, IUserService userService, IAuctionService auctionService, IBidService bidService)
        {
            _userService = userService;
            _auctionService = auctionService;
            _bidService = bidService;
            _userAuctionService = userAuctionService;


        }

        public User LoggedInUser { get; private set; }
        public IList<Auction> UpcomingAuctions { get; set; }
        public IList<Auction> CurrentAuctions { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchQuery { get; set; }
        public async Task<IActionResult> OnGet()
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;
            var userIdClaim = claimsIdentity?.FindFirst("Id");
            if (userIdClaim == null)
            {
                return RedirectToPage("/Accounts/Login");
            }

            LoggedInUser = _userService.GetUserByID(int.Parse(userIdClaim.Value));

            if (LoggedInUser == null)
            {
                return RedirectToPage("/Accounts/Login");
            }
            await LoadDataAsync();
            //UpcomingAuctions =  _auctionService.GetAllAuctions();
            //CurrentAuctions = UpcomingAuctions.FirstOrDefault(c=> c.Status == "Processing");
            //LoggedInUser = HttpContext.Session.GetObjectFromJson<User>("LoggedInUser");

            return Page();
        }

        [BindProperty]
        public decimal BidAmount { get; set; }

        public async Task<IActionResult> OnPost(int auctionId)

        {
            var claimsIdentity = User.Identity as ClaimsIdentity;
            var userIdClaim = claimsIdentity?.FindFirst("Id");
            if (userIdClaim == null)
            {
                return RedirectToPage("/Accounts/Login");
            }

            LoggedInUser = _userService.GetUserByID(int.Parse(userIdClaim.Value));

            if (LoggedInUser == null)
            {
                return RedirectToPage("/Accounts/Login");
            }
            UserAuction userAuction = new UserAuction()
            {
                UserId = LoggedInUser.Id,
                AuctionId = auctionId
            };
            if (_userAuctionService.GetUserAuctionByAuctionId(auctionId).Any(c => c.UserId == userAuction.UserId))
            {
                return Redirect($"/Auctions/BidPrice?id={auctionId}");
            }
            else
            {
                _userAuctionService.CreateAuction(userAuction);
                return Redirect($"/Auctions/BidPrice?id={auctionId}");

            }

            //await LoadDataAsync();
            //return Page();
        }

        private async Task LoadDataAsync()
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;
            var userIdClaim = claimsIdentity?.FindFirst("Id");
            if (userIdClaim == null)
            {
                 RedirectToPage("/Accounts/Login");
            }

            LoggedInUser = _userService.GetUserByID(int.Parse(userIdClaim.Value));

            if (LoggedInUser == null)
            {
                 RedirectToPage("/Accounts/Login");
            }
            if (!string.IsNullOrWhiteSpace(SearchQuery))
            {
                CurrentAuctions = _auctionService.GetAuctionByStatus("Processing");
                UpcomingAuctions = _auctionService.Search(SearchQuery);
            }
            else
            {
                CurrentAuctions = _auctionService.GetAuctionByStatus("Processing");
                UpcomingAuctions = _auctionService.GetAuctionByStatus("Pending");
            }
        }
    }
}
