
namespace CivilRegistrationMobile.Controllers
{
    public class GeneralController : Controller
    {
        readonly BaseService service = new();
        readonly IUnitOfWork unitOfWork;
        readonly IWebHostEnvironment environment;
        ServerDataHandler handler;
        public GeneralController(IUnitOfWork unitOfWork, IWebHostEnvironment environment)
        {
            this.unitOfWork = unitOfWork;
            this.environment = environment;
            handler = new(unitOfWork, environment);
        }

        public IActionResult Index(string lastName, string name, string patronymic,
            string address, string tin, string passport, string issued, string phone, string countryID, string regionID, string cityID)
        {
            ViewBag.PageName = "Index";
            ResponseHandler responseHandler;
            responseHandler = new(HttpContext);
            responseHandler.SaveToSession("lastName", lastName);
            responseHandler.SaveToSession("name", name);
            responseHandler.SaveToSession("patronymic", patronymic);
            responseHandler.SaveToSession("address", address);
            responseHandler.SaveToSession("tin", tin);
            responseHandler.SaveToSession("passport", passport);
            responseHandler.SaveToSession("issued", issued);
            responseHandler.SaveToSession("phone", phone);
            responseHandler.SaveToSession("countryID", countryID);
            responseHandler.SaveToSession("regionID", regionID);
            responseHandler.SaveToSession("cityID", cityID);

            return View();
        }

        public IActionResult MyApplications()
        {
            ViewBag.PageName = "MyApplications";
            return View();
        }

        [HttpGet]
        public IActionResult IndexNavigation(string pageName)
        {
            return RedirectToAction(pageName);
        }

        public IActionResult ApplicationFilter(string pageName)
        {
            ViewBag.PageName = pageName;
            return View();
        }
        public IActionResult ApplicationFix()
        {
            return View();
        }
        public IActionResult ApplicationStatus()
        {
            return View();
        }

        public IActionResult DeathRegistration(int? code)
        {
            color = service.ChangeColor(color, code);
            return View(color);
        }
        IconsColor color = new();
        public IActionResult NewbornRegistration()
        {
            color = service.ChangeColor(color, GlobalData.ColorCode);
            return View(color);
        }
        public IActionResult Payment(string pageName)
        {
            ViewBag.PageName = pageName;
            List<Models.Payment> payment = handler.GetPaymentList();
            double total = 0;
            foreach (var obj in payment)
            {
                total += Convert.ToDouble(obj.PaymentPrice);
            }
            ViewBag.TotalPrice = total;
            return View(payment);
        }

        public IActionResult DeeplinkToAmonat()
        {
            return Redirect($"amonat://applicationID={GlobalData.ApplicationID}");
        }

        public IActionResult Success()
        {
            return View();
        }
        public IActionResult Support()
        {
            return View();
        }

        public IActionResult GetNewbornRegistrationStatus()
        {
            Status status = new();
            status.Code = GlobalData.ApplicationStatus;
            return Ok(status);
        }

    }
}