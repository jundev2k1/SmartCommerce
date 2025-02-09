// Copyright (c) 2024 - Jun Dev. All rights reserved

using SmartCommerce.Infrastructure;
using SmartCommerce.Persistence;
using SmartCommerce.WebAPI;

var builder = WebApplication.CreateBuilder(args);
builder.Services
	.AddPersistence()
	.AddInfrastructure()
	.AddApplication(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.Configure();
app.UseCors("AllowSpecificOrigin");
app.UseAuthorization();
app.Run();
