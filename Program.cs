using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WorkoutCoachApp.Data; // Adjust the namespace based on your project structure
using WorkoutCoachApp.Services; // Ensure this namespace is correct

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews(); // Register MVC controllers and views

// Register your DbContext with Entity Framework
builder.Services.AddDbContext<WorkoutCoachContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Workouts"))); // Use your actual connection string

// Register your service for dependency injection
builder.Services.AddScoped<IWorkoutPlanService, WorkoutPlanService>(); // Register your workout plan service

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error"); // Custom error page for production
    app.UseHsts(); // Enable HTTP Strict Transport Security
}

app.UseHttpsRedirection(); // Redirect HTTP requests to HTTPS
app.UseStaticFiles(); // Serve static files

app.UseRouting(); // Enable routing

app.UseAuthorization(); // Enable authorization

// Configure the route for your application
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"); // Default route pattern

app.Run(); // Run the application
