using ErpManager.Web;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddApplication(builder.Configuration);
    builder.Services.AddInfrastructure();
}

var app = builder.Build();
app.Configure();
app.Run();
