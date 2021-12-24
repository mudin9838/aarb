using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace aarb.Models
{
    [Table("Branch")]
    public partial class Branch
    {
        public Branch()
        {
            TaxCenters = new HashSet<TaxCenter>();
            Woreda = new HashSet<Woredum>();
        }

        [Key]
        public int BranchId { get; set; }
        [Required]
        [StringLength(150)]
        public string BranchNameEng { get; set; }
        [Required]
        [StringLength(150)]
        public string BranchNameAmh { get; set; }
        public int BranchLevelId { get; set; }

        [ForeignKey(nameof(BranchLevelId))]
        [InverseProperty("Branches")]
        public virtual BranchLevel BranchLevel { get; set; }
        [InverseProperty(nameof(TaxCenter.Branch))]
        public virtual ICollection<TaxCenter> TaxCenters { get; set; }
        [InverseProperty(nameof(Woredum.Branch))]
        public virtual ICollection<Woredum> Woreda { get; set; }
    }
}
