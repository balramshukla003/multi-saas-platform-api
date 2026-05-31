using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace multi_saas_platform_api.DBModels;

[Table("masterproducts")]
[Index("ProductCode", Name = "ProductCode", IsUnique = true)]
public partial class Masterproduct
{
    [Key]
    public long ProductId { get; set; }

    [StringLength(200)]
    public string ProductName { get; set; } = null!;

    [StringLength(100)]
    public string ProductCode { get; set; } = null!;

    [Column(TypeName = "text")]
    public string? Description { get; set; }

    public bool? IsActive { get; set; }

    [Column(TypeName = "timestamp")]
    public DateTime? CreatedAt { get; set; }

    [InverseProperty("Product")]
    public virtual ICollection<Businesslicense> Businesslicenses { get; set; } = new List<Businesslicense>();

    [InverseProperty("Product")]
    public virtual ICollection<Businessproduct> Businessproducts { get; set; } = new List<Businessproduct>();
}
