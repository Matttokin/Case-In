namespace Case_In.Migrations
{
    using Case_In.DataBase;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Case_In.DataBase.ContextDB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Case_In.DataBase.ContextDB";
        }

        protected override void Seed(Case_In.DataBase.ContextDB context)
        {
            context.RegulationsDocs.AddOrUpdate(new DataBase.Models.RegulationsDoc() { Id = 1, NameDocs = "ТестовыйДокумент 1", LinkDocs = "https://vk.com/im" });
            context.RegulationsDocs.AddOrUpdate(new DataBase.Models.RegulationsDoc() { Id = 2, NameDocs = "ТестовыйДокумент 22", LinkDocs = "https://www.google.ru/" });
            context.RegulationsDocs.AddOrUpdate(new DataBase.Models.RegulationsDoc() { Id = 3, NameDocs = "ТестовыйДокумент 333", LinkDocs = "https://yandex.ru/" });

            context.Office.AddOrUpdate(new DataBase.Models.Office() { Id = 1, NameOffice = "Офис 1", AddressOffice = "Михайловская 150А", DescriptionOffice = "Какой-то офис", AddressOfficeOnMap = "https://goo.gl/maps/ybtTY3WeHSPcFRXG6" });
            context.Office.AddOrUpdate(new DataBase.Models.Office() { Id = 2, NameOffice = "Офис 22", AddressOffice = "Михайловская 1уц50А", DescriptionOffice = "Какой-то офиуаус", AddressOfficeOnMap = "https://goo.gl/maps/ybtTY3WeHSPcFRXG6" });
            context.Office.AddOrUpdate(new DataBase.Models.Office() { Id = 3, NameOffice = "Офис 33", AddressOffice = "Михайловская 15цуц0А", DescriptionOffice = "Какой-тов34343 офис", AddressOfficeOnMap = "https://goo.gl/maps/ybtTY3WeHSPcFRXG6" });

            context.OfficePlan.AddOrUpdate(new DataBase.Models.OfficePlan() { Id = 1, OfficeId = 1, imgLink = "https://studme.org/htm/img/15/2901/112.png" });
            context.OfficePlan.AddOrUpdate(new DataBase.Models.OfficePlan() { Id = 2, OfficeId = 1, imgLink = "https://photogrammetria.ru/uploads/posts/2013-01/1358890267_oforml_plan_02.jpg" });
            context.OfficePlan.AddOrUpdate(new DataBase.Models.OfficePlan() { Id = 3, OfficeId = 2, imgLink = "https://www.exprof-rf.ru/images/uploads/802-kadastrovie-raboti-v-barnaule-e1475253647512.jpg" });
            context.OfficePlan.AddOrUpdate(new DataBase.Models.OfficePlan() { Id = 4, OfficeId = 3, imgLink = "https://ce-na.ru/upload/iblock/afb/afb01ea6b753ae90a6ccf14126d36bc6.jpg" });

            context.SaveChanges();
        }
        public void startSeed()
        {
            Seed(new ContextDB());
        }
    }
}
