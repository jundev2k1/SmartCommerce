// Copyright (c) 2024 - Jun Dev. All rights reserved

using ErpManager.ERP;
using ErpManager.Infrastructure;
using ErpManager.Persistence;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddPersistence()
        .AddInfrastructure()
        .AddApplication(builder.Configuration);
}

var app = builder.Build();
{
    app.Configure();
    app.UseApplicationMiddleware();
    app.UseInfrastructureMiddleware();
}

app.Run();
