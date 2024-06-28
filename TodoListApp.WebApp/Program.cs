using Microsoft.EntityFrameworkCore;
using TodoListApp.Application.Interfaces;
using TodoListApp.Application.Services;
using TodoListApp.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews().AddNewtonsoftJson();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<ITodoListService, TodoListService>();
builder.Services.AddScoped<ITodoItemService, TodoItemService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=TodoList}/{action=Index}/{id?}");

app.Run();
