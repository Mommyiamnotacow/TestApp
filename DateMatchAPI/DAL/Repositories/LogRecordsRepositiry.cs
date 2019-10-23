using DAL.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class LogRecordsRepositiry : IRepository<LogRecords>
    {
        DateMatchDB db = new DateMatchDB();

        public void Create(LogRecords newEntity)
        {
            db.LogRecords.Add(newEntity);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            db.LogRecords.Remove(Get(id));
            db.SaveChanges();
        }

        public LogRecords Get(int id)
        {
            return db.LogRecords.Find(id);
        }

        public IEnumerable<LogRecords> GetAll()
        {
            return db.LogRecords.ToList();
        }

        public void Update(LogRecords newEntity)
        {
            db.LogRecords.AddOrUpdate(newEntity);
            db.SaveChanges();
        }
    }
}
