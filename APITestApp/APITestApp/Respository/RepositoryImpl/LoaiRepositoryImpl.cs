using APITestApp.Data.DataConnection;
using APITestApp.Models;
using APITestApp.Serializers;

namespace APITestApp.Respository.RepositoryImpl
{
    public class LoaiRepositoryImpl : LoaiRepository
    {
        private readonly MyDbContext _context;

        public LoaiRepositoryImpl(MyDbContext context)
        {
            _context = context;
        }

        public Loai addNew(Loai l)
        {
            throw new NotImplementedException();
        }

        public List<LoaiSerializer> getAll()
        {
            List<LoaiSerializer> loaiList = new List<LoaiSerializer>();
            var getDsLoai = _context.Loais.ToList();

            getDsLoai.ForEach(l => loaiList.Add(new LoaiSerializer { MaLoai = l.MaLoai, TenLoai = l.TenLoai }));

            return loaiList;
        }
    }
}
