using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Device.Repository.Interfaces
{
    public interface IRepository<T>
    {
        public IEnumerable<T> GetAll();
        public T? GetById(int id);
        public T AddOrUpdate(T entity, int? id);
        public bool Delete(int id);
    }
}
