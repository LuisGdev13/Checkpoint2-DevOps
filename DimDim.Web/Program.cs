using DimDim.Web.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

builder.Services.AddAuthorization();

builder.Services.AddApplicationInsightsTelemetry();

builder.Services.AddDbContext<DimDimDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DimDimDatabase")));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();