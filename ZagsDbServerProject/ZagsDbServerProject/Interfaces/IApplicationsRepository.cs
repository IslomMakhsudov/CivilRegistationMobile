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
		Task<IEnumerable<CustomersApplicationsMobileResponse>> GetCustomersApplications(int externalID, int applicationSourceID, DateTime? CreatedTimeFrom, DateTime? CreatedTimeTo, int? applicationTypeID);
		Task<int> GetApplicationsAmount(int? croisID, int? applicationStatusID, int? applicationTypeID);
		Task<ApplicationsPrintingForm> GetApplicationsPrintingForms(int applicationID);
		Task<IEnumerable<AllApplicationsResponse>> GetAllApplications(int? croisID, int languageID, int? applicationStatusID, int? applicationTypeID, int hierarchyLevel);
		Task<IEnumerable<ApplicationsResponse>> GetApplications(int languageID, int? applicationID, string applicantsFullName, int? applicationTypeID, int? cityDistrictID, int? croisID, DateTime? CreatedTimeFrom, DateTime? CreatedTimeTo, int[] applicationStatusesList, int hierarchyLevel);
		Task<IEnumerable<PaidApplicationsResponse>> GetPaidApplications(int languageID, int? applicationID, string applicantsFullName, int? applicationTypeID, int? cityDistrictID, int? croisID, DateTime? createdTimeFrom, DateTime? createdTimeTo, int[] applicationStatusesList, string transactionID, DateTime? paidTimeFrom, DateTime? paidTimeTo, int? paymentSystemID, int? registryServiceTypeID, int hierarchyLevel);
		Task<ApplicationsChequeResponse> GetApplicationsCheque(int applicationTypeID, int applicationPaymentID, int paymentSystemID, int languageID);
		Task<ApplicantsDataWindowMobileResponse> GetApplicantsDataMobile(int applicationID, int languageID);
		Task<ChildsDataWindowResponse> GetChildsDataMobile(int applicationID, int languageID);
		Task<FathersDataWindowResponse> GetFathersDataMobile(int applicationID);
		Task<MothersDataWindowResponse> GetMothersDataMobile(int applicationID);
		Task<ApplicantsDataWindowWebResponse> GetApplicantsDataWeb(int applicationID);
		Task<ChildsDataWindowResponse> GetChildsDataWeb(int applicationID, int languageID);
		Task<FathersDataWindowResponse> GetFathersDataWeb(int applicationID);
		Task<MothersDataWindowResponse> GetMothersDataWeb(int applicationID);
		Task<DeceasedDataWindowMobileResponse> GetDeceasedDataMobile(int applicationID, int languageID);
		Task<DeceasedDataWindowWebResponse> GetDeceasedDataWeb(int applicationID, int languageID);
		Task<IEnumerable<PaymentTypesMobileResponse>> GetPaymentTypes(int applicationID, int applicationSourceID);
		Task<int> GetApplicationsAmount(int croID, int? applicationTypeID);
		Task<DepartmentToWhichAddressResponse> GetDepartmentToWhichAddress(int applicationID);
		Task<IEnumerable<RejectionCausesResponse>> GetRejectionCauses(int languageID);
	}
}
