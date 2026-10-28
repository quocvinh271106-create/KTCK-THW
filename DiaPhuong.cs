
using System.ComponentModel.DataAnnotations;

namespace Covid19.DAL
{
    public class DiaPhuong
    {
        [Key]
        [MaxLength(3)]
        public string MaDP { get; set; } = null!;

        [Required]
        [MaxLength(50)]
        public string TenDP { get; set; } = null!;

        [Required]
        public int SoCaNhiemMoi { get; set; }

        [Required]
        public int MaTT { get; set; }

        public virtual TrangThai TrangThai { get; set; } = null!;
    }
}
