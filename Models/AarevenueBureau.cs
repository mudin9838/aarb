using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace aarb.Models
{
    [Table("AARevenueBureau")]
    public partial class AarevenueBureau
    {
        public AarevenueBureau()
        {
            BranchLevels = new HashSet<BranchLevel>();
        }

        [Key]
        public int BudgetYearId { get; set; }
        [Required]
        [Column("AARevenueBureauNameAmharic")]
        [StringLength(500)]
        public string AarevenueBureauNameAmharic { get; set; }
        [Required]
        [Column("AARevenueBureauNameEnglish")]
        [StringLength(500)]
        public string AarevenueBureauNameEnglish { get; set; }
        [StringLength(255)]
        public string LetterNo { get; set; }
        [Column(TypeName = "date")]
        public DateTime? InsertedDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime? UpdatedDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime? DeletedDate { get; set; }
        [StringLength(255)]
        public string InsertedBy { get; set; }
        [StringLength(255)]
        public string UpdatedBy { get; set; }
        [StringLength(255)]
        public string DeletedBy { get; set; }
        [Column(TypeName = "date")]
        public DateTime BudgetYear { get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public decimal ApprovedBudget { get; set; }

        [ForeignKey(nameof(BudgetYearId))]
        [InverseProperty(nameof(AafinanceBureau.AarevenueBureau))]
        public virtual AafinanceBureau BudgetYearNavigation { get; set; }
        [InverseProperty(nameof(BranchLevel.BudgetYear))]
        public virtual ICollection<BranchLevel> BranchLevels { get; set; }
    }
}
