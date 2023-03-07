using DB_course.Models.DBModels;
using DB_course.Repositories.DBRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB_course.Repositories.CompositRepository;
using DB_course.Models.CompositModels;

namespace DB_course.Repositories
{

    public interface IRepositoryAbstractFabric
    {
        public IRepository<Person> CreatePersonR();
        public IRepository<Place> CreatePlaceR();
        public IRepository<Useful> CreateUsefulR();
        public IRepository<WarehousemanLookCompose> CreateWarehousemanLookComposeRepositoryR();
        public IRepository<WorkerLookUsefulCompose> CreateWorkerLookUsefulComposeR();
        public IRepository<WorkerLookCompose> CreateWorkerLookComposeR();

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
        public IRepository<WarehousemanLookCompose> CreateWarehousemanLookComposeRepositoryR()
        {
            return new WarehousemanLookComposeRepository(connection);
        }

        public IRepository<WorkerLookCompose> CreateWorkerLookComposeR()
        {
            return new WorkerLookComposeRepository(connection);
        }

        public IRepository<WorkerLookUsefulCompose> CreateWorkerLookUsefulComposeR()
        {
            return new WorkerLookUsefulComposeRepository(connection);
        }
    }
}
