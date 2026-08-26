using Device.Repository.Data;
using Device.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;

namespace Device.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DeviceDbContext _context;
        protected readonly DbSet<T> _dbSet;
        public Repository(DeviceDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public T? GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public T AddOrUpdate(T entity, int? id)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
            return entity;
        }
        public bool Delete(int id)
        {
            var entity = GetById(id);
            try
            {
                _dbSet.Remove(entity);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
