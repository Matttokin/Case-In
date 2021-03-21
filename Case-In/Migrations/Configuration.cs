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
            context.RegulationsDocs.AddOrUpdate(new DataBase.Models.RegulationsDoc() { Id = 1, NameDocs = "Приказ от 11.07.2016 №1/618-П «Об утверждении Плана противодействия коррупции Государственной корпорации по атомной энергии «Росатом» на 2016 - 2017 годы»", 
                LinkDocs = "https://rosatom.ru/upload/iblock/4a1/4a1a5813e291ebfa9fa873390a403d4f.docx"
            });
            context.RegulationsDocs.AddOrUpdate(new DataBase.Models.RegulationsDoc() { Id = 2, NameDocs = "Приказ от 25.06.2013 № 1/666-П «Об утверждении перечня должностей Госкорпорации «Росатом», при назначении на которые граждане и при замещении которых работники Госкорпорации «Росатом» обязаны представлять сведения о своих доходах..»", 
                LinkDocs = "https://rosatom.ru/upload/iblock/8f7/8f7356a3f80f522a302bb01d368a13d4.docx"
            });
            context.RegulationsDocs.AddOrUpdate(new DataBase.Models.RegulationsDoc() { Id = 3, NameDocs = "Приказ от 25.06.2013 № 1/676-П «О мерах по реализации отдельных положений Указов Президента РФ от 02.04.2013 № 309 и № 310»", 
                LinkDocs = "https://rosatom.ru/upload/iblock/165/1658dc8fec40636aab2d78a5e435ada8.docx"
            });
            context.RegulationsDocs.AddOrUpdate(new DataBase.Models.RegulationsDoc() { Id = 4, NameDocs = "Приказ от 25.06.2013 № 1/677-П «Об определении в Госкорпорации «Росатом» подразделения по профилактике коррупционных и иных правонарушений» (в редакции приказа Госкорпорации «Росатом» от 27.01.2015 № 1/47-П)", 
                LinkDocs = "https://rosatom.ru/upload/iblock/a39/a39a757b9e0cc9dd02579a57b1aafe1d.doc"
            });
            context.RegulationsDocs.AddOrUpdate(new DataBase.Models.RegulationsDoc() { Id = 5, NameDocs = "Приказ от 20.09.2013 №1/2-НПА «Об утверждении Положения о порядке проведения антикоррупционной экспертизы нормативных правовых актов и проектов нормативных правовых актов Госкорпорации «Росатом»", 
                LinkDocs = "https://rosatom.ru/upload/iblock/683/6838ba36e6ca35eb4a30b9a14927773d.docx"
            });
            context.RegulationsDocs.AddOrUpdate(new DataBase.Models.RegulationsDoc() { Id = 6, NameDocs = "Приказ от 18.10.2013 №1/8-НПА «Об утверждении Порядка уведомления работниками Госкорпорации «Росатом» работодателя о фактах обращения каких-либо лиц в целях склонения к совершению коррупционных правонарушений, организации проверки этих сведений ... »", 
                LinkDocs = "https://rosatom.ru/upload/iblock/7a8/7a8b7b8a7154887ad67656b2fc6a3a88.docx"
            });
            context.RegulationsDocs.AddOrUpdate(new DataBase.Models.RegulationsDoc() { Id = 7, NameDocs = "Приказ от 18.04.2014 №1/378-П «О мерах по реализации Указа Президента Российской Федерации от 08.07.2013 № 613 «Вопросы противодействия коррупции»", 
                LinkDocs = "https://rosatom.ru/upload/iblock/49b/49bdab2721fcdc1a11956caaeda76730.docx"
            });

            context.Offices.AddOrUpdate(new DataBase.Models.Office() { 
                Id = 1, 
                NameOffice = "Аварийно-технический центр Минатома России, ФГУП", 
                AddressOffice = "3-й Верхний пер., 2, Санкт-Петербург, 194292", 
                DescriptionOffice = "Аварийно-технический центр Минатома России создан для организации и проведения аварийно-спасательных и других неотложных работ при радиационных авариях и инцидентах. Входит в состав российской системы предупреждения и ликвидации чрезвычайных ситуаций. ", 
                AddressOfficeOnMap = "https://goo.gl/maps/5M2QMdNg7GyBDsiw9" 
            });

            context.Offices.AddOrUpdate(new DataBase.Models.Office() { 
                Id = 2, 
                NameOffice = "АКМЭ-инжиниринг, АО", 
                AddressOffice = "ул. Пятницкая, д. 13 стр.1, Москва, 115035", 
                DescriptionOffice = "Совместное предприятие Госкорпорации «Росатом» и одной из крупнейших энергетических компаний России - ПАО «Иркутскэнерго». Создано для совместной разработки и дальнейшей коммерциализации технологии свинцово-висмутового реактора на быстрых нейтронах (СВБР). ", 
                AddressOfficeOnMap = "https://goo.gl/maps/HsrRi89yVZq8s7NF9"
            });

            context.Offices.AddOrUpdate(new DataBase.Models.Office() { 
                Id = 3, 
                NameOffice = "Ангарский электролизный химический комбинат (АЭХК), АО", 
                AddressOffice = "Ангарск, Иркутская обл., 665830", 
                DescriptionOffice = "Какой-тов34343 офис", 
                AddressOfficeOnMap = "https://goo.gl/maps/MCj9HJYbYrHxNvQy7"
            });

            context.Offices.AddOrUpdate(new DataBase.Models.Office()
            {
                Id = 4,
                NameOffice = "Атом-охрана, Ведомственная охрана Росатома, АО",
                AddressOffice = "ул. Расплетина, 3, Москва, 123060",
                DescriptionOffice = "Специализированная отраслевая охранная компания. Обеспечивает охрану предприятий, сохранность ядерных материалов и установок. Имеет широкую сеть филиалов по всей России с общей численностью 5000 человек.",
                AddressOfficeOnMap = "https://goo.gl/maps/8ZVm4ot49ZpPhbgm6"
            });

            context.Offices.AddOrUpdate(new DataBase.Models.Office()
            {
                Id = 5,
                NameOffice = "Атомкомплект, АО",
                AddressOffice = "ул. Большая Полянка, д.25, стр. 1, Москва, 119180",
                DescriptionOffice = "Акционерное общество \"Атомкомплект\" осуществляет функции уполномоченного органа и организатора проведения процедур закупок организаций Госкорпорации \"Росатом\", пороговое значение начальной (максимальной) цены договора в которых превышает 100 миллионов рублей, и центрального аппарата Госкорпорации \"Росатом\", при значении начальной (максимальной) цены договора свыше 10 миллионов рублей. ",
                AddressOfficeOnMap = "https://goo.gl/maps/19t5php858DPGM6y5"
            });

            context.OfficePlans.AddOrUpdate(new DataBase.Models.OfficePlan() { Id = 1, OfficeId = 1, imgLink = "https://studme.org/htm/img/15/2901/112.png" });
            context.OfficePlans.AddOrUpdate(new DataBase.Models.OfficePlan() { Id = 2, OfficeId = 1, imgLink = "https://photogrammetria.ru/uploads/posts/2013-01/1358890267_oforml_plan_02.jpg" });
            context.OfficePlans.AddOrUpdate(new DataBase.Models.OfficePlan() { Id = 3, OfficeId = 2, imgLink = "https://studme.org/htm/img/15/2901/112.png" });
            context.OfficePlans.AddOrUpdate(new DataBase.Models.OfficePlan() { Id = 4, OfficeId = 3, imgLink = "https://studme.org/htm/img/15/2901/112.png" });
            context.OfficePlans.AddOrUpdate(new DataBase.Models.OfficePlan() { Id = 3, OfficeId = 4, imgLink = "https://studme.org/htm/img/15/2901/112.png" });
            context.OfficePlans.AddOrUpdate(new DataBase.Models.OfficePlan() { Id = 4, OfficeId = 5, imgLink = "https://studme.org/htm/img/15/2901/112.png" });

            context.Cultures.AddOrUpdate(new DataBase.Models.Culture() { Id = 1, DataRow = "Госкорпорация «Росатом» (Государственная корпорация по " +
                "атомной энергии «Росатом») является одним из крупнейших" +
                "многопрофильных холдингов, располагающих активами в энергетике, " +
                "машиностроении и строительстве.Госкорпорация занимает " +
                "лидирующие позиции в области производства электроэнергии в " +
                "России, обеспечивая свыше 19 % энергетических потребностей " +
                "страны.Кроме этого, Госкорпорация обладает значительным " +
                "портфелем международных проектов, благодаря широкому спектру " +
                "компетенций во всех звеньях ядерного топливного цикла: " +
                "геологоразведка и добыча урана, конверсия и обогащение урана, " +
                "фабрикация ядерного топлива, машиностроение, проектирование " +
                "и строительство АЭС, генерация электрической энергии, вывод " +
                "ядерных объектов из эксплуатации, обращение с отработавшим " +
                "ядерным топливом и радиоактивными отходами.Занимает первое " +
                "место в мире по величине портфеля зарубежных проектов, на разной " +
                "стадии реализации находятся 35 энергоблоков в 12 странах."});
            context.Cultures.AddOrUpdate(new DataBase.Models.Culture() { Id = 2, DataRow = "Ключевые показатели деятельности ГК «Росатом»: " +
                "• свыше 333 предприятий и организаций в составе Корпорации; " +
                "• 266,4 тыс.сотрудников; " +
                "• 17 % мирового рынка фабрикации ядерного топлива; " +
                "• выработка электроэнергии на АЭС: 215,746 млрд кВт*ч(208, 784 " +
                "млрд кВт * ч в 2019 году); " +
                "• доля выработки АЭС от выработки электроэнергии в России: " +
                "20,28 % (19, 04 % в 2019 году); " +
                "• 38 % мирового рынка обогащения урана(№1 в мире); " +
                "• портфель зарубежных проектов на 31.12.2020 включал 35 блоков, " +
                "3 атомных энергоблока и ПАТЭС, сооруженных в РФ; " +
                "• единственный в мире атомный ледокольный флот." });

            context.Cultures.AddOrUpdate(new DataBase.Models.Culture() { Id = 3, DataRow = "В функции горнорудного дивизиона входят разведка, добыча и переработка урана. Управляющей компанией российских уранодобывающих активов корпорации является «Атомредметзолото». Главным уранодобывающим предприятием в его составе на протяжении более 40 лет остаётся «Приаргунское производственное горно-химическое объединение», добывающее до 90 % урана в стране[источник не указан 158 дней]. В стадии развития находятся месторождения «Хиагда» в Бурятии и «Далур» в Курганской области. Зарубежные активы управляются компанией Uranium One — канадским холдингом, 100 % акций которого принадлежит «Росатому»[11]. Госкорпорация «Росатом» занимает пятое место в мире по объёму добычи урана и второе — по объёму запасов урана в недрах" });
            context.Cultures.AddOrUpdate(new DataBase.Models.Culture() { Id = 4, DataRow = "Топливный дивизион госкорпорации консолидирует активы, специализирующиеся на конверсии и обогащении урана, и находится под управлением холдинга «ТВЭЛ». В задачи дивизиона входит фабрикация ядерного топлива, конверсия и обогащение урана, а также производство газовых центрифуг. Владея 40 % мировых мощностей, «Росатом» является лидером на мировом рынке услуг по обогащению урана. Обогатительные комбинаты корпорации, находящиеся под управлением объединённой компании «Разделительно-сублиматный комплекс», расположены в Ангарске Иркутской области («Ангарский электролизный химический комбинат»), Зеленогорске Красноярского края (ПО «Электрохимический завод»), Новоуральске Свердловской области(«Уральский электрохимический комбинат») и Северске Томской области(«Сибирский химический комбинат»)" });

            context.CultureImgs.AddOrUpdate(new DataBase.Models.CultureImg() { Id = 1,  CultureId = 1, ImgLink = "https://rosatom.ru/upload/medialibrary/c4b/c4bead5f3fa5836e69163237ea2ee81a.jpg" });
            context.CultureImgs.AddOrUpdate(new DataBase.Models.CultureImg() { Id = 2, CultureId = 1, ImgLink = "https://upload.wikimedia.org/wikipedia/commons/thumb/5/52/Atomagentur1.jpg/800px-Atomagentur1.jpg" });
            context.CultureImgs.AddOrUpdate(new DataBase.Models.CultureImg() { Id = 3, CultureId = 2, ImgLink = "https://www.hibiny.com/images/news/2018/180831/bcb081438dde8babd4ade08c5f5f91d1.jpg" });
            context.CultureImgs.AddOrUpdate(new DataBase.Models.CultureImg() { Id = 4, CultureId = 3, ImgLink = "https://ce-na.ru/upload/iblock/afb/afb01ea6b753ae90a6ccf14126d36bc6.jpg" });
            context.CultureImgs.AddOrUpdate(new DataBase.Models.CultureImg() { Id = 5, CultureId = 4, ImgLink = "https://upload.wikimedia.org/wikipedia/commons/thumb/8/89/RIAN_archive_132603_Nuclear_power_reactor_fuel_assembly.jpg/220px-RIAN_archive_132603_Nuclear_power_reactor_fuel_assembly.jpg" });

            context.Posts.AddOrUpdate(new DataBase.Models.Post() { Id = 1, NamePost = "Директор" });
            context.Posts.AddOrUpdate(new DataBase.Models.Post() { Id = 2, NamePost = "Старший менеджер" });
            context.Posts.AddOrUpdate(new DataBase.Models.Post() { Id = 3, NamePost = "Администратор" });


            context.Users.AddOrUpdate(new DataBase.Models.User() { Id = 1, NameUser = "Токин И.О.", Login = "MrTokin", Password = "1234567",
                DateBirth = DateTime.Parse("28.02.2000"), DateStartWork = DateTime.Parse("15.02.2020"),Salary = 100000, PostId = 1});
            context.Users.AddOrUpdate(new DataBase.Models.User() { Id = 2, NameUser = "Иванов И.И.", Login = "IvanIvanov", Password = "1234567q"
                , DateBirth = DateTime.Parse("28.02.2010"), DateStartWork = DateTime.Parse("15.02.2010"), Salary = 90000, PostId = 2});
            context.Users.AddOrUpdate(new DataBase.Models.User() { Id = 3, NameUser = "Жжонов В.А.", Login = "JonKoreya", Password = "1234567qw"
                , DateBirth = DateTime.Parse("28.02.2003"), DateStartWork = DateTime.Parse("15.02.2028"), Salary = 13000, PostId = 3});

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
