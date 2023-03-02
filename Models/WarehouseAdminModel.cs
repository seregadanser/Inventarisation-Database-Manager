using DB_course.Models.DBModels;
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
        private int maxId = 0;

        public int MaxId { get { return maxId; } }

        public WarehouseAdminModel(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            maxId = unitOfWork.personRepository.GetList().Count();
        }
        public void AddPlace(Place person)
        {
           
        }

        public void RemovePlace(int Id)
        {
           
        }

        public void UpdatePlace(int Id_cur, Person updateperson)
        {
         
        }

        public IEnumerable<Person> LookPlace()
        {
          return null;
        }

        public IEnumerable<Person> LookPlace(string value)
        {

           
            return null;
        }
    }
}
