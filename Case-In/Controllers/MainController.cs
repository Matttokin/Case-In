using Case_In.Classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Case_In.Controllers
{
    public class MainController : ApiController
    {
        public string Post(string json)
        {
            FrontJSON fj = JsonConvert.DeserializeObject<FrontJSON>(json);

            return fj.mainCommand;
        }
    }
}
