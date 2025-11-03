using CafremaApp.Infrastructure;
using CafremaApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

// 1. Supabase client (Auth/Realtime)
builder.Services.AddSupabaseInfrastructure(
    builder.Configuration["Supabase:Url"],
    builder.Configuration["Supabase:Key"]
);

// 2. EF Core DbContext
builder.Services.AddDbContext<Context>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
