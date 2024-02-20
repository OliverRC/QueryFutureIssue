using AspireApp1.ApiService.Entities;
using Microsoft.EntityFrameworkCore;

namespace AspireApp1.ApiService;

public class AppDbContext(DbContextOptions<AppDbContext> options): DbContext(options)
{
     public DbSet<Person> People => Set<Person>();
}