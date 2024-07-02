using Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddScoped<IUserService, UserService>(); 
builder.Services.AddScoped<IAuctionService, AuctionService>();
builder.Services.AddScoped<IJewelryService, JewelryService>();
builder.Services.AddScoped<IAuctionRequestService, AuctionRequestService>();
builder.Services.AddScoped<IMaterialService, MaterialService>(); 
builder.Services.AddScoped<IBidService, BidService>(); 


builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
builder.Services.AddHttpContextAccessor();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseSession();

app.MapRazorPages();

app.Run();
