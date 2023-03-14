using DB_course.Models.CompositModels;
using DB_course.Models.DBModels;
using DB_course.Repositories;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_course.Models
{
    public class WarehousemanModel : IModel
    {
        private IUnitOfWork unitOfWork;

        public WarehousemanModel(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void DelitUseful(int Id)
        {
            unitOfWork.UsefulRepository.Delete(Convert.ToString(Id));
            unitOfWork.UsefulRepository.Save();
        }

        public IEnumerable<WarehousemanLookCompose> LookWarehousemanLook()
        {
            return unitOfWork.WarehousemanLookComposeRepository.GetList();
        }

        public IEnumerable<WarehousemanLookCompose> LookWarehousemanLook(string value)
        {

            IEnumerable<WarehousemanLookCompose> personList;
            bool emptyValue = string.IsNullOrWhiteSpace(value);
            if(emptyValue == false)
                personList = unitOfWork.WarehousemanLookComposeRepository.Get(value);
            else
            {
                personList = unitOfWork.WarehousemanLookComposeRepository.GetList();
            }
            return personList;
        }
    }
}
