using DB_course.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_course.Repositories
{

    public interface IUnitOfWork
    {
        IRepository<Person> personRepository {get;}
    }

    public class UnitOfWork : IUnitOfWork
    {
        private WarehouseContext context;
        private IRepository<Person> personRep;


        public IRepository<Person> personRepository
        {
            get
            {
                if(personRep == null)
                    personRep = new PersonRepository(context);
                return personRep;
            }
        }

        public UnitOfWork(WarehouseContext context)
        {
            this.context = context;
        }
    }
}
