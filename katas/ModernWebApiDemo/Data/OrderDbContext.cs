namespace ModernWebApiDemo.Data;

using Microsoft.EntityFrameworkCore;
using ModernWebApiDemo.Models;

public class OrderDbContext(DbContextOptions<OrderDbContext> options) : DbContext(options)
{
    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<Lens> Lenses => Set<Lens>();
    public DbSet<Order> Orders => Set<Order>();
    public DbSet<OrderItem> OrderItems => Set<OrderItem>();
}