using DB_course.Models.CompositModels;
using DB_course.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_course.Repositories.CompositRepository
{
    internal class WorkerLookUsefulComposeRepository : ISQLRepository<WorkerLookUsefulCompose>
    {
        private WarehouseContext db;

        public IConnection DB { set { db = (WarehouseContext)value; } }

        public WorkerLookUsefulComposeRepository(IConnection db)
        {
            this.db = (WarehouseContext)db;
        }

        public IEnumerable<WorkerLookUsefulCompose> GetList()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<WorkerLookUsefulCompose> Get(string value)
        {

            int petId = int.TryParse(value, out _) ? Convert.ToInt32(value) : -1;
            if(petId == -1)
              throw new Exception("person not exists");


        }

        public void Create(WorkerLookUsefulCompose item)
        {
            throw new NotImplementedException();
        }

        public void Update(WorkerLookUsefulCompose item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
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
