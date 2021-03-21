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
                string[] helloArr = new string[]
                {
                    "привет", "здравствуй", "здравствуйте", "hello","hi"
                };
                string[] helpArr = new string[]
                {
                    "помощь", "инструкция", "manual", "руководство"
                };

                if (helloArr.Contains(text.ToLower()))
                {
                    outMessage = "Приветствую Вас";
                }
                else if (helpArr.Contains(text.ToLower()))
                {
                    outMessage = "Чтобы получить интересующую информацию, нажмите на соответствующую кнопку и следуйте инструкциям";
                }
                else
                {
                    return new BackJSON()
                    {
                        result = false,
                        errorMes = "Бот не умеет отвечать на такие сообщения"
                    };
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
