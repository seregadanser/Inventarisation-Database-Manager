using DB_course.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_course.Repositories.DBRepository
{
    public class PlaceofObjectRepository : IRepository<PlaceofObject>
    {
        private WarehouseContext db;

        public IConnection DB { set { db = (WarehouseContext)value; } }

        public PlaceofObjectRepository(IConnection db)
        {
            this.db = (WarehouseContext)db;
        }


        public void Create(PlaceofObject item)
        {
            throw new NotImplementedException();
        }

        public void Delete(string key)
        {
            throw new NotImplementedException();
        }

 

        public IEnumerable<PlaceofObject> Get(string value)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PlaceofObject> GetList()
        {
            throw new NotImplementedException();
        }

  

        public void Update(PlaceofObject item)
        {
            throw new NotImplementedException();
        }
        public void Save()
        {
            db.SaveChanges();
        }


        private bool disposed = false;



        public virtual void Dispose(bool disposing)
        {
            if(!disposed)
            {
                if(disposing)
                {
                    db.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
