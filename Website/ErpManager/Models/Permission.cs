#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ErpManager.Web.Models;

[Table("Permission")]
public partial class Permission
{
    [StringLength(20)]
    public string BranchID { get; set; }

    [Key]
    public int PermissionId { get; set; }

    [Required]
    [StringLength(50)]
    public string PermissionName { get; set; }

    public string PermissionMenu { get; set; }

    public string PermissionChildMenu { get; set; }

    [StringLength(255)]
    public string PermissionDescription { get; set; }

    public int? Priority { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? StartDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? EndDate { get; set; }

    public bool? Status { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateChanged { get; set; }

    [StringLength(30)]
    public string ChangedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedDate { get; set; }

    [StringLength(30)]
    public string CreatedBy { get; set; }

    [InverseProperty("Permission")]
    public virtual ICollection<UserCategory> UserCategories { get; set; } = new List<UserCategory>();
}