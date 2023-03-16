using DB_course.Models.DBModels;
using DB_course.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_course.Models
{
    public class HRAdminModel : IModel
    {
        private IUnitOfWork unitOfWork;


        public HRAdminModel(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;

        }
        public void AddPerson(Person person)
        {
            new DataValidateModel().Validate(person);
            unitOfWork.personRepository.Create(person);
            unitOfWork.personRepository.Save();
 
        }

        public void RemovePerson(string Id)
        {
            unitOfWork.personRepository.Delete(Id);
            unitOfWork.personRepository.Save();
        }

        public void UpdatePerson(string Id_cur, Person updateperson)
        {
            new DataValidateModel().Validate(updateperson);
            Person curperson = null;
            try
            {
                curperson = unitOfWork.personRepository.Get(Id_cur).First();
                if(curperson == null)
                    throw new Exception("No such person for update");
            }
            catch { return; }
            curperson.Position = updateperson.Position;
            curperson.Name = updateperson.Name;
            curperson.SecondName = updateperson.SecondName;
            curperson.DateOfBirthday = updateperson.DateOfBirthday;
            unitOfWork.personRepository.Update(curperson);
            unitOfWork.personRepository.Save();
        }

        public IEnumerable<Person> LookPerson()
        {
            return unitOfWork.personRepository.GetList();
        }

        public IEnumerable<Person> LookPerson(string value)
        {
            
            IEnumerable<Person> personList;
            bool emptyValue = string.IsNullOrWhiteSpace(value);
            if (emptyValue == false)
                personList = unitOfWork.personRepository.Get(value);
            else {
                personList = unitOfWork.personRepository.GetList(); }
            return personList;
        }
    }
}
