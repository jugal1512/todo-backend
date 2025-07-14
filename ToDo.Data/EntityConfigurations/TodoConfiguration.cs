using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDo.Domain.Todos;

namespace ToDo.Data.EntityConfigurations
{
    public class TodoConfiguration : IEntityTypeConfiguration<Todo>
    {
        public void Configure(EntityTypeBuilder<Todo> builder)
        {
            builder.ToTable("Todos");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title)
                .HasColumnType("varchar(100)")
                .IsRequired(true);

            builder.Property(x => x.Description)
                .HasColumnType("varchar(500)")
                .IsRequired(false);

            builder.Property(x => x.StartDate)
                .HasColumnType("datetime2")
                .IsRequired(true);

            builder.Property(x => x.EndDate)
                .HasColumnType("datetime2")
                .IsRequired(true);

            builder.Property(x => x.IsCompleted)
                .HasColumnType("bit")
                .HasDefaultValue(false)
                .IsRequired(true);

            builder.Property(x => x.IsDelete)
                .HasColumnType("bit")
                .HasDefaultValue(false)
                .IsRequired(true);

            builder.Property(x => x.CreatedAtUtc)
                .HasColumnType("datetime2")
                .IsRequired(true);

            builder.Property(x => x.UpdatedAtUtc)
                .HasColumnType("datetime2")
                .IsRequired(false);
        }
    }
}
