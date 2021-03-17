using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Case_In.DataBase.Models
{
    public class OfficePlan
    {
        public int Id { get; set; }

        public int OfficeId { get; set; }

        public Office Office { get; set; }

        [DisplayName("Cсылка на картинку")]
        public string imgLink { get; set; }        
    }
}