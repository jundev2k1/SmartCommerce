#nullable disable
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

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