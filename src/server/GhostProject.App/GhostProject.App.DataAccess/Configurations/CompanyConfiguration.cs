using GhostProject.App.Core.Business.Companies.Entities;
using GhostProject.App.DataAccess.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GhostProject.App.DataAccess.Configurations;

public class CompanyConfiguration : BaseConfiguration<Company, int>, IEntityTypeConfiguration<Company>
{
    public override void Configure(EntityTypeBuilder<Company> builder)
    {
        base.Configure(builder);
        builder.HasMany(x => x.Recruiters)
            .WithOne(x => x.Company);
        

        builder.HasMany(x => x.Rates)
            .WithOne(x => x.Company)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.SetNull);
    }
}
