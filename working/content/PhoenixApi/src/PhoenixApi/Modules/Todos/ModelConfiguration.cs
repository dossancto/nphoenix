using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using PhoenixApi.Modules.Todos.Models;

namespace PhoenixApi.Modules.Todos;

public class ModelConfiguration : IEntityTypeConfiguration<TodoModel>
{
    public void Configure(EntityTypeBuilder<TodoModel> builder)
    {
        builder.ToTable("Todos");

        builder.HasKey(t => t.Id);

        builder.Property(t => t.Title)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(t => t.Description)
            .HasMaxLength(1024);

        builder.Property(t => t.DueDate);

        builder.Property(t => t.IsCompleted)
            .HasDefaultValue(false);
    }
}