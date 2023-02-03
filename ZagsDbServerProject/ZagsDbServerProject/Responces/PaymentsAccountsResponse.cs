namespace ZagsDbServerProject.Responces
{
    public class PaymentsAccountsResponse
    {
        public int PaymentsAccountID { get; set; }
        public string DebitAccount { get; set; }
        public string CreditAccount { get; set; }
        public int PaymentSystemID { get; set; }
        public string PaymentSystemName { get; set; }
        public int ApplicationTypeID { get; set; }
        public string ApplicationTypeName { get; set; }
        public int PaymentTypeID { get; set; }
        public string PaymentTypeName { get; set; }
        public int UserID { get; set; }
        public string UserName { get; set; }
    }
}
