using BOL.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL.Services
{
    public interface IService<T>
    {
        T Get(int id);
        IEnumerable<T> GetAll();
        void Delete(int id);
        T Add(T entity);
        T Update(T entity);
        //колекция всех дат для пользователей
        IEnumerable<DateRangeUI> GetAllForUser();
        //колекция совпадений для пользователя
        IEnumerable<DateRangeUI> GetMatches(string startDate, string endDate);

    }
}
