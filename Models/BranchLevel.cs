using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace aarb.Models
{
    [Table("BranchLevel")]
    public partial class BranchLevel
    {
        public BranchLevel()
        {
            Branches = new HashSet<Branch>();
        }

        [Key]
        public int BranchLevelId { get; set; }
        [Required]
        [StringLength(150)]
        public string BranchLevelNameAmh { get; set; }
        [Required]
        [StringLength(150)]
        public string BranchLevelNamEng { get; set; }
        public int BudgetYearId { get; set; }

        [ForeignKey(nameof(BudgetYearId))]
        [InverseProperty(nameof(AarevenueBureau.BranchLevels))]
        public virtual AarevenueBureau BudgetYear { get; set; }
        [InverseProperty(nameof(Branch.BranchLevel))]
        public virtual ICollection<Branch> Branches { get; set; }
    }
}
