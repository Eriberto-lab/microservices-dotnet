using GeekShooping.Web.Services.IServices;

var builder = WebApplication.CreateBuilder(args);

#pragma warning disable CS8604 // Poss�vel argumento de refer�ncia nula.
builder.Services.AddHttpClient<IProductService, ProductService>(
    c => c.BaseAddress = new Uri(builder.Configuration["ServiceUrls:ProductAPI"])
);
#pragma warning restore CS8604 // Poss�vel argumento de refer�ncia nula.

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
