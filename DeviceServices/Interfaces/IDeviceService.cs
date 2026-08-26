using Device.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceServices.Interfaces
{
    public interface IDeviceService
    {
        public IEnumerable<DeviceBO> GetAll();
        public DeviceBO GetById(int id);
        public IEnumerable<DeviceBO> GetByState(int state);
        public IEnumerable<DeviceBO> GetByBrand(string brand);
        public DeviceBO AddOrUpdate(DeviceBO device, int? id);
        public bool Delete(int id);
    }
}
