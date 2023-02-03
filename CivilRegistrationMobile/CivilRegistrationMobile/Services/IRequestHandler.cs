using CivilRegistrationMobile.Models.ModelRequests;

namespace CivilRegistrationMobile.Services
{
    public interface IRequestHandler
    {
        public void SetDefaultExternalId(IndexModelRequest modelRequest);

        public void SetDefaultLang(IndexModelRequest modelRequest);

        public string GetExternalIdFromSession();

        public void SaveIndexModelRequestToSession(IndexModelRequest modelRequest);
    }
}
