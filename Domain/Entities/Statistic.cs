#nullable disable
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public partial class Statistic
{
    [StringLength(20)]
    public string BranchID { get; set; }

    [Key]
    public int StatisticID { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? StatisticDate { get; set; }

    public long? AccessStatistic { get; set; }

    public long? UserStatistic { get; set; }

    public long? ProductStatistic { get; set; }
}