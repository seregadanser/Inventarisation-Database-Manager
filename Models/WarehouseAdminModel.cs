using DB_course.Models.DBModels;
using DB_course.Models.CompositModels;
using DB_course.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_course.Models
{
    public class WarehouseAdminModel : IModel
    {
        private IUnitOfWork unitOfWork;
        public IUnitOfWork UnitOfWork { get { return unitOfWork; } }
 
        public WarehouseAdminModel(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;

        }
        
        public void AddPlace(Place place)
        {

        }
        public void RemovePlace(int key)
        {

        }
        public void UpdatePlace(int key, Place newPlace)
        {

        }
        public IEnumerable<Place> GetPlace()
        {
            return null;
        }
        public IEnumerable<Place> GetPlace(string value)
        {
            return null;
        }

        public void AddProduct(AdminCompose value)
        {

        }
        public void RemoveProduct(int id)
        {

        }
        public IEnumerable<AdminCompose> GetProducts()
        {
            return null;
        }
        public IEnumerable<AdminCompose> GetProducts(string value)
        {
            return null;
        }
    }
}
