#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ErpManager.Web.Models;

[Table("User")]
public partial class User
{
    [StringLength(20)]
    public string BranchID { get; set; }

    [Key]
    [StringLength(30)]
    public string UserName { get; set; }

    [Required]
    [StringLength(30)]
    public string Password { get; set; }

    [StringLength(255)]
    public string Avatar { get; set; }

    [StringLength(30)]
    public string FirstName { get; set; }

    [StringLength(30)]
    public string LastName { get; set; }

    [StringLength(60)]
    public string FullName { get; set; }

    [StringLength(255)]
    public string Address1 { get; set; }

    [StringLength(255)]
    public string Address2 { get; set; }

    public bool? Status { get; set; }

    [StringLength(30)]
    public string Phone { get; set; }

    [StringLength(50)]
    public string Email { get; set; }

    public int? Sex { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? Birthday { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateCreated { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateChanged { get; set; }

    [StringLength(30)]
    public string CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? LastLogin { get; set; }

    [StringLength(255)]
    public string LoginSession { get; set; }

    public int? UserCateID { get; set; }

    [ForeignKey("UserCateID")]
    [InverseProperty("Users")]
    public virtual UserCategory UserCate { get; set; }

    [InverseProperty("UserNameNavigation")]
    public virtual ICollection<UserHistory> UserHistories { get; set; } = new List<UserHistory>();
}