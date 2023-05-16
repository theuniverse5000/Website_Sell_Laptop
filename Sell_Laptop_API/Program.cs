using Data.Services.Implements;
using Data.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
//    builder.Configuration.GetConnectionString("DefaultConnection")
//    ));

builder.Services.AddControllers();
builder.Services.AddTransient<IRamServices, RamServices>();// Add DI
builder.Services.AddTransient<IBillServices, BillServices>();
builder.Services.AddTransient<IBillDetailServices, BillDetailServices>();
builder.Services.AddTransient<ICartServices, CartServices>();
builder.Services.AddTransient<ICartDetailServices, CartDetailServices>();
builder.Services.AddTransient<IProductDetailServices, ProductDetailServices>();

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
