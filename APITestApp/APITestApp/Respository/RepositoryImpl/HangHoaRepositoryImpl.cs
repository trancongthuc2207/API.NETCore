using APITestApp.Data;
using APITestApp.Data.DataConnection;
using APITestApp.Serializers;

namespace APITestApp.Respository.RepositoryImpl
{
    public class RepositoryImpl : HangHoaRepository
    {
        private readonly MyDbContext _context;

        public RepositoryImpl(MyDbContext context) {
            _context = context;
        }

        public HangHoa addNew(HangHoaSerializer hh)
        {
            var newhh = new HangHoa
            {
                MaHh = Guid.NewGuid(),
                TenHh = hh.TenHh,
                DonGia = hh.DonGia,
                GiamGia = hh.GiamGia,
                MoTa = hh.MoTa,
                MaLoai = hh.MaLoai,
            };

            _context.Add(newhh);
            _context.SaveChanges();

            return newhh;
        }

        public HangHoa_Show_Serializer get1ByMaHh(string id)
        {
            var hh = _context.HangHoas.SingleOrDefault(lo => lo.MaHh.ToString() == id);
            if (hh != null) { 
                return new HangHoa_Show_Serializer {
                    MaHh = hh.MaHh.ToString(),
                    DonGia = hh.DonGia,
                    TenHh = hh.TenHh,
                    MaLoai = (int)hh.MaLoai
                };
            }
            return null;
        }

        public List<HangHoa_Show_Serializer> getAll()
        {
            List<HangHoa_Show_Serializer> custom = new List<HangHoa_Show_Serializer>();
            var dsLoai = _context.HangHoas.ToList();
            dsLoai.ForEach(hh => custom.Add(new HangHoa_Show_Serializer { 
                MaHh = hh.MaHh.ToString(), 
                DonGia = hh.DonGia,
                TenHh = hh.TenHh,
                MaLoai = (int)hh.MaLoai
            }));
            return custom;
        }
    }
}
