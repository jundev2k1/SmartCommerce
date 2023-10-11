#nullable disable
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

[Table("Brand")]
public partial class Brand
{
    [Key]
    [StringLength(20)]
    public string BranchID { get; set; }

    [StringLength(255)]
    public string Avatar { get; set; }

    [Required]
    [StringLength(30)]
    public string BrandName { get; set; }

    [Required]
    public bool? Status { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? LastChanged { get; set; }
}