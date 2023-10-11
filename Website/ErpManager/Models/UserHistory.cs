#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ErpManager.Web.Models;

[Table("UserHistory")]
public partial class UserHistory
{
    [StringLength(20)]
    public string BranchID { get; set; }

    [Key]
    public int UserHistoryID { get; set; }

    [Required]
    [StringLength(30)]
    public string UserName { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedDate { get; set; }

    [ForeignKey("UserName")]
    [InverseProperty("UserHistories")]
    public virtual User UserNameNavigation { get; set; }
}