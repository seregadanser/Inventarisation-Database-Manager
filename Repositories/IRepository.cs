using DB_course.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_course.Repositories
{
    public interface IRepository<T> : IDisposable where T : class
    {
        public WarehouseContext DB {set;}
        IEnumerable<T> GetList(); // получение всех объектов
        IEnumerable<T> Get(string value); // получение одного объекта по id
        void Create(T item); // создание объекта
        void Update(T item); // обновление объекта
        void Delete(int id); // удаление объекта по id
        void Save();  // сохранение изменений

        
    }
}
