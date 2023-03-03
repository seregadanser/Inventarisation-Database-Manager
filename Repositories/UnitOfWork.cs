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
        IRepository<InventoryProduct> InventoryProductRepository { get; }
        IRepository<PlaceofObject> PlaceofObjectRepository { get; }
        IRepository<Place> PlaceRepository { get; }
        IRepository<Product> ProductRepository { get; }
        IRepository<Useful> UsefulRepository { get; }

        public void UpdateRepository(IRepositoryAbstractFabric fabric);

    }

    public class UnitOfWork : IUnitOfWork
    {
        private IRepositoryAbstractFabric fabric;

        private IRepository<Person> personRep;
        private IRepository<InventoryProduct> InventoryProductRep;
        private IRepository<PlaceofObject> PlaceofObjectRep;
        private IRepository<Place> PlaceRep;
        private IRepository<Product> ProductRep;
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

        public IRepository<InventoryProduct> InventoryProductRepository
        {
            get
            {
                if(InventoryProductRep == null)
                    InventoryProductRep = fabric.CreateInventoryProductR();
                return InventoryProductRep;
            }
        }
        public IRepository<PlaceofObject> PlaceofObjectRepository
        {
            get
            {
                if(PlaceofObjectRep == null)
                    PlaceofObjectRep = fabric.CreatePlaceOfObjectR();
                return PlaceofObjectRep;
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
        public IRepository<Product> ProductRepository
        {
            get
            {
                if(ProductRep == null)
                    ProductRep = fabric.CreateProductR();
                return ProductRep;
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
            InventoryProductRep = null;
            PlaceofObjectRep = null;
            PlaceRep = null;
            ProductRep = null;
            UsefulRep = null;
        }
    }
}
