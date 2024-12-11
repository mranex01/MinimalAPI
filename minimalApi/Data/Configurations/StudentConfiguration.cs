using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using minimalApi.Data.Model;

namespace minimalApi.Data.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Students");

            builder.HasKey(e => e.studentId);

            builder.Property(e => e.studentName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.studentClass)
                .IsRequired();

        }
    }
}
