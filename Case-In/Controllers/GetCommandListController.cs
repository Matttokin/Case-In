using Case_In.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Case_In.Controllers
{
    public class GetCommandListController : ApiController
    {
        // GET api/values
        public List<InfoCommand> Get()
        {
            List<InfoCommand> lic = new List<InfoCommand>();

            lic.Add(new InfoCommand() { nameCommand = "Нормативные документы", dataCommand = BasicConstants.RegulationsDocs });

            return lic;
        }
    }
}
