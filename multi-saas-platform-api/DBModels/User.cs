using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace multi_saas_platform_api.DBModels;

[Table("users")]
[Index("Uuid", Name = "UUID", IsUnique = true)]
[Index("BusinessId", Name = "idx_business_user")]
[Index("Status", Name = "idx_user_status")]
[Index("BusinessId", "Email", Name = "uq_company_email", IsUnique = true)]
public partial class User
{
    [Key]
    public long Id { get; set; }

    [Column("UUID")]
    public Guid Uuid { get; set; }

    public long BusinessId { get; set; }

    [Column("First_name")]
    [StringLength(100)]
    public string FirstName { get; set; } = null!;

    [Column("Last_name")]
    [StringLength(100)]
    public string? LastName { get; set; }

    public string Email { get; set; } = null!;

    [StringLength(30)]
    public string? Phone { get; set; }

    [Column("Password_hash")]
    [StringLength(255)]
    public string PasswordHash { get; set; } = null!;

    /// <summary>
    /// 1=Active, 0=Inactive
    /// </summary>
    public bool? Status { get; set; }

    [Column("Last_login_at", TypeName = "datetime")]
    public DateTime? LastLoginAt { get; set; }

    [Column("Created_at", TypeName = "timestamp")]
    public DateTime? CreatedAt { get; set; }

    [Column("Updated_at", TypeName = "timestamp")]
    public DateTime? UpdatedAt { get; set; }

    [ForeignKey("BusinessId")]
    [InverseProperty("Users")]
    public virtual Business Business { get; set; } = null!;
}
