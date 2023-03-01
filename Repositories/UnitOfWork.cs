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

        public void UpdateContext(WarehouseContext context);

    }

    public class UnitOfWork : IUnitOfWork
    {
        private WarehouseContext context;

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
                    personRep = new PersonRepository(context);
                return personRep;
            }
        }

        public IRepository<InventoryProduct> InventoryProductRepository
        {
            get
            {
                if (InventoryProductRep == null)
                    InventoryProductRep = new InventoryProductRepository(context);
                return InventoryProductRep;
            }
        }
        public IRepository<PlaceofObject> PlaceofObjectRepository
        {
            get
            {
                if (PlaceofObjectRep == null)
                    PlaceofObjectRep = new PlaceofObjectRepository(context);
                return PlaceofObjectRep;
            }
        }
        public IRepository<Place> PlaceRepository
        {
            get
            {
                if (PlaceRep == null)
                    PlaceRep = new PlaceRepository(context);
                return PlaceRep;
            }
        }
        public IRepository<Product> ProductRepository
        {
            get
            {
                if (ProductRep == null)
                    ProductRep = new ProductRepository(context);
                return ProductRep;
            }
        }
        public IRepository<Useful> UsefulRepository
        {
            get
            {
                if (UsefulRep == null)
                    UsefulRep = new UsefulRepository(context);
                return UsefulRep;
            }
        }
        public UnitOfWork(WarehouseContext context)
        {
            this.context = context;
        }

        public void UpdateContext(WarehouseContext context)
        {
            personRepository.DB = context;
            InventoryProductRepository.DB = context;
            PlaceofObjectRepository.DB = context;
            PlaceRepository.DB = context;
            ProductRepository.DB = context;
            UsefulRepository.DB = context;
        }
    }
}
