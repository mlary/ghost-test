using System.ComponentModel.DataAnnotations;

namespace GhostProject.App.Core.Common;

public class BaseEntityDto<TKey>
{
    [Required]
    public TKey Id { get; set; }
}
