using DB_course.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB_course.Repositories.DBRepository;
using DB_course.Repositories.CompositRepository;
using DB_course.Models.CompositModels;

namespace DB_course.Repositories
{

    public interface IUnitOfWork
    {
        IRepository<Person> personRepository {get;}
        IRepository<Place> PlaceRepository { get; }
        IRepository<Useful> UsefulRepository { get; }
        IRepository<WarehousemanLookCompose> WarehousemanLookComposeRepository { get; }
        IRepository<WorkerLookUsefulCompose> WorkerLookUsefulComposeRepository { get; }
        IRepository<WorkerLookCompose> WorkerLookComposeRepository { get; }
        public void UpdateRepository(IRepositoryAbstractFabric fabric);

    }

    public class UnitOfWork : IUnitOfWork
    {
        private IRepositoryAbstractFabric fabric;

        private IRepository<Person> personRep;
        private IRepository<Place> PlaceRep;
        private IRepository<Useful> UsefulRep;
        IRepository<WarehousemanLookCompose> WarehousemanLookComposeRep;
        IRepository<WorkerLookUsefulCompose> WorkerLookUsefulComposeRep;
        IRepository<WorkerLookCompose> WorkerLookComposeRep;

        public IRepository<Person> personRepository
        {
            get  
            {
                if(personRep == null)
                    personRep = fabric.CreatePersonR();
                return personRep;
            }
        }

        public IRepository<Place> PlaceRepository
        {
            get
            {
                if(PlaceRep == null)
                    PlaceRep = fabric.CreatePlaceR();
                return PlaceRep;
            }
        }

        public IRepository<Useful> UsefulRepository
        {
            get
            {
                if(UsefulRep == null)
                    UsefulRep = fabric.CreateUsefulR();
                return UsefulRep;
            }
        }
        public IRepository<WarehousemanLookCompose> WarehousemanLookComposeRepository {
            get
            {

                if(WarehousemanLookComposeRep == null)
                    WarehousemanLookComposeRep = fabric.CreateWarehousemanLookComposeRepositoryR();
                return WarehousemanLookComposeRep;

            }
        }

        public IRepository<WorkerLookUsefulCompose> WorkerLookUsefulComposeRepository
        {
            get
            {

                if(WorkerLookUsefulComposeRep == null)
                    WorkerLookUsefulComposeRep = fabric.CreateWorkerLookUsefulComposeR();
                return WorkerLookUsefulComposeRep;

            }
        }
        public IRepository<WorkerLookCompose> WorkerLookComposeRepository
        {
            get
            {

                if(WorkerLookComposeRep == null)
                    WorkerLookComposeRep = fabric.CreateWorkerLookComposeR();
                return WorkerLookComposeRep;

            }
        }
        public UnitOfWork(IRepositoryAbstractFabric fabric)
        {
            this.fabric = fabric;
        }

        public void UpdateRepository(IRepositoryAbstractFabric fabric)
        {
            this.fabric = fabric;
            personRep = null;
            PlaceRep = null;
            UsefulRep = null;
            WarehousemanLookComposeRep = null;
        }
    }
}
