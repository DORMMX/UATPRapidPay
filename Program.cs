using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Services;
using System.Text;
using UATPRapidPay.Authentication;

var builder = WebApplication.CreateBuilder(args);
var configuration = new ConfigurationBuilder().
    AddJsonFile("appsettings.json")    
    .Build();

var secretKey = Encoding.ASCII.GetBytes(
                configuration.GetValue<string>("SecretKey")
            );

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddSingleton<ICardRepository, CardRepository>();
builder.Services.AddSingleton<ITransactionRepositoy, TransactionRepositoy>();
builder.Services.AddSingleton<IBalanceRepository, BalanceRepository>();
builder.Services.AddSingleton<IUserRepository, UserRepository>();
builder.Services.AddSingleton<IJwtFactory, JwtFactory>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(secretKey),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAuthorization();
var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseAuthorization();
app.UseAuthentication();
app.MapControllers();

app.Run();