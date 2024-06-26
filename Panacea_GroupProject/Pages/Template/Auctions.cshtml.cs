using BusinessObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Panacea_GroupProject.Helpers;
using Service;

namespace Panacea_GroupProject.Pages.Template
{
    public class AuctionsModel : PageModel
    {
        private readonly IUserService _userService;
        private readonly IAuctionService _auctionService;
        private readonly IBidService _bidService;
        public AuctionsModel(IUserService userService, IAuctionService auctionService, IBidService bidService)
        {
            _userService = userService;
            _auctionService = auctionService;
            _bidService = bidService;
        }

        public User LoggedInUser { get; private set; }
        public IList<Auction> UpcomingAuctions { get; set; }
        public async Task OnGet()
        {
            UpcomingAuctions = await _auctionService.GetAllAuctions();
            LoggedInUser = HttpContext.Session.GetObjectFromJson<User>("LoggedInUser");
        }

        [BindProperty]
        public decimal BidAmount { get; set; }

        public async Task<IActionResult> OnPost()
        {
            LoggedInUser = HttpContext.Session.GetObjectFromJson<User>("LoggedInUser");
            Bid newBid = new Bid();
            newBid.UserId = LoggedInUser.Id;
            newBid.Amount = 1;
            newBid.AuctionId = 3;
            newBid.BidTime = DateTime.Now;
            newBid.IsDeleted = false;
            _bidService.AddBid(newBid);
            return Page();
        }
    }
}
