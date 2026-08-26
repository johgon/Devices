using Device.Domain.Models;
using Device.Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Device.Repository.Interfaces
{
    public interface IDeviceRepository : IRepository<Devicedb>
    {
        public IEnumerable<Devicedb?> GetByState(int state);
        public IEnumerable<Devicedb?> GetByBrand(string brand);
    }
}
