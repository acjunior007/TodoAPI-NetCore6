using Microsoft.EntityFrameworkCore;
using TodoAPI.Domain.Models;

namespace TodoAPI.Infra.Context
{
    public class DBTodoAPPContext : DbContext
    {
        public DBTodoAPPContext(DbContextOptions<DBTodoAPPContext> options) : base(options) { }

        public DbSet<Notes> Notes { get; set; }
    }
}
