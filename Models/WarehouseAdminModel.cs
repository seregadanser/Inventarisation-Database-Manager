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
            new DataValidateModel().Validate(place);
            unitOfWork.PlaceRepository.Create(place);
            unitOfWork.PlaceRepository.Save();
        }
        public void RemovePlace(int key)
        {
            if(key <= 0)
                throw new Exception("Invalid Id");
            unitOfWork.PlaceRepository.Delete(Convert.ToString(key));
            unitOfWork.PlaceRepository.Save();
        }
        public void UpdatePlace(int key, Place newPlace)
        {
            if(key <= 0)
                throw new Exception("Invalid Id");
            new DataValidateModel().Validate(newPlace);
            Place curperson = null;
            try
            {
                curperson = unitOfWork.PlaceRepository.Get(Convert.ToString(key)).First();
                if(curperson == null)
                    throw new Exception("No such place for update");
            }
            catch { return; }
            curperson.NumberLayer = newPlace.NumberLayer;
            curperson.NumberStay = newPlace.NumberStay;
            curperson.Size = newPlace.Size;
            curperson.Id = newPlace.Id;

            unitOfWork.PlaceRepository.Update(curperson);
            unitOfWork.PlaceRepository.Save();

        }
        public IEnumerable<Place> GetPlace()
        {
            return unitOfWork.PlaceRepository.GetList();
        }
        public IEnumerable<Place> GetPlace(string value)
        {
            return unitOfWork.PlaceRepository.Get(value);
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
