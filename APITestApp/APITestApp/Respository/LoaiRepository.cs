using APITestApp.Models;
using APITestApp.Serializers;
using Microsoft.AspNetCore.Mvc;

namespace APITestApp.Respository
{
    public interface LoaiRepository 
    {
        List<LoaiSerializer> getAll();

        Loai addNew(Loai l);
    }
}
