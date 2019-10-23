using BOL.DTO;
using BOL.Infrastructure;
using DAL.Context;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL.Services
{
    public class LogRecordsService : IService<LogRecordDTO>
    {
        IRepository<LogRecords> repo;
        public LogRecordsService(IRepository<LogRecords> repo)
        {
            this.repo = repo;
        }
        public LogRecordDTO Add(LogRecordDTO entity)
        {
            LogRecords log = new LogRecords
            {
                Time = entity.Time,
                Start = entity.Start,
                End = entity.End,
                isRequest = entity.isRequest
            };
            repo.Create(log);
            return entity;
        }

        public void Delete(int id)
        {
            repo.Delete(id);
        }

        public LogRecordDTO Get(int id)
        {
            LogRecordDTO logdto = new LogRecordDTO
            {
                ID = repo.Get(id).ID,
                Time = repo.Get(id).Time,
                Start = repo.Get(id).Start,
                End = repo.Get(id).End,
                isRequest = repo.Get(id).isRequest
            };
            return logdto;
        }

        public IEnumerable<LogRecordDTO> GetAll()
        {
            return repo.GetAll().Select(x => new LogRecordDTO
            {
                ID = x.ID,
                Time = x.Time,
                Start = x.Start,
                End = x.End,
                isRequest = x.isRequest
            });
        }

        public IEnumerable<DateRangeUI> GetAllForUser()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DateRangeUI> GetMatches(string startDate, string endDate)
        {
            throw new NotImplementedException();
        }

        public LogRecordDTO Update(LogRecordDTO entity)
        {
            LogRecords log = new LogRecords
            {
                ID = entity.ID,
                Time = entity.Time,
                Start = entity.Start,
                End = entity.End,
                isRequest = entity.isRequest
            };
            repo.Update(log);
            return entity;
        }
    }
}
