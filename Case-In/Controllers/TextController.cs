using Case_In.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Case_In.Controllers
{
    public class TextController : ApiController
    {
        public BackJSON Post(string text)
        {
            try
            {

                BackJSON backJSON;
                List<DataStruct> lds = new List<DataStruct>();
                string outMessage = "";
                switch (text)
                {
                    case "Привет": outMessage = "Приветствую Вас";
                        break;

                    default:
                        return new BackJSON()
                        {
                            result = false,
                            errorMes = "Бот не умеет отвечать на такие сообщения"
                        };
                        return backJSON;

                }

                lds.Add(new DataStruct()
                {
                    data = outMessage,
                    type = BasicType.text
                });
                backJSON = new BackJSON()
                {
                    result = true,
                    listData = lds,
                    listCommand = null
                };
                return backJSON;
            }
            catch
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
