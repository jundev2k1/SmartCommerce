// Copyright (c) 2024 - Jun Dev. All rights reserved

using Serilog;
using SmartCommerce.Infrastructure;
using SmartCommerce.Manager;
using SmartCommerce.Persistence;

var builder = WebApplication.CreateBuilder(args);
{
	Constants.CONST_PROJECT_NAME = Assembly.GetEntryAssembly()?.GetName().Name ?? "Default";
	Constants.CONST_RESOURCE_PHYSICAL_PATH = Path.Combine(Directory.GetCurrentDirectory(), "../Common/Resource");

	// Set config from Resource
	var configPath = Constants.CONST_RESOURCE_PHYSICAL_PATH + "/Configs";
	builder.Configuration.SetBasePath(configPath)
		.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
		.AddJsonFile($"overrides/{Constants.CONST_PROJECT_NAME}.json", optional: true, reloadOnChange: true)
		.AddEnvironmentVariables();

	// Add services
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
