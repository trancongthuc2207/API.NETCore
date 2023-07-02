using APITestApp.Data.DataConnection;
using APITestApp.Respository;
using Microsoft.AspNetCore.Mvc;

namespace APITestApp.Controllers.UserControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserConntroller_Loai : ControllerBase
    {
        private readonly MyDbContext _context;
        private readonly LoaiRepository _loaiRepository;

        public UserConntroller_Loai(LoaiRepository loaiRepository)
        {
            _loaiRepository = loaiRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var data = _loaiRepository.getAll();
                return Ok(data);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
