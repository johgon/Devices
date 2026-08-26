using Device.Domain.Models;
using Device.Repository.Data;
using Device.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Device.Repository
{
    public class DeviceRepository : Repository<Devicedb>, IDeviceRepository
    {
        public DeviceRepository(DeviceDbContext context) : base(context) { }
        public IEnumerable<Devicedb?> GetByState(int state)
        {
            return _context.Devices.Where(u => u.State == state);
        }

        public IEnumerable<Devicedb?> GetByBrand(string brand)
        {
            return _context.Devices.Where(u => u.Brand == brand);
        }
    }
}
