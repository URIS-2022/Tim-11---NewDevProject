using Logger;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<string>(builder.Configuration["awsSecretAccessKey"]);
builder.Services.AddSingleton<string>(builder.Configuration["awsAccessKeyId"]);

Logger.LoggerFactory.AddConfiguration(builder.Configuration);

builder.Services.AddSingleton(new EventConsumer(Logger.LoggerFactory.GetLoggerAsync()));

EventConsumer.Setup();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
