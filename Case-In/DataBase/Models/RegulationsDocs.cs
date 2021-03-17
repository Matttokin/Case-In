using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Case_In.DataBase.Models
{
    public class RegulationsDoc
    {
        public int Id { get; set; }

        [DisplayName("Название документа")]
        public string NameDocs { get; set; }

        [DisplayName("Ссылка на документ")]
        public string LinkDocs { get; set; }

    }
}