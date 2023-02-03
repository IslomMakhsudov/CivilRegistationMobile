namespace CivilRegistrationMobile.Services;

public static class SessionExtensions
{
    public static void Set<T>(this ISession session, string key, T value)
    {
        session.SetString(key, JsonSerializer.Serialize(value));
    }

    public static T? Get<T>(this ISession session, string key)
    {
        var value = session.GetString(key);
        return value == null ? default : JsonSerializer.Deserialize<T>(value);
    }

    public static void ResetValues(this ISession session)
    {
        session.Remove("Applicant");
        session.Remove("ApplicantFormCode");
        session.Remove("FormName");
        session.Remove("ApplicationID");
        session.Remove("CityID");
        session.Remove("ColorCode");
        session.Remove("ApplicationSum");
        session.Remove("IsApplicantDataExists");
        session.Remove("ApplicantCreated");
        session.Remove("ChildCreated");
        session.Remove("MotherCreated");
        session.Remove("FatherCreated");
        session.Remove("DeceasedCreated");
        session.Remove("ApplicationStatus");
        session.Remove("CorrectingStatus");
        session.Remove("ApplicantFields");
        session.Remove("ChildFields");
        session.Remove("FatherFields");
        session.Remove("MotherFields");
        session.Remove("DeceasedFields");
        session.Remove("ApplicationRegisterTo");
        session.Remove("ViewOnly");
        session.Remove("langCode");
        session.Remove("ViewOnly");
        session.Remove("CorrectedApplications");
        session.Remove("ApplicationRejected");
        session.Remove("NotInOneYear");
        session.Remove("ApplicantFromAmonat");
    }

    public static void ResetCreatedValues(this ISession session)
    {
        session.Remove("ApplicantCreated");
        session.Remove("ChildCreated");
        session.Remove("FatherCreated");
        session.Remove("MotherCreated");
        session.Remove("DeceasedCreated");
    }
}