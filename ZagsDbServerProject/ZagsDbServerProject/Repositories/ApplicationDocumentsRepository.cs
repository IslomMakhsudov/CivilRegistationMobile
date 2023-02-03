using ZagsDbServerProject.Entities;
using ZagsDbServerProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ZagsDbServerProject.Responces;

namespace ZagsDbServerProject.Repositories
{
	public class ApplicationDocumentsRepository : GenericRepository<ApplicationDocuments>, IApplicationDocumentsRepository
	{
		public ApplicationDocumentsRepository(AppDbContext context) : base(context)
		{

		}

		public async Task<IEnumerable<ApplicationDocumentsResponse>> GetApplicationDocuments(int ApplicationID)
		{
			var res = await Task.FromResult(
				from appDocs in context.ApplicationDocuments
				where appDocs.ApplicationID == ApplicationID
				join docType in context.ApplicationDocumentTypes on appDocs.DocumentTypeID equals docType.ApplicationDocumentTypeID
				select new ApplicationDocumentsResponse
                {
					Name = docType.Name,
					Src = appDocs.AddressLink
                });
			return res;
		}
	}
}
