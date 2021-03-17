using Case_In.DataBase.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Case_In.DataBase
{
    public class ContextDB : DbContext
    {
        public ContextDB()
            : base("DBConnection")
        { }

        public DbSet<RegulationsDoc> RegulationsDocs { get; set; }
        public DbSet<Office> Offices { get; set; }
        public DbSet<OfficePlan> OfficePlans { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<EmployeeTask> EmployeeTasks { get; set; }
        public DbSet<Culture> Cultures { get; set; }
        public DbSet<CultureImg> CultureImgs { get; set; }

    }
}