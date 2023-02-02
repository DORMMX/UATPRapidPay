using Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddSingleton<ICardRepository, CardRepository>();
builder.Services.AddSingleton<ITransactionRepositoy, TransactionRepositoy>();
builder.Services.AddSingleton<IBalanceRepository, BalanceRepository>();

var app = builder.Build();
// Configure the HTTP request pipeline.
app.UseAuthorization();
app.MapControllers();
app.Run();