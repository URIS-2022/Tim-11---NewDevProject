using AuctionMS.Communication;
using AuctionMS.Entities;
using AuctionMS.Exceptions;
using AuctionMS.Repositories;
using AuctionMS.Repositories.Implementations;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<ErrorHandlingMiddleware>();
builder.Services.AddSingleton(new LoggerProvider());

builder.Services.AddDbContext<PublicBiddingContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SQLServer"), builder =>
{
    builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
}));
builder.Services.AddScoped<IPublicBiddingRepository, PublicBiddingRepository>();
builder.Services.AddScoped<IAdvertisementRepository, AdvertisementRepository>();
builder.Services.AddScoped<IOfficialJournalRepository, OfficalJournalRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseMiddleware<ErrorHandlingMiddleware>();

app.MapControllers();

app.Run();
