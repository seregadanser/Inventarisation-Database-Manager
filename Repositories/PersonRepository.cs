﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_course.Repositories
{
    public class PersonRepository : IRepository<Person>
    {
        private WarehouseContext db;

        public PersonRepository()
        {
            this.db = new WarehouseContext();
        }

        public void Create(Person item)
        {
            db.Add(item);
        }

        public void Delete(int id)
        {
            Person book = db.Persons.Find(id);
            if (book != null)
                db.Persons.Remove(book);
        }


        public IEnumerable<Person> Get(string value)
        {
            var petList = new List<Person>();
            int petId = int.TryParse(value, out _) ? Convert.ToInt32(value) : 0;
            string petName = value;

            return (from user in db.Persons
                   where user.Id == petId || EF.Functions.Like(user.Name!, value)
                   select user).ToList();
          
        }

        public IEnumerable<Person> GetList()
        { 
            return db.Persons.ToList(); ;
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(Person item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
