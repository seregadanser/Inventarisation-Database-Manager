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
        private IRepository<Person> repository;
        
        private int maxId = 0;

        public int MaxId { get { return maxId; } }

        public HRAdminModel()
        {
            repository = new PersonRepository();
            maxId = repository.GetList().Count();
        }
        public void AddPerson(Person person)
        {
            repository.Create(person);
            repository.Save();
            maxId++;
        }

        public void RemovePerson(int Id)
        {
            repository.Delete(Id);
            repository.Save();
        }

        public void UpdatePerson(int Id_cur, Person updateperson)
        {
            Person curperson;
            curperson = repository.Get(Id_cur.ToString()).First();
            curperson.Position = updateperson.Position;
            curperson.Name = updateperson.Name;
            curperson.SecondName = updateperson.SecondName;
            curperson.Login = updateperson.Login;
            curperson.DateOfBirthday = updateperson.DateOfBirthday;
            repository.Update(curperson);
            repository.Save();
        }

        public IEnumerable<Person> LookPerson()
        {
           return repository.GetList();
        }

        public IEnumerable<Person> LookPerson(string value)
        {
            IEnumerable<Person> personList;
            bool emptyValue = string.IsNullOrWhiteSpace(value);
            if (emptyValue == false)
                personList = repository.Get(value);
            else personList = repository.GetList();
            return personList;
        }
    }
}
