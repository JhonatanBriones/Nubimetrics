using Challenge.Infrastructure.Extensions;
using Challenge.Infrastructure.Middlewares;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddNewtonsoftJson(option =>
{
    option.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwagger();
builder.Services.AddAllowAllHeadersCors();
builder.Services.AddOptions(builder.Configuration);
builder.Services.AddDbContexts(builder.Configuration);
builder.Services.AddAppServices(builder.Configuration);

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseGlobalFormatResponse();

app.UseMiddleware<GlobalException>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
