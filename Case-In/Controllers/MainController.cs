using Case_In.Classes;
using Case_In.DataBase;
using Case_In.DataBase.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            try
            {
                FrontJSON fj = JsonConvert.DeserializeObject<FrontJSON>(json);
                ContextDB context = new ContextDB();
                BackJSON backJSON;
                string[] authArr;
                List<DataStruct> lds = new List<DataStruct>();
                List<InfoCommand> lic = new List<InfoCommand>();
                switch (fj.mainCommand)
                {
                    case BasicConstants.RegulationsDocs:
                        var regulationsDocsList = context.RegulationsDocs;

                        foreach (RegulationsDoc doc in regulationsDocsList)
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

                    //case BasicConstants.SecurityPolicy:

                    //    backJSON = new BackJSON()
                    //    {
                    //        result = true,
                    //        listData = lds,
                    //        listCommand = null
                    //    };
                    //    return backJSON;


                    case BasicConstants.CompanyOffices:
                        var OfficeList = context.Offices;

                        foreach (Office doc in OfficeList)
                        {
                            lds.Add(new DataStruct()
                            {
                                data = doc.AddressOffice,
                                type = BasicType.text,
                                alias = doc.NameOffice
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
                        var OfficeInfo = context.Offices.FirstOrDefault(x => x.NameOffice.Equals(fj.param.Trim())) ;


                        if (OfficeInfo == null) return new BackJSON()
                        {
                            result = false,
                            errorMes = "Офис не найден"
                        };

                        lds.Add(new DataStruct()
                        {
                            data = OfficeInfo.NameOffice,
                            type = BasicType.text,
                            alias = "Название: "
                        });

                        lds.Add(new DataStruct()
                        {
                            data = OfficeInfo.AddressOffice,
                            type = BasicType.text,
                            alias = "Адрес: "
                        });

                        lds.Add(new DataStruct()
                        {
                            data = OfficeInfo.DescriptionOffice,
                            type = BasicType.text,
                            alias = "Описание: "
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
                        var OfficeInfoPlan = context.Offices.FirstOrDefault(x => x.NameOffice.Equals(fj.param.Trim()));
                        if (OfficeInfoPlan == null) return new BackJSON()
                        {
                            result = false,
                            errorMes = "Офис не найден"
                        };

                        var listPlan = context.OfficePlans.Where(x => x.OfficeId == OfficeInfoPlan.Id);
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

                    case BasicConstants.CultureInfo:
                        int idRow = 0;
                        if (!int.TryParse(fj.param, out idRow)) return new BackJSON()
                        {
                            result = false,
                            errorMes = "Ошибочный номер страницы"
                        };

                        var CultureInfo = context.Cultures.FirstOrDefault(x => x.Id == idRow);
                        if (CultureInfo == null) return new BackJSON()
                        {
                            result = false,
                            errorMes = "Данные не найдены"
                        };

                        lds.Add(new DataStruct()
                        {
                            data = CultureInfo.DataRow,
                            type = BasicType.text
                        });

                        var CultureInfoImg = context.CultureImgs.Where(x => x.CultureId == CultureInfo.Id);

                        foreach (CultureImg ci in CultureInfoImg)
                        {
                            lds.Add(new DataStruct()
                            {
                                data = ci.ImgLink,
                                type = BasicType.img
                            });
                        }

                        var countRow = context.Cultures.Count();

                        if (idRow < countRow && idRow > 0)
                        {
                            lic.Add(new InfoCommand()
                            {
                                nameCommand = "Далее",
                                dataCommand = BasicConstants.CultureInfo,
                                paramCommand = (idRow + 1).ToString(),
                                canUseWithoutChat = true
                            });
                        }

                        /*if (idRow <= countRow && idRow > 1)
                        {
                            lic.Add(new InfoCommand()
                            {
                                nameCommand = "Назад",
                                dataCommand = BasicConstants.CultureInfo,
                                paramCommand = (idRow - 1).ToString(),
                                canUseWithoutChat = true
                            });
                        }*/


                        backJSON = new BackJSON()
                        {
                            result = true,
                            listData = lds,
                            listCommand = lic
                        };
                        return backJSON;

                    case BasicConstants.UserInfo:
                        authArr = fj.param.Split(' ');
                        var loginUserInfo = authArr[0];
                        var passwordUserInfo = authArr[1];
                        var UserInfo = context.Users.Include(u => u.Post).FirstOrDefault(x => x.Login.Equals(loginUserInfo) && x.Password.Equals(passwordUserInfo));
                        if (UserInfo == null) return new BackJSON()
                        {
                            result = false,
                            errorMes = "Пользователь не найден"
                        };

                        lds.Add(new DataStruct()
                        {
                            data = UserInfo.NameUser,
                            type = BasicType.text,
                            alias = "ФИО: "
                        });

                        lds.Add(new DataStruct()
                        {
                            data = UserInfo.DateBirth.ToString("D"),
                            type = BasicType.text,
                            alias = "Дата рождения: "
                        });

                        lds.Add(new DataStruct()
                        {
                            data = UserInfo.DateStartWork.ToString("D"),
                            type = BasicType.text,
                            alias = "Дата начала работы: "
                        });

                        lds.Add(new DataStruct()
                        {
                            data = UserInfo.Salary.ToString(),
                            type = BasicType.text,
                            alias = "Оклад: "
                        });

                        lds.Add(new DataStruct()
                        {
                            data = UserInfo.Post.NamePost.ToString(),
                            type = BasicType.text,
                            alias = "Должность:"
                        });



                        var EmployeeTasksCount = context.EmployeeTasks.Where(x => x.UserId == UserInfo.Id && x.DateFinish != null).Count();

                        lds.Add(new DataStruct()
                        {
                            data = EmployeeTasksCount.ToString(),
                            type = BasicType.text,
                            alias = "Количество выполненых заданий: "
                        });






                        backJSON = new BackJSON()
                        {
                            result = true,
                            listData = lds,
                            listCommand = null
                        };
                        return backJSON;

                    case BasicConstants.Authorization:
                        authArr = fj.param.Split(' ');
                        var loginAuthorization = authArr[0];
                        var passwordAuthorization = authArr[1];

                        var UserInfoAuth = context.Users.FirstOrDefault(x => x.Login.Equals(loginAuthorization) && x.Password.Equals(passwordAuthorization));
                        if (UserInfoAuth == null)
                        {
                            return new BackJSON()
                            {
                                result = false,
                                errorMes = "Неверный логин или пароль"
                            };
                        } else
                        {
                            lds.Add(new DataStruct()
                            {
                                data = "Пользователь авторизован",
                                type = BasicType.text
                            });
                            return new BackJSON()
                            {
                                result = true,
                                listData = lds

                            };
                        }

                    default: return new BackJSON()
                    {
                        result = false,
                        errorMes = "Неизвестная команда"
                    };

                }
        } catch
            {
                return new BackJSON()
        {
            result = false,
                    errorMes = "Ошибка сервера"
                };
    }
} 

    } 
}
