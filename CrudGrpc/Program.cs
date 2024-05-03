using CrudGrpc.Services;
using CrudGrpc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// строка подключения
string connStr = "Server=(localdb)\\mssqllocaldb;Database=grpcdb;Trusted_Connection=True;";
// добавляем контекст ApplicationContext в качестве сервиса в приложение
builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connStr));
builder.Services.AddGrpc();

var app = builder.Build();


app.MapGrpcService<UserApiService>();
app.MapGet("/", () => "Hello METANIT.COM");

app.Run();