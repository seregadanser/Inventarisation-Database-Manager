﻿using DB_course.Models.DBModels;
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

        public WarehouseContext DB { set { db = value; } }

        public PlaceofObjectRepository(WarehouseContext db)
        {
            this.db = db;
        }

        public void Create(PlaceofObject item)
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

        public IEnumerable<PlaceofObject> Get(string value)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PlaceofObject> GetList()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(PlaceofObject item)
        {
            throw new NotImplementedException();
        }
    }
}
