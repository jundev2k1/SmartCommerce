// Copyright (c) 2024 - Jun Dev. All rights reserved

using ErpManager.ERP;
using ErpManager.Infrastructure;
using ErpManager.Persistence;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
{
	builder.Services
		.AddPersistence()
		.AddInfrastructure()
		.AddApplication(builder.Configuration);
	builder.Host.UseSerilog((context, configuration) =>
		configuration.ReadFrom.Configuration(context.Configuration));
}

var app = builder.Build();
{
	app.Configure();
	app.UseInfrastructure();
	app.UsePersistence();
}

app.Run();
