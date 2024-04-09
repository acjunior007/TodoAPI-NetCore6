using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TodoListAPI.Domain.Models;

namespace TodoListAPI.Infra.EntitiesConfiguration
{
	internal class NotesConfiguration : IEntityTypeConfiguration<Notes>
	{
		public void Configure(EntityTypeBuilder<Notes> builder)
		{
			builder.HasKey(x => x.Id);
			builder.Property(x => x.Description).HasMaxLength(200).IsRequired();
			builder.Property(x => x.DateCreated).HasDefaultValue(DateTime.UtcNow);
			builder.Property(x => x.Active).HasDefaultValue(true);
		}
	}
}
