using Device.Domain.Models;
using Device.Repository;
using Device.Repository.Data;
using Device.Repository.Interfaces;
using DeviceServices.Interfaces;
using System.Collections.Generic;


namespace DeviceServices
{
    public class DeviceService : IDeviceService
    {
        private readonly IDeviceRepository _repo;

        public DeviceService(IDeviceRepository repo)
        {
            _repo = repo;
        }
        private DeviceBO GenerateBO(Devicedb d)
        {
            return new DeviceBO
            {
                Id = d.Id,
                Name = d.Name,
                Brand = d.Brand,
                State = (DeviceState)d.State,
                CreationDate = d.CreationDate
            };
        }
        public IEnumerable<DeviceBO> GetAll()
        {
            var devices = _repo.GetAll();
            return devices.Select(d => GenerateBO(d));
        }

        public DeviceBO GetById(int id)
        {
            var device = _repo.GetById(id);
            if (device == null) return null;
            return GenerateBO(device);
        }
        public IEnumerable<DeviceBO> GetByBrand(string brand)
        {
            var devices = _repo.GetByBrand(brand);
            if (devices == null) return null;
            return devices.Select(d => GenerateBO(d));
        }

        public IEnumerable<DeviceBO> GetByState(int state)
        {
            var devices = _repo.GetByState(state);
            if (devices == null) return null;
            return devices.Select(d => GenerateBO(d));
        }
        public DeviceBO AddOrUpdate(DeviceBO device, int? id)
        {
            Devicedb devicedb;
            if (id.HasValue)
            {
                devicedb = _repo.GetById(id.Value);
                if (devicedb == null) return null;
                if (devicedb.State == (int)DeviceState.InUse)
                {
                    devicedb.State = (int)device.State;
                }
                else
                {
                    devicedb.Name = device.Name;
                    devicedb.Brand = device.Brand;
                    devicedb.State = (int)device.State;
                }

            }
            else
            {
                devicedb = new Devicedb
                {
                    Name = device.Name,
                    Brand = device.Brand,
                    State = (int)device.State,
                    CreationDate = DateTime.Now
                };
            }
            _repo.AddOrUpdate(devicedb, id);
            return GenerateBO(devicedb);
        }
        public bool Delete(int id)
        {
            var device = _repo.GetById(id);
            if (device == null) return false;
            _repo.Delete(device.Id);
            return true;
        }
    }
}
