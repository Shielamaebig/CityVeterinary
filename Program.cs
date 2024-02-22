using CityVeterinary.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSwaggerGen(c => c.SwaggerDoc("v2", new OpenApiInfo { Title = "CityVeterinary", Version = "v2" }));
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddDbContext<ApplicationDataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ApplicationDbConection"));
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.Use((context, next) =>
{
    var token = context.Request.Cookies["Auth"];
    if (!string.IsNullOrEmpty(token))
    {
        context.Request.Headers.Append("Authorization", "Bearer " + token);
    }
    return next(context);
});

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v2/swagger.json", "CityVeterinary");
});
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
