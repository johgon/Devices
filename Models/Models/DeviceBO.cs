using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Device.Domain.Models
{
    public class DeviceBO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public DeviceState State { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
