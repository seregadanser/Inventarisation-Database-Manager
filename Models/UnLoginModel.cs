using DB_course.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_course.Models
{
    public class UnLoginModel  : IModel
    {
        private IUnitOfWork unitOfWork;


        public UnLoginModel(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void check(string login, string password)
        {

        }

    }
}
