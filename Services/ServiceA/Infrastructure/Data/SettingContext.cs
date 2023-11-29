
using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Infrastructure.Data
{
    public class SettingContext : DbContext
    {
        public SettingContext(DbContextOptions<SettingContext> options) : base(options)
        {

        }

        public DbSet<Setting> Settings { get; set; }
    }
}