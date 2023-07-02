using APITestApp.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APITestApp.Data
{
    [Table("HangHoa")]
    public class HangHoa
    {   
        [Key]
        public Guid MaHh { get; set; }
        [Required]
        [MaxLength(100)]
        public String TenHh { get; set; }
        public String MoTa { get; set; }
        [Range(0, double.MaxValue)]
        public double DonGia { get; set; }
        public byte GiamGia { get; set; }

        public int? MaLoai { get; set; }
        [ForeignKey("MaLoai")]
        public Loai Loai { get; set; }
    }
}
