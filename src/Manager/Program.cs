// Copyright (c) 2024 - Jun Dev. All rights reserved

using SmartCommerce.Manager;
using SmartCommerce.Infrastructure;
using SmartCommerce.Persistence;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
{
	builder.Services
		.AddPersistence()
		.AddInfrastructure()
		.AddApplication(builder.Configuration);
	builder.Host.UseSerilog();
}

var app = builder.Build();
{
	app.Configure();
	app.UseInfrastructure();
	app.UsePersistence();
}

app.Run();
