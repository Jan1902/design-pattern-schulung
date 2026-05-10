using Microsoft.EntityFrameworkCore;
using ModernWebApiDemo;
using ModernWebApiDemo.Data;
using ModernWebApiDemo.Filters;
using ModernWebApiDemo.Middleware;
using ModernWebApiDemo.Services.Clock;
using ModernWebApiDemo.Services.Customers;
using ModernWebApiDemo.Services.Orders;
using ModernWebApiDemo.Services.Pricing;

var builder = WebApplication.CreateBuilder(args);

// Standard-Services
builder.Services.AddControllers(options =>
{
    options.Filters.Add<ExecutionTimingFilter>();
});

builder.Services.AddDbContext<OrderDbContext>(options =>
    options.UseInMemoryDatabase("lensforge-orders"));

// Singleton: eine Instanz für die gesamte App-Laufzeit
builder.Services.AddSingleton<IClock, SystemClock>();

// Scoped: pro HTTP-Request eine Instanz
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();

// Strategy via DI: alle Implementierungen werden gesammelt registriert.
// Wer IEnumerable<IPricingStrategy> injiziert bekommt, erhält alle drei.
builder.Services.AddScoped<IPricingStrategy, StandardPricing>();
builder.Services.AddScoped<IPricingStrategy, BulkDiscountPricing>();
builder.Services.AddScoped<IPricingStrategy, PremiumCustomerPricing>();

// Observer via DI: gleiches Prinzip für Event-Handler
//builder.Services.AddScoped<IOrderEventHandler, EmailOrderNotifier>();
//builder.Services.AddScoped<IOrderEventHandler, SlackOrderNotifier>();
//builder.Services.AddScoped<IOrderEventHandler, AuditLogNotifier>();
builder.Services.AddOrderEventHandlersFromAssembly(typeof(Program));

var app = builder.Build();

// Chain of Responsibility: Middleware-Pipeline
app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseMiddleware<RequestLoggingMiddleware>();
app.MapControllers();

// Datenbank mit Demo-Daten füllen
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<OrderDbContext>();
    DbSeeder.Seed(db);
}

app.Run();
