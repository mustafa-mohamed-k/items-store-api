using ItemStore.Data;
using ItemStore.Service;
using ItemStoreAPI.Mappings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// mappers
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddAutoMapper(typeof(ItemProfile));

// create singleton for itemsrepository because we are using an in-memory data store (list of items)
builder.Services.AddSingleton<IItemsRepository, ItemsRepository>();

builder.Services.AddScoped<IItemsService, ItemsService>();

// controllers
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
