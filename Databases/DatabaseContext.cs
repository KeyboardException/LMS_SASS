using LMS_SASS.Models;
using Microsoft.EntityFrameworkCore;

namespace LMS_SASS.Databases;

public class DatabaseContext : DbContext {

	public DbSet<UserModel> Users { get; set; }

	public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
		
    }
}
