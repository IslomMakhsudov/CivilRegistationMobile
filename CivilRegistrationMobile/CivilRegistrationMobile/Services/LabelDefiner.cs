namespace CivilRegistrationMobile.Services
{
    public class LabelDefiner
    {
        private readonly ServerDataHandler handler;
        private readonly IUnitOfWork _unit;
        public LabelDefiner(ServerDataHandler handler, IUnitOfWork unit)
        {
            this.handler = handler;
            _unit = unit;
        }

        public async Task IndexLabels(Controller controller, int lang)
        {
            controller.ViewBag.NewApplication = await handler.LabelById(lang, 4);
            controller.ViewBag.MyApplications = await handler.LabelById(lang, 5);
            controller.ViewBag.Civil = await handler.LabelById(lang, 68);
            controller.ViewBag.NewbornRegistration = await handler.LabelById(lang, 364);
            controller.ViewBag.DeathRegistration = await handler.LabelById(lang, 7);
            controller.ViewBag.ReasonTitle = await handler.LabelById(lang, 1556);
            controller.ViewBag.RegistryOffice = await handler.LabelById(lang, 177);
            controller.ViewBag.Support = await handler.LabelById(lang, 1);
        }

        public async Task RegistryOfficesLabels(Controller controller, int lang)
        {
            controller.ViewBag.RegistryOffice = await handler.LabelById(lang, 177);
        }

        public async Task ApplicationFilterLabels(Controller controller, int lang)
        {
            controller.ViewBag.ServiceType = await handler.LabelById(lang, 80);
            controller.ViewBag.Newborn = await handler.LabelById(lang, 1405);
            controller.ViewBag.Deceased = await handler.LabelById(lang, 1406);
            controller.ViewBag.From = await handler.LabelById(lang, 1448);
            controller.ViewBag.To = await handler.LabelById(lang, 1449);
            controller.ViewBag.Find = await handler.LabelById(lang, 82);
            controller.ViewBag.ChooseDateTime = await handler.LabelById(lang, 1537);
        }

        public async Task DeathRegistrationLabels(Controller controller, int lang)
        {
            controller.ViewBag.NotInOneYear = await handler.LabelById(lang, 1609);
            controller.ViewBag.DeathRegistration = await handler.LabelById(lang, 7);
            controller.ViewBag.ApplicantDetails = await handler.LabelById(lang, 8);
            controller.ViewBag.DeceasedDetails = await handler.LabelById(lang, 85);
            controller.ViewBag.Continue = await handler.LabelById(lang, 12);
            controller.ViewBag.Agreement = await handler.LabelById(lang, 11);
        }

        public async Task SupportLabels(Controller controller, int lang)
        {
            controller.ViewBag.SupportTitle = await handler.LabelById(lang, 1);
            controller.ViewBag.Questions = await handler.LabelById(lang, 2);
            controller.ViewBag.Contacts = await handler.LabelById(lang, 3);
        }

        public async Task NewbornRegistrationLabels(Controller controller, int lang)
        {
            controller.ViewBag.NotInOneYear = await handler.LabelById(lang, 1609);
            controller.ViewBag.NewbornRegistration = await handler.LabelById(lang, 364);
            controller.ViewBag.ApplicantDetails = await handler.LabelById(lang, 8);
            controller.ViewBag.ChildDetails = await handler.LabelById(lang, 9);
            controller.ViewBag.FatherDetails = await handler.LabelById(lang, 46);
            controller.ViewBag.MotherDetails = await handler.LabelById(lang, 45);
            controller.ViewBag.Continue = await handler.LabelById(lang, 12);
            controller.ViewBag.Agreement = await handler.LabelById(lang, 11);
        }

        public async Task PaymentLabels(Controller controller, int lang)
        {
            controller.ViewBag.PaymentTitle = await handler.LabelById(lang, 65);
            controller.ViewBag.Sum = await handler.LabelById(lang, 66);
            //controller.ViewBag.Somon = handler.LabelById(lang, );
            controller.ViewBag.Continue = await handler.LabelById(lang, 12);
        }

        public async Task SuccessLabels(Controller controller, int lang)
        {
            controller.ViewBag.Sent = await handler.LabelById(lang, 358);
            controller.ViewBag.ToMain = await handler.LabelById(lang, 74);
            controller.ViewBag.ApplicationRequest = await handler.LabelById(lang, 72);
            controller.ViewBag.MyApplications = await handler.LabelById(lang, 5);
        }

        public async Task ApplicationsLabels(Controller controller, int lang, int applicationId)
        {
            controller.ViewBag.ReasonTitle = await handler.LabelById(lang, 1608);
            controller.ViewBag.ImageSize = await handler.LabelById(lang, 1607);
            controller.ViewBag.Whom = await handler.LabelById(lang, 1384);
            controller.ViewBag.Which = await handler.LabelById(lang, 1385);
            controller.ViewBag.ToFather = await handler.LabelById(lang, 1563);
            controller.ViewBag.ToMother = await handler.LabelById(lang, 1564);
            controller.ViewBag.DeathPlace = await handler.LabelById(lang, 1567);
            controller.ViewBag.LastLivePlace = await handler.LabelById(lang, 1565);
            controller.ViewBag.ApplicantDetails = await handler.LabelById(lang, 8);
            controller.ViewBag.ChildDetails = await handler.LabelById(lang, 9);
            controller.ViewBag.FatherDetails = await handler.LabelById(lang, 44);
            controller.ViewBag.MotherDetails = await handler.LabelById(lang, 45);
            controller.ViewBag.DeceasedDetails = await handler.LabelById(lang, 85);
            controller.ViewBag.Country = await handler.LabelById(lang, 365);
            controller.ViewBag.Region = await handler.LabelById(lang, 14);
            controller.ViewBag.City = await handler.LabelById(lang, 15);
            controller.ViewBag.Village = await handler.LabelById(lang, 16);
            controller.ViewBag.LastName = await handler.LabelById(lang, 29);
            controller.ViewBag.Name = await handler.LabelById(lang, 30);
            controller.ViewBag.Patronymic = await handler.LabelById(lang, 31);
            controller.ViewBag.CurrentAddress = await handler.LabelById(lang, 13);
            controller.ViewBag.TIN = await handler.LabelById(lang, 22);
            controller.ViewBag.PassportNumber = await handler.LabelById(lang, 23);
            controller.ViewBag.IssuingAuth = await handler.LabelById(lang, 24);
            controller.ViewBag.PhoneNumber = await handler.LabelById(lang, 25);
            controller.ViewBag.ChooseAddress = await handler.LabelById(lang, 146);
            controller.ViewBag.Document = await handler.LabelById(lang, 26);
            controller.ViewBag.Next = await handler.LabelById(lang, 27);
            controller.ViewBag.ChildTitle = await handler.LabelById(lang, 28);
            controller.ViewBag.Title = await handler.LabelById(lang, 29);
            controller.ViewBag.Sex = await handler.LabelById(lang, 32);
            controller.ViewBag.Male = await handler.LabelById(lang, 33);
            controller.ViewBag.Female = await handler.LabelById(lang, 34);
            controller.ViewBag.DateOfBirth = await handler.LabelById(lang, 52);
            controller.ViewBag.TimeOfBirth = await handler.LabelById(lang, 1550);
            controller.ViewBag.DateOfDeath = await handler.LabelById(lang, 89);
            controller.ViewBag.BirthPlace = await handler.LabelById(lang, 36);
            controller.ViewBag.NewbornCount = await handler.LabelById(lang, 37);
            controller.ViewBag.ChildrenCount = await handler.LabelById(lang, 158);
            controller.ViewBag.ChildProperty = await handler.LabelById(lang, 39);
            controller.ViewBag.PregnancyDuration = await handler.LabelById(lang, 42);
            controller.ViewBag.Weight = await handler.LabelById(lang, 41);
            controller.ViewBag.Height = await handler.LabelById(lang, 40);
            controller.ViewBag.DeceasedTitle = await handler.LabelById(lang, 88);
            controller.ViewBag.Address = await handler.LabelById(lang, 21);
            controller.ViewBag.MaritalStatus = await handler.LabelById(lang, 362);
            controller.ViewBag.Citizenship = await handler.LabelById(lang, 53);
            controller.ViewBag.Nationality = await handler.LabelById(lang, 54);
            controller.ViewBag.Education = await handler.LabelById(lang, 57);
            controller.ViewBag.WorkPlace = await handler.LabelById(lang, 56);
            controller.ViewBag.RegistryOffice = await handler.LabelById(lang, 17);
            controller.ViewBag.DeathDocument = await handler.LabelById(lang, 92);
            controller.ViewBag.NewbornDocument = await handler.LabelById(lang, 43);
            controller.ViewBag.Applicant = await handler.LabelById(lang, 47);
            controller.ViewBag.Father = await handler.LabelById(lang, 48);
            controller.ViewBag.LiveFrom = await handler.LabelById(lang, 55);
            controller.ViewBag.Mother = await handler.LabelById(lang, 59);
            controller.ViewBag.JobType = await handler.LabelById(lang, 63);
            controller.ViewBag.WeddingDocument = await handler.LabelById(lang, 64);
            controller.ViewBag.FatherTitle = await handler.LabelById(lang, 46);
            controller.ViewBag.MotherTitle = await handler.LabelById(lang, 1555);
            controller.ViewBag.ChooseRegion = await handler.LabelById(lang, 1530);
            controller.ViewBag.ChooseCity = await handler.LabelById(lang, 1531);
            controller.ViewBag.ChooseVillage = await handler.LabelById(lang, 1532);
            controller.ViewBag.FillField = await handler.LabelById(lang, 1533);
            controller.ViewBag.ChooseAddress = await handler.LabelById(lang, 1534);
            controller.ViewBag.TakePicture = await handler.LabelById(lang, 1535);
            controller.ViewBag.ChooseDocument = await handler.LabelById(lang, 1536);
            controller.ViewBag.ChooseSex = await handler.LabelById(lang, 1544);
            controller.ViewBag.ChooseDateTime = await handler.LabelById(lang, 1537);
            controller.ViewBag.ChooseCount = await handler.LabelById(lang, 1545);
            controller.ViewBag.From1To15 = await handler.LabelById(lang, 1546);
            controller.ViewBag.From100To9999 = await handler.LabelById(lang, 1547);
            controller.ViewBag.From10To70 = await handler.LabelById(lang, 1548);
            controller.ViewBag.From20To50 = await handler.LabelById(lang, 1549);
            controller.ViewBag.ChooseNationality = await handler.LabelById(lang, 1552);
            controller.ViewBag.ChooseCitizenship = await handler.LabelById(lang, 1553);
            controller.ViewBag.ChooseRegistryOffice = await handler.LabelById(lang, 1437);
            controller.ViewBag.ChooseEducation = await handler.LabelById(lang, 1554);
            controller.ViewBag.ChooseMaritalStatus = await handler.LabelById(lang, 1558);
            controller.ViewBag.ChooseJobType = await handler.LabelById(lang, 1559);
            controller.ViewBag.PersonalInfo = await handler.LabelById(lang, 1551);
            controller.ViewBag.ChooseName = await handler.LabelById(lang, 1560);
            controller.ViewBag.CommentBtn = await handler.LabelById(lang, 1581);
            controller.ViewBag.CommentTitle = await handler.LabelById(lang, 173);

            if(applicationId > 0)
            {
                Applications? application = await _unit.Applications.GetByID(applicationId);
                if(application != null)
                {
                    if(application.ApplicationStatusID == 6)
                    {
                        controller.ViewBag.CommentBody = _unit.ApplicationsCorrectionComments.GetLastCommentOfApplication(applicationId).Result.Comment;
                    }
                }
            }
        }
    }
}
