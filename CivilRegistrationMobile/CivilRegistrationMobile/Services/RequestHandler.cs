using CivilRegistrationMobile.Models.ModelRequests;
using System.Numerics;
using System.Xml.Linq;

namespace CivilRegistrationMobile.Services
{
    public class RequestHandler : IRequestHandler
    {
        private readonly HttpContext? _context;
        private readonly ResponseHandler _responseHandler;
        public RequestHandler(IHttpContextAccessor httpContextAccessor, ResponseHandler responseHandler)
        {
            _context = httpContextAccessor.HttpContext;
            _responseHandler = responseHandler;
        }

        public string GetExternalIdFromSession()
        {
            if(_context != null)
            {
                if (_context.Session.Keys.Contains("externalID"))
                {
                    var exId = _context.Session.GetString("externalID");

                    if (!string.IsNullOrWhiteSpace(exId) && exId != "0") 
                        return exId;
                }
            }
            return "";
        }

        public void SaveIndexModelRequestToSession(IndexModelRequest modelRequest)
        {
            if (!string.IsNullOrWhiteSpace(modelRequest.ExternalId) && modelRequest.ExternalId != "0")
            {
                _responseHandler.SaveToSession("lastName",modelRequest.LastName);
                _responseHandler.SaveToSession("name", modelRequest.Name);
                _responseHandler.SaveToSession("patronymic", modelRequest.Patronymic);
                _responseHandler.SaveToSession("address", modelRequest.Address);
                _responseHandler.SaveToSession("tin", modelRequest.Tin);
                _responseHandler.SaveToSession("passport", modelRequest.Passport);
                _responseHandler.SaveToSession("issued", modelRequest.Issued);
                _responseHandler.SaveToSession("phone", modelRequest.Phone);
                _responseHandler.SaveToSession("countryID", modelRequest.CountryId);
                _responseHandler.SaveToSession("regionID", modelRequest.RegionId);
                _responseHandler.SaveToSession("cityID", modelRequest.CityId);
                _responseHandler.SaveToSession("externalID", modelRequest.ExternalId);
                _responseHandler.SaveToSession("lang", modelRequest.Lang);
                _responseHandler.SaveToSession("payID", modelRequest.PayId);
            }
            else
            {
                throw new KeyNotFoundException("ExternalId not found");
            }
        }

        public void SaveFakeDataToSession()
        {
            _responseHandler.SaveToSession("lastName", "Низаматоддинов");
            _responseHandler.SaveToSession("name", "Абду");
            _responseHandler.SaveToSession("patronymic", "Мухсинович");
            _responseHandler.SaveToSession("address", "к.Рачаб");
            _responseHandler.SaveToSession("tin", "12345");
            _responseHandler.SaveToSession("passport", "12345");
            _responseHandler.SaveToSession("issued", "Рачаб");
            _responseHandler.SaveToSession("phone", "920000000");
            _responseHandler.SaveToSession("countryID", "185");
            _responseHandler.SaveToSession("regionID", "4");// 4
            _responseHandler.SaveToSession("cityID", "518");// 518
            _responseHandler.SaveToSession("externalID", "3");
            _responseHandler.SaveToSession("lang", "2");
            _responseHandler.SaveToSession("payID", "1");
        }

        public void SetDefaultExternalId(IndexModelRequest modelRequest)
        {
            if (modelRequest.ExternalId == "0" || string.IsNullOrWhiteSpace(modelRequest.ExternalId))
                modelRequest.ExternalId = "3";
        }

        public void SetDefaultLang(IndexModelRequest modelRequest)
        {
            modelRequest.Lang = string.IsNullOrWhiteSpace(modelRequest.Lang) == true? "2" : modelRequest.Lang;
        }
    }
}
