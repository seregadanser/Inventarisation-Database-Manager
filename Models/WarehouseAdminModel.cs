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
        public IUnitOfWork UnitOfWork { get { return unitOfWork; } }
 
        public WarehouseAdminModel(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;

        }
       
    }
}
