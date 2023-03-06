using DB_course.Models.DBModels;
using DB_course.Repositories.DBRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_course.Repositories
{

    public interface IRepositoryAbstractFabric
    {
        public IRepository<Person> CreatePersonR();
        public IRepository<Place> CreatePlaceR();
        public IRepository<Useful> CreateUsefulR();

    }
    public class SQLRepositoryAbstractFabric : IRepositoryAbstractFabric
    {
        IConnection connection;

        public SQLRepositoryAbstractFabric(IConnection connection)
        {
            this.connection = connection;
        }


        public IRepository<Person> CreatePersonR()
        {
            return new PersonRepository(connection);
        }


        public IRepository<Place> CreatePlaceR()
        {
            return new PlaceRepository(connection);
        }



        public IRepository<Useful> CreateUsefulR()
        {
            return new UsefulRepository(connection);
        }
    }
}
