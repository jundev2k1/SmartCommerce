using ErpManager.Web;
using Persistence;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddApplication(builder.Configuration);
    builder.Services.AddPersistence();
}

var app = builder.Build();
app.Configure();
app.Run();
