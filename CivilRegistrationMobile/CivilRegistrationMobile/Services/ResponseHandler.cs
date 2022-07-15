namespace CivilRegistrationMobile.Services
{
    public class ResponseHandler
    {
        HttpContext context;
        public ResponseHandler(HttpContext context)
        {
            this.context = context;
        }
        public void SaveToSession(string key, string value)
        {
            if (!context.Session.Keys.Contains(key))
            {
                if(value != null)
                {
                    context.Session.SetString(key, value);
                }
            }
        }

        public bool TryFillModel(Applicant applicant)
        {
            if (context.Session.Keys.Contains("name") || context.Session.Keys.Contains("lastName") ||
                context.Session.Keys.Contains("patronymic") || context.Session.Keys.Contains("address") ||
                context.Session.Keys.Contains("tin") || context.Session.Keys.Contains("passport") ||
                context.Session.Keys.Contains("issued") || context.Session.Keys.Contains("phone"))
            {
                applicant.Name = CheckValue(context.Session.GetString("name"));
                applicant.LastName = CheckValue(context.Session.GetString("lastName"));
                applicant.Patronymic = CheckValue(context.Session.GetString("patronymic"));
                applicant.CurrentAddress = CheckValue(context.Session.GetString("address"));
                applicant.TIN = CheckValue(context.Session.GetString("tin"));
                applicant.PassportNumber = CheckValue(context.Session.GetString("passport"));
                applicant.IssuingAuth = CheckValue(context.Session.GetString("issued"));
                applicant.PhoneNumber = CheckValue(context.Session.GetString("phone"));

                return true;
            }
            else
            {
                return false;
            }
        }

        private string CheckValue(string? val)
        {
            if (string.IsNullOrEmpty(val))
            {
                return "";
            }
            else
            {
                return val;
            }
        }
    }
}
