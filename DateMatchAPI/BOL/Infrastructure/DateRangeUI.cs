using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL.Infrastructure
{
    //юзеру не обязательно знать об айди, будем использовать класс ориентированый
    //для отображения данных пользователю (UserIntarface)
    public class DateRangeUI
    {
        public string Start { get; set; }
        public string End { get; set; }
    }
}
