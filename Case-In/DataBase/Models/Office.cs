using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Case_In.DataBase.Models
{
    public class Office
    {        
        public int Id { get; set; }

        [DisplayName("Название офиса")]
        public string NameOffice { get; set; }

        [DisplayName("Описание офиса")]
        public string DescriptionOffice { get; set; }

        [DisplayName("Адрес офиса")]
        public string AddressOffice { get; set; }

        [DisplayName("Адрес офиса на карте")]
        public string AddressOfficeOnMap { get; set; }
    }
}