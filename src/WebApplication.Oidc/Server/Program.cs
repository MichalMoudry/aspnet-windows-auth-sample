using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

var builder =
    Microsoft.AspNetCore.Builder.WebApplication.CreateSlimBuilder(args);
builder.WebHost.ConfigureKestrel(i => i.AddServerHeader = false);
builder.Services.AddControllers();
builder.Services.AddHealthChecks();

var app = builder.Build();
app.UseHealthChecks("/health");

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
