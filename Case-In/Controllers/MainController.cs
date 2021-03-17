using Case_In.Classes;
using Case_In.DataBase;
using Case_In.DataBase.Models;
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
        public BackJSON Post(string json)
        {
            FrontJSON fj = JsonConvert.DeserializeObject<FrontJSON>(json);
            ContextDB context = new ContextDB();
            BackJSON backJSON;
            List<DataStruct> lds = new List<DataStruct>();
            switch (fj.mainCommand)
            {
                case BasicConstants.RegulationsDocs:                    
                    var regulationsDocsList = context.RegulationsDocs;
                                        
                    foreach(RegulationsDoc doc in regulationsDocsList)
                    {
                        lds.Add(new DataStruct() 
                        { 
                            data = doc.LinkDocs, 
                            type = BasicType.link, 
                            alias = doc.NameDocs 
                        });
                    }

                    backJSON = new BackJSON()
                    {
                        result = true,
                        listData = lds,
                        listCommand = null
                    };
                    return backJSON;


                case BasicConstants.CompanyOffices:
                    var OfficeList = context.Office;
                                        
                    foreach (Office doc in OfficeList)
                    {
                        lds.Add(new DataStruct()
                        {
                            data = doc.NameOffice + " " + doc.AddressOffice,
                            type = BasicType.link
                        });
                    }

                    backJSON = new BackJSON()
                    {
                        result = true,
                        listData = lds,
                        listCommand = null
                    };
                    return backJSON;

                case BasicConstants.CompanyOfficesInfo:
                    var OfficeInfo = context.Office.FirstOrDefault(x => x.NameOffice.Equals(fj.param));
                    if (OfficeInfo == null) return new BackJSON()
                    {
                        result = false,
                        errorMes = "Офис не найден"
                    };

                    lds.Add(new DataStruct()
                    {
                        data = OfficeInfo.NameOffice,
                        type = BasicType.text
                    });

                    lds.Add(new DataStruct()
                    {
                        data = OfficeInfo.AddressOffice,
                        type = BasicType.text
                    });

                    lds.Add(new DataStruct()
                    {
                        data = OfficeInfo.DescriptionOffice,
                        type = BasicType.text
                    });

                    lds.Add(new DataStruct()
                    {
                        data = OfficeInfo.AddressOfficeOnMap,
                        type = BasicType.link,
                        alias = "Показать на карте"
                    });

                    backJSON = new BackJSON()
                    {
                        result = true,
                        listData = lds,
                        listCommand = null
                    };
                    return backJSON;

                case BasicConstants.CompanyOfficesPlan:
                    var OfficeInfoPlan = context.Office.FirstOrDefault(x => x.NameOffice.Equals(fj.param));
                    if (OfficeInfoPlan == null) return new BackJSON()
                    {
                        result = false,
                        errorMes = "Офис не найден"
                    };

                    var listPlan = context.OfficePlan.Where(x => x.OfficeId == OfficeInfoPlan.Id);
                    foreach (OfficePlan doc in listPlan)
                    {
                        lds.Add(new DataStruct()
                        {
                            data = doc.imgLink,
                            type = BasicType.img
                        });
                    }

                    backJSON = new BackJSON()
                    {
                        result = true,
                        listData = lds,
                        listCommand = null
                    };
                    return backJSON;

                default: return new BackJSON()
                { 
                    result = false,
                    errorMes = "Неизвестная команда"
                };

            }            
        }
    }
}
