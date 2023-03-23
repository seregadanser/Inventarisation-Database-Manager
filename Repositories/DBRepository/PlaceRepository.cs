using DB_course.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_course.Repositories.DBRepository
{
    public class PlaceRepository : ISQLRepository<Place>
    {

        private WarehouseContext db;

        public IConnection DB { set { db = (WarehouseContext)value; } }

        public PlaceRepository(IConnection db)
        {
            this.db = (WarehouseContext)db;
        }
        public void Create(Place item)
        {
            db.Places.Add(item);
        }

        public void Delete(string id)
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
            return db.Places.ToList();
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
