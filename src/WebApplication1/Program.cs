using Microsoft.AspNetCore.Authentication.Negotiate;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.ConfigureKestrel(i => i.AddServerHeader = false);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services
    .AddAuthentication(NegotiateDefaults.AuthenticationScheme)
    .AddNegotiate();

// By default, all incoming requests will be authorized according to the default policy.
builder.Services.AddAuthorization(
    options => options.FallbackPolicy = options.DefaultPolicy
);
builder.Services.AddRazorPages();

var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.Run();
