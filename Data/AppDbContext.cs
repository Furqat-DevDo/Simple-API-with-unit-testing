using Lesson1.Models;
using Microsoft.EntityFrameworkCore;

namespace Lesson1.Data;
public class AppDbContext:DbContext
{
    public DbSet<User> Users { get; set;}
    public AppDbContext(DbContextOptions<AppDbContext> options)
    :base(options){ } 
}