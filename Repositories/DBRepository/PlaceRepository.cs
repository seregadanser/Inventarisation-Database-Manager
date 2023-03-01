using DB_course.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_course.Repositories.DBRepository
{
    public class PlaceRepository : IRepository<Place>
    {

        private WarehouseContext db;

        public PlaceRepository(WarehouseContext db)
        {
            this.db = db;
        }
        public void Create(Place item)
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

        public IEnumerable<Place> Get(string value)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Place> GetList()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Place item)
        {
            throw new NotImplementedException();
        }
    }
}
