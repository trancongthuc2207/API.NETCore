using APITestApp.Data;
using APITestApp.Serializers;

namespace APITestApp.Respository
{
    public interface HangHoaRepository
    {
        List<HangHoa_Show_Serializer> getAll();
        HangHoa_Show_Serializer get1ByMaHh(String id);

        HangHoa addNew(HangHoaSerializer hh);
    }
}
