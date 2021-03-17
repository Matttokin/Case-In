using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Case_In.DataBase.Models
{
    public class EmployeeTask
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        [DisplayName("Название задачи")]
        public string NameTask { get; set; }

        [DisplayName("Дата начала выполнения")]
        public DateTime DateStart { get; set; }

        [DisplayName("Дата окончания выполнения")]
        public DateTime? DateFinish { get; set; }
    }
}