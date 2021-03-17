using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Case_In.DataBase.Models
{
    public class User
    {
        public int Id { get; set; }

        [DisplayName("ФИО")]
        public string NameUser { get; set; }

        [DisplayName("Дата рождения")]
        public DateTime DateBirth { get; set; }

        [DisplayName("Дата выхода на работу")]
        public DateTime DateStartWork { get; set; }

        [DisplayName("ЗП")]
        public decimal Salary { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}