using Microsoft.AspNetCore.Authentication;
using Services;
using UATPRapidPay.Authentication;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddSingleton<ICardRepository, CardRepository>();
builder.Services.AddSingleton<ITransactionRepositoy, TransactionRepositoy>();
builder.Services.AddSingleton<IBalanceRepository, BalanceRepository>();
builder.Services.AddSingleton<IUserRepository, UserRepository>();
builder.Services.AddAuthentication("BasicAuthentication")
                .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>
                ("BasicAuthentication", null);
builder.Services.AddAuthorization();
var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseAuthorization();
app.UseAuthentication();
app.MapControllers();
app.Run();