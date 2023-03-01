using DB_course.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_course.Repositories.DBRepository
{
    public class InventoryProductRepository : IRepository<InventoryProduct>
    {
        private WarehouseContext db;

        public InventoryProductRepository(WarehouseContext db)
        {
            this.db = db;
        }

        public void Create(InventoryProduct item)
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

        public IEnumerable<InventoryProduct> Get(string value)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<InventoryProduct> GetList()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(InventoryProduct item)
        {
            throw new NotImplementedException();
        }
    }
}
