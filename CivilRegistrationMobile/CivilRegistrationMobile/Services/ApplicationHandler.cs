namespace CivilRegistrationMobile.Services;

public class ApplicationHandler
{
    private readonly ModelDataChanger _changer;
    private readonly ServerDataHandler _handler;
    private readonly ResponseHandler _responseHandler;
    private readonly IUnitOfWork _unit;
    private readonly HttpContext? _context;
    public ApplicationHandler(ServerDataHandler handler, ModelDataChanger changer, ResponseHandler responseHandler, IUnitOfWork unit, IHttpContextAccessor accessor)
    {
        _handler = handler;
        _changer = changer;
        _responseHandler = responseHandler;
        _unit = unit;
        _context = accessor.HttpContext;
    }

    public async Task<Applicant> FillApplicant()
    {
        _context.Session.SetString("FormName", "applicant");
        var applicantCreated = _context.Session.Get<bool>("ApplicantCreated");
        var correctingStatus = _context.Session.Get<bool>("CorrectingStatus");
        Applicant? applicant;
        if (applicantCreated || correctingStatus)
        {
            var lang = _context.Session.Get<int>("lang");
            var applicationId = _context.Session.Get<int>("ApplicationID");
            applicant = await _changer.GetApplicant(applicationId, lang);
            if (applicant != null)
            {
                await FillApplicationList(applicant, 1);
                _context.Session.Set("RegisterTo", applicant.RegisterTo);
                return applicant;
            }

            applicant = new Applicant();
            await FillApplicationList(applicant, 0);
            return applicant;
        }

        applicant = new Applicant
        {
            ApplicationType = Convert.ToInt32(_context.Session.Get<int?>("ApplicantFormCode"))
        };

        _responseHandler.FillApplicantModel(applicant);
        await FillApplicationList(applicant, 1);

        _context.Session.Set("ApplicantFromAmonat", applicant);

        if (applicant.RegionList != null && applicant.CityList != null)
            _context.Session.SetString("IsApplicantDataExists", "1");

        return applicant;
    }

    public async Task<Child> FillChild()
    {
        _context.Session.SetString("FormName", "child");
        var childCreated = _context.Session.Get<bool>("ChildCreated");
        var correctingStatus = _context.Session.Get<bool>("CorrectingStatus");
        Child? child;
        if (childCreated || correctingStatus)
        {
            var lang = _context.Session.Get<int>("lang");
            var applicationId = _context.Session.Get<int>("ApplicationID");
            child = await _changer.GetChild(applicationId, lang);
            if (child != null)
            {
                await FillApplicationList(child, 1);
                return child;
            }

            child = new Child();
            await FillApplicationList(child, 0);
            return child;
        }

        child = new Child();
        await FillApplicationList(child, 0);
        return child;
    }

    public async Task<Deceased> FillDeceased()
    {
        _context.Session.SetString("FormName", "deceased");
        var deceasedCreated = _context.Session.Get<bool>("DeceasedCreated");
        var correctionStatus = _context.Session.Get<bool>("CorrectingStatus");
        Deceased? deceased;
        if (deceasedCreated || correctionStatus)
        {
            var applicationId = _context.Session.Get<int>("ApplicationID");
            var lang = _context.Session.Get<int>("lang");
            deceased = await _changer.GetDeceased(applicationId, lang);
            if (deceased != null)
            {
                await FillDeceasedList(deceased, 1);
                return deceased;
            }

            deceased = new Deceased();
            await FillDeceasedList(deceased, 0);
            return deceased;
        }
        deceased = new Deceased();
        await FillDeceasedList(deceased, 0);
        return deceased;
    }

    public async Task<Father> FillFather()
    {
        _context.Session.SetString("FormName", "father");
        var fatherCreated = _context.Session.Get<bool>("FatherCreated");
        var correctionStatus = _context.Session.Get<bool>("CorrectingStatus");
        var applicationId = _context.Session.Get<int>("ApplicationID");

        var application = await _unit.Applications.GetDepartmentToWhichAddress(applicationId);
        var registerCode = application.RegistratedByWhichMemberID ?? 0;
        Father? father;
        if (fatherCreated || correctionStatus)
        {
            var lang = _context.Session.Get<int>("lang");
            father = await _changer.GetFather(applicationId, lang);
            if (father != null)
            {
                father.RegisterCode = registerCode;

                if(registerCode == 3)
                {
                    var applicationFather = await _unit.Applications.GetByID(applicationId);
                    father.RegistryOffice = applicationFather.DepartmentID ?? 0;
                }

                await FillApplicationList(father, 1);
                return father;
            }

            father = new Father
            {
                RegisterCode = registerCode
            };
            await FillApplicationList(father, 0);
            return father;
        }
        father = new Father
        {
            RegisterCode = registerCode
        };
        await FillApplicationList(father, 0);
        return father;
    }

    public async Task<Mother> FillMother()
    {
        int applicationId = _context.Session.Get<int>("ApplicationID");
        _context.Session.SetString("FormName", "mother");
        var motherCreated = _context.Session.Get<bool>("MotherCreated");
        var correctionStatus = _context.Session.Get<bool>("CorrectingStatus");
        int registerCode = _context.Session.Get<int>("ApplicationRegisterTo");
        Mother? mother;
        if (motherCreated || correctionStatus)
        {
            mother = await _changer.GetMother(applicationId);
            if (mother != null)
            {
                mother.RegisterCode = registerCode;
                if (registerCode == 4) mother.RegistryOffice = _unit.Applications.GetByID(applicationId).Result.DepartmentID ?? 0;
                await FillApplicationList(mother, 1);
                return mother;
            }

            mother = new Mother
            {
                RegisterCode = registerCode
            };
            await FillApplicationList(mother, 0);
            return mother;
        }
        mother = new Mother
        {
            RegisterCode = registerCode
        };
        await FillApplicationList(mother, 0);
        return mother;
    }

    internal async Task FillDeceasedList(Deceased model, int code)
    {
        var lang = _context.Session.Get<int>("lang");
        switch (code)
        {
            case 0:
                model.CountryList = await _handler.GetCountryNames(0);
                model.RegionList = await _handler.GetRegions(0, 0);
                model.CityList = await _handler.GetCities(0, 0);
                model.VillageList = await _handler.GetVillages(0, 0);
                model.RegistryOfficeList = await _handler.GetRegistryOffices(0, 0, null);
                model.CitizenshipList = await _handler.GetCitizenship(0);
                model.NationalityList = await _handler.GetNationality(0);
                model.EducationList = await _handler.GetEducation(0, lang);
                model.JobTypeList = await _handler.GetJobTitle(0, lang);
                model.MaritalStatusesList = await _handler.GetMaritalStatuses(0, lang);
                model.DeathCountryList = await _handler.GetCountryNames(0);
                model.DeathRegionList = await _handler.GetRegions(0, 0);
                model.DeathCityList = await _handler.GetCities(0, 0);
                model.DeathVillageList = await _handler.GetVillages(0, 0);
                model.BirthCountryList = await _handler.GetCountryNames(0);
                model.BirthRegionList = await _handler.GetRegions(0, 0);
                model.BirthCityList = await _handler.GetCities(0, 0);
                model.BirthVillageList = await _handler.GetVillages(0, 0);
                break;
            case 1:
                model.CountryList = await _handler.GetCountryNames(model.CurrentCountry);
                model.RegionList = await _handler.GetRegions(model.CurrentRegion, model.CurrentCountry);
                model.CityList = await _handler.GetCities(model.CurrentCity, model.CurrentRegion);
                model.VillageList = await _handler.GetVillages(model.CurrentVillage, model.CurrentCity);
                model.RegistryOfficeList = await _handler.GetRegistryOffices(model.RegistryOffice ?? 0, model.CurrentCity, model.CurrentVillage);
                model.CitizenshipList = await _handler.GetCitizenship(model.Citizenship);
                model.NationalityList = await _handler.GetNationality(model.Nationality);
                model.EducationList = await _handler.GetEducation(model.Education, lang);
                model.JobTypeList = await _handler.GetJobTitle(model.JobType, lang);
                model.MaritalStatusesList = await _handler.GetMaritalStatuses(model.MaritalStatus, lang);
                model.DeathCountryList = await _handler.GetCountryNames(model.DeathCountry);
                model.DeathRegionList = await _handler.GetRegions(model.DeathRegion, model.DeathCountry);
                model.DeathCityList = await _handler.GetCities(model.DeathCity, model.DeathRegion);
                model.DeathVillageList = await _handler.GetVillages(model.DeathVillage, model.DeathCity);
                model.BirthCountryList = await _handler.GetCountryNames(model.BirthCountry);
                model.BirthRegionList = await _handler.GetRegions(model.BirthRegion, model.BirthCountry);
                model.BirthCityList = await _handler.GetCities(model.BirthCity, model.BirthRegion);
                model.BirthVillageList = await _handler.GetVillages(model.BirthVillage, model.BirthCity);
                break;
        }
    }

    internal async Task FillApplicationList(ApplicationLists model, int code)
    {
        var lang = _context.Session.Get<int>("lang");
        switch (code)
        {
            case 0:
                model.CountryList = await _handler.GetCountryNames(0);
                model.RegionList = await _handler.GetRegions(0, 0);
                model.CityList = await _handler.GetCities(0, 0);
                model.VillageList = await _handler.GetVillages(0, 0);
                model.RegistryOfficeList = await _handler.GetRegistryOffices(0, 0, null);
                model.CitizenshipList = await _handler.GetCitizenship(0);
                model.NationalityList = await _handler.GetNationality(0);
                model.EducationList = await _handler.GetEducation(0, lang);
                model.JobTypeList = await _handler.GetJobTitle(0, lang);
                model.MaritalStatusesList = await _handler.GetMaritalStatuses(0, lang);
                break;
            case 1:
                model.CountryList = await _handler.GetCountryNames(model.CurrentCountry);
                model.RegionList = await _handler.GetRegions(model.CurrentRegion, model.CurrentCountry);
                model.CityList = await _handler.GetCities(model.CurrentCity, model.CurrentRegion);
                model.VillageList = await _handler.GetVillages(model.CurrentVillage, model.CurrentCity);
                model.RegistryOfficeList = await _handler.GetRegistryOffices(model.RegistryOffice ?? 0, model.CurrentCity, model.CurrentVillage);
                model.CitizenshipList = await _handler.GetCitizenship(model.Citizenship);
                model.NationalityList = await _handler.GetNationality(model.Nationality);
                model.EducationList = await _handler.GetEducation(model.Education, lang);
                model.JobTypeList = await _handler.GetJobTitle(model.JobType, lang);
                model.MaritalStatusesList = await _handler.GetMaritalStatuses(model.MaritalStatus, lang);
                break;
        }
    }

    public void ChangeCorrectionStatus(int code)
    {
        var correctingStatus = _context.Session.Get<bool>("CorrectingStatus");
        if (!correctingStatus) return;
        var correctedApplications = _context.Session.Get<CorrectedApplications>("CorrectedApplications");
        if (correctedApplications == null) return;
        switch (code)
        {
            case 1:
                correctedApplications.Applicant = true;
                break;
            case 2:
                correctedApplications.Child = true;
                break;
            case 3:
                correctedApplications.Father = true;
                break;
            case 4:
                correctedApplications.Mother = true;
                break;
            case 5:
                correctedApplications.Deceased = true;
                break;
        }

        _context.Session.Set("CorrectedApplications", correctedApplications);
    }
}