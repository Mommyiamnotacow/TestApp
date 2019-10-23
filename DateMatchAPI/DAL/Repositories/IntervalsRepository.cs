using DAL.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class IntervalsRepository : IRepository<Intervals>
    {
        DateMatchDB db = new DateMatchDB();

        public void Create(Intervals newEntity)
        {
            db.Intervals.Add(newEntity);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            db.Intervals.Remove(Get(id));
            db.SaveChanges();
        }

        public Intervals Get(int id)
        {
            return db.Intervals.Find(id);
        }

        public IEnumerable<Intervals> GetAll()
        {
            return db.Intervals.ToList();
        }

        public void Update(Intervals newEntity)
        {
            db.Intervals.AddOrUpdate(newEntity);
            db.SaveChanges();
        }
    }
}
