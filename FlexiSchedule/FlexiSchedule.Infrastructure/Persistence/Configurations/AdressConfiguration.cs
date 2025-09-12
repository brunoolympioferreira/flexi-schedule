namespace FlexiSchedule.Infrastructure.Persistence.Configurations;
public class AdressConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.HasKey(a => a.Id);

        builder.Property(a => a.Street)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(a => a.Number)
            .IsRequired();

        builder.Property(a => a.District)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(a => a.City)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(a => a.State)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(a => a.Country)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(a => a.ZipCode)
            .IsRequired()
            .HasMaxLength(20);

        builder.Property(a => a.Complement)
            .HasMaxLength(100);

        builder.HasOne<Client>()
            .WithMany(c => c.Addresses)
            .HasForeignKey(a => a.ClientId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
    }
}
