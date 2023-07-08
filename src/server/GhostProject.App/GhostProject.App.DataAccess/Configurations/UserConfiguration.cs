using GhostProject.App.Core.Business.Users.Entities;
using GhostProject.App.DataAccess.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GhostProject.App.DataAccess.Configurations;

public class UserConfiguration: BaseConfiguration<User, int>, IEntityTypeConfiguration<User>
{
    public override void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(x => x.Email).IsRequired();
        builder.Property(x => x.NormalizedEmail).IsRequired();
        builder.Property(x => x.LastName).IsRequired();
        builder.Property(x => x.FirstName).IsRequired();
        builder.Property(x => x.PasswordHash).IsRequired();
        builder.Property(x => x.PasswordHash).IsRequired();
        builder.HasIndex(x => x.Email).IsUnique();
        builder.HasIndex(x => x.NormalizedEmail).IsUnique();
        base.Configure(builder);
    }
}
