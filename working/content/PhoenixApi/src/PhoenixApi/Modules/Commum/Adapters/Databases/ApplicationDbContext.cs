using Microsoft.EntityFrameworkCore;

namespace PhoenixApi.Modules.Commum.Adapters.Databases;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
}