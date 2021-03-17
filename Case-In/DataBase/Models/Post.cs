using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Case_In.DataBase.Models
{
    public class Post
    {
        public int Id { get; set; }

        [DisplayName("Название должности")]
        public string NamePost { get; set; }
    }
}