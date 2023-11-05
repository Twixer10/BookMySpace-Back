// <copyright file="Program.cs" company="Équipe 4 - BENEY, DESRAYAUD, TANQUEREL, TECHER, TANIERE">
// Copyright (c) Équipe 4 - BENEY, DESRAYAUD, TANQUEREL, TECHER, TANIERE. All rights reserved.
// </copyright>

using BookMySpace.Repository;
using BookMySpace.Repository.Contracts;
using BookMySpace.Services;
using BookMySpace.Services.Contracts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Dependencies injection
builder.Services.AddScoped<ISpaceService, SpaceService>();
builder.Services.AddScoped<ISpaceRepository, AdoSpaceRepository>();

builder.Services.AddScoped<IBookingService, BookingService>(); 
builder.Services.AddScoped<IBookingRepository, AdoBookingRepository>();

builder.Services.AddScoped<IOptionService, OptionService>();
builder.Services.AddScoped<IOptionRepository, AdoOptionRepository>();

builder.Services.AddScoped<ITypeSpaceRepository, AdoTypeSpaceRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();