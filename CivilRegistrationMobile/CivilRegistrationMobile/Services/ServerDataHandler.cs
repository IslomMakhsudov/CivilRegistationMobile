namespace CivilRegistrationMobile.Services;

public class ServerDataHandler
{
    private readonly IMemoryCache _cache;
    private readonly ModelDataChanger _changer;
    private readonly IUnitOfWork _unit;
    private readonly IWebHostEnvironment _webHostEnvironment;
    private int _addressId;
    private int _customerId;
    private int _participantDataId;
    private readonly HttpContext context;

    public ServerDataHandler(IUnitOfWork unit, IWebHostEnvironment environment, IMemoryCache cache,
        ModelDataChanger changer, IHttpContextAccessor accessor)
    {
        _webHostEnvironment = environment;
        _unit = unit;
        _cache = cache;
        _changer = changer;
        context = accessor.HttpContext;
    }


    #region Lists
    // Get names of country, city, registry office and region from database
    public async Task<List<SelectListItem>> GetCountryNames(int countryId)
    {
        var countyExists = false;
        if (context.Session.Keys.Contains("countryID") && countryId == 0)
            countryId = Convert.ToInt32(context.Session.GetString("countryID"));
        List<SelectListItem> countries = new();
        IEnumerable<Countries> countryTask = await _unit.BaseTypes.GetAllCountries();

        if (countryId != 0) countyExists = true;
        foreach (var obj in countryTask)
            if (obj.CountryID == countryId)
                countries.Add(new SelectListItem
                    { Value = obj.CountryID.ToString(), Text = obj.ShortName, Selected = true });
            else if (obj.ShortName == "Тоҷикистон" && countyExists == false)
                countries.Add(new SelectListItem
                    { Value = obj.CountryID.ToString(), Text = obj.ShortName, Selected = true });
            else
                countries.Add(new SelectListItem { Value = obj.CountryID.ToString(), Text = obj.ShortName });
        return countries;
    }

    public async Task<List<SelectListItem>> GetRegions(int regionId, int countryId)
    {
        List<SelectListItem> regions = new();
        if (regionId == 0) return regions;
        IEnumerable<Regions> regionsTask = await _unit.BaseTypes.GetRegionsOfCountry(countryId);

        if (context.Session.Keys.Contains("regionID"))
            regionId = Convert.ToInt32(context.Session.GetString("regionID"));
        regions.AddRange(regionsTask.Select(obj => obj.RegionID == regionId
            ? new SelectListItem { Value = obj.RegionID.ToString(), Text = obj.Name, Selected = true }
            : new SelectListItem { Value = obj.RegionID.ToString(), Text = obj.Name }));
        return regions;
    }

    public async Task<ApplicationStatus> GetApplicationStatus(int lang, int statusId, int typeId, int applicationId)
    {
        ApplicationStatus appStatus = new()
        {
            StatusID = statusId,
            TypeID = typeId,
            ApplicationID = applicationId,
            Title = await LabelById(lang, typeId == 1 ? 364 : 7),
            LinkText = await LabelById(lang, 76),
            UpTitle = await LabelById(lang, 71),
            UpStatusText = await LabelById(lang, 358),
            MainBtnText = await LabelById(lang, 74),
            CorrectBtnText = await LabelById(lang, 84)
        };

        var application = _unit.Applications.GetByID(applicationId).Result;


        appStatus.UpDate = application.CreatedTime.ToString("dd/MM/yyyy");
        appStatus.UpTime = application.CreatedTime.ToString("HH:mm:ss");
        appStatus.MidDate = application.PaidTime?.ToString("dd/MM/yyyy");
        appStatus.MidTime = application.PaidTime?.ToString("HH:mm:ss");
        appStatus.BotDate = application.CompletedTime?.ToString("dd/MM/yyyy");
        appStatus.BotTime = application.CompletedTime?.ToString("HH:mm:ss");

        switch (statusId)
        {
            case 1:
                break;
            case 2:
                appStatus.MidTitle = await LabelById(lang, 75);
                appStatus.MidStatusText = await LabelById(lang, 1398);
                break;
            case 3:
                appStatus.MidTitle = await LabelById(lang, 77);
                appStatus.MidStatusText = await LabelById(lang, 1400);
                appStatus.BotTitle = await LabelById(lang, 78);
                appStatus.BotStatusText = await LabelById(lang, 1397);
                break;
            case 4:
                appStatus.MidTitle = await LabelById(lang, 77);
                appStatus.MidStatusText = await LabelById(lang, 1400);
                appStatus.BotTitle = await LabelById(lang, 79);
                appStatus.BotStatusText = await LabelById(lang, 359);
                break;
            case 6:
                appStatus.MidTitle = await LabelById(lang, 83);
                appStatus.MidStatusText = await LabelById(lang, 1387);
                break;
        }

        return appStatus;
    }

    public async Task<string> LabelById(int lang, int labelId)
    {
        if (labelId == 0) return "";
        if (_cache.TryGetValue(labelId, out Labels label))
            return lang switch
            {
                1 => label.Label1,
                2 => label.Label2,
                _ => label.Label3
            };
        Labels labels = await _unit.Labels.GetByID(labelId);
        _cache.Set(labelId, labels);
        return lang switch
        {
            1 => labels.Label1,
            2 => labels.Label2,
            _ => labels.Label3
        };
    }

    public async Task<List<SelectListItem>> GetCities(int cityId, int regionId)
    {
        List<SelectListItem> cities = new();
        if (cityId == 0) return cities;
        IEnumerable<CitiesDistricts> regionsTask = await _unit.BaseTypes.GetCitiesDistrictsOfRegion(regionId);
        if (context.Session.Keys.Contains("cityID")) cityId = Convert.ToInt32(context.Session.GetString("cityID"));
        cities.AddRange(regionsTask.Select(obj => obj.CityDistrictID == cityId
            ? new SelectListItem { Value = obj.CityDistrictID.ToString(), Text = obj.Name, Selected = true }
            : new SelectListItem { Value = obj.CityDistrictID.ToString(), Text = obj.Name }));
        return cities;
    }

    public async Task<List<SelectListItem>> GetRegistryOffices(int registryOfficeId, int cityId, int? villageId)
    {
        List<SelectListItem> registryOffices = new();
        if (registryOfficeId == 0) return registryOffices;
        IEnumerable<RegistryOfficeDepartments> regionsTask =
            await _unit.BaseTypes.GetRegistryOfficeDepartmentsOfVillagesOrCitiesDistricts(villageId, cityId);
        registryOffices.AddRange(regionsTask.Select(obj => obj.DepartmentID == registryOfficeId
            ? new SelectListItem { Value = obj.DepartmentID.ToString(), Text = obj.DepartmentName, Selected = true }
            : new SelectListItem { Value = obj.DepartmentID.ToString(), Text = obj.DepartmentName }));
        return registryOffices;
    }

    public async Task<List<SelectListItem>> GetVillages(int? villageId, int cityId)
    {
        List<SelectListItem> villages = new();
        if (villageId == 0 || villageId == null) return villages;
        IEnumerable<Villages> regionsTask = await _unit.BaseTypes.GetVillagesOfCitiesDistricts(cityId);
        villages.AddRange(regionsTask.Select(obj => obj.VillageID == villageId
            ? new SelectListItem { Value = obj.VillageID.ToString(), Text = obj.Name, Selected = true }
            : new SelectListItem { Value = obj.VillageID.ToString(), Text = obj.Name }));
        return villages;
    }

    public async Task<List<SelectListItem>> GetCitizenship(int citizenshipId)
    {
        var citizenshipExist = false;
        List<SelectListItem> citizenship = new();
        IEnumerable<Cityzenship> citizenTask = await _unit.BaseTypes.GetAllCityzenship();
        if (citizenshipId > 0) citizenshipExist = true;
        foreach (var obj in citizenTask)
            if (obj.CityzenshipID == citizenshipId)
                citizenship.Add(new SelectListItem
                    { Value = obj.CityzenshipID.ToString(), Text = obj.Name, Selected = true });
            else if (obj.CityzenshipID == 185 && citizenshipExist == false)
                citizenship.Add(new SelectListItem
                    { Value = obj.CityzenshipID.ToString(), Text = obj.Name, Selected = true });
            else
                citizenship.Add(new SelectListItem { Value = obj.CityzenshipID.ToString(), Text = obj.Name });
        return citizenship;
    }

    public async Task<List<SelectListItem>> GetNationality(int nationalityId)
    {
        var nationalityExist = false;
        List<SelectListItem> nationality = new();
        IEnumerable<Nationalities> nationalityTask = await _unit.BaseTypes.GetAllNationalities();
        if (nationalityId > 0) nationalityExist = true;
        foreach (var obj in nationalityTask)
            if (obj.NationalityID == nationalityId)
                nationality.Add(new SelectListItem
                    { Value = obj.NationalityID.ToString(), Text = obj.Name, Selected = true });
            else if (obj.Name == "тоҷик" && nationalityExist == false)
                nationality.Add(new SelectListItem
                    { Value = obj.NationalityID.ToString(), Text = obj.Name, Selected = true });
            else
                nationality.Add(new SelectListItem { Value = obj.NationalityID.ToString(), Text = obj.Name });
        return nationality;
    }

    public async Task<List<SelectListItem>> GetEducation(int educationId, int lang)
    {
        IEnumerable<EducationLevels> educationsTask = await _unit.BaseTypes.GetAllEducationLevels();
        return educationsTask.Select(obj => obj.EducationLevelID == educationId
                ? new SelectListItem
                { Value = obj.EducationLevelID.ToString(), Text = LabelById(lang, obj.LabelID).Result, Selected = true }
                : new SelectListItem 
                { Value = obj.EducationLevelID.ToString(), Text = LabelById(lang, obj.LabelID).Result })
            .ToList();
    }

    public async Task<List<SelectListItem>> GetMaritalStatuses(int maritalStatusId, int lang)
    {
        IEnumerable<MaritalStatuses> maritalTask = await _unit.BaseTypes.GetMaritalStatuses();
        return maritalTask.Select(obj => obj.MaritalStatusID == maritalStatusId
                ? new SelectListItem
                { Value = obj.MaritalStatusID.ToString(), Text = LabelById(lang, obj.LabelID).Result, Selected = true }
                : new SelectListItem 
                { Value = obj.MaritalStatusID.ToString(), Text = LabelById(lang, obj.LabelID).Result })
            .ToList();
    }

    public async Task<List<SelectListItem>> RegionsByCountryId(int countryId)
    {
        IEnumerable<Regions> regionsTask = await _unit.BaseTypes.GetRegionsOfCountry(countryId);
        return regionsTask.Select(obj => new SelectListItem { Value = obj.RegionID.ToString(), Text = obj.Name })
            .ToList();
    }

    public async Task<List<SelectListItem>> CitiesByRegionId(int regionId)
    {
        IEnumerable<CitiesDistricts> citiesTask = await _unit.BaseTypes.GetCitiesDistrictsOfRegion(regionId);
        return citiesTask.Select(obj => new SelectListItem
            { Value = obj.CityDistrictID.ToString(), Text = obj.Name }).ToList();
    }

    public async Task<List<SelectListItem>> VillagesByCityId(int cityId)
    {
        IEnumerable<Villages> villagesTask = await _unit.BaseTypes.GetVillagesOfCitiesDistricts(cityId);
        return villagesTask
            .Select(obj => new SelectListItem { Value = obj.VillageID.ToString(), Text = obj.Name }).ToList();
    }

    public async Task<List<SelectListItem>> OfficesByVillageOrCityId(int? villageId, int cityId)
    {
        IEnumerable<RegistryOfficeDepartments> registryOfficesTask = await _unit.BaseTypes
            .GetRegistryOfficeDepartmentsOfVillagesOrCitiesDistricts(villageId, cityId);
        return registryOfficesTask.Select(obj => new SelectListItem
            { Value = obj.DepartmentID.ToString(), Text = obj.DepartmentName }).ToList();
    }

    public async Task<List<SelectListItem>> GetJobTitle(int jobTitle, int lang)
    {
        IEnumerable<TypesOfActivitiesInWork> jobTitleTask = await _unit.BaseTypes.GetTypesOfActivitiesInWorks();
        return jobTitleTask.Select(obj => obj.TypeOfActivitiesInWorkID == jobTitle
                ? new SelectListItem
                    { Value = obj.TypeOfActivitiesInWorkID.ToString(), Text = LabelById(lang, obj.LabelID).Result, Selected = true }
                : new SelectListItem { Value = obj.TypeOfActivitiesInWorkID.ToString(), Text = LabelById(lang, obj.LabelID).Result })
            .ToList();
    }

    public async Task<List<Support>> Faq()
    {
        IEnumerable<FAQ> faqList = await _unit.FAQ.GetTopNFAQs(4);
        return faqList.Select(obj => new Support { Id = obj.FaqID, Answer = obj.FaqAnswer, Question = obj.FaqQuestion }).ToList();
    }

    public async Task<CorrectedApplications> GetCorrection(int applicationId)
    {
        CorrectedApplications correction = new();

        IEnumerable<ApplicationMistakes> mistakes =
            await _unit.ApplicationMistakes.GetMistakesByApplicationID(applicationId);

        List<ApplicationField> applicant = new();
        List<ApplicationField> child = new();
        List<ApplicationField> father = new();
        List<ApplicationField> mother = new();
        List<ApplicationField> deceased = new();

        foreach (var field in mistakes)
            switch (field.ApplicationMemberTypeID)
            {
                case 1:
                    applicant.Add(new ApplicationField
                    {
                        Id = field.ApplicationID, Name = field.FieldName,
                        MemberId = field.ApplicationMemberTypeID
                    });
                    break;
                case 2:
                    child.Add(new ApplicationField
                    {
                        Id = field.ApplicationID, Name = field.FieldName,
                        MemberId = field.ApplicationMemberTypeID
                    });
                    break;
                case 3:
                    father.Add(new ApplicationField
                    {
                        Id = field.ApplicationID, Name = field.FieldName,
                        MemberId = field.ApplicationMemberTypeID
                    });
                    break;
                case 4:
                    mother.Add(new ApplicationField
                    {
                        Id = field.ApplicationID, Name = field.FieldName,
                        MemberId = field.ApplicationMemberTypeID
                    });
                    break;
                case 5:
                    deceased.Add(new ApplicationField
                    {
                        Id = field.ApplicationID, Name = field.FieldName,
                        MemberId = field.ApplicationMemberTypeID
                    });
                    break;
            }

        if (applicant.Count > 0)
        {
            correction.Applicant = false;
            context.Session.Set("ApplicantFields", applicant);
        }

        if (child.Count > 0)
        {
            correction.Child = false;
            context.Session.Set("ChildFields", child);
        }

        if (father.Count > 0)
        {
            correction.Father = false;
            context.Session.Set("FatherFields", father);
        }

        if (mother.Count > 0)
        {
            correction.Mother = false;
            context.Session.Set("MotherFields", mother);
        }

        if (deceased.Count > 0)
        {
            correction.Deceased = false;
            context.Session.Set("DeceasedFields", deceased);
        }

        var corrected = context.Session.Get<CorrectedApplications>("CorrectedApplications");
        if (corrected == null)
            context.Session.Set("CorrectedApplications", correction);
        return correction;
    }

    public async Task<IEnumerable<ApplicationTitle>> GetAllApplications(DateTime? dateFrom, DateTime? dateTo,
        int? applicationTypeId)
    {
        var lang = Convert.ToInt32(context.Session.GetString("lang"));
        var externalId = Convert.ToInt32(context.Session.GetString("externalID"));
        IEnumerable<CustomersApplicationsMobileResponse> customersApplications = _unit.Applications
            .GetCustomersApplications(externalId, 1, dateFrom, dateTo, applicationTypeId).Result;
           // .GetCustomersApplications(1, 1, null, null, null).Result;
           List<ApplicationTitle> list = new();
            
           foreach (var obj in customersApplications)
           {
               
               ApplicationTitle title = new()
               {
                   ApplicationID = obj.ApplicationID,
                   Title = obj.ApplicationTypeName,
                   ApplicationStatus = obj.ApplicationStatusID,
                   Date = obj.CreatedOrPaidDateTime.Date.ToString("dd/MM/yyyy"),
                   Time = obj.CreatedOrPaidDateTime.AddTicks(-(obj.CreatedOrPaidDateTime.Ticks % 10000000)).TimeOfDay.ToString(),
                   ApplicationType = obj.ApplicationTypeID,
                   RegistryOfficeID = obj.RegistryOfficeDepartmentID,
                   MemberTypeId = obj.RegistratedByWhichMemberID,
                   AddressTypeId = obj.RegistratedByWhichAddress,
                   ActionName = "ApplicationStatus"
               };

               switch (obj.ApplicationStatusID)
               {
                    case 1:
                        title.SvgFill = "#95A5A6";
                        title.Blob = "draft";
                        title.PathD = "M8 3.5a.5.5 0 0 0-1 0V9a.5.5 0 0 0 .252.434l3.5 2a.5.5 0 0 0 .496-.868L8 8.71V3.5z";
                        title.BotTextColor = "color-draft";
                        title.BotText = await LabelById(lang, 373);
                        title.ActionName = obj.ApplicationTypeID == 1 ? "NewbornRegistration" : "DeathRegistration";
                        break;
                    case 2:
                        title.SvgFill = "#f39c12";
                        title.Blob = "waiting";
                        title.PathD = "M8 3.5a.5.5 0 0 0-1 0V9a.5.5 0 0 0 .252.434l3.5 2a.5.5 0 0 0 .496-.868L8 8.71V3.5z";
                        title.BotTextColor = "color-waiting";
                        title.BotText = await LabelById(lang, 1398);
                        break;
                    case 3:
                        title.SvgFill = "#f39c12";
                        title.Blob = "waiting";
                        title.PathD = "M8 3.5a.5.5 0 0 0-1 0V9a.5.5 0 0 0 .252.434l3.5 2a.5.5 0 0 0 .496-.868L8 8.71V3.5z";
                        title.BotTextColor = "color-waiting";
                        title.BotText = await LabelById(lang, 1397);
                        break;
                    case 4:
                        title.SvgFill = "#00b06c";
                        title.Blob = "Service_approved";
                        title.PathD = "M10.97 4.97a.235.235 0 0 0-.02.022L7.477 9.417 5.384 7.323a.75.75 0 0 0-1.06 1.06L6.97 11.03a.75.75 0 0 0 1.079-.02l3.992-4.99a.75.75 0 0 0-1.071-1.05z";
                        title.BotTextColor = "color-success";
                        title.BotText = await LabelById(lang, 359);
                        break;
                    case 5:
                        title.SvgFill = "#e74c3c";
                        title.Blob = "Service_declined";
                        title.PathD = "M5.354 4.646a.5.5 0 1 0-.708.708L7.293 8l-2.647 2.646a.5.5 0 0 0 .708.708L8 8.707l2.646 2.647a.5.5 0 0 0 .708-.708L8.707 8l2.647-2.646a.5.5 0 0 0-.708-.708L8 7.293 5.354 4.646z";
                        title.BotTextColor = "color-dissmiss";
                        title.BotText = await LabelById(lang, 361);
                        break;
                    case 6:
                        title.Blob = "Service_correction parent";
                        title.BotTextColor = "color-correction";
                        title.BotText = await LabelById(lang, 1387);
                    break;
               }


               list.Add(title);
           }
              

           return list;
    }
    #endregion

    public async Task SaveParticipantData(Applicant? applicant)
    {
        var externalId = Convert.ToInt32(context.Session.GetString("externalID"));
        var correctingStatus = context.Session.Get<bool>("CorrectingStatus");
        var created = context.Session.Get<bool>("ApplicantCreated");
        var lang = Convert.ToInt32(context.Session.GetString("lang"));

        var applications = await SaveApplicantData(new ApplicantDataDto
        {
            Context = context,
            ExternalId = externalId,
            CorrectingStatus = correctingStatus,
            ApplicantCreated = created,
            ApplicantFormCode = Convert.ToInt32(context.Session.GetString("ApplicantFormCode"))
        });
        var applicationId = applications.ApplicationID;
        context.Session.Set("Application", applications);
        context.Session.Set("ApplicationID", applicationId);

        if (applicant != null)
        {
            ApplicationsParticipantsData applicantPartData = new()
            {
                Surname = applicant.LastName,
                Name = applicant.Name,
                Patronymic = applicant.Patronymic,
                PassportNumber = applicant.PassportNumber,
                PassportItnNumber = applicant.TIN,
                PassportGivingOrgan = applicant.IssuingAuth,
                TelephoneNumber = applicant.PhoneNumber,
                ApplicationMemberTypeID = 1,
                TypeOfActivitiesInWorkID = null,
                ExternalID = externalId,
                LanguageID = lang
            };

            var formCode = Convert.ToInt32(context.Session.GetString("ApplicantFormCode"));
            applicantPartData.ApplicationTypeID = formCode == 1 ? 1 : 2;

            var customer = await _unit.Customers.GetCustomerByExternalID(externalId);
            if (customer != null)
            {
                _customerId = customer.CustomerID;
                await UpdateCustomer(customer, applicant);
                applicantPartData.AddressID = Convert.ToInt32(customer.AddressID);
            }
            else
            {
                _customerId = await SaveCustomerData(applicant, applicationId, created, correctingStatus, lang, externalId);
                applicantPartData.AddressID = _addressId;
            }

            applicantPartData.CustomerID = _customerId;
            applicantPartData.ApplicationID = applications.ApplicationID;

            context.Session.SetString("ApplicationID", applicantPartData.ApplicationID.ToString());

            if (applicant.RegisterTo != null)
                switch (applicant.RegisterTo)
                {
                    case 1:
                        await SaveApplicationDetails(applicant.RegisterTo, 17, 5, 2, created, correctingStatus,
                            applicationId);
                        break;
                    case 3:
                        await SaveApplicationDetails(applicant.RegisterTo, 16, 2, 1, created, correctingStatus,
                            applicationId);
                        break;
                    case 4:
                        await SaveApplicationDetails(applicant.RegisterTo, 16, 2, 1, created, correctingStatus,
                            applicationId);
                        break;
                    default:
                        await SaveApplicationDetails(applicant.RegisterTo, 17, 5, 2, created, correctingStatus,
                            applicationId);
                        break;
                }


            await UpdateOrInsert(applicantPartData, created, correctingStatus, 1, applicationId);
            _participantDataId = applicantPartData.ApplicationParticipantsDataID;
            if (applicant.DocumentPicture1 != null && applicant.DocumentPicture2 != null)
            {
                string? filePath1 = null;
                string? filePath2 = null;

                if (created || correctingStatus)
                {
                    var applicantOld = await _changer.GetApplicant(applicationId, lang);

                    if (applicantOld != null)
                    {
                        filePath1 = applicantOld.DocumentLink_1;
                        filePath2 = applicantOld.DocumentLink_2;
                    }
                }

                var applicantDocument1 = await SaveApplicationDocuments(applicant.DocumentPicture1, 4, 1, filePath1);
                applicant.DocumentLink_1 = applicantDocument1.AddressLink;
                    
                var applicantDocument2 = await SaveApplicationDocuments(applicant.DocumentPicture2, 5, 1, filePath2);
                applicant.DocumentLink_2 = applicantDocument2.AddressLink;
                    
            }
        }

        applications.ApplicationParticipantsDataID = _participantDataId;
        await _unit.Complete();
    }

    private async Task UpdateCustomer(Customers customer, Applicant applicant)
    {
        customer.Surname = applicant.LastName;
        customer.Name = applicant.Name;
        customer.Patronymic = applicant.Patronymic;
        customer.PassportNumber = applicant.PassportNumber;
        customer.PassportItnNumber = applicant.TIN;
        customer.PassportGivingOrgan = applicant.IssuingAuth;
        customer.AddressID = await SaveOrUpdateAddress(applicant, customer.AddressID);
        customer.VillageID = applicant.CurrentVillage;
        customer.CityDistrictID = applicant.CurrentCity;
        customer.RegionID = applicant.CurrentRegion;
        customer.CountryID = applicant.CurrentCountry;
    }

    public async Task SaveParticipantData(Child? child)
    {
        var applicationId = Convert.ToInt32(context.Session.GetString("ApplicationID"));
        var created = context.Session.Get<bool>("ChildCreated");
        var correctingStatus = context.Session.Get<bool>("CorrectingStatus");
        var lang = Convert.ToInt32(context.Session.GetString("lang"));

        if (child == null) return;

        
        ApplicationsParticipantsData participantsData = new()
        {
            Surname = child.LastName,
            Name = child.Name,
            Patronymic = child.Patronymic,
            Birthday = (child.DateOfBirth.Date + child.TimeOfBirth.TimeOfDay),
            Sex = child.Sex,
            CustomerID = await SaveCustomerData(child, correctingStatus, created, applicationId, lang),
            ApplicationTypeID = 1,
            ApplicationMemberTypeID = 2,
            ApplicationID = applicationId,
            AddressID = _addressId,
            TypeOfActivitiesInWorkID = null,
            LanguageID = lang
        };

        if (child.Weight != null)
            await SaveApplicationDetails(child.Weight, 1, 2, 1, created, correctingStatus, applicationId);
        if (child.Height != null)
            await SaveApplicationDetails(child.Height, 2, 2, 1, created, correctingStatus, applicationId);
        if (child.PregnancyDuration != null)
            await SaveApplicationDetails(child.PregnancyDuration, 5, 2, 1, created, correctingStatus, applicationId);

        await SaveApplicationDetails(child.NewbornCount, 3, 2, 1, created, correctingStatus, applicationId);
        await SaveApplicationDetails(child.ChildCount, 4, 2, 1, created, correctingStatus, applicationId);


        Applications application = await _unit.Applications.GetByID(applicationId);
        application.MainEventTime = child.DateOfBirth.Date + child.TimeOfBirth.TimeOfDay;

        await UpdateOrInsert(participantsData, created, correctingStatus, 2, applicationId);
        _participantDataId = participantsData.ApplicationParticipantsDataID;
        if (child.DocumentPicture1 != null)
        {
            string? filePath1 = null;
            if (created || correctingStatus)
            {
                var childOld = await _changer.GetChild(applicationId, lang);
                if (childOld != null) filePath1 = childOld.DocumentLink_1;
            }

            var childDocument = await SaveApplicationDocuments(child.DocumentPicture1, 6, 2, filePath1);
            child.DocumentLink_1 = childDocument.AddressLink;
                
        }
    }

    public async Task SaveParticipantData(Father? father)
    {
        var correctingStatus = context.Session.Get<bool>("CorrectingStatus");
        var created = context.Session.Get<bool>("FatherCreated");
        var applicationId = context.Session.Get<int>("ApplicationID");
        var lang = Convert.ToInt32(context.Session.GetString("lang"));

        if (father == null) return;
        ApplicationsParticipantsData participantsData = new()
        {
            Surname = father.LastName,
            Name = father.Name,
            Patronymic = father.Patronymic,
            Birthday = father.DateOfBirth,
            Sex = true,
            CustomerID = await SaveCustomerData(father, correctingStatus, created, applicationId, lang),
            ApplicationID = Convert.ToInt32(context.Session.GetString("ApplicationID")),
            ApplicationMemberTypeID = 3,
            ApplicationTypeID = 1,
            PlaceOfWork = father.WorkPlace,
            TypeOfActivitiesInWorkID = null,
            CurrentAddressLivingStartTime = father.LiveFrom,
            CurrentCitizenship = father.Citizenship,
            PassportGivingOrgan = father.IssuingAuth,
            EducationLevelID = father.Education,
            AddressID = _addressId,
            CurrentNationality = father.Nationality,
            PassportNumber = father.PassportNumber,
            LanguageID = lang
        };


        var applicant = await _changer.GetApplicant(applicationId, lang);

        if (applicant?.RegisterTo != null && applicant.RegisterTo == 3)
        {
            var applications = _unit.Applications.GetByID(applicationId).Result;
            if (applications != null)
            {
                applications.DepartmentID = father.RegistryOffice;
                _unit.Applications.UpdateData(applications);
            }
        }
        

        await UpdateOrInsert(participantsData, created, correctingStatus, 3, applicationId);
        _participantDataId = participantsData.ApplicationParticipantsDataID;
        if (father.PersonDocumentPicture1 == null || father.PersonDocumentPicture2 == null) return;
        string? filePath1 = null;
        string? filePath2 = null;

        if (created || correctingStatus)
        {
            var fatherOld = await _changer.GetFather(applicationId, lang);
            if (fatherOld != null)
            {
                filePath1 = fatherOld.DocumentLink_1;
                filePath2 = fatherOld.DocumentLink_2;
            }
        }

        var fatherDocument1 = await SaveApplicationDocuments(father.PersonDocumentPicture1, 4, 3, filePath1);
        father.DocumentLink_1 = fatherDocument1.AddressLink;

        var fatherDocument2 = await SaveApplicationDocuments(father.PersonDocumentPicture2, 5, 3, filePath2);
        father.DocumentLink_2 = fatherDocument2.AddressLink;

    }

    public async Task SaveParticipantData(Mother? mother)
    {
        var correctingStatus = context.Session.Get<bool>("CorrectingStatus");
        var created = context.Session.Get<bool>("MotherCreated");
        var applicationId = context.Session.Get<int>("ApplicationID");
        var lang = Convert.ToInt32(context.Session.GetString("lang"));

        if (mother == null) return;
        ApplicationsParticipantsData participantsData = new()
        {
            Surname = mother.LastName,
            Name = mother.Name,
            Patronymic = mother.Patronymic,
            Birthday = mother.DateOfBirth,
            Sex = false,
            CustomerID = await SaveCustomerData(mother, correctingStatus, created, applicationId, lang),
            ApplicationID = Convert.ToInt32(context.Session.GetString("ApplicationID")),
            ApplicationMemberTypeID = 4,
            ApplicationTypeID = 1,
            PlaceOfWork = mother.WorkPlace,
            TypeOfActivitiesInWorkID = mother.JobType,
            CurrentAddressLivingStartTime = mother.LiveFrom,
            CurrentCitizenship = mother.Citizenship,
            PassportGivingOrgan = mother.IssuingAuth,
            EducationLevelID = mother.Education,
            AddressID = _addressId,
            CurrentNationality = mother.Nationality,
            PassportNumber = mother.PassportNumber,
            LanguageID = lang
        };

        var applicant = await _changer.GetApplicant(applicationId, lang);

        if (applicant?.RegisterTo != null && applicant.RegisterTo == 4)
        {
            var applications = _unit.Applications.GetByID(applicationId).Result;
            if (applications != null)
            {
                applications.DepartmentID = mother.RegistryOffice;
                _unit.Applications.UpdateData(applications);
            }
        }

        await UpdateOrInsert(participantsData, created, correctingStatus, 4, applicationId);
        _participantDataId = participantsData.ApplicationParticipantsDataID;
        if (mother.PersonDocumentPicture1 == null || mother.PersonDocumentPicture2 == null ||
            mother.MarriageDocumentPicture1 == null) return;
        string? filePath1 = null;
        string? filePath2 = null;
        string? filePath3 = null;

        if (created || correctingStatus)
        {
            var motherOld = await _changer.GetMother(applicationId);
            if (motherOld != null)
            {
                filePath1 = motherOld.DocumentLink_1;
                filePath2 = motherOld.DocumentLink_2;
                filePath3 = motherOld.DocumentLink_3;
            }
        }

        var motherDocument1 = await SaveApplicationDocuments(mother.PersonDocumentPicture1, 4, 4, filePath1);
        mother.DocumentLink_1 = motherDocument1.AddressLink;

        var motherDocument2 = await SaveApplicationDocuments(mother.PersonDocumentPicture2, 5, 4, filePath2);
        mother.DocumentLink_2 = motherDocument2.AddressLink;

        var motherDocument3 = await SaveApplicationDocuments(mother.MarriageDocumentPicture1, 2, 4, filePath3);
        mother.DocumentLink_3 = motherDocument3.AddressLink;
          
    }

    public async Task SaveParticipantData(Deceased? deceased)
    {
        var applicationId = context.Session.Get<int>("ApplicationID");
        var correctingStatus = context.Session.Get<bool>("CorrectingStatus");
        var created = context.Session.Get<bool>("DeceasedCreated");
        var lang = Convert.ToInt32(context.Session.GetString("lang"));
        int? deceasedCustomerId = null;

        if (deceased != null)
        {
            ApplicationsParticipantsData participantsData = new()
            {
                Surname = deceased.LastName,
                Name = deceased.Name,
                Patronymic = deceased.Patronymic,
                Birthday = deceased.DateOfBirth,
                Sex = deceased.Sex,
                CustomerID = await SaveCustomerData(deceased, correctingStatus, created, applicationId, lang),
                ApplicationID = Convert.ToInt32(context.Session.GetString("ApplicationID")),
                ApplicationMemberTypeID = 5,
                ApplicationTypeID = 2,
                AddressID = _addressId,
                LanguageID = Convert.ToInt32(context.Session.GetString("lang")),
                PlaceOfWork = deceased.WorkPlace,
                EducationLevelID = deceased.Education,
                MaritalStatusID = deceased.MaritalStatus,
                CurrentNationality = deceased.Nationality,
                CurrentCitizenship = deceased.Citizenship 
            };

            if (created || correctingStatus)
            {
                var participantsDeceased = _unit.ApplicationsParticipantsData.GetByPredicate(ad =>
                    ad.ApplicationID == applicationId && ad.ApplicationMemberTypeID == 5).Result;
                deceasedCustomerId = participantsDeceased.CustomerID;
            }

            await SaveDeceasedDetails(new DeceasedDetailsDto
            {
                Detail = await SaveAddress(deceased, 2, deceasedCustomerId),
                ApplicationSpecificId = 9,
                ApplicationId = applicationId,
                SpecificId = 9,
                CorrectingStatus = correctingStatus,
                DeceasedCreated = created
            });
            await SaveDeceasedDetails(new DeceasedDetailsDto
            {
                Detail = await SaveAddress(deceased, 3, deceasedCustomerId),
                ApplicationSpecificId = 7,
                ApplicationId = applicationId,
                SpecificId = 7,
                CorrectingStatus = correctingStatus,
                DeceasedCreated = created
            });
            await SaveDeceasedDetails(new DeceasedDetailsDto
            {
                Detail = deceased.DateOfDeath.ToString("yyyy-MM-dd HH:mm:ss.fffffff"),
                ApplicationSpecificId = 6,
                ApplicationId = applicationId,
                SpecificId = 6,
                CorrectingStatus = correctingStatus,
                DeceasedCreated = created
            });
            await SaveDeceasedDetails(new DeceasedDetailsDto
            {
                Detail = deceased.BirthAddress,
                ApplicationSpecificId = 8,
                ApplicationId = applicationId,
                SpecificId = 8,
                CorrectingStatus = correctingStatus,
                DeceasedCreated = created
            });
            await SaveDeceasedDetails(new DeceasedDetailsDto
            {
                Detail = deceased.DeathAddress,
                ApplicationSpecificId = 10,
                ApplicationId = applicationId,
                SpecificId = 10,
                CorrectingStatus = correctingStatus,
                DeceasedCreated = created
            });

            var applications = _unit.Applications.GetByID(applicationId).Result;
            if (applications != null)
            {
                applications.DepartmentID = deceased.RegistryOffice;
                _unit.Applications.UpdateData(applications);
            }

            Applications application = await _unit.Applications.GetByID(applicationId);
            application.MainEventTime = deceased.DateOfDeath;

            await UpdateOrInsert(participantsData, created, correctingStatus, 5, applicationId);
            _participantDataId = participantsData.ApplicationParticipantsDataID;
        }

        if (deceased is not { DeathDocumentPicture1: { } }) return;

        string? filePath1 = null;

        if (created || correctingStatus)
        {
            var deceasedOld = await _changer.GetDeceased(applicationId, lang);
            if (deceasedOld != null) filePath1 = deceasedOld.DocumentLink_1;
        }

        var document = await SaveApplicationDocuments(deceased.DeathDocumentPicture1, 7, 5, filePath1);
        deceased.DocumentLink_1 = document.AddressLink;
    }

    private async Task SaveApplicationDetails(object? detail, int specificId, int memberType, int applicationType,
        bool created, bool correction, int applicationId)
    {
        ApplicationsDetails applicationDetail;

        if (correction)
        {
            applicationDetail = await _unit.ApplicationsDetails.GetByPredicate(ad => ad.ApplicationID == applicationId && ad.SpecificApplicationDataID == specificId);
            applicationDetail.MistakeStatus = 3;
            applicationDetail.ApplicationTypeID = applicationType;
            applicationDetail.SpecificApplicationDataID = specificId;
            applicationDetail.ApplicationMemberTypeID = memberType;
            applicationDetail.LabelID = await _unit.SpecificApplicationData.GetLabelID(specificId);
            applicationDetail.ApplicationTypesSpecificDataID = specificId;
            applicationDetail.Detail = detail?.ToString();
        }
        else
        {
            if (created)
            {
                applicationDetail = await _unit.ApplicationsDetails.GetByPredicate(ad => ad.ApplicationID == applicationId && ad.SpecificApplicationDataID == specificId);
                applicationDetail.MistakeStatus = 3;
                applicationDetail.ApplicationTypeID = applicationType;
                applicationDetail.SpecificApplicationDataID = specificId;
                applicationDetail.ApplicationMemberTypeID = memberType;
                applicationDetail.LabelID = await _unit.SpecificApplicationData.GetLabelID(specificId);
                applicationDetail.ApplicationTypesSpecificDataID = specificId;
                applicationDetail.Detail = detail?.ToString();
            }
            else
            {
                applicationDetail = new ApplicationsDetails
                {
                    ApplicationID = applicationId,
                    MistakeStatus = 3,
                    ApplicationTypeID = applicationType,
                    SpecificApplicationDataID = specificId,
                    ApplicationMemberTypeID = memberType,
                    LabelID = _unit.SpecificApplicationData.GetLabelID(specificId).Result,
                    ApplicationTypesSpecificDataID = specificId,
                    Detail = detail?.ToString()
                };
                _unit.ApplicationsDetails.InsertData(applicationDetail);
            }
        }
    }

    private async Task SaveDeceasedDetails(DeceasedDetailsDto detailsDto)
    {
        ApplicationsDetails deceasedDetails;
        var created = detailsDto.DeceasedCreated;
        var correction = detailsDto.CorrectingStatus;
        var detail = detailsDto.Detail;
        var applicationId = detailsDto.ApplicationId;
        var specificId = detailsDto.SpecificId;
        var applicationSpecificId = detailsDto.ApplicationSpecificId;

        if (correction && created)
        {
            deceasedDetails = await _unit.ApplicationsDetails.GetByPredicate(ad =>
                ad.ApplicationID == applicationId && ad.SpecificApplicationDataID == specificId);
            deceasedDetails.Detail = detail.ToString();
            deceasedDetails.MistakeStatus = 3;
        }
        else
        {
            deceasedDetails = new ApplicationsDetails
            {
                ApplicationID = applicationId,
                Detail = detail.ToString(),
                MistakeStatus = 3,
                ApplicationTypeID = 2,
                SpecificApplicationDataID = specificId,
                ApplicationMemberTypeID = 5,
                LabelID = await _unit.SpecificApplicationData.GetLabelID(specificId)
            };
            if (applicationSpecificId.HasValue)
                deceasedDetails.ApplicationTypesSpecificDataID = applicationSpecificId.Value;
            _unit.ApplicationsDetails.InsertData(deceasedDetails);
        }
    }

    private async Task<Applications> SaveApplicantData(ApplicantDataDto applicantDataDto)
    {
        var created = applicantDataDto.ApplicantCreated;
        var correction = applicantDataDto.CorrectingStatus;
        Applications? applications;
        if (correction || created)
        {
            var applicationId = applicantDataDto.Context.Session.Get<int>("ApplicationID");
            applications = await _unit.Applications.GetByID(applicationId);
            applications.CreatedTime = DateTime.Now;
        }
        else
        {
            var applicantFormCode = applicantDataDto.ApplicantFormCode;
            var externalId = applicantDataDto.ExternalId;
            applications = CreateApplications(externalId, applicantFormCode);
            _unit.Applications.InsertData(applications);
            
        }

        // context.SaveChanges() is called here
        await _unit.Complete();
        return applications;
    }

    private static Applications CreateApplications(int externalId, int applicantFormCode)
    {
        Applications applications = new()
        {
            CreatedTime = DateTime.Now,
            ApplicationSourceID = 1,
            ApplicationPaymentID = null,
            PaymentSystemID = null,
            ExternalID = externalId,
            ApplicationToCROISStatusID = 1,
            ApplicationStatusID = 1
        };
        if (applicantFormCode == 1)
            applications.ApplicationTypeID = 1;
        else
            applications.ApplicationTypeID = 2;
        return applications;
    }

    private async Task<int> SaveCustomerData(Applicant? applicant, int applicationId, bool created, bool correction, int lang,
        int externalId)
    {
        Customers customer;

        if (correction || created)
        {
            var customerId = _unit.ApplicationsParticipantsData.GetByPredicate(ad =>
                ad.ApplicationID == applicationId && ad.ApplicationMemberTypeID == 1).Result.CustomerID;
            customer = await GetApplicantCustomer(true, customerId, applicant, externalId, lang);
        }
        else
        {
            customer = await GetApplicantCustomer(false, _customerId, applicant, externalId, lang);
            _unit.Customers.InsertData(customer);
        }

        await _unit.Complete();

        return customer.CustomerID;
    }

    private async Task<int> SaveCustomerData(Child? child, bool correction, bool created, int applicationId, int lang)
    {
        Customers customer;

        if (correction || created)
        {
            var participantsData = _unit.ApplicationsParticipantsData.GetByPredicate(ad =>
                ad.ApplicationID == applicationId && ad.ApplicationMemberTypeID == 2).Result;
            customer = await GetChildCustomer(true, participantsData.CustomerID, child, lang);
        }
        else
        {
            customer = await GetChildCustomer(false, null, child, lang);
            _unit.Customers.InsertData(customer);
        }

        await _unit.Complete();
        return customer.CustomerID;
    }

    private async Task<int> SaveCustomerData(Father? father, bool correction, bool created, int applicationId, int lang)
    {
        Customers customer;

        if (correction || created)
        {
            var participantsData = _unit.ApplicationsParticipantsData.GetByPredicate(ad =>
                ad.ApplicationID == applicationId && ad.ApplicationMemberTypeID == 3).Result;
            customer = await GetFatherCustomer(true, participantsData.CustomerID, father, lang);
        }
        else
        {
            customer = await GetFatherCustomer(false, null, father, lang);
            _unit.Customers.InsertData(customer);
        }

        await _unit.Complete();

        return customer.CustomerID;
    }

    private async Task<int> SaveCustomerData(Mother? mother, bool correction, bool created, int applicationId, int lang)
    {
        Customers customer;

        if (correction || created)
        {
            var participantsData = _unit.ApplicationsParticipantsData.GetByPredicate(ad =>
                ad.ApplicationID == applicationId && ad.ApplicationMemberTypeID == 4).Result;
            customer = await GetMotherCustomer(true, participantsData.CustomerID, mother, lang);
        }
        else
        {
            customer = await GetMotherCustomer(false, null, mother, lang);
            _unit.Customers.InsertData(customer);
        }

        await _unit.Complete();

        return customer.CustomerID;
    }

    private async Task<int> SaveCustomerData(Deceased? deceased, bool correction, bool created, int applicationId, int lang)
    {
        Customers customer;

        if (correction || created)
        {
            var participantsData = _unit.ApplicationsParticipantsData.GetByPredicate(ad =>
                ad.ApplicationID == applicationId && ad.ApplicationMemberTypeID == 5).Result;
            customer = await GetDeceasedCustomer(true, participantsData.CustomerID, deceased, lang);
        }
        else
        {
            customer = await GetDeceasedCustomer(false, null, deceased, lang);
            _unit.Customers.InsertData(customer);
        }

        await _unit.Complete();

        return customer.CustomerID;
    }

    private async Task<Customers> GetApplicantCustomer(bool isUpdate, int? customerId, Applicant? applicant, int externalId,
        int lang)
    {
        Customers? customer = null;
        if (isUpdate)
        {
            customer = _unit.Customers.GetByID(customerId).Result;
            if (applicant != null)
            {
                await UpdateCustomer(customer, applicant);
            }

            customer.ExternalID = externalId;
            customer.LanguageID = lang;
        }
        else
        {
            if (applicant != null)
                customer = new Customers
                {
                    Surname = applicant.LastName,
                    Name = applicant.Name,
                    Patronymic = applicant.Patronymic,
                    PassportNumber = applicant.PassportNumber,
                    PassportItnNumber = applicant.TIN,
                    PassportGivingOrgan = applicant.IssuingAuth,
                    AddressID = await SaveOrUpdateAddress(applicant, null),
                    VillageID = applicant.CurrentVillage,
                    CityDistrictID = applicant.CurrentCity,
                    RegionID = applicant.CurrentRegion,
                    CountryID = applicant.CurrentCountry,
                    ExternalID = externalId,
                    LanguageID = lang
                };
        }

        return customer ?? throw new InvalidOperationException("Failed to get applicant customer");
    }

    private async Task<Customers> GetChildCustomer(bool isUpdate, int? customerId, Child? child, int lang)
    {
        Customers? customer = null;

        if (isUpdate)
        {
            customer = _unit.Customers.GetByID(customerId).Result;
            if (child != null)
            {
                customer.CountryID = child.CurrentCountry;
                customer.RegionID = child.CurrentRegion;
                customer.CityDistrictID = child.CurrentCity;
                customer.VillageID = child.CurrentVillage;
                customer.Surname = child.LastName;
                customer.Name = child.Name;
                customer.Patronymic = child.Patronymic;
                customer.Sex = child.Sex;
                customer.AddressID = await SaveAddress(child, customer.AddressID);
                customer.Birthday = child.DateOfBirth.Add(child.TimeOfBirth.TimeOfDay);
            }

            customer.LanguageID = lang;
        }
        else
        {
            if (child != null)
                customer = new Customers
                {
                    CountryID = child.CurrentCountry,
                    RegionID = child.CurrentRegion,
                    CityDistrictID = child.CurrentCity,
                    VillageID = child.CurrentVillage,
                    Surname = child.LastName,
                    Name = child.Name,
                    Patronymic = child.Patronymic,
                    Sex = child.Sex,
                    AddressID = await SaveAddress(child, null),
                    Birthday = child.DateOfBirth.Add(child.TimeOfBirth.TimeOfDay),
                    LanguageID = lang
                };
        }

        return customer ?? throw new InvalidOperationException("Failed to get child customer");
    }

    private async Task<Customers> GetFatherCustomer(bool isUpdate, int? customerId, Father? father, int lang)
    {
        Customers? customer = null;
        if (isUpdate)
        {
            customer = _unit.Customers.GetByID(customerId).Result;
            if (father != null)
            {
                customer.Surname = father.LastName;
                customer.Name = father.Name;
                customer.Patronymic = father.Patronymic;
                customer.Birthday = father.DateOfBirth;
                customer.Sex = true;
                customer.PassportNumber = father.PassportNumber;
                customer.PlaceOfWork = father.WorkPlace;
                customer.TypeOfActivitiesInWorkID = father.JobType;
                customer.CurrentAddressLivingStartTime = father.LiveFrom;
                customer.CityzenshipID = father.Citizenship;
                customer.NationalityID = father.Nationality;
                customer.AddressID = await SaveAddress(father, customer.AddressID);
                customer.CountryID = father.CurrentCountry;
                customer.RegionID = father.CurrentRegion;
                customer.CityDistrictID = father.CurrentCity;
                customer.VillageID = father.CurrentVillage;
            }

            customer.LanguageID = lang;
        }
        else
        {
            if (father != null)
                customer = new Customers
                {
                    Surname = father.LastName,
                    Name = father.Name,
                    Patronymic = father.Patronymic,
                    Birthday = father.DateOfBirth,
                    Sex = true,
                    PassportNumber = father.PassportNumber,
                    PlaceOfWork = father.WorkPlace,
                    TypeOfActivitiesInWorkID = father.JobType,
                    CurrentAddressLivingStartTime = father.LiveFrom,
                    CityzenshipID = father.Citizenship,
                    NationalityID = father.Nationality,
                    AddressID = await SaveAddress(father, null),
                    CountryID = father.CurrentCountry,
                    RegionID = father.CurrentRegion,
                    CityDistrictID = father.CurrentCity,
                    VillageID = father.CurrentVillage,
                    LanguageID = lang
                };
        }

        return customer ?? throw new InvalidOperationException("Failed to get father customer");
    }

    private async Task<Customers> GetMotherCustomer(bool isUpdate, int? customerId, Mother? mother, int lang)
    {
        Customers? customer = null;
        if (isUpdate)
        {
            customer = _unit.Customers.GetByID(customerId).Result;
            if (mother != null)
            {
                customer.Surname = mother.LastName;
                customer.Name = mother.Name;
                customer.Patronymic = mother.Patronymic;
                customer.Birthday = mother.DateOfBirth;
                customer.Sex = true;
                customer.PassportNumber = mother.PassportNumber;
                customer.PlaceOfWork = mother.WorkPlace;
                customer.TypeOfActivitiesInWorkID = mother.JobType;
                customer.CurrentAddressLivingStartTime = mother.LiveFrom;
                customer.CityzenshipID = mother.Citizenship;
                customer.NationalityID = mother.Nationality;
                customer.AddressID = await SaveAddress(mother, customer.AddressID);
                customer.CountryID = mother.CurrentCountry;
                customer.RegionID = mother.CurrentRegion;
                customer.CityDistrictID = mother.CurrentCity;
                customer.VillageID = mother.CurrentVillage;
            }

            customer.LanguageID = lang;
        }
        else
        {
            if (mother != null)
                customer = new Customers
                {
                    Surname = mother.LastName,
                    Name = mother.Name,
                    Patronymic = mother.Patronymic,
                    Birthday = mother.DateOfBirth,
                    Sex = true,
                    PassportNumber = mother.PassportNumber,
                    PlaceOfWork = mother.WorkPlace,
                    TypeOfActivitiesInWorkID = mother.JobType,
                    CurrentAddressLivingStartTime = mother.LiveFrom,
                    CityzenshipID = mother.Citizenship,
                    NationalityID = mother.Nationality,
                    AddressID = await SaveAddress(mother, null),
                    CountryID = mother.CurrentCountry,
                    RegionID = mother.CurrentRegion,
                    CityDistrictID = mother.CurrentCity,
                    VillageID = mother.CurrentVillage,
                    LanguageID = lang
                };
        }

        return customer ?? throw new InvalidOperationException("Failed to get mother customer");
    }

    private async Task<Customers> GetDeceasedCustomer(bool isUpdate, int? customerId, Deceased? deceased, int lang)
    {
        Customers? customer = null;
        if (isUpdate)
        {
            customer = _unit.Customers.GetByID(customerId).Result;
            if (deceased != null)
            {
                customer.Surname = deceased.LastName;
                customer.Name = deceased.Name;
                customer.Patronymic = deceased.Patronymic;
                customer.Birthday = deceased.DateOfBirth;
                customer.Sex = deceased.Sex;
                customer.CountryID = deceased.CurrentCountry;
                customer.RegionID = deceased.CurrentRegion;
                customer.CityDistrictID = deceased.CurrentCity;
                customer.VillageID = deceased.CurrentVillage;
                customer.AddressID = await SaveAddress(deceased, 1, customer.AddressID);
            }

            customer.LanguageID = lang;
        }
        else
        {
            if (deceased != null)
                customer = new Customers
                {
                    Surname = deceased.LastName,
                    Name = deceased.Name,
                    Patronymic = deceased.Patronymic,
                    Birthday = deceased.DateOfBirth,
                    Sex = deceased.Sex,
                    CountryID = deceased.CurrentCountry,
                    RegionID = deceased.CurrentRegion,
                    CityDistrictID = deceased.CurrentCity,
                    VillageID = deceased.CurrentVillage,
                    AddressID = await SaveAddress(deceased, 1, null),
                    LanguageID = lang
                };
        }

        return customer ?? throw new InvalidOperationException("Failed to get deceased customer");
    }

    private async Task<int> SaveOrUpdateAddress(Applicant? applicant, int? id)
    {
        Addresses address;
        if (applicant == null) return 0;
        if (id != null)
        {
            address = await _unit.Addresses.GetByID(id);
            address.AddressName = applicant.CurrentAddress;
            address.CityDistrictID = applicant.CurrentCity;
            address.RegionID = applicant.CurrentRegion;
            address.CountryID = applicant.CurrentCountry;
            address.VillageID = applicant.CurrentVillage;
        }
        else
        {
            address = new Addresses
            {
                AddressName = applicant.CurrentAddress,
                CityDistrictID = applicant.CurrentCity,
                RegionID = applicant.CurrentRegion,
                CountryID = applicant.CurrentCountry,
                StatusID = 1,
                VillageID = applicant.CurrentVillage
            };
            _unit.Addresses.InsertData(address);
        }

        await _unit.Complete();

        _addressId = address.AddressID;
        return address.AddressID;
    }

    private async Task<int> SaveAddress(Child? child, int? id)
    {
        Addresses address;
        if (child == null) return 0;
        if (id != null)
        {
            address = _unit.Addresses.GetByID(id).Result;
            address.AddressName = child.Birthplace;
            address.CountryID = child.CurrentCountry;
            address.RegionID = child.CurrentRegion;
            address.CityDistrictID = child.CurrentCity;
            address.VillageID = child.CurrentVillage;
        }
        else
        {
            address = new Addresses
            {
                AddressName = child.Birthplace,
                CountryID = child.CurrentCountry,
                RegionID = child.CurrentRegion,
                CityDistrictID = child.CurrentCity,
                VillageID = child.CurrentVillage,
                StatusID = 1
            };
            _unit.Addresses.InsertData(address);
        }

        await _unit.Complete();

        _addressId = address.AddressID;
        return address.AddressID;
    }

    private async Task<int> SaveAddress(Father? father, int? id)
    {
        Addresses address;
        if (father == null) return 0;
        if (id != null)
        {
            address = _unit.Addresses.GetByID(id).Result;
            address.AddressName = father.CurrentAddress;
            address.CityDistrictID = father.CurrentCity;
            address.RegionID = father.CurrentRegion;
            address.CountryID = father.CurrentCountry;
            address.VillageID = father.CurrentVillage;
        }
        else
        {
            address = new Addresses
            {
                AddressName = father.CurrentAddress,
                CityDistrictID = father.CurrentCity,
                RegionID = father.CurrentRegion,
                CountryID = father.CurrentCountry,
                VillageID = father.CurrentVillage,
                StatusID = 1
            };
            _unit.Addresses.InsertData(address);
        }

        await _unit.Complete();
        _addressId = address.AddressID;
        return address.AddressID;
    }

    private async Task<int> SaveAddress(Mother? mother, int? id)
    {
        Addresses address;
        if (mother == null) return 0;
        if (id != null)
        {
            address = _unit.Addresses.GetByID(id).Result;
            address.AddressName = mother.CurrentAddress;
            address.CityDistrictID = mother.CurrentCity;
            address.RegionID = mother.CurrentRegion;
            address.CountryID = mother.CurrentCountry;
            address.VillageID = mother.CurrentVillage;
        }
        else
        {
            address = new Addresses
            {
                AddressName = mother.CurrentAddress,
                CityDistrictID = mother.CurrentCity,
                RegionID = mother.CurrentRegion,
                CountryID = mother.CurrentCountry,
                VillageID = mother.CurrentVillage,
                StatusID = 1
            };
            _unit.Addresses.InsertData(address);
        }

        await _unit.Complete();
        _addressId = address.AddressID;
        return address.AddressID;
    }

    /// <summary>
    ///     Saves data into Addresses table
    /// </summary>
    /// <param name="deceased"></param>
    /// <param name="code">1 for LastLivePlace, 2 for BirthPlace and another for DeathPlace</param>
    /// <param name="id"></param>
    /// <returns>returns an id of saved address</returns>
    private async Task<int> SaveAddress(Deceased? deceased, int code, int? id)
    {
        Addresses address;

        if (id != null)
        {
            address = await _unit.Addresses.GetByID(id);
            SortAddress(address, deceased, code);
        }
        else
        {
            address = new Addresses { StatusID = 1 };
            SortAddress(address, deceased, code);
            _unit.Addresses.InsertData(address);
        }

        await _unit.Complete();
        _addressId = address.AddressID;
        return address.AddressID;
    }

    private static void SortAddress(Addresses address, Deceased? deceased, int code)
    {
        if (deceased == null) return;
        switch (code)
        {
            case 1:
                address.CountryID = deceased.CurrentCountry;
                address.RegionID = deceased.CurrentRegion;
                address.CityDistrictID = deceased.CurrentCity;
                address.VillageID = deceased.CurrentVillage;
                address.AddressName = deceased.CurrentAddress;
                break;
            case 2:
                address.CountryID = deceased.DeathCountry;
                address.RegionID = deceased.DeathRegion;
                address.CityDistrictID = deceased.DeathCity;
                address.VillageID = deceased.DeathVillage;
                address.AddressName = deceased.DeathAddress;
                break;
            default:
                address.CountryID = deceased.BirthCountry;
                address.RegionID = deceased.BirthRegion;
                address.CityDistrictID = deceased.BirthCity;
                address.VillageID = deceased.BirthVillage;
                address.AddressName = deceased.BirthAddress;
                break;
        }
    }

    private async Task<ApplicationDocuments> SaveApplicationDocuments(IFormFile? file, int documentType,
        int fromCode, string? filePath)
    {
        ApplicationDocuments? applicationDocuments;
        var correction = context.Session.Get<bool>("CorrectingStatus");
        var created = false;
        var participantId = 0;
        var applicationId = context.Session.Get<int>("ApplicationID");
        var lang = Convert.ToInt32(context.Session.GetString("lang"));

        switch (fromCode)
        {
            case 1:
                created = context.Session.Get<bool>("ApplicantCreated");
                if (correction || created)
                {
                    var applicantData  = await _unit.Applications.GetApplicantsDataMobile(applicationId, lang);
                    if (applicantData != null)
                        participantId = applicantData.ApplicationParticipantsDataID;
                }
                break;
            case 2:
                created = context.Session.Get<bool>("ChildCreated");
                if (correction || created)
                {
                    var childData = await _unit.Applications.GetChildsDataMobile(applicationId, lang);
                    if(childData != null)
                        participantId = childData.ApplicationParticipantsDataID;
                }
                break;
            case 3:
                created = context.Session.Get<bool>("FatherCreated");
                if (correction || created)
                {
                    var fatherData = await _unit.Applications.GetFathersDataMobile(applicationId);
                    if(fatherData != null)
                        participantId = fatherData.ApplicationParticipantsDataID;
                }
                break;
            case 4:
                created = context.Session.Get<bool>("MotherCreated");
                if (correction || created)
                {
                    var motherData = await _unit.Applications.GetMothersDataMobile(applicationId);
                    if (motherData != null)
                        participantId = motherData.ApplicationParticipantsDataID;
                }
                break;
            case 5:
                created = context.Session.Get<bool>("DeceasedCreated");
                if (correction || created)
                {
                    var deceasedData = await _unit.Applications.GetDeceasedDataMobile(applicationId, lang);
                    if (deceasedData != null)
                        participantId = deceasedData.ApplicationParticipantsDataID;
                }
                break;
        }

        if (correction)
        {
            if (filePath != null)
            {
                applicationDocuments = _unit.ApplicationDocuments.GetByPredicate(ad =>
                    ad.ApplicationID == applicationId && ad.ApplicationParticipantsDataID == participantId).Result;
                if (applicationDocuments != null)
                {
                    applicationDocuments.AddressLink = SaveDocument(file, fromCode, filePath).Result;
                    applicationDocuments.RecievedTime = DateTime.Now;
                }
                else
                {
                    applicationDocuments = await CreateDocument(file, fromCode, filePath, documentType);
                }
            }
            else
            {
                applicationDocuments = await CreateDocument(file, fromCode, filePath, documentType);
            }
        }
        else
        {
            if (created)
            {
                if (filePath != null)
                {
                    applicationDocuments = (ApplicationDocuments?)_unit.ApplicationDocuments.GetByPredicate(ad =>
                        ad.ApplicationID == applicationId && ad.ApplicationParticipantsDataID == participantId).Result;
                    if (applicationDocuments != null)
                    {
                        applicationDocuments.AddressLink = SaveDocument(file, fromCode, filePath).Result;
                        applicationDocuments.RecievedTime = DateTime.Now;
                    }
                    else
                    {
                        applicationDocuments = await CreateDocument(file, fromCode, filePath, documentType);
                        _unit.ApplicationDocuments.InsertData(applicationDocuments);
                    }
                }
                else
                {
                    applicationDocuments = await CreateDocument(file, fromCode, filePath, documentType);
                }
            }
            else
            {
                applicationDocuments = await CreateDocument(file, fromCode, filePath, documentType);
                _unit.ApplicationDocuments.InsertData(applicationDocuments);
            }
        }

        await _unit.Complete();
        context.Session.Set("ApplicationDocuments", applicationDocuments);
        return applicationDocuments;
    }

    private async Task<ApplicationDocuments> CreateDocument(IFormFile? file, int fromCode, string? filePath,
        int documentType)
    {
        ApplicationDocuments applicationDocuments = new()
        {
            AddressLink = await SaveDocument(file, fromCode, filePath),
            RecievedTime = DateTime.Now,
            DocumentTypeID = documentType,
            ApplicationID = Convert.ToInt32(context.Session.GetString("ApplicationID")),
            ApplicationParticipantsDataID = _participantDataId
        };
        var applicantFormCode = Convert.ToInt32(context.Session.GetString("ApplicantFormCode"));
        applicationDocuments.ApplicationTypeID = applicantFormCode == 1 ? 1 : 2;
        return applicationDocuments;
    }

    public async Task<string> SaveDocument(IFormFile? file, int fromCode, string? filePath)
    {
        if (file == null) return "";
        var created = fromCode switch
        {
            1 => context.Session.Get<bool>("ApplicantCreated"),
            2 => context.Session.Get<bool>("ChildCreated"),
            3 => context.Session.Get<bool>("FatherCreated"),
            4 => context.Session.Get<bool>("MotherCreated"),
            5 => context.Session.Get<bool>("DeceasedCreated"),
            _ => context.Session.Get<bool>("ApplicantCreated")
        };
        if (created)
            if (filePath != null)
                File.Delete(filePath);

        var documentName = Guid.NewGuid() + ".jpeg";
        Directory.CreateDirectory(_webHostEnvironment.WebRootPath + "/media/applicant_Documents/");
        var path = _webHostEnvironment.WebRootPath + "/media/applicant_Documents/" + documentName;
        try
        {
            await using var fileSteam = new MemoryStream();
            await file.CopyToAsync(fileSteam);

            Image image = CompressImage(fileSteam, 20);
            image.Save(path);

        }
        catch
        {
            return "";
        }

        return path;
    }

    private static Image CompressImage(MemoryStream stream, int newQuality)   // set quality to 1-100, eg 50
    {
        using Image image = Image.FromStream(stream);
        using Image memImage = new Bitmap(image);
        ImageCodecInfo myImageCodecInfo;
        System.Drawing.Imaging.Encoder myEncoder;
        EncoderParameter myEncoderParameter;
        EncoderParameters myEncoderParameters;
        myImageCodecInfo = GetEncoderInfo("image/jpeg");
        myEncoder = System.Drawing.Imaging.Encoder.Quality;
        myEncoderParameters = new EncoderParameters(1);
        myEncoderParameter = new EncoderParameter(myEncoder, newQuality);
        myEncoderParameters.Param[0] = myEncoderParameter;

        MemoryStream memStream = new();
        memImage.Save(memStream, myImageCodecInfo, myEncoderParameters);
        Image newImage = Image.FromStream(memStream);
        ImageAttributes imageAttributes = new();
        using (Graphics g = Graphics.FromImage(newImage))
        {
            g.InterpolationMode =
              System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;  //**
            g.DrawImage(newImage, new Rectangle(Point.Empty, newImage.Size), 0, 0,
              newImage.Width, newImage.Height, GraphicsUnit.Pixel, imageAttributes);
        }
        return newImage;
    }

    private static ImageCodecInfo GetEncoderInfo(string mimeType)
    {
        ImageCodecInfo[] encoders;
        encoders = ImageCodecInfo.GetImageEncoders();
        foreach (ImageCodecInfo ici in encoders)
            if (ici.MimeType == mimeType) return ici;

        return encoders[0];
    }

    public async Task<List<Payment>> GetPaymentList(int applicationId)
    {
        IEnumerable<PaymentTypesMobileResponse> payments = await _unit.Applications.GetPaymentTypes(applicationId, 1);

        return payments.Select(obj => new Payment
            {
                PaymentType = obj.RegistryService, PaymentPrice = obj.ServiceSum.ToString(CultureInfo.InvariantCulture)
            })
            .ToList();
    }

    public async Task UpdateCustomerLang(int externalId, int langId)
    {
        var customer = await _unit.Customers.GetCustomerByExternalID(externalId);
        if (customer == null) return;
        customer.LanguageID = langId;
        _unit.Customers.UpdateData(customer);
        await _unit.Complete();
    }

    private async Task UpdateOrInsert(ApplicationsParticipantsData participantsData, bool created, bool correction,
        int memberType, int applicationId)
    {
        if (correction || created)
        {
            var participantsDataOld = await _unit.ApplicationsParticipantsData.GetByPredicate(ad =>
                ad.ApplicationID == applicationId && ad.ApplicationMemberTypeID == memberType);
            participantsDataOld.Surname = participantsData.Surname;
            participantsDataOld.Name = participantsData.Name;
            participantsDataOld.Patronymic = participantsData.Patronymic;
            participantsDataOld.Birthday = participantsData.Birthday;
            participantsDataOld.Sex = participantsData.Sex;
            participantsDataOld.TelephoneNumber = participantsData.TelephoneNumber;
            participantsDataOld.PassportNumber = participantsData.PassportNumber;
            participantsDataOld.PassportItnNumber = participantsData.PassportItnNumber;
            participantsDataOld.PassportGivingOrgan = participantsData.PassportGivingOrgan;
            participantsDataOld.PlaceOfWork = participantsData.PlaceOfWork;
            participantsDataOld.CurrentAddressLivingStartTime = participantsData.CurrentAddressLivingStartTime;
            participantsDataOld.ExternalID = participantsData.ExternalID;
            participantsDataOld.CustomerID = participantsData.CustomerID;
            participantsDataOld.AddressID = participantsData.AddressID;
            participantsDataOld.LanguageID = participantsData.LanguageID;
            participantsDataOld.ApplicationID = participantsData.ApplicationID;
            participantsDataOld.ApplicationTypeID = participantsData.ApplicationTypeID;
            participantsDataOld.CurrentCitizenship = participantsData.CurrentCitizenship;
            participantsDataOld.MaritalStatusID = participantsData.MaritalStatusID;
            participantsDataOld.CurrentNationality = participantsData.CurrentNationality;
            participantsDataOld.EducationLevelID = participantsData.EducationLevelID;
            participantsDataOld.TypeOfActivitiesInWorkID = participantsData.TypeOfActivitiesInWorkID;
        }
        else
        {
            _unit.ApplicationsParticipantsData.InsertData(participantsData);
        }

        await _unit.Complete();
    }
}