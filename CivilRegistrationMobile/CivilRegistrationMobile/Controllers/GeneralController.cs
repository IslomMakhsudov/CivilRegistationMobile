using CivilRegistrationMobile.Models.ModelRequests;
using Microsoft.AspNetCore.Diagnostics;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using ZagsDbServerProject.Exceptions;

namespace CivilRegistrationMobile.Controllers;

public class GeneralController : Controller
{
    private readonly ServerDataHandler _handler;
    private readonly ResponseHandler _responseHandler;
    private readonly BaseService _service;
    private readonly IUnitOfWork _unit;
    private readonly LabelDefiner _labelDefiner;
    private IconsColor _color = new();
    private readonly IConfiguration config;
    private readonly ILogger<GeneralController> _logger;
    private readonly RequestHandler _requestHandler;
    public GeneralController(IUnitOfWork unitOfWork, ServerDataHandler handler, ResponseHandler responseHandler,
        BaseService service, LabelDefiner labelDefiner, IConfiguration config, ILogger<GeneralController> logger, RequestHandler requestHandler)
    {
        _unit = unitOfWork;
        _handler = handler;
        _responseHandler = responseHandler;
        _service = service;
        _labelDefiner = labelDefiner;
        this.config = config;
        _logger = logger;
        _requestHandler = requestHandler;
    }

    public async Task<IActionResult> Index([FromQuery] IndexModelRequest modelRequest)
    {
        ViewBag.PageName = "Index";
        HttpContext.Session.ResetValues();

        _requestHandler.SaveFakeDataToSession();

        _requestHandler.SetDefaultExternalId(modelRequest);

        _requestHandler.SetDefaultLang(modelRequest);


        _requestHandler.SaveIndexModelRequestToSession(modelRequest);

        int externalId = Convert.ToInt32(_requestHandler.GetExternalIdFromSession());

        var langId = Convert.ToInt32(HttpContext.Session.GetString("lang"));

        if(externalId != 0) 
            await _handler.UpdateCustomerLang(externalId, langId);

        await _labelDefiner.IndexLabels(this, langId);
        
        return View();

        #region comments
        /* if (externalId == "0" || string.IsNullOrWhiteSpace(externalId)) externalId = "3";

         if (HttpContext.Session.Keys.Contains("externalID"))
         {
             var exId = HttpContext.Session.GetString("externalID");
             if (!string.IsNullOrWhiteSpace(exId) && exId != "0") externalId = exId;
         }

         if (!string.IsNullOrWhiteSpace(externalId) && externalId != "0")
         {
             ViewBag.PageName = "Index";

             *//*_responseHandler.SaveToSession("lastName", "Низаматтатидинов", HttpContext);
             _responseHandler.SaveToSession("name", "Абду", HttpContext);
             _responseHandler.SaveToSession("patronymic", "Мухсинович", HttpContext);
             _responseHandler.SaveToSession("address", "к.Рачаб", HttpContext);
             _responseHandler.SaveToSession("tin", "12345", HttpContext);
             _responseHandler.SaveToSession("passport", "12345", HttpContext);
             _responseHandler.SaveToSession("issued", "Рачаб", HttpContext);
             _responseHandler.SaveToSession("phone", "920000000", HttpContext);
             _responseHandler.SaveToSession("countryID", "185", HttpContext);
             _responseHandler.SaveToSession("regionID", "4", HttpContext);// 4
             _responseHandler.SaveToSession("cityID", "518", HttpContext);// 518
             _responseHandler.SaveToSession("externalID", externalId, HttpContext);
             _responseHandler.SaveToSession("lang", lang, HttpContext);
             _responseHandler.SaveToSession("payID", payId, HttpContext);*//*

             _responseHandler.SaveToSession("lastName", lastName, HttpContext);
             _responseHandler.SaveToSession("name", name, HttpContext);
             _responseHandler.SaveToSession("patronymic", patronymic, HttpContext);
             _responseHandler.SaveToSession("address", address, HttpContext);
             _responseHandler.SaveToSession("tin", tin, HttpContext);
             _responseHandler.SaveToSession("passport", passport, HttpContext);
             _responseHandler.SaveToSession("issued", issued, HttpContext);
             _responseHandler.SaveToSession("phone", phone, HttpContext);
             _responseHandler.SaveToSession("countryID", countryId, HttpContext);
             _responseHandler.SaveToSession("regionID", regionId, HttpContext);
             _responseHandler.SaveToSession("cityID", cityId, HttpContext);
             _responseHandler.SaveToSession("externalID", externalId, HttpContext);
             _responseHandler.SaveToSession("lang", lang, HttpContext);
             _responseHandler.SaveToSession("payID", payId, HttpContext);
         }
         else
         {
             throw new KeyNotFoundException("ExternalId not found");
         }*/

        #endregion
    }

    public async Task<IActionResult> MyApplications(DateTime? dateFrom, DateTime? dateTo, int? applicationTypeId)
    {
        HttpContext.Session.ResetValues();
        var lang = Convert.ToInt32(HttpContext.Session.GetString("lang"));
        ViewBag.PageName = "MyApplications";
        var applications = await _handler.GetAllApplications(dateFrom, dateTo, applicationTypeId);
        await _labelDefiner.IndexLabels(this, lang);
        return View(applications);
    }

    public async Task<IActionResult> ApplicationFilter(string pageName)
    {
        var lang = Convert.ToInt32(HttpContext.Session.GetString("lang"));
        await _labelDefiner.ApplicationFilterLabels(this, lang);
        return View();
    }

    public async Task<IActionResult> RegistryOffices()
    {
        ViewBag.PageName = "RegistryOffices";
        var lang = Convert.ToInt32(HttpContext.Session.GetString("lang"));
        IEnumerable<RegistryOfficeDepartments> registryOfficeDepartments = await _unit.Departments.GetDepartmentsWithLocations();
        List<RegistryOffice> registryOffices = new();
        foreach (var office in registryOfficeDepartments)
        {
            string scheduleLabel = await _handler.LabelById(lang, office.WorkScheduleLabelID);
            registryOffices.Add(
                new RegistryOffice { Id = office.AddressID, LocationLink = office.LocationLink, Name = office.DepartmentName, WorkTime = office.WorkTime + " " + scheduleLabel }
            );
        }
        await _labelDefiner.RegistryOfficesLabels(this, lang);
        return View(registryOffices);
    }

    public IActionResult FilterSubmit(Filter filter)
    {
        return RedirectToAction("MyApplications",
            new { dateFrom = filter.From, dateTo = filter.To, applicationTypeID = filter.ApplicationType });
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public async Task<IActionResult> Error()
    {
        var model = new ErrorViewModel();
        model.RequestId = Activity.Current?.Id;
        if (model.RequestId == null)
        {
            model.RequestId = HttpContext.TraceIdentifier;
        }
        var lang = Convert.ToInt32(HttpContext.Session.GetString("lang"));

        model.ExceptionMessage = await _handler.LabelById(lang, 1611);
        ViewBag.ExceptionTitle = await _handler.LabelById(lang, 1610);

        string message = $"RequestId: {model.RequestId}";
        _logger.LogError(message);

        return View(model);
    }

    public async Task<IActionResult> ApplicationStatus(int applicationId, int statusId, int typeId)
    {
        HttpContext.Session.SetString("ApplicationStatusID", statusId.ToString());
        if (applicationId <= 0) return BadRequest();
        var lang = Convert.ToInt32(HttpContext.Session.GetString("lang"));
        var appStatus = await _handler.GetApplicationStatus(lang, statusId, typeId, applicationId);
        appStatus.RegistryOfficeID = HttpContext.Session.Get<int>("RegistryOfficeID");
        return View(appStatus);
    }

    public async Task<IActionResult> DeathRegistration(int? code, int statusId, int? applicationId)
    {
        var lang = Convert.ToInt32(HttpContext.Session.GetString("lang"));
        if (code == 2)
        {
            _color = new IconsColor();
            _color = _service.ChangeColor(4);
            HttpContext.Session.SetString("ApplicantFormCode", "2");
            HttpContext.Session.Set("ApplicationStatus", 2);
            HttpContext.Session.Set("ApplicationID", applicationId);
            HttpContext.Session.Set("ApplicantCreated", true);
            HttpContext.Session.Set("DeceasedCreated", true);
            HttpContext.Session.Set("ViewOnly", true);
            await _labelDefiner.DeathRegistrationLabels(this, lang);
            return View(_color);
        }
        if (statusId == 1)
        {

            var applicationType = _unit.Applications.GetByID(applicationId).Result.ApplicationTypeID;
            int specificId = applicationType == 1 ? 16 : 17;

            var applicationsDetail = await _unit.ApplicationsDetails
                .GetByPredicate(ad => ad.ApplicationID == applicationId && ad.SpecificApplicationDataID == specificId);
            var registerTo = applicationsDetail.Detail;

            HttpContext.Session.Set("RegisterTo", int.Parse(registerTo));
            HttpContext.Session.Set("ApplicationID", applicationId);
            HttpContext.Session.ResetCreatedValues();
            _color = new();

            var applicant = await _unit.ApplicationsParticipantsData.GetByPredicate(ad =>
                ad.ApplicationID == applicationId && ad.ApplicationMemberTypeID == 1);

            if (applicant != null)
            {
                _color = _service.ChangeColor(1);
                HttpContext.Session.Set("ApplicantCreated", true);
                HttpContext.Session.Set("ApplicationStatus", 1);
            }

            var deceased = await _unit.ApplicationsParticipantsData.GetByPredicate(ad =>
                ad.ApplicationID == applicationId && ad.ApplicationMemberTypeID == 5);
            if (deceased != null)
            {
                _color = _service.ChangeColor(2);
                HttpContext.Session.Set("ApplicationStatus", 2);
                HttpContext.Session.Set("DeceasedCreated", true);
            }
            HttpContext.Session.SetString("ApplicantFormCode", "2");
            await _labelDefiner.DeathRegistrationLabels(this, lang);
            HttpContext.Session.Remove("ViewOnly");
            return View(_color);
        }

        if (applicationId != null && applicationId != 0)
        {
            _color = new IconsColor();
            _color = _service.ChangeColor(4);
            _color.IsCorrecting = true;
            HttpContext.Session.SetString("ApplicantFormCode", "2");
            await _labelDefiner.DeathRegistrationLabels(this, lang);
            HttpContext.Session.Remove("ViewOnly");
            return View(_color);
        }

        if (code == 1)
        {
            HttpContext.Session.ResetValues();
            _color = new IconsColor();
        }
        HttpContext.Session.SetString("ApplicantFormCode", "2");
        await _labelDefiner.DeathRegistrationLabels(this, lang);
        HttpContext.Session.Remove("ViewOnly");
        return View(_color);
    }

    public async Task<IActionResult> NewbornRegistration(int? code, int? applicationId, int? statusId)
    {
        var lang = Convert.ToInt32(HttpContext.Session.GetString("lang"));
        if (code == 2)
        {
            _color = new IconsColor();
            _color = _service.ChangeColor(4);
            HttpContext.Session.SetString("ApplicantFormCode", "1");
            HttpContext.Session.Set("ApplicationStatus", 4);
            HttpContext.Session.Set("ApplicationID", applicationId);
            HttpContext.Session.Set("ApplicantCreated", true);
            HttpContext.Session.Set("ChildCreated", true);
            HttpContext.Session.Set("FatherCreated", true);
            HttpContext.Session.Set("MotherCreated", true);
            HttpContext.Session.Set("ViewOnly", true);
            await _labelDefiner.NewbornRegistrationLabels(this, lang);
            return View(_color);
        }
        if (statusId == 1)
        {
            HttpContext.Session.Set("ApplicationID", applicationId);
            HttpContext.Session.ResetCreatedValues();
            _color = new();
            var applicant = await _unit.ApplicationsParticipantsData.GetByPredicate(ad =>
                ad.ApplicationID == applicationId && ad.ApplicationMemberTypeID == 1);
            if (applicant != null)
            {
                _color = _service.ChangeColor(1);
                HttpContext.Session.Set("ApplicantCreated", true);
                HttpContext.Session.Set("ApplicationStatus", 1);
            }

            var child = await _unit.ApplicationsParticipantsData.GetByPredicate(ad =>
                ad.ApplicationID == applicationId && ad.ApplicationMemberTypeID == 2);
            if (child != null)
            {
                _color = _service.ChangeColor(2);
                HttpContext.Session.Set("ApplicationStatus", 2);
                HttpContext.Session.Set("ChildCreated", true);
            }

            var father = await _unit.ApplicationsParticipantsData.GetByPredicate(ad =>
                ad.ApplicationID == applicationId && ad.ApplicationMemberTypeID == 3);
            if (father != null)
            {
                _color = _service.ChangeColor(3);
                HttpContext.Session.Set("ApplicationStatus", 3);
                HttpContext.Session.Set("FatherCreated", true);
            }

            var mother = await _unit.ApplicationsParticipantsData.GetByPredicate(ad =>
                ad.ApplicationID == applicationId && ad.ApplicationMemberTypeID == 4);
            if (mother != null)
            {
                _color = _service.ChangeColor(4);
                HttpContext.Session.Set("ApplicationStatus", 4);
                HttpContext.Session.Set("MotherCreated", true);
            }

            HttpContext.Session.SetString("ApplicantFormCode", "1");
            HttpContext.Session.Remove("ViewOnly");
            await _labelDefiner.NewbornRegistrationLabels(this, lang);
            return View(_color);
        }

        if (applicationId != null && applicationId != 0)
        {
            _color = new IconsColor();
            _color = _service.ChangeColor(4);
            _color.IsCorrecting = true;
            HttpContext.Session.SetString("ApplicantFormCode", "1");
            await _labelDefiner.NewbornRegistrationLabels(this, lang);
            HttpContext.Session.Remove("ViewOnly");
            return View(_color);
        }

        if (code == 1)
        {
            HttpContext.Session.ResetValues();
            _color = new IconsColor();
        }
        HttpContext.Session.SetString("ApplicantFormCode", "1");
        await _labelDefiner.NewbornRegistrationLabels(this, lang);
        HttpContext.Session.Remove("ViewOnly");
        return View(_color);
    }

    [HttpGet]
    public async Task<IActionResult> Payment(string pageName)
    {
        var correctingStatus = HttpContext.Session.Get<bool>("CorrectingStatus");
        var lang = Convert.ToInt32(HttpContext.Session.GetString("lang"));
        var applicationId = Convert.ToInt32(HttpContext.Session.GetString("ApplicationID"));
        Applications applications = _unit.Applications.GetByID(applicationId).Result;
        if (correctingStatus && applications.ApplicationStatusID == 6)
        {
            applications.ApplicationStatusID = 2;
            applications.CorrectedTime = DateTime.Now;
            await _unit.Complete();
            return RedirectToAction("Success");
        }
        ViewBag.PageName = pageName;
        if (applicationId != 0)
        {
            try
            {
                var payment = await _handler.GetPaymentList(applicationId);
                var total = payment.Sum(obj => Convert.ToDouble(obj.PaymentPrice));
                HttpContext.Session.SetString("ApplicationSum", total.ToString(CultureInfo.InvariantCulture));
                ViewBag.TotalPrice = total;
                await _labelDefiner.PaymentLabels(this, lang);
                return View(payment);
            }
            catch (Exception)
            {
                HttpContext.Session.Set("NotInOneYear", true);
                var applicantFormCode = Convert.ToInt32(HttpContext.Session.GetString("ApplicantFormCode"));
                return RedirectToAction(applicantFormCode == 1 ? "NewbornRegistration" : "DeathRegistration", "General", new { applicationId, statusId = 4 });
            }
        }

        return RedirectToAction("Index");
    }

    public IActionResult DeeplinkToAmonat()
    {
        var applicationId = Convert.ToInt32(HttpContext.Session.GetString("ApplicationID"));
        var applicationSum = Convert.ToDouble(HttpContext.Session.GetString("ApplicationSum"));
        var payId = Convert.ToInt32(HttpContext.Session.GetString("payID"));

        if (config.GetValue<int>("DeeplinkSettings") == 1)
        {
            return Ok(new DeeplinkDto { View = "pay", PayId = payId, ApplicationId = applicationId, ApplicationSum = applicationSum });
        }
        else
        {
            return Redirect($"amonat://resolve?view=pay&payID={payId}&number={applicationId}&sum={applicationSum}");
        }
    }

    public async Task<IActionResult> Success()
    {
        var lang = Convert.ToInt32(HttpContext.Session.GetString("lang"));
        await _labelDefiner.SuccessLabels(this, lang);
        return View();
    }

    public async Task<IActionResult> Support()
    {
        IEnumerable<SupportsResponse> support = await _unit.BaseTypes.GetSupports();
        ViewBag.Support = support;
        ViewBag.PageName = "Support";
        var lang = HttpContext.Session.GetString("lang");
        var faq = await _handler.Faq();
        await _labelDefiner.SupportLabels(this, Convert.ToInt32(lang));
        return View(faq);
    }

    [HttpGet]
    public IActionResult GetNewbornRegistrationStatus()
    {
        Status status = new()
        {
            Code = HttpContext.Session.Get<int>("ApplicationStatus")
        };
        var correctingStatus = HttpContext.Session.Get<bool>("CorrectingStatus");
        if (correctingStatus)
            return BadRequest();
        return Ok(status);
    }

    [HttpGet]
    public IActionResult GetImagesColor()
    {
        var applicationStatus = HttpContext.Session.Get<int>("ApplicationStatus");
        var correctingStatus = HttpContext.Session.Get<bool>("CorrectingStatus");
        var color = _service.ChangeColor(correctingStatus ? 4 : applicationStatus);

        return Ok(color);
    }

    public IActionResult GetApplicationStatus()
    {
        var status = HttpContext.Session.GetString("ApplicationStatusID");
        return Ok(status);
    }

    public async Task<IActionResult> CorrectApplication(int applicationId)
    {
        var application = await _unit.Applications.GetByID(applicationId);
        HttpContext.Session.Set("CorrectingStatus", true);
        HttpContext.Session.SetString("ApplicantFormCode", application.ApplicationTypeID.ToString());
        HttpContext.Session.Set("ApplicationID", applicationId);

        string actionName = application.ApplicationTypeID == 1 ? "NewbornRegistration" : "DeathRegistration";

        return RedirectToAction(actionName, new { code = 1, applicationID = applicationId });
    }

    [HttpGet]
    public async Task<IActionResult> GetCorrectedApplication()
    {
        var applicationId = HttpContext.Session.Get<int>("ApplicationID");
        await _handler.GetCorrection(applicationId);
        var application = HttpContext.Session.Get<CorrectedApplications>("CorrectedApplications");
        return Ok(application);
    }

    [HttpGet]
    public IActionResult GetCorrectingStatus()
    {
        bool? status = HttpContext.Session.Get<bool>("CorrectingStatus");

        return status switch
        {
            null => BadRequest(),
            true => Ok(status),
            _ => BadRequest()
        };
    }

    [HttpGet]
    public IActionResult GetCityId()
    {
        var cityId = HttpContext.Session.GetString("cityID");
        var formName = HttpContext.Session.GetString("FormName");
        if ((string.IsNullOrWhiteSpace(cityId) || cityId == "0") && formName == "applicant") return BadRequest();
        return Ok(cityId);
    }

    [HttpGet]
    public IActionResult GetRegionId()
    {
        var regionId = HttpContext.Session.GetString("regionID");
        var formName = HttpContext.Session.GetString("FormName");
        if ((string.IsNullOrWhiteSpace(regionId) || regionId == "0") && formName == "applicant") return BadRequest();
        return Ok(regionId);
    }

    public IActionResult GetViewOnly()
    {
        if (HttpContext.Session.Keys.Contains("ViewOnly"))
            if(HttpContext.Session.Get<bool>("ViewOnly"))
                return Ok(HttpContext.Session.Get<bool>("ViewOnly"));
        return BadRequest();
    }

    public IActionResult GetLangCode()
    {
        return Ok(HttpContext.Session.Get<string>("langCode"));
    }

    [HttpGet]
    public async Task<IActionResult> GetReasonLabel(int applicationId)
    {
        int lang = Convert.ToInt32(HttpContext.Session.GetString("lang"));

        var application = await _unit.Applications.GetByID(applicationId);
        int rejectionId = application.RejectionCauseID;

        var applicationRejection = await _unit.Applications.GetRejectionCauses(lang);
        var rejection = applicationRejection.FirstOrDefault(r => r.RejectionCauseID == rejectionId);

        string rejectionText = "Ошибка при получении причины отказа";
        if (rejection != null)
            rejectionText = rejection.RejectionLabel;

        return Ok(rejectionText);
    }

    [HttpGet]
    public async Task<IActionResult> GetLabels(int id)
    {
        int lang = Convert.ToInt32(HttpContext.Session.GetString("lang"));
        string result = await _handler.LabelById(lang, id);
        if(string.IsNullOrWhiteSpace(result)) return BadRequest();
        return Ok(result);
    }

    public IActionResult SessionReset()
    {
        HttpContext.Session.ResetValues();
        return Ok();
    }

    public IActionResult GetNotInOneYearValue()
    {
        bool value = HttpContext.Session.Get<bool>("NotInOneYear");
        if (value) 
            return Ok();
        return BadRequest();
    }

}