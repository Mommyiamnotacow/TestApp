using BOL.DTO;
using BOL.Infrastructure;
using BOL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DateMatchAPI.Controllers
{


    public class ValuesController : ApiController
    {
        IService<IntervalsDTO> intervals;
        IService<LogRecordDTO> log;

        public ValuesController(IService<IntervalsDTO> intervals, IService<LogRecordDTO> log)
        {
            this.intervals = intervals;
            this.log = log;
        }
        // GET api/values
        public IEnumerable<DateRangeUI> Get()
        {
            return intervals.GetAllForUser();
        }

        // GET api/yyyy-mm-dd/yyyy-mm-dd
        public HttpResponseMessage Get(string start, string end)
        {
            //логируем запрос пользователя
            log.Add(new LogRecordDTO
            {
                Time = DateTime.Now,
                Start = Convert.ToDateTime(start),
                End = Convert.ToDateTime(end),
                isRequest = true

            });

            IEnumerable<DateRangeUI> matches = intervals.GetMatches(start, end);
            //логируем ответ пользователю
            foreach (var i in matches)
            {
                log.Add(new LogRecordDTO
                {
                    Time = DateTime.Now,
                    Start = Convert.ToDateTime(i.Start),
                    End = Convert.ToDateTime(i.End),
                    isRequest = false
                });
            }

            return Request.CreateResponse(HttpStatusCode.OK, matches);
        }

        // POST api/yyyy-mm-dd/yyyy-mm-dd
        public HttpResponseMessage Post(string start, string end)
        {
            intervals.Add(new IntervalsDTO
            {
                Start = Convert.ToDateTime(start),
                End = Convert.ToDateTime(end)
            });

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            intervals.Delete(id);
        }
    }
}
