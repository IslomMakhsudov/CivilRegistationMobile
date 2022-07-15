using ZagsDbServerProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ZagsDbServerProject.Responces;
using System.Threading.Tasks;

namespace ZagsDbServerProject.Interfaces
{
	public interface IApplicationsRepository : IGenericRepository<Applications>
	{
		Task<IEnumerable<CustomersApplicationsMobileResponse>> GetCustomersApplications(int externalID, int applicationSourceID);
		Task<int> GetApplicationsAmount(int departmentID, int? applicationStatusID);
		Task<IEnumerable<AllApplicationsResponse>> GetAllApplications(int departmentID, int languageID, int? applicationStatusID);
		Task<IEnumerable<ApplicationsParticipantsData>> TestMethod();
		Task<ApplicantsDataWindowMobileResponse> GetApplicantsDataMobile(int applicationID, int languageID);
		Task<ChildsDataWindowMobileResponse> GetChildsDataMobile(int applicationID, int languageID);
		Task<FathersDataWindowMobileResponse> GetFathersDataMobile(int applicationID);
		Task<MothersDataWindowMobileResponse> GetMothersDataMobile(int applicationID);
		Task<ApplicantsDataWindowWebResponse> GetApplicantsDataWeb(int applicationID);
		Task<ChildsDataWindowWebResponse> GetChildsDataWeb(int applicationID, int languageID);
		Task<FathersDataWindowWebResponse> GetFathersDataWeb(int applicationID);
		Task<MothersDataWindowWebResponse> GetMothersDataWeb(int applicationID);
		Task<IEnumerable<PaymentTypesMobileResponse>> GetPaymentTypes(int applicationID, int applicationSourceID);
	}
}
