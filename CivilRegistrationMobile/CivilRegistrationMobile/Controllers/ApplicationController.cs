using Newtonsoft.Json.Linq;

namespace CivilRegistrationMobile.Controllers
{
    public class ApplicationController : Controller
    {
        readonly IUnitOfWork _unitOfWork;
        readonly ServerDataHandler handler;
        readonly IWebHostEnvironment _webHostEnvironment;
       
        Applicant applicant;
        public ApplicationController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            applicant = new();
           
            _webHostEnvironment = webHostEnvironment;
            _unitOfWork = unitOfWork;
            handler = new(_unitOfWork, _webHostEnvironment);
        }
        
        // Applicant View Methods
        public IActionResult ApplicantDetails()
        {
            ResponseHandler responseHandler = new(HttpContext);
            if (GlobalData.applicantCreated)
            {
                ViewBag.CountryNames = handler.GetCountryNames();
                return View(GlobalData._applicant);
            }
            else
            {
                ViewBag.CountryNames = handler.GetCountryNames();

                if (responseHandler.TryFillModel(applicant))
                {
                    ViewBag.CountryNames = handler.GetCountryNames();
                    return View(applicant);
                }
                return View();
            }
        }

        [HttpPost]
        public IActionResult ApplicantCreate(Applicant applicant)
        {
            if (applicant != null) 
            {
                GlobalData._applicant = applicant;
                handler.SaveParticipantData(applicant);
                GlobalData.applicantCreated = true;
                GlobalData.ApplicationStatus = (int)GlobalData.NewbornStatus.ApplicantDone;
                GlobalData.ColorCode = 1;
                return RedirectToAction("NewbornRegistration", "General");
            }

            return BadRequest();
        }

        public IActionResult ChildDetails()
        {
            if (GlobalData.childCreated)
            {
                return View(GlobalData._child);
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        public IActionResult ChildCreate(Child child)
        {
            if(child != null)
            {
                GlobalData._child = child; 
                handler.SaveParticipantData(child);
                GlobalData.childCreated = true;
                GlobalData.ApplicationStatus = (int)GlobalData.NewbornStatus.ChildDone;
                GlobalData.ColorCode = 2;
                return RedirectToAction("NewbornRegistration", "General");
            }
            return BadRequest();
        }
        public IActionResult DeceasedDetails()
        {
            ViewBag.CountryNames = handler.GetCountryNames();
            return View();
        }
        [HttpPost]
        public IActionResult DeceasedCreate()
        {
            return RedirectToAction("DeathRegistration", "General", new {code = 2});
        }

        public IActionResult FatherDetails()
        {
            if (GlobalData.fatherCreated)
            {
                ViewBag.Nationality = handler.GetNationality();
                ViewBag.Citizenship = handler.GetCitizenship();
                ViewBag.CountryNames = handler.GetCountryNames();
                return View(GlobalData._father);
            }
            else
            {
                ViewBag.Nationality = handler.GetNationality();
                ViewBag.Citizenship = handler.GetCitizenship();
                ViewBag.CountryNames = handler.GetCountryNames();
                return View();
            }
        }
        [HttpPost]
        public IActionResult FatherCreate(Father father)
        {
            if(father != null)
            {
                GlobalData._father = father;
                handler.SaveParticipantData(father);
                GlobalData.fatherCreated = true;
                GlobalData.ApplicationStatus = (int)GlobalData.NewbornStatus.FatherDone;
                GlobalData.ColorCode = 3;
                return RedirectToAction("NewbornRegistration", "General");
            }
            return BadRequest();
        }
        public IActionResult MotherDetails()
        {
            if (GlobalData.motherCreated)
            {
                ViewBag.Nationality = handler.GetNationality();
                ViewBag.Citizenship = handler.GetCitizenship();
                ViewBag.CountryNames = handler.GetCountryNames();
                return View(GlobalData._mother);
            }
            else
            {
                ViewBag.Nationality = handler.GetNationality();
                ViewBag.Citizenship = handler.GetCitizenship();
                ViewBag.CountryNames = handler.GetCountryNames();
                return View();
            }
        }
        [HttpPost]
        public IActionResult MotherCreate(Mother mother)
        {
            if(mother != null)
            {
                GlobalData._mother = mother;
                handler.SaveParticipantData(mother);
                GlobalData.motherCreated = true;
                GlobalData.ApplicationStatus = (int)GlobalData.NewbornStatus.MotherDone;
                GlobalData.ColorCode = 4;
                return RedirectToAction("NewbornRegistration", "General");
            }
            return BadRequest();
        }


        [HttpGet]
        public IActionResult CountryChange(int id)
        {
            List<SelectListItem> selectListItems = handler.GetRegionsByCountryID(id);

            if(selectListItems.Count != 0)
            {
                return Ok(selectListItems);
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpGet]
        public IActionResult RegionChange(int id)
        {
            return Ok(handler.GetCitiesByRegionID(id));
        }
        [HttpGet]
        public IActionResult CityChange(int id)
        {
            GlobalData.CityID = id;
            List<List<SelectListItem>> villagesAndOffices = new();
            villagesAndOffices.Add(handler.GetOfficesByVillageOrCityID(null,id));
            villagesAndOffices.Add(handler.GetVillagesByCityID(id));
            return Ok(villagesAndOffices); 

        }
        [HttpGet]
        public IActionResult VillageChange(int id)
        {
            return Ok(handler.GetOfficesByVillageOrCityID(id,GlobalData.CityID));
        }
    }

}