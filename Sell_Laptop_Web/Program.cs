var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllersWithViews();
//builder.Services.AddTransient<IRamServices, RamServices>();// Add DI
//builder.Services.AddTransient<IBillServices, BillServices>();
//builder.Services.AddTransient<IBillDetailServices, BillDetailServices>();
//builder.Services.AddTransient<ICartServices, CartServices>();
//builder.Services.AddTransient<ICartDetailServices, CartDetailServices>();
//builder.Services.AddTransient<IProductDetailServices, ProductDetailServices>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication(); ;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
