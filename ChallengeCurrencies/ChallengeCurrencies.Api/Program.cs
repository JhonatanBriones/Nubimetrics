using ChallengeCurrencies.Api.Interfaces;
using ChallengeCurrencies.Api.Services;
using Newtonsoft.Json;
using static ChallengeCurrencies.Api.Enum.Enum;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddNewtonsoftJson(option =>
{
    option.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
}); 

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient(nameof(Client.MercadoLibreClient), client =>
{
    client.BaseAddress = new Uri(builder.Configuration["BaseUrl"]);
});
builder.Services.AddTransient<ICurrencyService, CurrencyService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
