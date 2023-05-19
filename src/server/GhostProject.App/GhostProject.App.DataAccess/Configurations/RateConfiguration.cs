using GhostProject.App.Core.Business.Rates.Entities;
using GhostProject.App.DataAccess.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GhostProject.App.DataAccess.Configurations;

public class RateConfiguration : BaseConfiguration<Rate, int>, IEntityTypeConfiguration<Rate>
{
    public override void Configure(EntityTypeBuilder<Rate> builder)
    {
        base.Configure(builder);

        builder.HasOne(x => x.Company)
            .WithMany(x => x.Rates)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(x => x.Recruiter)
            .WithMany(x => x.Rates)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
