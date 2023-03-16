using DB_course.Models.DBModels;
using DB_course.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_course.Models
{
   public enum State{ FIRST, OK, INVALID };
    public class UnLoginModel  : IModel
    {
        private IUnitOfWork unitOfWork;


        public UnLoginModel(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public State check(string login, string password)
        {
            Person p = unitOfWork.personRepository.Get(login).FirstOrDefault();
            if(p == null)
                throw new Exception("Person not found");
            if(p.Password == Hash.HashFunc(password))
            {
                if(p.NumberOfCome == 0)
                    return State.FIRST;
                return State.OK;
            }
            return State.INVALID;
        }

    }
}
