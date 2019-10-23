using ConsoleWebAPI.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleWebAPI.WebAPI
{
    class WebApi
    {
        public string Start { get; set; }
        public string End { get; set; }
        static HttpClient httpClient = new HttpClient();
        Logger logger = new Logger();

        public WebApi(string start, string end)
        {
            Start = start;
            End = end;
        }

        public async Task<bool> WriteToDBAsync(string uri)
        {
            var res = await httpClient.PostAsync($"{uri}{Start}/{End}",null);
            Log newLog = new Log()
            {
                Time = DateTime.Now,
                Start = this.Start,
                End = this.End,
                isRequest = false
            };
            logger.InsertLog(newLog);
            logger.SaveChanges();            
            return true;
        }

        public async Task<Dictionary<string, string>> GetMatchesAsync(string uri)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();

            var responseString = await httpClient.GetStringAsync($"{uri}{Start}/{End}");

            dynamic stuff = JsonConvert.DeserializeObject(responseString);

            foreach (var i in stuff)
            {
                result.Add(i.From.ToString(), i.To.ToString());
            }

            Log log = new Log()
            {
                Time = DateTime.Now,
                Start = this.Start,
                End = this.End,
                isRequest = false
            };
            logger.InsertLog(log);
            logger.SaveChanges();

            return result;
        }

    }
}
