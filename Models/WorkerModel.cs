using DB_course.Models.CompositModels;
using DB_course.Models.DBModels;
using DB_course.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_course.Models
{
    public class WorkerModel : IModel
    {
        private IUnitOfWork unitOfWork;
        string curId = "";
        public int MaxId { get { return maxId; } }
        private int maxId = 0;

        public WorkerModel(IUnitOfWork unitOfWork, string login)
        {
            this.unitOfWork = unitOfWork;
            this.curId = login;
        }

        public void DelitUseful(int Id)
        {
            unitOfWork.UsefulRepository.Delete(Convert.ToString(Id));
            unitOfWork.UsefulRepository.Save();
        }

        public void AddUseful(WorkerLookCompose value)
        {
            Useful u = new Useful();
            u.PersonId = curId;
            u.InventoryId = value.Inventory_number;
            u.DateOfStart = null;
            new DataValidateModel().Validate(u);
            unitOfWork.UsefulRepository.Create(u);
            unitOfWork.UsefulRepository.Save();
        }

        public IEnumerable<WorkerLookCompose> LookProducts()
        {
            return unitOfWork.WorkerLookComposeRepository.GetList();
        }

        public void UpdatePasswoord(string newpassword)
        {
            Person curperson = null;
            try
            {
                curperson = unitOfWork.personRepository.Get(curId).First();
                if(curperson == null)
                    throw new Exception("No such person for update");
            }
            catch { return; }
            curperson.Password = newpassword;
            curperson.NumberOfCome = curperson.NumberOfCome + 1;
            unitOfWork.personRepository.Update(curperson);
            unitOfWork.personRepository.Save();
        }
        public IEnumerable<WorkerLookCompose> LookProducts(string value)
        {
            IEnumerable<WorkerLookCompose> personList;
            bool emptyValue = string.IsNullOrWhiteSpace(value);
            if (emptyValue == false)
                personList = unitOfWork.WorkerLookComposeRepository.Get(value);
            else
            {
                personList = unitOfWork.WorkerLookComposeRepository.GetList();
            }
            return personList;
        }
        public IEnumerable<WorkerLookUsefulCompose> LookUsing()
        {
            return unitOfWork.WorkerLookUsefulComposeRepository.Get(Convert.ToString(curId));
        }
    }
}
