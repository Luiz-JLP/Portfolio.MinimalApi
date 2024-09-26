using Entities;
using Microsoft.EntityFrameworkCore;

namespace Repositories.Context;

public class InMemoryContext(DbContextOptions<InMemoryContext> options) : DbContext(options)
{
    public DbSet<Administrator> Administrators { get; set; }

    public DbSet<Vehicle> Vehicles { get; set; }
}
