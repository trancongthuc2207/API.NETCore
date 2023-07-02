using APITestApp.Models;
using Microsoft.EntityFrameworkCore;

namespace APITestApp.Data.DataConnection
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options) { }
        #region
        public DbSet<HangHoa> HangHoas { get; set; }
        public DbSet<Loai> Loais { get; set; }
        #endregion

    }
}
