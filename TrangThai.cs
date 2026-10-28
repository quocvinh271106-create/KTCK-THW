
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Covid19.DAL
{
    public class TrangThai
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaTT { get; set; }

        [Required]
        [MaxLength(100)]
        public string TenTT { get; set; } = null!;

        public string? GhiChu { get; set; }

        public virtual ICollection<DiaPhuong> DiaPhuongs { get; set; }
            = new List<DiaPhuong>();
    }
}
