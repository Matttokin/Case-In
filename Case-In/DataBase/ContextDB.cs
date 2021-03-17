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
        public DbSet<Office> Office { get; set; }
        public DbSet<OfficePlan> OfficePlan { get; set; }

    }
}