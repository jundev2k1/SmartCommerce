// Copyright (c) 2024 - Jun Dev. All rights reserved

using ErpManager.Infrastructure;
using ErpManager.Manager;
using ErpManager.Persistence;

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
