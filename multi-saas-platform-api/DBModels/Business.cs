using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace multi_saas_platform_api.DBModels;

[Table("business")]
[Index("BusinessCode", Name = "BusinessCode", IsUnique = true)]
public partial class Business
{
    [Key]
    public long BusinessId { get; set; }

    [StringLength(255)]
    public string BusinessName { get; set; } = null!;

    [StringLength(100)]
    public string BusinessCode { get; set; } = null!;

    [StringLength(255)]
    public string? BusinessEmail { get; set; }

    [StringLength(50)]
    public string? BusinessPhone { get; set; }

    [Column(TypeName = "text")]
    public string? BusinessAddress { get; set; }

    [Column("GSTNumber")]
    [StringLength(100)]
    public string? Gstnumber { get; set; }

    [Column("CINNumber")]
    [StringLength(100)]
    public string? Cinnumber { get; set; }

    public bool? IsActive { get; set; }

    [Column(TypeName = "timestamp")]
    public DateTime? CreatedAt { get; set; }

    [Column(TypeName = "timestamp")]
    public DateTime? UpdatedAt { get; set; }

    [InverseProperty("Business")]
    public virtual ICollection<Businesslicense> Businesslicenses { get; set; } = new List<Businesslicense>();

    [InverseProperty("Business")]
    public virtual ICollection<Businessproduct> Businessproducts { get; set; } = new List<Businessproduct>();

    [InverseProperty("Business")]
    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
