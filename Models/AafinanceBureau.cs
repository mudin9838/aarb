using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace aarb.Models
{
    [Table("AAFinanceBureau")]
    public partial class AafinanceBureau
    {
        [Key]
        public int BudgetYearId { get; set; }
        [Required]
        [Column("AAFinanceBureaunNameAmharic")]
        [StringLength(500)]
        public string AafinanceBureaunNameAmharic { get; set; }
        [Required]
        [Column("AAFinanceBureaunNameEnglish")]
        [StringLength(500)]
        public string AafinanceBureaunNameEnglish { get; set; }
        [Column(TypeName = "date")]
        public DateTime BudgetYear { get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public decimal ApprovedBudget { get; set; }
        public byte[] UplodedLetter { get; set; }

        [InverseProperty("BudgetYearNavigation")]
        public virtual AarevenueBureau AarevenueBureau { get; set; }
    }
}
