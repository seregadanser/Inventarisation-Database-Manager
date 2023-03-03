using DB_course.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_course.Repositories.DBRepository
{
    public class UsefulRepository : ISQLRepository<Useful>
    {

        private WarehouseContext db;

        public IConnection DB { set { db = (WarehouseContext)value; } }

        public UsefulRepository(IConnection db)
        {
            this.db = (WarehouseContext)db;
        }

        public void Create(Useful item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Useful> Get(string value)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Useful> GetList()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Useful item)
        {
            throw new NotImplementedException();
        }
    }
}
