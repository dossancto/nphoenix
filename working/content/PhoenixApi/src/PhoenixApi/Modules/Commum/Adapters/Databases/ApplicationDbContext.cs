using Microsoft.EntityFrameworkCore;

using PhoenixApi.Modules.Todos.Models;

namespace PhoenixApi.Modules.Commum.Adapters.Databases;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<TodoModel> Todos { get; set; } = null!;
}