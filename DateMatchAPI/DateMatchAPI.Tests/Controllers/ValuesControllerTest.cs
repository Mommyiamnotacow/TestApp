using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DateMatchAPI;
using DateMatchAPI.Controllers;

namespace DateMatchAPI.Tests.Controllers
{
    [TestClass]
    public class ValuesControllerTest
    {
        [TestMethod]
        public void PostTest()
        {
            DateTime start = Convert.ToDateTime("2019-01-01");
            DateTime end = Convert.ToDateTime("2019-12-31");

            Assert.IsNotNull(start);
            Assert.IsNotNull(end);
        }

       
    }

}
