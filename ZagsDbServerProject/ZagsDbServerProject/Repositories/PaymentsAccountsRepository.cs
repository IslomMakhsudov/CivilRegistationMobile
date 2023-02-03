using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using ZagsDbServerProject.Entities;
using ZagsDbServerProject.Interfaces;
using ZagsDbServerProject.Responces;

namespace ZagsDbServerProject.Repositories
{
    public class PaymentsAccountsRepository : GenericRepository<PaymentsAccounts>, IPaymentsAccountsRepository
    {
        public PaymentsAccountsRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<PaymentsAccountsResponse>> GetPaymentsAccounts(int languageID)
        {
            var ans = await Task.FromResult(
                from paymentsAccounts in context.PaymentsAccounts
                where paymentsAccounts.StatusID == 1
                join paymentSystems in context.PaymentSystems on paymentsAccounts.PaymentSystemID equals paymentSystems.PaymentSystemID
                join applicationTypes in context.ApplicationTypes on paymentsAccounts.ApplicationTypeID equals applicationTypes.ApplicationTypeID
                join labels in context.Labels on applicationTypes.LabelID equals labels.LabelID 
                join paymentTypes in context.PaymentTypes on paymentsAccounts.PaymentTypeID equals paymentTypes.PaymentTypeID
                join users in context.Users on paymentsAccounts.UserID equals users.UserID
                select new PaymentsAccountsResponse
                {
                    PaymentsAccountID = paymentsAccounts.PaymentsAccountID,
                    DebitAccount = paymentsAccounts.DebitAccount,
                    CreditAccount = paymentsAccounts.CreditAccount,
                    PaymentSystemID = paymentSystems.PaymentSystemID,
                    PaymentSystemName = paymentSystems.ShortName,
                    ApplicationTypeID = applicationTypes.ApplicationTypeID,
                    ApplicationTypeName = (languageID == 1) ? labels.Label1 : (languageID == 2) ? labels.Label2 : labels.Label3,
                    PaymentTypeID = paymentTypes.PaymentTypeID,
                    PaymentTypeName = paymentTypes.Name,
                    UserID = users.UserID,
                    UserName  = users.Surname + " " + users.Name + " " + users.Patronymic
                }
            );

            return ans;
        }
    }
}
