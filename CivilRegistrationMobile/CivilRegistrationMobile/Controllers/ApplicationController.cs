namespace CivilRegistrationMobile.Controllers;

public class ApplicationController : Controller
{
    private readonly ApplicationHandler _applicationHandler;
    private readonly ModelDataChanger _changer;
    private readonly ServerDataHandler _handler;
    private readonly LabelDefiner _labelDefiner;
    private readonly IUnitOfWork _unit;
    public ApplicationController(ModelDataChanger changer,
        ServerDataHandler handler, ApplicationHandler applicationHandler, LabelDefiner labelDefiner, IUnitOfWork unit)
    {
        _handler = handler;
        _changer = changer;
        _applicationHandler = applicationHandler;
        _labelDefiner = labelDefiner;
        _unit = unit;
    }

    // Applicant View Methods
    public async Task<IActionResult> ApplicantDetails()
    {
        var applicant = await _applicationHandler.FillApplicant();
        HttpContext.Session.Set("Applicant", applicant);
        var lang = Convert.ToInt32(HttpContext.Session.GetString("lang"));
        var applicationId = HttpContext.Session.Get<int>("ApplicationID");
        await _labelDefiner.ApplicationsLabels(this, lang, applicationId);
        return View(applicant);
    }

    [HttpPost]
    public async Task<IActionResult> ApplicantCreate(Applicant? applicant)
    {
        if (applicant == null) return BadRequest();
        HttpContext.Session.SetString("cityID", applicant.CurrentCity.ToString());
        HttpContext.Session.SetString("regionID", applicant.CurrentRegion.ToString());
        var code = Convert.ToInt32(HttpContext.Session.GetString("ApplicantFormCode"));

        HttpContext.Session.Set(code == 2 ? "RegisterTo" : "ApplicationRegisterTo", applicant.RegisterTo);

        await _handler.SaveParticipantData(applicant);

        HttpContext.Session.Set("ApplicantCreated", true);
        HttpContext.Session.Set("ApplicationStatus", 1);
        HttpContext.Session.Set("ColorCode", 1);
        var applicantFormCode = Convert.ToInt32(HttpContext.Session.GetString("ApplicantFormCode"));
        _applicationHandler.ChangeCorrectionStatus(1);
        int applicationId = HttpContext.Session.Get<int>("ApplicationID");

        HttpContext.Session.Set("Applicant", applicant);

        return RedirectToAction(applicantFormCode == 1 ? "NewbornRegistration" : "DeathRegistration", "General", new {applicationId, statusId = 1});
    }

    public async Task<IActionResult> ChildDetails()
    {
        var child = await _applicationHandler.FillChild();
        var lang = Convert.ToInt32(HttpContext.Session.GetString("lang"));
        var applicationId = HttpContext.Session.Get<int>("ApplicationID");
        await _labelDefiner.ApplicationsLabels(this, lang, applicationId);
        return View(child);
    }

    [HttpPost]
    public async Task<IActionResult> ChildCreate(Child child)
    {
        if (!ModelState.IsValid)
        {
            HttpContext.Session.Set("ApplicationRejected", true);
            ViewBag.IsValid = 0;
            await _applicationHandler.FillApplicationList(child, 1);
            var lang = Convert.ToInt32(HttpContext.Session.GetString("lang"));
            var applicationId = HttpContext.Session.Get<int>("ApplicationID");
            await _labelDefiner.ApplicationsLabels(this, lang, applicationId);
            return View("ChildDetails",child);
        }

        if (child == null) return BadRequest();
        await _handler.SaveParticipantData(child);
        HttpContext.Session.Set("ChildCreated", true);
        HttpContext.Session.Set("ApplicationStatus", 2);
        HttpContext.Session.Set("ColorCode", 2);
        _applicationHandler.ChangeCorrectionStatus(2);
        return RedirectToAction("NewbornRegistration", "General");
    }

    public async Task<IActionResult> DeceasedDetails()
    {
        var deceased = await _applicationHandler.FillDeceased();
        var lang = Convert.ToInt32(HttpContext.Session.GetString("lang"));
        var applicationId = HttpContext.Session.Get<int>("ApplicationID");
        await _labelDefiner.ApplicationsLabels(this, lang, applicationId);
        return View(deceased);
    }

    [HttpPost]
    public async Task<IActionResult> DeceasedCreate(Deceased deceased)
    {
        if(!ModelState.IsValid)
        {
            HttpContext.Session.Set("ApplicationRejected", true);
            ViewBag.IsValid = 0;
            await _applicationHandler.FillDeceasedList(deceased, 1);
            var lang = Convert.ToInt32(HttpContext.Session.GetString("lang"));
            var applicationId = HttpContext.Session.Get<int>("ApplicationID");
            await _labelDefiner.ApplicationsLabels(this, lang, applicationId);
            return View("DeceasedDetails", deceased);
        }

        if (deceased == null) return BadRequest();
        await _handler.SaveParticipantData(deceased);
        HttpContext.Session.Set("DeceasedCreated", true);
        HttpContext.Session.Set("ApplicationStatus", 2);
        HttpContext.Session.Set("ColorCode", 2);
        _applicationHandler.ChangeCorrectionStatus(5);
        return RedirectToAction("DeathRegistration", "General");
    }

    public async Task<IActionResult> FatherDetails()
    {
        var father = await _applicationHandler.FillFather();
        var lang = Convert.ToInt32(HttpContext.Session.GetString("lang"));
        var applicationId = HttpContext.Session.Get<int>("ApplicationID");
        await _labelDefiner.ApplicationsLabels(this, lang, applicationId);
        return View(father);
    }

    [HttpPost]
    public async Task<IActionResult> FatherCreate(Father? father)
    {
        if (father == null) return BadRequest();
        await _handler.SaveParticipantData(father);
        HttpContext.Session.Set("FatherCreated", true);
        HttpContext.Session.Set("ApplicationStatus", 3);
        HttpContext.Session.Set("ColorCode", 3);
        _applicationHandler.ChangeCorrectionStatus(3);
        return RedirectToAction("NewbornRegistration", "General");
    }

    public async Task<IActionResult> MotherDetails()
    {
        var mother = await _applicationHandler.FillMother();
        var lang = Convert.ToInt32(HttpContext.Session.GetString("lang"));
        var applicationId = HttpContext.Session.Get<int>("ApplicationID");
        await _labelDefiner.ApplicationsLabels(this, lang, applicationId);
        return View(mother);
    }

    [HttpPost]
    public async Task<IActionResult> MotherCreate(Mother? mother)
    {
        if (mother == null) return BadRequest();

        await _handler.SaveParticipantData(mother);
        HttpContext.Session.Set("MotherCreated", true);
        HttpContext.Session.Set("ApplicationStatus", 4);
        HttpContext.Session.Set("ColorCode", 4);
        _applicationHandler.ChangeCorrectionStatus(4);
        return RedirectToAction("NewbornRegistration", "General");
    }

    [HttpGet]
    public async Task<IActionResult> CountryChange(int id)
    {
        var selectListItems = await _handler.RegionsByCountryId(id);

        if (selectListItems.Count != 0) return Ok(selectListItems);
        return BadRequest();
    }

    [HttpGet]
    public async Task<IActionResult> RegionChange(int id)
    {
        var cities = await _handler.CitiesByRegionId(id);
        return Ok(cities);
    }

    [HttpGet]
    public async Task<IActionResult> CityChange(int id)
    {
        HttpContext.Session.SetString("CityID", id.ToString());
        List<List<SelectListItem>> villagesAndOffices = new()
        {
            await _handler.OfficesByVillageOrCityId(null, id),
            await _handler.VillagesByCityId(id)
        };
        return Ok(villagesAndOffices);
    }

    [HttpGet]
    public IActionResult VillageChange(int id)
    {
        var cityId = Convert.ToInt32(HttpContext.Session.GetString("CityID"));
        return Ok(_handler.OfficesByVillageOrCityId(id, cityId));
    }

    [HttpGet]
    public async Task<IActionResult> GetApplicant()
    {
        var applicationId = HttpContext.Session.Get<int>("ApplicationID");
        var lang = HttpContext.Session.Get<int>("lang");
        var applicant = await _changer.GetApplicant(applicationId, lang);
        if (applicant == null) return BadRequest();
        var countryId = applicant.CurrentCountry;
        var regionId = applicant.CurrentRegion;
        var cityId = applicant.CurrentCity;
        var villageId = applicant.CurrentVillage;

        applicant.CountryList = await _handler.GetCountryNames(countryId);
        applicant.RegionList = await _handler.GetRegions(regionId, countryId);
        applicant.CityList = await _handler.GetCities(cityId, regionId);
        applicant.VillageList = await _handler.GetVillages(villageId, cityId);

        return Ok(applicant);
    }

    [HttpGet]
    public IActionResult GetApplicationStatus()
    {
        var applicationStatus = HttpContext.Session.Get<int>("ApplicationStatus");
        return Ok(applicationStatus);
    }

    [HttpGet]
    public IActionResult GetApplicantDataExist()
    {
        var isDataExist = Convert.ToInt32(HttpContext.Session.GetString("IsApplicantDataExists"));
        return Ok(isDataExist);
    }

    [HttpGet]
    public IActionResult GetApplicationsCreated()
    {
        ApplicationsCreated applications = new()
        {
            Applicant = HttpContext.Session.Get<bool>("ApplicantCreated"),
            Child = HttpContext.Session.Get<bool>("ChildCreated"),
            Father = HttpContext.Session.Get<bool>("FatherCreated"),
            Mother = HttpContext.Session.Get<bool>("MotherCreated"),
            Deceased = HttpContext.Session.Get<bool>("DeceasedCreated")
        };
        return Ok(applications);
    }

    [HttpGet]
    public IActionResult GetApplicationFromCode()
    {
        var applicantFormCode = Convert.ToInt32(HttpContext.Session.GetString("ApplicantFormCode"));
        if (applicantFormCode != 0)
            return Ok(applicantFormCode);
        return BadRequest();
    }

    public IActionResult GetApplicantRegisterCode()
    {
        var code = HttpContext.Session.Get<int?>("RegisterTo");
        if (code != null)
            return Ok(code);
        return BadRequest();
    }

    [HttpGet]
    public IActionResult GetCurrentFormName()
    {
        if (!string.IsNullOrWhiteSpace(HttpContext.Session.GetString("FormName")))
            return Ok(HttpContext.Session.GetString("FormName"));
        return BadRequest();
    }

    [HttpGet]
    public IActionResult GetApplicantFields()
    {
        var applicantFields = HttpContext.Session.Get<List<ApplicationField>>("ApplicantFields");
        if (applicantFields != null)
            return Ok(applicantFields);
        return BadRequest();
    }

    [HttpGet]
    public IActionResult GetChildFields()
    {
        var childFields = HttpContext.Session.Get<List<ApplicationField>>("ChildFields");
        if (childFields != null)
            return Ok(childFields);
        return BadRequest();
    }

    [HttpGet]
    public IActionResult GetFatherFields()
    {
        var fatherFields = HttpContext.Session.Get<List<ApplicationField>>("FatherFields");
        if (fatherFields != null)
            return Ok(fatherFields);
        return BadRequest();
    }

    [HttpGet]
    public IActionResult GetMotherFields()
    {
        var motherFields = HttpContext.Session.Get<List<ApplicationField>>("MotherFields");
        if (motherFields != null)
            return Ok(motherFields);
        return BadRequest();
    }

    [HttpGet]
    public IActionResult GetDeceasedFields()
    {
        var deceasedFields = HttpContext.Session.Get<List<ApplicationField>>("DeceasedFields");
        
        if (deceasedFields != null)
            return Ok(deceasedFields);
        return BadRequest();
    }


    [HttpGet]   
    public IActionResult GetNames(string name)
    {
        IEnumerable<TajikNames> names = _unit.TajikNames.GetTajikNames(name).Result;
        return Ok(names);
    }

    [HttpGet]
    public IActionResult GetApplicationRejected()
    {
        var rejectionStatus = HttpContext.Session.Get<bool>("ApplicationRejected");
        if(rejectionStatus)
            return Ok(rejectionStatus);
        return BadRequest();
    }

    [HttpGet]
    public IActionResult GetApplicantFromAmonat()
    {
        if(HttpContext.Session.Keys.Contains("ApplicantFromAmonat"))
            return Ok(HttpContext.Session.Get<Applicant>("ApplicantFromAmonat"));

        return BadRequest();
    }

    [HttpGet]
    public IActionResult GetApplicantData()
    {
        if (HttpContext.Session.Keys.Contains("Applicant"))
            return Ok(HttpContext.Session.Get<Applicant>("Applicant"));

        return BadRequest();
    }
}