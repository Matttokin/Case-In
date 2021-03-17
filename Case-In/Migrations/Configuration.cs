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

            context.Offices.AddOrUpdate(new DataBase.Models.Office() { Id = 1, NameOffice = "Офис 1", AddressOffice = "Михайловская 150А", DescriptionOffice = "Какой-то офис", AddressOfficeOnMap = "https://goo.gl/maps/ybtTY3WeHSPcFRXG6" });
            context.Offices.AddOrUpdate(new DataBase.Models.Office() { Id = 2, NameOffice = "Офис 22", AddressOffice = "Михайловская 1уц50А", DescriptionOffice = "Какой-то офиуаус", AddressOfficeOnMap = "https://goo.gl/maps/ybtTY3WeHSPcFRXG6" });
            context.Offices.AddOrUpdate(new DataBase.Models.Office() { Id = 3, NameOffice = "Офис 33", AddressOffice = "Михайловская 15цуц0А", DescriptionOffice = "Какой-тов34343 офис", AddressOfficeOnMap = "https://goo.gl/maps/ybtTY3WeHSPcFRXG6" });

            context.OfficePlans.AddOrUpdate(new DataBase.Models.OfficePlan() { Id = 1, OfficeId = 1, imgLink = "https://studme.org/htm/img/15/2901/112.png" });
            context.OfficePlans.AddOrUpdate(new DataBase.Models.OfficePlan() { Id = 2, OfficeId = 1, imgLink = "https://photogrammetria.ru/uploads/posts/2013-01/1358890267_oforml_plan_02.jpg" });
            context.OfficePlans.AddOrUpdate(new DataBase.Models.OfficePlan() { Id = 3, OfficeId = 2, imgLink = "https://www.exprof-rf.ru/images/uploads/802-kadastrovie-raboti-v-barnaule-e1475253647512.jpg" });
            context.OfficePlans.AddOrUpdate(new DataBase.Models.OfficePlan() { Id = 4, OfficeId = 3, imgLink = "https://ce-na.ru/upload/iblock/afb/afb01ea6b753ae90a6ccf14126d36bc6.jpg" });

            context.Cultures.AddOrUpdate(new DataBase.Models.Culture() { Id = 1, DataRow = "Компания была создана ршщвацщрарцрацартщу"});
            context.Cultures.AddOrUpdate(new DataBase.Models.Culture() { Id = 2, DataRow = "Заводцлзрйцуриаитцщуа" });
            context.Cultures.AddOrUpdate(new DataBase.Models.Culture() { Id = 3, DataRow = "персонал ыврощращцуа" });
            context.Cultures.AddOrUpdate(new DataBase.Models.Culture() { Id = 4, DataRow = "аурцуцауцрагуцра" });

            context.CultureImgs.AddOrUpdate(new DataBase.Models.CultureImg() { Id = 1,  CultureId = 1, ImgLink = "https://studme.org/htm/img/15/2901/112.png" });
            context.CultureImgs.AddOrUpdate(new DataBase.Models.CultureImg() { Id = 2, CultureId = 1, ImgLink = "https://www.exprof-rf.ru/images/uploads/802-kadastrovie-raboti-v-barnaule-e1475253647512.jpg" });
            context.CultureImgs.AddOrUpdate(new DataBase.Models.CultureImg() { Id = 3, CultureId = 2, ImgLink = "https://ce-na.ru/upload/iblock/afb/afb01ea6b753ae90a6ccf14126d36bc6.jpg" });

            context.Posts.AddOrUpdate(new DataBase.Models.Post() { Id = 1, NamePost = "Директор директоров" });
            context.Posts.AddOrUpdate(new DataBase.Models.Post() { Id = 2, NamePost = "Старший менеджер" });
            context.Posts.AddOrUpdate(new DataBase.Models.Post() { Id = 3, NamePost = "Администратор" });


            context.Users.AddOrUpdate(new DataBase.Models.User() { Id = 1, NameUser = "Токин И.О.", DateBirth = DateTime.Parse("28.02.2000"), DateStartWork = DateTime.Parse("15.02.2020"),Salary = 100000, PostId = 1});
            context.Users.AddOrUpdate(new DataBase.Models.User() { Id = 2, NameUser = "Иванов И.И.", DateBirth = DateTime.Parse("28.02.2010"), DateStartWork = DateTime.Parse("15.02.2010"), Salary = 90000, PostId = 2});
            context.Users.AddOrUpdate(new DataBase.Models.User() { Id = 3, NameUser = "Токин И.О.", DateBirth = DateTime.Parse("28.02.2003"), DateStartWork = DateTime.Parse("15.02.2028"), Salary = 13000, PostId = 3});

            context.EmployeeTasks.AddOrUpdate(new DataBase.Models.EmployeeTask() { Id = 1, UserId = 1, NameTask = "Задача 1", DateStart = DateTime.Parse("28.02.2003"), DateFinish = DateTime.Parse("28.02.2003") });
            context.EmployeeTasks.AddOrUpdate(new DataBase.Models.EmployeeTask() { Id = 2, UserId = 1, NameTask = "Задача 2", DateStart = DateTime.Parse("28.02.2003"), DateFinish = DateTime.Parse("28.02.2003") });
            context.EmployeeTasks.AddOrUpdate(new DataBase.Models.EmployeeTask() { Id = 3, UserId = 1, NameTask = "Задача 3", DateStart = DateTime.Parse("28.02.2003") });
            context.EmployeeTasks.AddOrUpdate(new DataBase.Models.EmployeeTask() { Id = 4, UserId = 1, NameTask = "Задача 4", DateStart = DateTime.Parse("28.02.2003"), DateFinish = DateTime.Parse("28.02.2003") });
            context.EmployeeTasks.AddOrUpdate(new DataBase.Models.EmployeeTask() { Id = 5, UserId = 2, NameTask = "Задача 5", DateStart = DateTime.Parse("28.02.2003"), DateFinish = DateTime.Parse("28.02.2003") });
            context.SaveChanges();
        }
        public void startSeed()
        {
            Seed(new ContextDB());
        }
    }
}
