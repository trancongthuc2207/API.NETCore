using APITestApp.Data;
using APITestApp.Data.DataConnection;
using APITestApp.Respository;
using APITestApp.Serializers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APITestApp.Controllers.UserControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserConntroller_HangHoa : ControllerBase
    {
        private readonly MyDbContext _context;
        private readonly HangHoaRepository _hangHoarepository;

        public UserConntroller_HangHoa(HangHoaRepository hangHoarepository) {
            _hangHoarepository = hangHoarepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try {
                var data = _hangHoarepository.getAll();
                return Ok(data);
            }
            catch {
                return BadRequest();
            }
        }

        [HttpGet("{MaHh}")]
        public IActionResult GetByMaHh(String MaHh)
        {
            try
            {
                var data = _hangHoarepository.get1ByMaHh(MaHh);
                return Ok(data);
            }
            catch
            {
                return BadRequest();
            }
        }


        [HttpPost]
        public IActionResult CreateNewHangHoa(HangHoaSerializer hh)
        {
            try
            {
                var data = _hangHoarepository.addNew(hh);
                return Ok(data);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
