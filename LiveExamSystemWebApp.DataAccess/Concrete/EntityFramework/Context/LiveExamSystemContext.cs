using LiveExamSystemWebApp.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using LiveExamSystemWebApp.Core.Utilities.Security.Hashing;

namespace LiveExamSystemWebApp.DataAccess.Concrete.EntityFramework.Context;

public class LiveExamSystemContext : DbContext
{
	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		const string ConnectDeveloper = "server=localhost;port=3306;database=LiveExamSystemDb;user=root;password=matehujin12;Charset=utf8;";
		// const string ConnetProduct = "server=localhost;port=3306;database=LiveExamSystemDb;user=LiveExamSystem;password=L8o4mc6^;Charset=utf8;";
		optionsBuilder.UseLazyLoadingProxies()
			.UseMySql(ConnectDeveloper, ServerVersion.AutoDetect(ConnectDeveloper))
			.EnableSensitiveDataLogging()
			.ConfigureWarnings(warnings =>
			{
				warnings.Ignore(CoreEventId.LazyLoadOnDisposedContextWarning);
			});
	}
	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		var admin = new AppUser()
		{
			Id = 1,
			FirstName = "Admin",
			LastName = "Admin",
			Email = "admin@admin.com",
			Token = "",
			IsActived = true,
			Role = "Admin"
		};
		admin.PasswordHash = HashingHelper.CreatePasswordHashOld("Admin123", admin.SecretKey);
		modelBuilder.Entity<AppUser>().HasData(admin);
		base.OnModelCreating(modelBuilder);
	}

	public DbSet<Answer> Answers { get; set; }
	public DbSet<AppConfig> AppConfigs { get; set; }
	public DbSet<AppSeo> AppSeos { get; set; }
	public DbSet<AppUser> AppUsers { get; set; }
	public DbSet<Category> Categories { get; set; }
	public DbSet<Document> Documents { get; set; }
	public DbSet<Exam> Exams { get; set; }
	public DbSet<Letter> Letters { get; set; }
	public DbSet<Question> Questions { get; set; }	
}
