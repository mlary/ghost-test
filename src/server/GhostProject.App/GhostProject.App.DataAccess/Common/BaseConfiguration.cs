using GhostProject.App.Core.Common;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GhostProject.App.DataAccess.Common
{
    public abstract class BaseConfiguration<T, TKey> where T : BaseEntity<TKey>
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(e => e.Id);
        }
    }
}
