using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PianoTeacherWebApp_Lab2_.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<PianoTeacherDBContext>(options =>
	options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
	.AddEntityFrameworkStores<PianoTeacherDBContext>();
builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication()
	  .AddMicrosoftAccount(microsoftOptions =>
	  {
		  //IConfigurationSection section = builder.Configuration.GetSection("Authentication").GetSection("Microsoft");
		  microsoftOptions.ClientId = "cce8cdff-8cb0-49d2-acb8-caea9169eab9";
		  microsoftOptions.ClientSecret = "GZs8Q~AhLCwEhaJgHtH8sD1CftLTBApSX4DIzcLl";
	  })
   .AddGoogle(options =>
   {
	   //IConfigurationSection googleAuthNSection =config.GetSection("Authentication:Google");
	   options.ClientId = "293028431134-acdo3o3ube9cl3s47q279egnmo47vd90.apps.googleusercontent.com";
	   options.ClientSecret = "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";
   });
//.AddFacebook(options =>
//{
// IConfigurationSection FBAuthNSection =
// config.GetSection("Authentication:FB");
// options.ClientId = FBAuthNSection["ClientId"];
// options.ClientSecret = FBAuthNSection["ClientSecret"];
//})
//.AddTwitter(twitterOptions =>
//{
// twitterOptions.ConsumerKey = config["Authentication:Twitter:ConsumerAPIKey"];
// twitterOptions.ConsumerSecret = config["Authentication:Twitter:ConsumerSecret"];
// twitterOptions.RetrieveUserDetails = true;
//});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseMigrationsEndPoint();
}
else
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
