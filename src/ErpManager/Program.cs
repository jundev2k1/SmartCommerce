// Copyright (c) 2024 - Jun Dev. All rights reserved

using ErpManager.ERP;
using ErpManager.Infrastructure;
using ErpManager.Persistence;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddApplication(builder.Configuration)
        .AddPersistence()
        .AddInfrastructure();
}

var app = builder.Build();
{
    app.Configure();
    app.UserApplicationMiddleware();
    app.UseInfrastructureMiddleware();
}

app.Run();
