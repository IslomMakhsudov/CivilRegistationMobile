namespace CivilRegistrationMobile.Services;

public class ResponseHandler
{
    private readonly HttpContext? _context;
    public ResponseHandler(IHttpContextAccessor httpContextAccessor)
    {
        _context = httpContextAccessor.HttpContext;
    }
    public void SaveToSession(string key, string? value)
    {
        if (!string.IsNullOrWhiteSpace(value)){
            if(!_context.Session.Keys.Contains(key)) 
                _context.Session.SetString(key, value);
        }   
    }

    public void FillApplicantModel(Applicant applicant)
    {
        if (_context.Session.Keys.Contains("name"))
            applicant.Name = CheckValue(_context.Session.GetString("name"));

        if (_context.Session.Keys.Contains("lastName"))
            applicant.LastName = CheckValue(_context.Session.GetString("lastName"));

        if (_context.Session.Keys.Contains("patronymic"))
            applicant.Patronymic = CheckValue(_context.Session.GetString("patronymic"));

        if (_context.Session.Keys.Contains("address"))
            applicant.CurrentAddress = CheckValue(_context.Session.GetString("address"));

        if (_context.Session.Keys.Contains("tin"))
            applicant.TIN = CheckValue(_context.Session.GetString("tin"));

        if (_context.Session.Keys.Contains("passport"))
            applicant.PassportNumber = CheckValue(_context.Session.GetString("passport"));

        if (_context.Session.Keys.Contains("issued"))
            applicant.IssuingAuth = CheckValue(_context.Session.GetString("issued"));

        if (_context.Session.Keys.Contains("phone"))
            applicant.PhoneNumber = CheckValue(_context.Session.GetString("phone"));

        applicant.CurrentCountry = CheckValueOfPlace(_context.Session.GetString("countryID"));
        applicant.CurrentRegion = CheckValueOfPlace(_context.Session.GetString("regionID"));
        applicant.CurrentCity = CheckValueOfPlace(_context.Session.GetString("cityID"));
    }


    private static string CheckValue(string? val)
    {
        return string.IsNullOrEmpty(val) ? "" : val;
    }

    private static int CheckValueOfPlace(string? val)
    {
        return string.IsNullOrWhiteSpace(val) ? 0 : Convert.ToInt32(val);
    }
}