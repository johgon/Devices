using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Device.Repository.Data
{
    public class Devicedb
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public int State { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
