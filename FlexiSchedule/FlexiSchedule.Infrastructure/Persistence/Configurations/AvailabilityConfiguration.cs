using FlexiSchedule.Domain.Enums;

namespace FlexiSchedule.Infrastructure.Persistence.Configurations;
public class AvailabilityConfiguration : IEntityTypeConfiguration<Availability>
{
    public void Configure(EntityTypeBuilder<Availability> builder)
    {
        builder.ToTable("Availabilities");

        builder.HasKey(a => a.Id);

        builder.Property(a => a.WeekDay)
            .IsRequired()
            .HasConversion(
                v => v.ToString(),
                v => (WeekDayEnum)Enum.Parse(typeof(WeekDayEnum), v))
            .HasMaxLength(20);

        builder.Property(a => a.StartTime)
            .HasConversion(
                v => v.ToTimeSpan(),
                v => TimeOnly.FromTimeSpan(v))
            .IsRequired();

        builder.Property(a => a.EndTime)
            .HasConversion(
                v => v.ToTimeSpan(),
                v => TimeOnly.FromTimeSpan(v))
            .IsRequired();

        builder.Property(a => a.DateRangeStart)
            .HasConversion(
                v => v.ToDateTime(TimeOnly.MinValue),
                v => DateOnly.FromDateTime(v))
            .IsRequired();

        builder.Property(a => a.DateRangeEnd)
            .HasConversion(
                v => v.ToDateTime(TimeOnly.MinValue),
                v => DateOnly.FromDateTime(v))
            .IsRequired();

        builder.Property(a => a.IsClosed)
            .IsRequired();

        builder.Property(a => a.ProfessionalId)
            .IsRequired();

        builder.HasOne<Professional>()
            .WithMany(p => p.Availabilities)
            .HasForeignKey(a => a.ProfessionalId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
