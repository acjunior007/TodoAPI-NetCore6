using Microsoft.EntityFrameworkCore;
using TodoListAPI.Domain.Models;

namespace TodoListAPI.Infra.Context
{
	public class DBTodoAPPContext : DbContext
	{
		public DBTodoAPPContext(DbContextOptions<DBTodoAPPContext> options) : base(options) { }

		public DbSet<Notes> Notes { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(DBTodoAPPContext).Assembly);

			modelBuilder.Entity<Notes>().HasData(new Notes
			{
				Id = 1,
				Description = $"Description_{DateTime.Now.Second}_01",
			});

			modelBuilder.Entity<Notes>().HasData(new Notes
			{
				Id = 2,
				Description = $"Description_{DateTime.Now.Second}_02",
			});

			modelBuilder.Entity<Notes>().HasData(new Notes
			{
				Id = 3,
				Description = $"Description_{DateTime.Now.Second}_03",
			});

			modelBuilder.Entity<Notes>().HasData(new Notes
			{
				Id = 4,
				Description = $"Description_{DateTime.Now.Second}_04",
			});

			modelBuilder.Entity<Notes>().HasData(new Notes
			{
				Id = 5,
				Description = $"Description_{DateTime.Now.Second}_05",
			});
		}
	}
}
