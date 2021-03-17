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

            lic.Add(new InfoCommand() 
            { 
                nameCommand = "Нормативные документы", 
                dataCommand = BasicConstants.RegulationsDocs,
                paramCommand = null
            });

            lic.Add(new InfoCommand()
            {
                nameCommand = "Офисы компании",
                dataCommand = BasicConstants.CompanyOffices,
                paramCommand = null
            });

            lic.Add(new InfoCommand()
            {
                nameCommand = "Информация об офисе",
                dataCommand = BasicConstants.CompanyOfficesInfo,
                paramCommand = "Название офиса"
            });

            lic.Add(new InfoCommand()
            {
                nameCommand = "План офиса",
                dataCommand = BasicConstants.CompanyOfficesPlan,
                paramCommand = "Название офиса"
            });

            return lic;
        }
    }
}
