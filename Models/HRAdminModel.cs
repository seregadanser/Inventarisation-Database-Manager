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
        private int maxId = 0;

        public int MaxId { get { return maxId; } }

        public HRAdminModel(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            maxId = unitOfWork.personRepository.GetList().Count();
        }
        public void AddPerson(Person person)
        {
            new DataValidateModel().Validate(person);
            unitOfWork.personRepository.Create(person);
            unitOfWork.personRepository.Save();
            maxId++;
        }

        public void RemovePerson(int Id)
        {
            unitOfWork.personRepository.Delete(Id);
            unitOfWork.personRepository.Save();
        }

        public void UpdatePerson(int Id_cur, Person updateperson)
        {
            new DataValidateModel().Validate(updateperson);
            Person curperson;
            curperson = unitOfWork.personRepository.Get(Id_cur.ToString()).First();
            curperson.Position = updateperson.Position;
            curperson.Name = updateperson.Name;
            curperson.SecondName = updateperson.SecondName;
            curperson.Login = updateperson.Login;
            curperson.DateOfBirthday = updateperson.DateOfBirthday;
            unitOfWork.personRepository.Update(curperson);
            unitOfWork.personRepository.Save();
        }

        public IEnumerable<Person> LookPerson()
        {
            maxId = unitOfWork.personRepository.GetList().Count();
            return unitOfWork.personRepository.GetList();
        }

        public IEnumerable<Person> LookPerson(string value)
        {
            
            IEnumerable<Person> personList;
            bool emptyValue = string.IsNullOrWhiteSpace(value);
            if (emptyValue == false)
                personList = unitOfWork.personRepository.Get(value);
            else { maxId = unitOfWork.personRepository.GetList().Count();
                personList = unitOfWork.personRepository.GetList(); }
            return personList;
        }
    }
}
