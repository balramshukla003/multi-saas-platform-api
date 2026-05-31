using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace multi_saas_platform_api.DBModels;

[Table("businesslicenses")]
[Index("BusinessId", Name = "BusinessId")]
[Index("LicenseKey", Name = "LicenseKey", IsUnique = true)]
[Index("ProductId", Name = "ProductId")]
public partial class Businesslicense
{
    [Key]
    public long LicenseId { get; set; }

    public long BusinessId { get; set; }

    public long ProductId { get; set; }

    public string? LicenseKey { get; set; }

    [StringLength(100)]
    public string? PlanName { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? StartDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ExpiryDate { get; set; }

    public int? MaxUsers { get; set; }

    public int? MaxBranches { get; set; }

    public bool? IsActive { get; set; }

    [Column(TypeName = "timestamp")]
    public DateTime? CreatedAt { get; set; }

    [ForeignKey("BusinessId")]
    [InverseProperty("Businesslicenses")]
    public virtual Business Business { get; set; } = null!;

    [ForeignKey("ProductId")]
    [InverseProperty("Businesslicenses")]
    public virtual Masterproduct Product { get; set; } = null!;
}
