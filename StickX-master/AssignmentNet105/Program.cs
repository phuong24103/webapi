using AssignmentNet105_Shared.Data;
using AssignmentNet105.IServices;
using AssignmentNet105.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Add Dependencies
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IFavoriteProductsService, FavoriteProductsService>();
builder.Services.AddScoped<IColorService, ColorService>();
builder.Services.AddScoped<ISizeService, SizeService>();
builder.Services.AddScoped<IVoucherService, VoucherServices>();
builder.Services.AddScoped<IBillService, BillServices>();
builder.Services.AddScoped<IBillDetailsService,BillDetailsServices>();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<ICartDetailsService, CartDetailsService>();
builder.Services.AddScoped<IRankService, RankService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
