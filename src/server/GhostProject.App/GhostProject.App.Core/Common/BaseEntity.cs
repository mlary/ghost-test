using System.ComponentModel.DataAnnotations;

namespace GhostProject.App.Core.Common;

/// <summary>
/// Describes entity id
/// </summary>
/// <typeparam name="TKey">Id type</typeparam>
public abstract class BaseEntity<TKey>
{
    /// <summary>
    /// Id of the entity
    /// </summary>
    [Key]
    public TKey Id { get; set; }
}
