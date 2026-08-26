using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Device.Domain.Models;

namespace Device.Repository.Data
{
    public class DeviceDbContext : DbContext
    {
        public DeviceDbContext(DbContextOptions<DeviceDbContext> options)
                : base(options) { }
        public DbSet<Devicedb> Devices => Set<Devicedb>();

    }
}
