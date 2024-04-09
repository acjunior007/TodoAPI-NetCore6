﻿using Microsoft.EntityFrameworkCore;
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
		}
	}
}
