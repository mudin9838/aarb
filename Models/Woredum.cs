using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace aarb.Models
{
    public partial class Woredum
    {
        [Key]
        public int WoredaId { get; set; }
        [Required]
        [StringLength(150)]
        public string WoredaNameEng { get; set; }
        [Required]
        [StringLength(150)]
        public string WoredaNameAmh { get; set; }
        public int BranchId { get; set; }

        [ForeignKey(nameof(BranchId))]
        [InverseProperty("Woreda")]
        public virtual Branch Branch { get; set; }
    }
}
