using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Case_In.DataBase.Models
{
    public class CultureImg
    {
        public int Id { get; set; }
        public int CultureId { get; set; }
        public Culture Culture { get; set; }
        public string ImgLink { get; set; }
    }
}