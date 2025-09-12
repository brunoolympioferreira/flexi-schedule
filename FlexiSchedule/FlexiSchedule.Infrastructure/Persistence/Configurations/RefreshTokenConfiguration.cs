namespace FlexiSchedule.Infrastructure.Persistence.Configurations;
public class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
{
    public void Configure(EntityTypeBuilder<RefreshToken> builder)
    {
        builder.HasKey(r => r.Id);

        builder.Property(r => r.Token).HasMaxLength(500);

        builder.HasOne(p => p.Professional)
            .WithMany(p => p.RefreshTokens)
            .HasForeignKey(r => r.ProfessionalId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
