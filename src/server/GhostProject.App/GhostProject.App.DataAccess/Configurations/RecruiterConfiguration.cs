using GhostProject.App.Core.Business.Recruiters.Entities;
using GhostProject.App.DataAccess.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GhostProject.App.DataAccess.Configurations;

public class RecruiterConfiguration : BaseConfiguration<Recruiter, int>, IEntityTypeConfiguration<Recruiter>
{
    public override void Configure(EntityTypeBuilder<Recruiter> builder)
    {
        base.Configure(builder);

        builder.HasMany(x => x.Rates)
            .WithOne(x => x.Recruiter);

        builder.HasIndex(x => x.LinkedInUrl).IsUnique();

        builder.HasOne(x => x.Company)
            .WithMany(x => x.Recruiters)
            .HasForeignKey(x => x.CompanyId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.SetNull);
    }
}
