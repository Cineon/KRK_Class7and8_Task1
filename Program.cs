using KRK_Class7_Task1.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Connecting Database service to this project
builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseSqlServer(   // Choosing DB
        builder.Configuration.GetConnectionString("MyConnectString") // Defining connection string to DB
    )
    .LogTo(Console.WriteLine)   // DB logs will appear on my project terminal.
    .EnableSensitiveDataLogging()   // More information that will appear on terminal.
);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

CreateDbIfNotExist(app);    // Calling method from the bottom.

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();


// Adding instance of DbInitializer from MyDbContext service.
// To create DB even if it doesn't exist.
static void CreateDbIfNotExist(IHost host)
{
    using (var scope = host.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        try
        {
            var context = services.GetRequiredService<MyDbContext>();
            DbInitializer.Initialize(context);
        }
        catch (Exception ex)
        {
            var logger = services.GetRequiredService<ILogger<Program>>();
            logger.LogError(ex, "An error occures while creating the DB");
        }
    }
}