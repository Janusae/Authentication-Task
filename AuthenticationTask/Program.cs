using CoreLayout.Models.User;
using DBConnection.Moi_Connection;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<MoiDbConnection>(options =>
{
	options.UseSqlServer(@"Server=Computer\sena;Database=Test65;Integrated Security = True; TrustServerCertificate = True");
});
builder.Services.AddAuthentication(options =>
{
	options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
	options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
	options.DefaultSignOutScheme = CookieAuthenticationDefaults.AuthenticationScheme;

}).AddCookie(options =>
{
	options.LoginPath = "";
	options.LogoutPath = "";
	options.ExpireTimeSpan = TimeSpan.FromDays(30);
});
builder.Services.AddScoped<IUserService , UserService>();
// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
