using System.ComponentModel.DataAnnotations;

namespace APITestApp.Serializers
{
    public class HangHoaSerializer
    {
        public String TenHh { get; set; }
        public String MoTa { get; set; }
        [Range(0, double.MaxValue)]
        public double DonGia { get; set; }
        public byte GiamGia { get; set; }
        public int MaLoai { get; set; }
    }

    public class HangHoa_Show_Serializer
    {
        public String MaHh { get; set; }
        public String TenHh { get; set; }
        public double DonGia { get; set; }
        public int MaLoai { get; set; }
    }

}
