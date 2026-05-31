using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace multi_saas_platform_api.DBModels;

[Table("masterroles")]
public partial class Masterrole
{
    [Key]
    public long RoleId { get; set; }

    [StringLength(100)]
    public string RoleName { get; set; } = null!;

    public bool? IsActive { get; set; }

    [Column(TypeName = "timestamp")]
    public DateTime? CreatedAt { get; set; }
}
