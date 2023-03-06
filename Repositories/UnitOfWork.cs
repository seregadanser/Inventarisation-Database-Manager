using DB_course.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB_course.Repositories.DBRepository;

namespace DB_course.Repositories
{

    public interface IUnitOfWork
    {
        IRepository<Person> personRepository {get;}
        IRepository<Place> PlaceRepository { get; }
        IRepository<Useful> UsefulRepository { get; }

        public void UpdateRepository(IRepositoryAbstractFabric fabric);

    }

    public class UnitOfWork : IUnitOfWork
    {
        private IRepositoryAbstractFabric fabric;

        private IRepository<Person> personRep;
        private IRepository<Place> PlaceRep;
        private IRepository<Useful> UsefulRep;


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
        }
    }
}
