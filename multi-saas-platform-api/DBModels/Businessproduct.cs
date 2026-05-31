using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace multi_saas_platform_api.DBModels;

[Table("businessproducts")]
[Index("BusinessId", Name = "BusinessId")]
[Index("ProductId", Name = "ProductId")]
public partial class Businessproduct
{
    [Key]
    public long BusinessProductId { get; set; }

    public long BusinessId { get; set; }

    public long ProductId { get; set; }

    public bool? IsActive { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ActivatedOn { get; set; }

    [ForeignKey("BusinessId")]
    [InverseProperty("Businessproducts")]
    public virtual Business Business { get; set; } = null!;

    [ForeignKey("ProductId")]
    [InverseProperty("Businessproducts")]
    public virtual Masterproduct Product { get; set; } = null!;
}
