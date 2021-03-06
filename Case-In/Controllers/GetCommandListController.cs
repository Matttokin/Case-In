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
        public List<InfoCommand> Get(bool isAuth)
        {
            
            List<InfoCommand> lic = new List<InfoCommand>();

            lic.Add(new InfoCommand() 
            { 
                nameCommand = "Нормативные документы", 
                dataCommand = BasicConstants.RegulationsDocs,
                paramCommand = null,
                canUseWithoutChat = true
            });

            lic.Add(new InfoCommand()
            {
                nameCommand = "Офисы компании",
                dataCommand = BasicConstants.CompanyOffices,
                paramCommand = null,
                canUseWithoutChat = true
            });

            lic.Add(new InfoCommand()
            {
                nameCommand = "Информация об офисе",
                dataCommand = BasicConstants.CompanyOfficesInfo,
                paramCommand = "Название офиса",
                canUseWithoutChat = false
            });

            lic.Add(new InfoCommand()
            {
                nameCommand = "План офиса",
                dataCommand = BasicConstants.CompanyOfficesPlan,
                paramCommand = "Название офиса",
                canUseWithoutChat = false
            });

            lic.Add(new InfoCommand()
            {
                nameCommand = "Корпоративная культура",
                dataCommand = BasicConstants.CultureInfo,
                paramCommand = "1",
                canUseWithoutChat = true
            });
            if (isAuth)
            {
                lic.Add(new InfoCommand()
                {
                    nameCommand = "О себе",
                    dataCommand = BasicConstants.UserInfo,
                    paramCommand = "JSON",
                    canUseWithoutChat = true
                });
            } else
            {
                lic.Add(new InfoCommand()
                {
                    nameCommand = "Авторизоваться",
                    dataCommand = BasicConstants.Authorization,
                    paramCommand = "JSON",
                    canUseWithoutChat = false
                });
            }

            return lic;
        }
    }
}
