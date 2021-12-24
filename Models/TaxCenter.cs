using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace aarb.Models
{
    [Table("TaxCenter")]
    public partial class TaxCenter
    {
        [Key]
        public int TaxCenterId { get; set; }
        [Required]
        [StringLength(150)]
        public string TaxCenterNameEng { get; set; }
        [Required]
        [StringLength(150)]
        public string TaxCenterNameAmh { get; set; }
        public int BranchId { get; set; }

        [ForeignKey(nameof(BranchId))]
        [InverseProperty("TaxCenters")]
        public virtual Branch Branch { get; set; }
    }
}
