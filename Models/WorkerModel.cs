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
        int curId = -1;
        public int MaxId { get { return maxId; } }
        private int maxId = 0;

        public WorkerModel(IUnitOfWork unitOfWork, int curId)
        {
            this.unitOfWork = unitOfWork;
            this.curId = curId;
            maxId = unitOfWork.UsefulRepository.GetList().Count();
        }

        public void DelitUseful(int Id)
        {
            unitOfWork.UsefulRepository.Delete(Id);
            unitOfWork.UsefulRepository.Save();
        }

        public void AddUseful(WorkerLookCompose value)
        {
            Useful u = new Useful();
            u.Id = maxId;
            u.PersonId = curId;
            u.InventoryId = value.Id;
            u.DateOfStart = null;
            //add validation
            unitOfWork.UsefulRepository.Create(u);
            unitOfWork.UsefulRepository.Save();
        }

        public IEnumerable<WorkerLookCompose> LookProducts()
        {
            maxId = unitOfWork.UsefulRepository.GetList().Count();
            return unitOfWork.WorkerLookComposeRepository.GetList();
        }

        public IEnumerable<WorkerLookCompose> LookProducts(string value)
        {
            IEnumerable<WorkerLookCompose> personList;
            bool emptyValue = string.IsNullOrWhiteSpace(value);
            if (emptyValue == false)
                personList = unitOfWork.WorkerLookComposeRepository.Get(value);
            else
            {
                maxId = unitOfWork.UsefulRepository.GetList().Count();
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
