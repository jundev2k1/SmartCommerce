#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ErpManager.Web.Models;

[Table("UserCategory")]
public partial class UserCategory
{
    [StringLength(20)]
    public string BranchID { get; set; }

    [Key]
    public int UserCateID { get; set; }

    [Required]
    [StringLength(50)]
    public string Name { get; set; }

    public int? Priority { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateCreated { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateChanged { get; set; }

    [StringLength(30)]
    public string ChangedBy { get; set; }

    [StringLength(30)]
    public string CreatedBy { get; set; }

    public bool? Status { get; set; }

    public int? PermissionId { get; set; }

    [ForeignKey("PermissionId")]
    [InverseProperty("UserCategories")]
    public virtual Permission Permission { get; set; }

    [InverseProperty("UserCate")]
    public virtual ICollection<User> Users { get; set; } = new List<User>();
}