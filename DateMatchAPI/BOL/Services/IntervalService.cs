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
    public class IntervalService : IService<IntervalsDTO>
    {
        IRepository<Intervals> repo;

        public IntervalService(IRepository<Intervals> repo)
        {
            this.repo = repo;
        }
        public IntervalsDTO Add(IntervalsDTO entity)
        {
            Intervals interval = new Intervals
            {
                Start = entity.Start,
                End = entity.End
            };
            repo.Create(interval);
            return entity;
        }

        public void Delete(int id)
        {
            repo.Delete(id);
        }

        public IntervalsDTO Get(int id)
        {
            IntervalsDTO interval = new IntervalsDTO
            {
                ID = repo.Get(id).ID,
                Start = repo.Get(id).Start,
                End = repo.Get(id).End
            };
            return interval;
        }

        public IEnumerable<IntervalsDTO> GetAll()
        {
            return repo.GetAll().Select(x => new IntervalsDTO
            {
                ID = x.ID,
                Start = x.Start,
                End = x.End
            });
        }
        //колекция для пользователя без id
        public IEnumerable<DateRangeUI> GetAllForUser()
        {
            return repo.GetAll().Select(x => new DateRangeUI
            {
                Start = x.Start.Date.ToShortDateString(),
                End = x.End.Date.ToShortDateString()
            });
        }
        //колекция совпадений запроса
        public IEnumerable<DateRangeUI> GetMatches(string startDate, string endDate)
        {
            DateTime start = Convert.ToDateTime(startDate);
            DateTime end = Convert.ToDateTime(endDate);

            List<DateRangeUI> list = new List<DateRangeUI>();
            foreach (var i in repo.GetAll())
            {
                if ((start >= i.Start && start <= i.End) || (end >= i.Start && end <= i.End))
                    list.Add(new DateRangeUI
                    {
                        Start = i.Start.Date.ToShortDateString(),
                        End = i.End.Date.ToShortDateString()
                    });
            }
            return list;
        }

        public IntervalsDTO Update(IntervalsDTO entity)
        {
            Intervals interval = new Intervals
            {
                ID = entity.ID,
                Start = entity.Start,
                End = entity.End
            };
            repo.Update(interval);
            return entity;
        }
    }
}
